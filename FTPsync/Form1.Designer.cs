namespace FTPsync
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.IDM_FILE = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_config = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ConfigLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ConfigSave = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ConfigSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_EXIT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_SERVERS = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ADD_SERVER = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_SERVERS_LIST = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_synchronization = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_Sync_CreateTaskList = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_Sync_StartSync = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_HELP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ABOUT = new System.Windows.Forms.ToolStripMenuItem();
            this.configOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.configSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.task_grid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewImageColumn();
            this.remote_server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remote_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remote_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task_list_counts = new System.Windows.Forms.StatusStrip();
            this.sstatus_task = new System.Windows.Forms.ToolStripStatusLabel();
            this.sstatus_upload = new System.Windows.Forms.ToolStripStatusLabel();
            this.sstatus_notupload = new System.Windows.Forms.ToolStripStatusLabel();
            this.sstatus_delete = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.task_grid)).BeginInit();
            this.task_list_counts.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_FILE,
            this.IDM_SERVERS,
            this.IDM_synchronization,
            this.IDM_HELP});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // IDM_FILE
            // 
            this.IDM_FILE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_config,
            this.IDM_EXIT});
            this.IDM_FILE.Name = "IDM_FILE";
            this.IDM_FILE.Size = new System.Drawing.Size(48, 20);
            this.IDM_FILE.Text = "Файл";
            // 
            // IDM_config
            // 
            this.IDM_config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_ConfigLoad,
            this.IDM_ConfigSave,
            this.IDM_ConfigSaveAs});
            this.IDM_config.Name = "IDM_config";
            this.IDM_config.Size = new System.Drawing.Size(155, 22);
            this.IDM_config.Text = "Конфигурация";
            // 
            // IDM_ConfigLoad
            // 
            this.IDM_ConfigLoad.Name = "IDM_ConfigLoad";
            this.IDM_ConfigLoad.Size = new System.Drawing.Size(153, 22);
            this.IDM_ConfigLoad.Text = "Загрузить";
            this.IDM_ConfigLoad.Click += new System.EventHandler(this.IDM_ConfigLoad_Click);
            // 
            // IDM_ConfigSave
            // 
            this.IDM_ConfigSave.Name = "IDM_ConfigSave";
            this.IDM_ConfigSave.Size = new System.Drawing.Size(153, 22);
            this.IDM_ConfigSave.Text = "Сохранить";
            this.IDM_ConfigSave.Click += new System.EventHandler(this.IDM_ConfigSave_Click);
            // 
            // IDM_ConfigSaveAs
            // 
            this.IDM_ConfigSaveAs.Name = "IDM_ConfigSaveAs";
            this.IDM_ConfigSaveAs.Size = new System.Drawing.Size(153, 22);
            this.IDM_ConfigSaveAs.Text = "Сохранить как";
            this.IDM_ConfigSaveAs.Click += new System.EventHandler(this.IDM_ConfigSaveAs_Click);
            // 
            // IDM_EXIT
            // 
            this.IDM_EXIT.Name = "IDM_EXIT";
            this.IDM_EXIT.Size = new System.Drawing.Size(155, 22);
            this.IDM_EXIT.Text = "Выход";
            this.IDM_EXIT.Click += new System.EventHandler(this.IDM_EXIT_Click);
            // 
            // IDM_SERVERS
            // 
            this.IDM_SERVERS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_ADD_SERVER,
            this.IDM_SERVERS_LIST});
            this.IDM_SERVERS.Name = "IDM_SERVERS";
            this.IDM_SERVERS.Size = new System.Drawing.Size(65, 20);
            this.IDM_SERVERS.Text = "Сервера";
            // 
            // IDM_ADD_SERVER
            // 
            this.IDM_ADD_SERVER.Name = "IDM_ADD_SERVER";
            this.IDM_ADD_SERVER.Size = new System.Drawing.Size(126, 22);
            this.IDM_ADD_SERVER.Text = "Добавить";
            this.IDM_ADD_SERVER.Click += new System.EventHandler(this.IDM_ADD_SERVER_Click);
            // 
            // IDM_SERVERS_LIST
            // 
            this.IDM_SERVERS_LIST.Name = "IDM_SERVERS_LIST";
            this.IDM_SERVERS_LIST.Size = new System.Drawing.Size(126, 22);
            this.IDM_SERVERS_LIST.Text = "Список";
            // 
            // IDM_synchronization
            // 
            this.IDM_synchronization.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_Sync_CreateTaskList,
            this.IDM_Sync_StartSync});
            this.IDM_synchronization.Name = "IDM_synchronization";
            this.IDM_synchronization.Size = new System.Drawing.Size(105, 20);
            this.IDM_synchronization.Text = "Синхронизация";
            // 
            // IDM_Sync_CreateTaskList
            // 
            this.IDM_Sync_CreateTaskList.Name = "IDM_Sync_CreateTaskList";
            this.IDM_Sync_CreateTaskList.Size = new System.Drawing.Size(204, 22);
            this.IDM_Sync_CreateTaskList.Text = "Получить список";
            this.IDM_Sync_CreateTaskList.Click += new System.EventHandler(this.IDM_Sync_CreateTaskList_Click);
            // 
            // IDM_Sync_StartSync
            // 
            this.IDM_Sync_StartSync.Enabled = false;
            this.IDM_Sync_StartSync.Name = "IDM_Sync_StartSync";
            this.IDM_Sync_StartSync.Size = new System.Drawing.Size(204, 22);
            this.IDM_Sync_StartSync.Text = "Начать синхронизацию";
            this.IDM_Sync_StartSync.Click += new System.EventHandler(this.IDM_Sync_StartSync_Click);
            // 
            // IDM_HELP
            // 
            this.IDM_HELP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_ABOUT});
            this.IDM_HELP.Name = "IDM_HELP";
            this.IDM_HELP.Size = new System.Drawing.Size(65, 20);
            this.IDM_HELP.Text = "Справка";
            // 
            // IDM_ABOUT
            // 
            this.IDM_ABOUT.Name = "IDM_ABOUT";
            this.IDM_ABOUT.Size = new System.Drawing.Size(149, 22);
            this.IDM_ABOUT.Text = "О программе";
            this.IDM_ABOUT.Click += new System.EventHandler(this.IDM_ABOUT_Click);
            // 
            // configOpenDialog
            // 
            this.configOpenDialog.FileName = "*.bin";
            // 
            // task_grid
            // 
            this.task_grid.AllowUserToAddRows = false;
            this.task_grid.AllowUserToDeleteRows = false;
            this.task_grid.AllowUserToResizeRows = false;
            this.task_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.task_grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.task_grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.task_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.task_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.task_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.task_grid.ColumnHeadersHeight = 25;
            this.task_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.task_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.local_dir,
            this.local_size,
            this.action,
            this.remote_server,
            this.remote_dir,
            this.remote_size});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.task_grid.DefaultCellStyle = dataGridViewCellStyle12;
            this.task_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.task_grid.GridColor = System.Drawing.Color.LightGray;
            this.task_grid.Location = new System.Drawing.Point(0, 25);
            this.task_grid.MultiSelect = false;
            this.task_grid.Name = "task_grid";
            this.task_grid.RowHeadersVisible = false;
            this.task_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.task_grid.ShowEditingIcon = false;
            this.task_grid.ShowRowErrors = false;
            this.task_grid.Size = new System.Drawing.Size(805, 382);
            this.task_grid.TabIndex = 3;
            this.task_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.task_grid_CellContentClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.id.FalseValue = "-1";
            this.id.FillWeight = 92.48085F;
            this.id.HeaderText = "";
            this.id.Name = "id";
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.Width = 20;
            // 
            // name
            // 
            this.name.FillWeight = 102.3069F;
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // local_dir
            // 
            this.local_dir.FillWeight = 102.3069F;
            this.local_dir.HeaderText = "Локальный каталог";
            this.local_dir.Name = "local_dir";
            this.local_dir.ReadOnly = true;
            // 
            // local_size
            // 
            this.local_size.FillWeight = 102.3069F;
            this.local_size.HeaderText = "Размер";
            this.local_size.Name = "local_size";
            this.local_size.ReadOnly = true;
            // 
            // action
            // 
            this.action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.action.FillWeight = 91.37056F;
            this.action.HeaderText = "";
            this.action.Name = "action";
            this.action.ReadOnly = true;
            this.action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.action.Width = 25;
            // 
            // remote_server
            // 
            this.remote_server.HeaderText = "Сервер";
            this.remote_server.Name = "remote_server";
            this.remote_server.ReadOnly = true;
            // 
            // remote_dir
            // 
            this.remote_dir.FillWeight = 102.3069F;
            this.remote_dir.HeaderText = "Удалённый каталог";
            this.remote_dir.Name = "remote_dir";
            this.remote_dir.ReadOnly = true;
            this.remote_dir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // remote_size
            // 
            this.remote_size.FillWeight = 102.3069F;
            this.remote_size.HeaderText = "Размер";
            this.remote_size.Name = "remote_size";
            this.remote_size.ReadOnly = true;
            // 
            // task_list_counts
            // 
            this.task_list_counts.AutoSize = false;
            this.task_list_counts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.task_list_counts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sstatus_task,
            this.sstatus_upload,
            this.sstatus_notupload,
            this.sstatus_delete});
            this.task_list_counts.Location = new System.Drawing.Point(0, 407);
            this.task_list_counts.Name = "task_list_counts";
            this.task_list_counts.ShowItemToolTips = true;
            this.task_list_counts.Size = new System.Drawing.Size(805, 22);
            this.task_list_counts.SizingGrip = false;
            this.task_list_counts.TabIndex = 4;
            this.task_list_counts.Text = "statusStrip1";
            // 
            // sstatus_task
            // 
            this.sstatus_task.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sstatus_task.Image = global::FTPsync.Properties.Resources.task_list;
            this.sstatus_task.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sstatus_task.Margin = new System.Windows.Forms.Padding(0, 3, 3, 2);
            this.sstatus_task.Name = "sstatus_task";
            this.sstatus_task.Size = new System.Drawing.Size(20, 17);
            this.sstatus_task.ToolTipText = "Количество заданий";
            // 
            // sstatus_upload
            // 
            this.sstatus_upload.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sstatus_upload.Image = global::FTPsync.Properties.Resources.arrow_right_green;
            this.sstatus_upload.ImageTransparentColor = System.Drawing.Color.White;
            this.sstatus_upload.Margin = new System.Windows.Forms.Padding(0, 3, 3, 2);
            this.sstatus_upload.Name = "sstatus_upload";
            this.sstatus_upload.Size = new System.Drawing.Size(20, 17);
            this.sstatus_upload.ToolTipText = "Загрузка";
            // 
            // sstatus_notupload
            // 
            this.sstatus_notupload.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sstatus_notupload.Image = global::FTPsync.Properties.Resources.circle_denied_red;
            this.sstatus_notupload.Margin = new System.Windows.Forms.Padding(0, 3, 3, 2);
            this.sstatus_notupload.Name = "sstatus_notupload";
            this.sstatus_notupload.Size = new System.Drawing.Size(20, 17);
            this.sstatus_notupload.ToolTipText = "Нет действия";
            // 
            // sstatus_delete
            // 
            this.sstatus_delete.Image = global::FTPsync.Properties.Resources.cross_red;
            this.sstatus_delete.Margin = new System.Windows.Forms.Padding(0, 3, 3, 2);
            this.sstatus_delete.Name = "sstatus_delete";
            this.sstatus_delete.Size = new System.Drawing.Size(16, 17);
            this.sstatus_delete.ToolTipText = "Удаление";
            // 
            // bgw
            // 
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 429);
            this.Controls.Add(this.task_list_counts);
            this.Controls.Add(this.task_grid);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FTP GoSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.task_grid)).EndInit();
            this.task_list_counts.ResumeLayout(false);
            this.task_list_counts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem IDM_FILE;
        private System.Windows.Forms.ToolStripMenuItem IDM_HELP;
        private System.Windows.Forms.ToolStripMenuItem IDM_EXIT;
        private System.Windows.Forms.ToolStripMenuItem IDM_ABOUT;
        private System.Windows.Forms.ToolStripMenuItem IDM_SERVERS;
        private System.Windows.Forms.ToolStripMenuItem IDM_ADD_SERVER;
        private System.Windows.Forms.ToolStripMenuItem IDM_SERVERS_LIST;
        private System.Windows.Forms.OpenFileDialog configOpenDialog;
        private System.Windows.Forms.SaveFileDialog configSaveDialog;
        private System.Windows.Forms.ToolStripMenuItem IDM_config;
        private System.Windows.Forms.ToolStripMenuItem IDM_ConfigLoad;
        private System.Windows.Forms.ToolStripMenuItem IDM_ConfigSave;
        private System.Windows.Forms.ToolStripMenuItem IDM_ConfigSaveAs;
        private System.Windows.Forms.DataGridView task_grid;
        private System.Windows.Forms.StatusStrip task_list_counts;
        private System.Windows.Forms.ToolStripMenuItem IDM_synchronization;
        private System.Windows.Forms.ToolStripMenuItem IDM_Sync_CreateTaskList;
        private System.Windows.Forms.ToolStripMenuItem IDM_Sync_StartSync;
        private System.Windows.Forms.ToolStripStatusLabel sstatus_task;
        private System.Windows.Forms.ToolStripStatusLabel sstatus_upload;
        private System.Windows.Forms.ToolStripStatusLabel sstatus_notupload;
        private System.Windows.Forms.ToolStripStatusLabel sstatus_delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_size;
        private System.Windows.Forms.DataGridViewImageColumn action;
        private System.Windows.Forms.DataGridViewTextBoxColumn remote_server;
        private System.Windows.Forms.DataGridViewTextBoxColumn remote_dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn remote_size;
        private System.ComponentModel.BackgroundWorker bgw;
    }
}

