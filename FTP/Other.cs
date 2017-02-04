using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.FtpClient;

namespace FTP
{
    // SERVER
    [Serializable()]
    public enum Server_Type { main, client }

    // DIRS
    [Serializable()]
    public struct LocalRemoteDir
    {
        public string local;
        public string remote;

        public LocalRemoteDir(string local, string remote)
        {
            this.local = local;
            this.remote = remote;
        }
    }


    public struct ServerHandler
    {
        public Server server;
        public FtpClient handler;

        public ServerHandler(Server server, FtpClient handler)
        {
            this.server = server;
            this.handler = handler;
        }
    }
}
