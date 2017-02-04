using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Configuration;
using FTPsync.Properties;
using FTP;
using System.Net.FtpClient;
using System.Net.Sockets;


namespace FTPsync
{
    public partial class Form1 : Form
    {
        public ServerSettings server_settings;
        public List<TaskListItem> task_list = new List<TaskListItem>();

        private bool inSync = false;
        delegate void SetTaskGridItemStatusDelegate(int index, TaskStatus status, string msg = null);

        public Form1() { 
            InitializeComponent();
            server_settings = ServerSettings.Instance;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig();
            this.FillStatusStripCounts();
        }

        // =============== CONFIG
        private void LoadConfig(string filename = "")
        {
            try
            {
                Helper.LoadConfigurationFile(filename);
                UpdateServersMenu();
                IDM_SERVERS.ShowDropDown();
                IDM_SERVERS_LIST.ShowDropDown();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось загрузить конфигурационный файл.\r\nReason: " + e.Message);
            }
        }
        private void SaveConfig(string filename = "")
        {
            try
            {
                Helper.SaveConfigFile(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось сохранить конфигурационный файл.\r\nReason: " + e.Message);
            }
        }
        private void IDM_ConfigLoad_Click(object sender, EventArgs e)
        {
            configOpenDialog.Filter = "Configuration file (*.bin)|*.bin";
            configOpenDialog.FileName = "";
            configOpenDialog.RestoreDirectory = true;
            DialogResult dr = configOpenDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                LoadConfig(configOpenDialog.FileName);
            }
        }

        private void IDM_ConfigSave_Click(object sender, EventArgs e)
        {
            if (Helper.getConfigFilepath() == null)
                IDM_ConfigSaveAs.PerformClick();
            else
                SaveConfig();
        }
        private void IDM_ConfigSaveAs_Click(object sender, EventArgs e)
        {
            configSaveDialog.Filter = "Configuration file (*.bin)|*.bin";
            configSaveDialog.FileName = "";
            configSaveDialog.RestoreDirectory = true;
            DialogResult dr = configSaveDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                SaveConfig(configSaveDialog.FileName);
            }
        }
        // =============== -CONFIG

        /* [+] MENU */
        private void UpdateServersMenu()
        {
            // Clear dropdown menu of list
            ToolStripMenuItem parent = IDM_SERVERS_LIST;
            parent.DropDownItems.Clear();
            // Fill dropdown
            if (server_settings.Servers != null && server_settings.Servers.Count > 0)
            {
                for (int i = 0; i < server_settings.Servers.Count; i++)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(server_settings.Servers[i].name + " [" + ServerInfo.getTypeCaption(server_settings.Servers[i].type) + "]");
                    item.DropDownItems.Add(new ToolStripMenuItem("Редактировать", null, new System.EventHandler(menu_ServerEdit)));
                        item.DropDownItems[0].Tag = i;
                    if (server_settings.Servers.Count == 1 || (server_settings.Servers.Count > 1 && server_settings.Servers[i].type == Server_Type.client))
                    {
                        item.DropDownItems.Add(new ToolStripMenuItem("Удалить", null, new System.EventHandler(menu_ServerDelete)));
                        item.DropDownItems[1].Tag = i;
                    }
                    parent.DropDownItems.Add(item);
                }
            }
        }

        // ============ +SERVER PROCESS
        private void IDM_ADD_SERVER_Click(object sender, EventArgs e)
        {
            ServerForm();
        }
        void menu_ServerEdit(object sender, System.EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            ServerForm((int)item.Tag);
        }
        void ServerForm(int id = -1)
        {
            ServerForm Form = new ServerForm();
            Form.Owner = this;
            if (id >= 0)
            {
                Form.Tag = id;
                Form.FillData(server_settings.Servers[id]);
            }
            Form.ShowDialog();
            Form.Dispose();

            UpdateServersMenu();
        }
        void menu_ServerDelete(object sender, System.EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            int id = (int)item.Tag;

            if (MessageBox.Show("Вы действительно хотите удалить сервер \"" + server_settings.Servers[id].name + "\" ?", "Подтвреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                server_settings.Remove(id);
                UpdateServersMenu();
            }
        }
        // ============ -SERVER PROCESS

        public void TaskListProcessStatus()
        {
            List<ToolStripMenuItem> menu_list = new List<ToolStripMenuItem>();
                menu_list.Add(IDM_config);
                menu_list.Add(IDM_SERVERS);
                menu_list.Add(IDM_Sync_CreateTaskList);

            foreach (ToolStripMenuItem item in menu_list)
            {
                item.Enabled = !inSync;
            }

            IDM_Sync_StartSync.Text = inSync ? "Остановить синхронизацию" : "Начать синхронизацию";
            task_grid.Columns[0].ReadOnly = inSync;
        }

        public void FillStatusStripCounts()
        {
            int active_tasks = 0;

            IDictionary<TaskType, int[]> counters = new Dictionary<TaskType, int[]>();
            counters.Add(TaskType.upload, new int[] { 0, 0 });
            counters.Add(TaskType.none, new int[] { 0, 0 });
            counters.Add(TaskType.delete, new int[] { 0, 0 });

            if (task_list != null && task_list.Count > 0)
            {
                foreach (TaskListItem item in task_list)
                {
                    if (item.active) { 
                        counters[item.type][0]++;
                        active_tasks++;
                    }
                    counters[item.type][1]++;
                }

            }

            sstatus_task.Text = active_tasks + " из " + task_list.Count;
            sstatus_upload.Text = counters[TaskType.upload][0] + " из " + counters[TaskType.upload][1];
            sstatus_notupload.Text = counters[TaskType.none][0] + " из " + counters[TaskType.none][1];
            sstatus_delete.Text = counters[TaskType.delete][0] + " из " + counters[TaskType.delete][1];

            task_list_counts.Refresh();
        }

        private void task_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (inSync) return;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Checkbox changed
                if (e.ColumnIndex == 0 && cell.Tag != null && (int)cell.Tag >= 0)
                {
                    TaskListItem item = task_list[(int)cell.Tag];
                    item.active = !item.active;
                    task_list[(int)cell.Tag] = item;
                    FillStatusStripCounts();
                    cell.Value = item.active;
                }
            }
        }

        public void GetTaskListCallback()
        {
            task_grid.Rows.Clear();

            // Fill task list
            if (task_list != null && task_list.Count > 0)
            {
                int rowIndex;
                foreach (TaskListItem item in task_list)
                {
                    rowIndex = task_grid.Rows.Add();

                    task_grid.Rows[rowIndex].Cells[0].Tag = rowIndex;
                    task_grid.Rows[rowIndex].Cells[0].Value = item.active & item.type != TaskType.none;
                    task_grid.Rows[rowIndex].Cells[1].Value = item.name;
                    task_grid.Rows[rowIndex].Cells[2].Value = item.local_catalog;
                    task_grid.Rows[rowIndex].Cells[3].Value = item.local_size > 0 ? Helper.BytesToString(item.local_size) : "";
                    task_grid.Rows[rowIndex].Cells[4].Value = Helper.TaskTypeBitmap(item.type);
                    task_grid.Rows[rowIndex].Cells[4].ToolTipText = Helper.TaskStatusDefaultText(item.type == TaskType.none ? TaskStatus.notprocess: TaskStatus.pending);
                    task_grid.Rows[rowIndex].Cells[5].Value = item.remote_server.name;
                    task_grid.Rows[rowIndex].Cells[6].Value = item.remote_catalog;
                    task_grid.Rows[rowIndex].Cells[7].Value = item.remote_size > 0 ? Helper.BytesToString(item.remote_size) : "";
                }
            }
            FillStatusStripCounts();
            IDM_Sync_StartSync.Enabled = true;
        }

        // Connect to FTP and make TASK LIST
        private void IDM_Sync_CreateTaskList_Click(object sender, EventArgs e)
        {
            task_grid.Rows.Clear();
            GetListLogForm Form = new GetListLogForm();
            Form.Owner = this;
            Form.ShowDialog();
            Form.Dispose();
        }

// ----------------------------------------------------------------------
        // Start SYNC process
        private void IDM_Sync_StartSync_Click(object sender, EventArgs e)
        {
            if (task_list != null && task_list.Count > 0)
            {
                if (bgw.IsBusy != true)
                {
                    inSync = true;
                    TaskListProcessStatus();
                    bgw.RunWorkerAsync();
                }
                else
                {
                    if (bgw.WorkerSupportsCancellation)
                    {
                        bgw.CancelAsync();
                    }
                    else
                    {
                        MessageBox.Show("Невозможно остановить! Дождитесь окончания процесса!");
                    }
                    
                }
            }
        }


        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 3;

            ParallelLoopResult taskProcessingResult = Parallel.For(0,task_list.Count,options, (i, loopState) =>
            {
                TaskListItem item = task_list[i];
                if (item.active)
                {
                    if (item.type == TaskType.upload)
                    {
                        SetTaskGridItemStatus(i, TaskStatus.processing);

                        CopyFileForm Form = new CopyFileForm();
                        Form.Tag = item;
                        Form.ShowDialog();

                        // Get status
                        TaskStatus status = Form.getStatusType();
                        task_grid.Rows[i].Cells[4].Value = Helper.TaskStatusBitmap(status);
                        task_grid.Rows[i].Cells[4].ToolTipText = Form.getStatusMsg();

                        Form.Dispose();
                    }
                    else if (item.type == TaskType.delete)
                    {
                        SetTaskGridItemStatus(i, TaskStatus.processing);
                        try
                        {
                            FtpClient ftp = new FtpClient();
                            ftp.Host = item.remote_server.IP.ToString();
                            ftp.Port = item.remote_server.port;
                            ftp.Credentials = new NetworkCredential(item.remote_server.login, item.remote_server.password);
                            ftp.Connect();
                            ftp.DeleteFile(item.remote_catalog + item.name);
                            ftp.Disconnect();
                            
                            SetTaskGridItemStatus(i, TaskStatus.success, "Файл удалён");
                        }
                        catch(SocketException ex)
                        {
                            SetTaskGridItemStatus(i, TaskStatus.fail, ex.Message);
                        }
                    }

                }
            });

            if (taskProcessingResult.IsCompleted)
            {
                //MessageBox.Show("YRAA");
            }
        }


        public void SetTaskGridItemStatus(int index, TaskStatus status, string msg = null)
        {
            if (msg == null)
            {
                msg = Helper.TaskStatusDefaultText(status);
            }

            if (this.task_grid.InvokeRequired)
            {
                SetTaskGridItemStatusDelegate d = new SetTaskGridItemStatusDelegate(SetTaskGridItemStatus);
                this.Invoke(d, new object[] { index, status, msg });
            }
            else
            {
                this.task_grid.Rows[index].Cells[4].Value = Helper.TaskStatusBitmap(status);
                this.task_grid.Rows[index].Cells[4].ToolTipText = msg;
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            inSync = false;
            TaskListProcessStatus();
            MessageBox.Show("Синхронизация окончена!");
        }

        /* +++ ABOUT + CLOSE +++*/
        private void IDM_ABOUT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Maxic\nКонтакты:\nEmail: unrelaxby@gmail.com\nSkype: maxic_unrelax");
        }
        private void IDM_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.server_settings.is_changed)
            {
                if (MessageBox.Show("Сохранить текущую конфигурацию?", "Конфигурация была изменена", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) // SAVE Config
                {
                    IDM_ConfigSave.PerformClick();
                }
            }
        }

    }
}
