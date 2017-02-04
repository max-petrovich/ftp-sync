namespace FTPsync
{
    partial class ServerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_port = new System.Windows.Forms.NumericUpDown();
            this.f_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.f_login = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.f_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.f_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_CANCEL = new System.Windows.Forms.Button();
            this.B_SAVE = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_DIRS_LIST = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.f_type = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_port)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.f_port);
            this.groupBox1.Controls.Add(this.f_password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.f_login);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.f_ip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.f_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры подключения";
            // 
            // f_port
            // 
            this.f_port.Location = new System.Drawing.Point(271, 54);
            this.f_port.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.f_port.Name = "f_port";
            this.f_port.Size = new System.Drawing.Size(65, 20);
            this.f_port.TabIndex = 11;
            this.f_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.f_port.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // f_password
            // 
            this.f_password.Location = new System.Drawing.Point(90, 106);
            this.f_password.Name = "f_password";
            this.f_password.Size = new System.Drawing.Size(246, 20);
            this.f_password.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Порт:";
            // 
            // f_login
            // 
            this.f_login.Location = new System.Drawing.Point(90, 80);
            this.f_login.Name = "f_login";
            this.f_login.Size = new System.Drawing.Size(246, 20);
            this.f_login.TabIndex = 4;
            this.f_login.Text = "mysite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Логин:";
            // 
            // f_ip
            // 
            this.f_ip.Location = new System.Drawing.Point(90, 54);
            this.f_ip.Name = "f_ip";
            this.f_ip.Size = new System.Drawing.Size(143, 20);
            this.f_ip.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP:";
            // 
            // f_name
            // 
            this.f_name.Location = new System.Drawing.Point(90, 26);
            this.f_name.Name = "f_name";
            this.f_name.Size = new System.Drawing.Size(246, 20);
            this.f_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя сервера:";
            // 
            // B_CANCEL
            // 
            this.B_CANCEL.Location = new System.Drawing.Point(248, 238);
            this.B_CANCEL.Name = "B_CANCEL";
            this.B_CANCEL.Size = new System.Drawing.Size(99, 23);
            this.B_CANCEL.TabIndex = 1;
            this.B_CANCEL.Text = "Отмена";
            this.B_CANCEL.UseVisualStyleBackColor = true;
            this.B_CANCEL.Click += new System.EventHandler(this.B_CANCEL_Click);
            // 
            // B_SAVE
            // 
            this.B_SAVE.Location = new System.Drawing.Point(143, 238);
            this.B_SAVE.Name = "B_SAVE";
            this.B_SAVE.Size = new System.Drawing.Size(99, 23);
            this.B_SAVE.TabIndex = 2;
            this.B_SAVE.Text = "Сохранить";
            this.B_SAVE.UseVisualStyleBackColor = true;
            this.B_SAVE.Click += new System.EventHandler(this.B_SAVE_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.B_DIRS_LIST);
            this.groupBox2.Location = new System.Drawing.Point(6, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Директории синхронизации";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = " Выберите директории";
            // 
            // B_DIRS_LIST
            // 
            this.B_DIRS_LIST.Location = new System.Drawing.Point(305, 19);
            this.B_DIRS_LIST.Name = "B_DIRS_LIST";
            this.B_DIRS_LIST.Size = new System.Drawing.Size(31, 23);
            this.B_DIRS_LIST.TabIndex = 0;
            this.B_DIRS_LIST.Text = "+";
            this.B_DIRS_LIST.UseVisualStyleBackColor = true;
            this.B_DIRS_LIST.Click += new System.EventHandler(this.B_DIRS_LIST_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Тип сервера:";
            // 
            // f_type
            // 
            this.f_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f_type.FormattingEnabled = true;
            this.f_type.Location = new System.Drawing.Point(96, 6);
            this.f_type.Name = "f_type";
            this.f_type.Size = new System.Drawing.Size(246, 21);
            this.f_type.TabIndex = 1;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 267);
            this.Controls.Add(this.f_type);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.B_SAVE);
            this.Controls.Add(this.B_CANCEL);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка FTP соединения";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f_port)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox f_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox f_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox f_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox f_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button B_CANCEL;
        private System.Windows.Forms.Button B_SAVE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button B_DIRS_LIST;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox f_type;
        private System.Windows.Forms.NumericUpDown f_port;
    }
}