using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.FtpClient;
using System.Net.Sockets;

namespace FTPsync
{
    public partial class CopyFileForm : Form
    {

        private TaskStatus _status = TaskStatus.fail;
        private string _status_string = "";
        private TaskListItem task;

        private long FileSizeAll = 0;

        // --------
        private delegate void SetProgressDelegate(long bytes_loaded, long bytes_all);

        public CopyFileForm()
        {
            InitializeComponent();
            l_filename.Parent = pb_bg;
        }

        private void CopyFileForm_Load(object sender, EventArgs e)
        {
            // Fill info about file
            if (this.Tag != null)
            {
                task = (TaskListItem)this.Tag;
                this.l_filename.Text = task.name;
                this.l_source.Text = "[" + task.local_server.name + "] " + task.local_catalog;
                this.l_dest.Text = "[" + task.remote_server.name + "] " + task.remote_catalog;

                FileSizeAll = task.local_size;

                this.SetProgress(0, FileSizeAll);

                if (!bgw1.IsBusy)
                {
                    bgw1.RunWorkerAsync();
                }
            }
            else
            {
                throw new Exception("No data");
            }
        }

        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            
            try
            {
                // Connect to local_ftp
                FtpClient ftp_local = new FtpClient();
                ftp_local.Host = task.local_server.IP.ToString();
                ftp_local.Port = task.local_server.port;
                ftp_local.Credentials = new NetworkCredential(task.local_server.login, task.local_server.password);
                ftp_local.Connect();
                // Connect to remote_ftp
                FtpClient ftp_remote = new FtpClient();
                ftp_remote.Host = task.remote_server.IP.ToString();
                ftp_remote.Port = task.remote_server.port;
                ftp_remote.Credentials = new NetworkCredential(task.remote_server.login, task.remote_server.password);
                ftp_remote.Connect();
                // Filepath'es
                string local_filepath = task.local_catalog + task.name;
                string remote_filepath = task.remote_catalog + task.name;
                // Check local file
                if (ftp_local.FileExists(local_filepath)) {
                    // if exist - delete
                    if (ftp_remote.FileExists(remote_filepath))
                    {
                        ftp_remote.DeleteFile(remote_filepath);
                    }
                    // STREAM \\
                    // LOCAL
                    using (Stream rstream = ftp_remote.OpenWrite(remote_filepath))
                    {
                        try
                        {
                            using (Stream lstream = ftp_local.OpenRead(local_filepath, FtpDataType.Binary))
                            {
                                try
                                {
                                    byte[] buffer = new byte[2048];
                                    long bytes_loaded = 0;
                                    int bytesRead;
                                    while ((bytesRead = lstream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        if (worker.CancellationPending)
                                        {
                                            setStatus(TaskStatus.fail, "Операция отменена");
                                            break;
                                        }

                                        rstream.Write(buffer, 0, bytesRead);

                                        bytes_loaded += bytesRead;
                                        SetProgress(bytes_loaded, FileSizeAll);
                                    }
                                    setStatus(TaskStatus.success, "Файл синхронизирован");
                                }
                                catch (Exception ex)
                                {
                                    setStatus(TaskStatus.fail, ex.Message);
                                }
                                finally
                                {
                                    lstream.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            setStatus(TaskStatus.fail, ex.Message);
                        }
                        finally
                        {
                            rstream.Close();
                        }
                    }
                } else {
                    setStatus(TaskStatus.fail, "Локальный файл не обнаружен");
                }

                // Disconect ftp's
                ftp_local.Disconnect();
                ftp_remote.Disconnect();
            }
            catch (SocketException ex) {
                setStatus(TaskStatus.fail, ex.Message);
            }

        }

        private void SetProgress(long bytes_loaded, long bytes_all)
        {
            if (progress_bar.InvokeRequired)
            {
                SetProgressDelegate d = new SetProgressDelegate(SetProgress);
                this.Invoke(d, new object[] { bytes_loaded, bytes_all });
            }
            else
            {
                int percentage = (int)Math.Floor(((double)bytes_loaded / bytes_all) * 100);
                if (percentage > 100)
                    percentage = 100;
                this.l_uploaded.Text = Helper.BytesToString(bytes_loaded) + " из " + Helper.BytesToString(bytes_all);
                this.Text = percentage + "%";
                this.progress_bar.Value = percentage;
            }
        }

        private void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            b_cancel.PerformClick();
        }


        private void setStatus(TaskStatus type, string msg)
        {
            _status = type;
            _status_string = msg;
        }

        public TaskStatus getStatusType()
        {
            return _status;
        }
        public string getStatusMsg()
        {
            return _status_string;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void CopyFileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgw1.IsBusy)
            {
                if (MessageBox.Show("Процесс ещё не завершён!\r\nВы точно хотите отменить операцию?", "Подтвреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (bgw1.WorkerSupportsCancellation == true)
                    {
                        bgw1.CancelAsync();
                    }
                    else
                    {
                        MessageBox.Show("Прекращение выполнения недоступно! Дождитесь окончания операции!");
                    }
                }
                e.Cancel = true;
            }
        }

        private void CopyFileForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

    }
}
