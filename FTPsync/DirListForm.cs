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

namespace FTPsync
{
    public partial class DirListForm : Form
    {

        private Server server;

        public DirListForm()
        {
            InitializeComponent();
        }
        private void DirListForm_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                throw new Exception("No server tag DirList Form");
            }
            this.server = (Server)this.Tag; // Link to real object
            if (this.server.dirs == null)
            {
                this.server.dirs = new Dirs();
            }
            else if (this.server.dirs.DirList.Count > 0)
            {
                // Fill data to table
                for (int i = 0; i < this.server.dirs.DirList.Count; i++ )
                {
                    this.dirs_table.Rows.Add(this.server.dirs.DirList[i].local, this.server.dirs.DirList[i].remote);
                }
            }
        }
        // Save
        private void B_save_Click(object sender, EventArgs e)
        {
            if ((dirs_table.Rows.Count - 1) == 0)
            {
                MessageBox.Show("Таблица пуста, невозможно сохранить");
                return;
            }

            // Check for empty part-row
            bool part_empty_row_exists = false;
            for (int row = 0; row < dirs_table.Rows.Count - 1; row++)
            {
                if (string.IsNullOrWhiteSpace((string)dirs_table.Rows[row].Cells[0].Value) && string.IsNullOrWhiteSpace((string)dirs_table.Rows[row].Cells[1].Value))
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace((string)dirs_table.Rows[row].Cells[0].Value) || string.IsNullOrWhiteSpace((string)dirs_table.Rows[row].Cells[1].Value))
                {
                    part_empty_row_exists = true;
                    break;
                }
            }
            if (part_empty_row_exists)
            {
                MessageBox.Show("Заполните недостающие поля таблицы ( и локальный, и удалённый путь)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Update Dirs
            this.server.dirs.DirList.Clear();

            for (int row = 0; row < dirs_table.Rows.Count - 1; row++)
            {
                if (!string.IsNullOrWhiteSpace((string)dirs_table.Rows[row].Cells[0].Value) && !string.IsNullOrWhiteSpace((string)dirs_table.Rows[row].Cells[1].Value))
                {
                    this.server.dirs.Add(new LocalRemoteDir((string)dirs_table.Rows[row].Cells[0].Value, (string)dirs_table.Rows[row].Cells[1].Value));   
                }
            }


            this.server.dirs.is_changed = false;

            B_cancel.PerformClick();
            
        }
        private void B_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
