namespace FTPsync
{
    partial class DirListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dirs_table = new System.Windows.Forms.DataGridView();
            this.local_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remote_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_cancel = new System.Windows.Forms.Button();
            this.B_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dirs_table)).BeginInit();
            this.SuspendLayout();
            // 
            // dirs_table
            // 
            this.dirs_table.AllowUserToDeleteRows = false;
            this.dirs_table.AllowUserToResizeRows = false;
            this.dirs_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dirs_table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dirs_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dirs_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.local_path,
            this.remote_path});
            this.dirs_table.Location = new System.Drawing.Point(6, 10);
            this.dirs_table.MultiSelect = false;
            this.dirs_table.Name = "dirs_table";
            this.dirs_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dirs_table.Size = new System.Drawing.Size(533, 242);
            this.dirs_table.TabIndex = 0;
            // 
            // local_path
            // 
            this.local_path.HeaderText = "Локальный путь";
            this.local_path.Name = "local_path";
            // 
            // remote_path
            // 
            this.remote_path.HeaderText = "Удалённый путь";
            this.remote_path.Name = "remote_path";
            // 
            // B_cancel
            // 
            this.B_cancel.Location = new System.Drawing.Point(438, 259);
            this.B_cancel.Name = "B_cancel";
            this.B_cancel.Size = new System.Drawing.Size(101, 23);
            this.B_cancel.TabIndex = 1;
            this.B_cancel.Text = "Отмена";
            this.B_cancel.UseVisualStyleBackColor = true;
            this.B_cancel.Click += new System.EventHandler(this.B_cancel_Click);
            // 
            // B_save
            // 
            this.B_save.Location = new System.Drawing.Point(319, 258);
            this.B_save.Name = "B_save";
            this.B_save.Size = new System.Drawing.Size(113, 23);
            this.B_save.TabIndex = 2;
            this.B_save.Text = "Сохранить";
            this.B_save.UseVisualStyleBackColor = true;
            this.B_save.Click += new System.EventHandler(this.B_save_Click);
            // 
            // DirListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 289);
            this.Controls.Add(this.B_save);
            this.Controls.Add(this.B_cancel);
            this.Controls.Add(this.dirs_table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Директории синхронизации";
            this.Load += new System.EventHandler(this.DirListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dirs_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dirs_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn remote_path;
        private System.Windows.Forms.Button B_cancel;
        private System.Windows.Forms.Button B_save;
    }
}