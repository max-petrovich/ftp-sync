using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using FTP;
using FTPsync.Properties;


namespace FTPsync
{
    // ---------------------
    // TASKS
    public enum TaskType { none, upload, delete }
    public enum TaskStatus { notprocess,pending, processing, success, fail }
    public struct TaskListItem
    {
        public string name;
        public Server local_server;
        public string local_catalog;
        public long local_size;
        public Server remote_server;
        public string remote_catalog;
        public long remote_size;

        public bool active;
        public TaskType type;
    }

    public struct TaskItemGrid
    {
        public int index;
        public TaskListItem task;
        public TaskItemGrid(int index, TaskListItem task)
        {
            this.index = index;
            this.task = task;
        }
    }

    public static class Helper
    {
        public static string getConfigFilepath(string filename = "")
        {
            string config_path = null;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                config_path = filename;
            }
            else if (Settings.Default.ConfigPath != null && !string.IsNullOrWhiteSpace(Settings.Default.ConfigPath) && File.Exists(Settings.Default.ConfigPath))
            {
                config_path = Settings.Default.ConfigPath;
            }
            return config_path;
        }

        public static bool LoadConfigurationFile(string filename = "")
        {
            string config_path = Helper.getConfigFilepath(filename);

            if (config_path != null && File.Exists(config_path))
            {
                try
                {
                    ServerSettingsFile.Load(config_path);
                }
                catch (Exception e)
                {
                    config_path = null;
                    throw new Exception(e.Message);
                }

                Settings.Default.ConfigPath = config_path;
                Settings.Default.Save();
            }

            if (config_path != null)
            {
                return true;
            }
            return false;
        }

        public static bool SaveConfigFile(string filename = "")
        {
            string config_path = Helper.getConfigFilepath(filename);
            if (config_path != null)
            {
                try
                {
                    ServerSettingsFile.Save(config_path);
                    Settings.Default.ConfigPath = config_path;
                    Settings.Default.Save();
                }
                catch (Exception e)
                {
                    config_path = null;
                    throw new Exception(e.Message);
                }
            }
            if (config_path != null)
            {
                return true;
            }
            return false;
        }

        public static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public static Bitmap TaskTypeBitmap(TaskType type)
        {
            Bitmap bmp = null;

            switch(type) {
                case TaskType.upload:
                    bmp = Resources.arrow_right_green;
                    break;
                case TaskType.delete:
                    bmp = Resources.cross_red;
                    break;
                case TaskType.none:
                    bmp = Resources.arrow_right_red;
                    break;
                default:
                    bmp = Resources.arrow_right_red;
                    break;
            }

            return bmp;
        }

        public static Bitmap TaskStatusBitmap(TaskStatus result)
        {
            Bitmap bmp = Resources.circle_denied_red;

            switch (result)
            {
                case TaskStatus.processing:
                    bmp = Resources.progress;
                    break;
                case TaskStatus.success:
                    bmp = Resources.tick_green;
                    break;
                case TaskStatus.fail:
                    bmp = Resources.triangle_yellow;
                    break;
            }

            return bmp;
        }

        public static String TaskStatusDefaultText(TaskStatus status)
        {
            string result = "";
            IDictionary<TaskStatus, string> texts = new Dictionary<TaskStatus, string>();
            texts.Add(TaskStatus.notprocess, "Не требует обработки");
            texts.Add(TaskStatus.fail, "Ошибка");
            texts.Add(TaskStatus.processing, "В процессе");
            texts.Add(TaskStatus.success, "Успешно");
            texts.Add(TaskStatus.pending, "Ожидает обработки");

            if (texts.ContainsKey(status))
            {
                result = texts[status];
            }

            return result;
        }
    }
}
