using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FTP;
using System.Net.FtpClient;

namespace FTPsync
{

/*
    Class: Settings
    Store FTP Servers settings 
*/
    public sealed class ServerSettings
    {
        private static ServerSettings instance;
        private ServerSettings() {}
        public static ServerSettings Instance { get { if (instance == null) { instance = new ServerSettings(); } return instance; } }
        // -------------------------------
        private List<Server> _servers = new List<Server>();
        public List<Server> Servers { get { return _servers; } }

        public bool is_changed = false;

        /* [+] CRUD */
        public bool Add(Server server)
        {
            if (server != null)
            {
                _servers.Add(server);
                is_changed = true;
                this.SortList();
                return true;
            }
            return false;
        }

        public bool Update(Server old_server, Server new_server)
        {
            if (old_server != null && new_server != null)
            {
                int index = _servers.IndexOf(old_server);
                if (index >= 0)
                {
                    _servers[index] = null;
                    _servers[index] = new_server;
                    is_changed = true;
                    this.SortList();
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            if (Servers.Count > 0)
            {
                this.Remove(0);
                this.Clear();
            }
        }

        public bool Remove(int id)
        {
            _servers[id].dirs = null;
            _servers[id] = null;
            _servers.RemoveAt(id);
            is_changed = true;
            this.SortList();
            return true;
        }
        /* [-] CRUD */

        private void SortList()
        {
            _servers = _servers.OrderBy(o => o.type).ToList();
        }
    }

    public static class ServerSettingsFile
    {

        public static bool Load(string filename)
        {
            // Check filename
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new Exception("Empty filename");
            }
            else if (!File.Exists(filename))
            {
                throw new Exception("File not exists");
            }

            ServerSettings server_settings = ServerSettings.Instance;

            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                using (Stream fStream = File.OpenRead(filename))
                {
                    object robj = formater.Deserialize(fStream);
                    if (robj.GetType() == server_settings.Servers.GetType())
                    {
                        server_settings.Clear();
                        List<Server> temp_list = robj as List<Server>;
                        for (int i = 0; i < temp_list.Count; i++ )
                        {
                            server_settings.Add(temp_list[i]);
                        }
                        server_settings.is_changed = false;
                        return true;
                    }
                    
                }
            }
            catch
            {
                throw new Exception("File is not correct!");
            }
            return false;
        }

        public static bool Save(string filename)
        {
            // Check filename
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new Exception("Empty filename");
            }
            if (!Directory.Exists(Path.GetDirectoryName(filename)))
            {
                throw new Exception("Directory doesnt exists");
            }

            ServerSettings settings = ServerSettings.Instance;

            if (settings.Servers != null)
            {
                BinaryFormatter formater = new BinaryFormatter();
                try
                {
                    using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        formater.Serialize(fStream, settings.Servers);
                        settings.is_changed = false;
                        return true;
                    }
                }
                catch
                {
                    throw new Exception("Serialization failed");
                }
            }

            return false;
        }
    }


}
