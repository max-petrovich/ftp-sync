using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTP;
using System.Net;
using System.Net.FtpClient;
using System.Net.Sockets;

namespace FTPsync
{
    enum MsgType { Info, Success, Error }

    public partial class GetListLogForm : Form
    {

        delegate void SetTextCallback(string text, MsgType type);

        private Form1 parent;
        private List<TaskListItem> task_list = new List<TaskListItem>();

        List<ServerHandler> remote_ftp_handlers = new List<ServerHandler>();
        ServerHandler main_ftp = new ServerHandler(null, null);

        public GetListLogForm()
        {
            InitializeComponent();
        }

        private void GetListLogForm_Load(object sender, EventArgs e)
        {
            this.parent = this.Owner as Form1;
            if (bgw.IsBusy != true)
            {
                bgw.RunWorkerAsync();
            }
        }

        private string GetMsgTypeText(MsgType type)
        {
            string result = "";
            IDictionary<MsgType, string> msg_type_ru = new Dictionary<MsgType, string>();
            msg_type_ru.Add(MsgType.Info, "Информация");
            msg_type_ru.Add(MsgType.Error, "Ошибка");
            msg_type_ru.Add(MsgType.Success, "Успешно");

            if (msg_type_ru.ContainsKey(type))
            {
                result = msg_type_ru[type];
            }
            return result;
        }

        private void PostMsg(string text, MsgType type)
        {
            if (this.messages.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(PostMsg);
                this.Invoke(d, new object[] { text, type });
            }
            else
            {
                string msg = "";
                if (type != MsgType.Info)
                {
                    msg += "[" + GetMsgTypeText(type) + "] ";
                }
                msg += text + "\r\n";
                this.messages.AppendText(msg);
            }
        }


        /*****    MAIN FUNC ****/
        // ASYNC WORK
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<string> main_ftp_items_list = new List<string>();

            // Connect to servers
            foreach (Server server in parent.server_settings.Servers)
            {
                if (worker.CancellationPending) { return; }
                PostMsg("Попытка соединения с сервером " + server.name + " (" + server.IP + ":" + server.port + ") ...", MsgType.Info);
                try
                {
                    // Connect to server
                    FtpClient ftp = new FtpClient();
                    ftp.Host = server.IP.ToString();
                    ftp.Port = server.port;
                    ftp.Credentials = new NetworkCredential(server.login, server.password);
                    ftp.Connect();

                    if (server.type == Server_Type.main)
                    {
                        main_ftp = new ServerHandler(server, ftp);
                    }
                    else
                    {
                        remote_ftp_handlers.Add(new ServerHandler(server, ftp));
                    }

                    PostMsg("Соединение установлено!", MsgType.Success);
                    
                }
                catch (Exception ex)
                {
                    PostMsg("Не удалось соединиться с сервером: " + server.name + " (" + server.IP + ":" + server.port + ")! "+ex.Message, MsgType.Error);
                }
            }

            // Check main and at least one remote server handler
            if (main_ftp.handler != null && remote_ftp_handlers.Count > 0)
            {

                // Compare [Main] server to [remote_I] server DIRS
                foreach (ServerHandler ftp in remote_ftp_handlers)
                {
                    if (worker.CancellationPending) { return; }
                    PostMsg("Обработка текущего сервера: [ " + ftp.server.name+" ]", MsgType.Info);

                    foreach(LocalRemoteDir dirInfo in ftp.server.dirs.DirList) {
                        if (worker.CancellationPending) { return; }
                        bool dirs_available = true;
                        // Check dirs
                        if (!main_ftp.handler.DirectoryExists(dirInfo.local))
                        {
                            PostMsg("Директория не найдена: " + main_ftp.server.name + ":" + dirInfo.local, MsgType.Error);
                            dirs_available = false;
                        }
                        if (!ftp.handler.DirectoryExists(dirInfo.remote))
                        {
                            PostMsg("Директория не найдена: " + ftp.server.name + ":" + dirInfo.remote, MsgType.Error);
                            dirs_available = false;
                        }
                        if (dirs_available)
                        {
                            PostMsg("Синхронизация директорий: [ " + main_ftp.server.name + ":" + dirInfo.local + " => " + ftp.server.name + ":" + dirInfo.remote + " ]", MsgType.Info);
                            // LIST MAIN SERVER {cur_DIR}
                            main_ftp.handler.SetWorkingDirectory(dirInfo.local);

                            main_ftp_items_list.Clear();

                            // COMPARE: main_server <> remote server | DIR
                            foreach (FtpListItem item in main_ftp.handler.GetListing(main_ftp.handler.GetWorkingDirectory(), FtpListOption.Modify | FtpListOption.Size))
                            {
                                if (worker.CancellationPending) { return; }

                                if (item.Type == FtpFileSystemObjectType.File)
                                {
                                    main_ftp_items_list.Add(item.Name);

                                    // INIT ITEM
                                    TaskListItem task_list_item = new TaskListItem();
                                    task_list_item.active = false;
                                    task_list_item.type = TaskType.none;
                                    task_list_item.name = item.Name;
                                    task_list_item.local_server = main_ftp.server;
                                    task_list_item.local_size = item.Size;
                                    task_list_item.local_catalog = dirInfo.local;
                                    task_list_item.remote_server = ftp.server;
                                    task_list_item.remote_catalog = dirInfo.remote;

                                    // Check file exist in REMOTE DIR
                                    string remote_filepath = dirInfo.remote + "/" + item.Name;
                                    if (ftp.handler.FileExists(remote_filepath))
                                    {
                                        task_list_item.remote_size = ftp.handler.GetFileSize(remote_filepath);
                                        if (task_list_item.remote_size != item.Size)
                                        {
                                            task_list_item.active = true;
                                            task_list_item.type = TaskType.upload;
                                            PostMsg("[ЗАГРУЗИТЬ] " + ftp.server.name + item.FullName + " (не совпадение размеров)", MsgType.Info);
                                        }
                                    }
                                    else
                                    {
                                        task_list_item.active = true;
                                        task_list_item.type = TaskType.upload;
                                        task_list_item.remote_size = 0;
                                        PostMsg("[ЗАГРУЗИТЬ] " + ftp.server.name + item.FullName + " (нет на сервере-клиенте)", MsgType.Info);
                                    }
                                    // ADD to task list
                                    task_list.Add(task_list_item);
                                }
                            }

                            // GET ITEMS TO DELETE: COMPARE REMOTE LIST <> LOCAL LIST ITEMS | DIR
                            ftp.handler.SetWorkingDirectory(dirInfo.remote);
                            foreach (FtpListItem item in ftp.handler.GetListing(ftp.handler.GetWorkingDirectory(), FtpListOption.Modify | FtpListOption.Size))
                            {
                                if (worker.CancellationPending){return;}
                                if (item.Type == FtpFileSystemObjectType.File)
                                {
                                    if (!main_ftp_items_list.Contains(item.Name))
                                    {
                                        TaskListItem task_list_item = new TaskListItem();
                                        task_list_item.active = true;
                                        task_list_item.type = TaskType.delete;
                                        task_list_item.name = item.Name;
                                        task_list_item.local_size = 0;
                                        task_list_item.local_catalog = dirInfo.local;
                                        task_list_item.remote_size = item.Size;
                                        task_list_item.remote_catalog = dirInfo.remote;
                                        task_list_item.remote_server = ftp.server;
                                        task_list.Add(task_list_item);

                                        PostMsg("[УДАЛИТЬ] " + ftp.server.name + item.FullName + " (отсутствует на главном сервере)", MsgType.Info);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (main_ftp.handler == null)
                {
                    PostMsg("Главный сервер недоступен!", MsgType.Error);
                }
                if (remote_ftp_handlers.Count == 0)
                {
                    PostMsg("Сервера-клиенты недоступны!", MsgType.Error);
                }
                PostMsg("Продолжение невозможно!", MsgType.Error);
                return;
            }


        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.Close();
        }


        private void GetListLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgw.IsBusy)
            {
                if (MessageBox.Show("Процесс ещё не завершён!\r\nВы точно хотите отменить операцию?", "Подтвреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (bgw.WorkerSupportsCancellation == true)
                    {
                        bgw.CancelAsync();
                    }
                    else
                    {
                        MessageBox.Show("Прекращение выполнения недоступно! Дождитесь окончания операции!");
                    }
                }
                e.Cancel = true;
            }
        }

        private void GetListLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Close all ftp handlers
            try
            {
                main_ftp.handler.Disconnect();
            }
            catch (Exception ex) { return; }
            if (remote_ftp_handlers.Count > 0)
            {
                foreach (ServerHandler ftp in remote_ftp_handlers)
                {
                    try
                    {
                        ftp.handler.Disconnect();
                    }
                    catch (Exception ex) { return; }
                }
            }

            this.parent.task_list.Clear();
            if (task_list.Count > 0)
            {
                this.parent.task_list = task_list;
            }
            this.parent.GetTaskListCallback();
        }

    }
}
