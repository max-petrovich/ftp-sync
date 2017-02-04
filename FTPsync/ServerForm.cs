using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using FTP;

namespace FTPsync
{
    public partial class ServerForm : Form
    {
        private Form1 parent;
        private Server server;
        private List<Server_Type> s_types = new List<Server_Type>();

        public ServerForm()
        {
            InitializeComponent();
            // Init temp server object
            server = new Server();
            server.dirs = new Dirs();
        }
        private void ServerForm_Load(object sender, EventArgs e)
        {
            this.parent = this.Owner as Form1;

            // Check existing main server in list
            bool main_server_exists = false;
            if (parent.server_settings.Servers != null && parent.server_settings.Servers.Count > 0)
            {
                for (int i = 0; i < this.parent.server_settings.Servers.Count; i++)
                {
                    if (this.parent.server_settings.Servers[i].type == Server_Type.main)
                    {
                        main_server_exists = true;
                    }
                }
            }
            // Create types list
            foreach (Server_Type type in Enum.GetValues(typeof(Server_Type)))
            {
                // Remote main from combox
                if (main_server_exists)
                {
                    if (type == Server_Type.main && (Tag == null || (parent.server_settings.Servers[(int)Tag].type == Server_Type.client)))
                    {
                        continue;
                    }
                }
                s_types.Add(type);
            }
            // Fill Combobox
            this.FillFormTypes();
        }
        protected override bool ShowWithoutActivation { get { return true; } }

        // Fill to form data from server (if server != null - all data)
        public void FillData(Server serv)
        {
            if (serv != null)
            {
                this.server = serv;

                this.f_type.Text = ServerInfo.getTypeCaption(serv.type);
                this.f_name.Text = serv.name;
                this.f_ip.Text = serv.IP.ToString();
                this.f_port.Text = serv.port.ToString();
                this.f_login.Text = serv.login;
                this.f_password.Text = serv.password;
            }
        }

        // Fill and select server type to form
        private void FillFormTypes()
        {
            // Add items
            for (int i = 0; i < s_types.Count; i++ )
            {
                f_type.Items.Add(ServerInfo.getTypeCaption(s_types[i]));
                if (s_types[i] == Server_Type.client)
                {
                    this.f_type.SelectedIndex = i;
                }
            }
            // If edit
            if (Tag != null)
            {
                for (int i = 0; i < s_types.Count; i++)
                {
                    if (s_types[i] == parent.server_settings.Servers[(int)Tag].type)
                    {
                        f_type.SelectedIndex = i;
                        break;
                    }
                }
            }

        }

        // Edit dirs
        private void B_DIRS_LIST_Click(object sender, EventArgs e)
        {
            DirListForm Form = new DirListForm();
            Form.Owner = this;
            Form.Tag = this.server;
            Form.ShowDialog();
        }

        private void B_SAVE_Click(object sender, EventArgs e)
        {
            // Validate data
            List<string> error = new List<string>();

            if (string.IsNullOrWhiteSpace(f_name.Text))
            {
                error.Add("Заполните 'имя соединения'");
            }
            IPAddress temp;
            if (string.IsNullOrWhiteSpace(f_ip.Text))
            {
                error.Add("Заполните 'IP'");
            } 
            else if (!IPAddress.TryParse(f_ip.Text, out temp))
            {
                error.Add("Некорректное значение поля 'IP'");
            }
            if (string.IsNullOrWhiteSpace(f_port.Text))
            {
                error.Add("Заполните 'порт'");
            }
            else if (int.Parse(f_port.Text) <= 0 && int.Parse(f_port.Text) > 65535)
            {
                error.Add("Некорректное значение поля 'порт'");
            }
            if (string.IsNullOrWhiteSpace(f_login.Text))
            {
                error.Add("Заполните 'логин'");
            }
            if (string.IsNullOrWhiteSpace(f_password.Text))
            {
                error.Add("Заполните 'пароль'");
            }
            // Check dirs
            if (server.dirs == null || server.dirs.DirList.Count == 0)
            {
                error.Add("Добавьте 'директории синхронизации'");
            }

            // Check error
            if (error.Count > 0)
            {
                string error_text = "";
                for (int i = 0; i < error.Count; i++ )
                {
                    error_text += error[i] + "\r\n";
                }
                MessageBox.Show(error_text, "Исправьте ошибки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Save / Add Server
            server.name = f_name.Text;
            server.IP = IPAddress.Parse(f_ip.Text);
            server.port = int.Parse(f_port.Text);
            server.login = f_login.Text;
            server.password = f_password.Text;
            server.type = s_types[f_type.SelectedIndex];

            if (this.Tag != null)
            {
                parent.server_settings.Update(parent.server_settings.Servers[(int)Tag], server);
            }
            else
            {
                parent.server_settings.Add(server);
            }

            B_CANCEL.PerformClick();

        }
        private void B_CANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
