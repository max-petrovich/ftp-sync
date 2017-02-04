using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.FtpClient;

namespace FTP
{
    [Serializable()]
    public class Server
    {
        public Server_Type type = Server_Type.client;

        // Server title
        private string _name;
        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /* Connection params*/
        public IPAddress IP;
        public int port = 21;
        public string login;
        public string password;

        public Dirs dirs;
    }

    public static class ServerInfo {

        public static string getTypeCaption(Server_Type type)
        {
            string result = "";

            IDictionary<Server_Type, string> server_type_text = new Dictionary<Server_Type, string>();
            server_type_text.Add(Server_Type.main, "Главный");
            server_type_text.Add(Server_Type.client, "Клиент");

            if (server_type_text.ContainsKey(type))
            {
                result = server_type_text[type];
            }
            return result;
        }
    }
}
