namespace FTPsync
{
    partial class CopyFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyFileForm));
            this.pb_bg = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.b_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.l_uploaded = new System.Windows.Forms.Label();
            this.l_dest = new System.Windows.Forms.Label();
            this.l_source = new System.Windows.Forms.Label();
            this.l_filename = new System.Windows.Forms.Label();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pb_bg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_bg
            // 
            this.pb_bg.BackColor = System.Drawing.Color.Transparent;
            this.pb_bg.Image = global::FTPsync.Properties.Resources.copyFileBG;
            this.pb_bg.Location = new System.Drawing.Point(0, 0);
            this.pb_bg.Name = "pb_bg";
            this.pb_bg.Size = new System.Drawing.Size(401, 41);
            this.pb_bg.TabIndex = 2;
            this.pb_bg.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.b_cancel);
            this.panel1.Location = new System.Drawing.Point(0, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 40);
            this.panel1.TabIndex = 4;
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(273, 8);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(101, 26);
            this.b_cancel.TabIndex = 0;
            this.b_cancel.Text = "Отменить";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Откуда:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Куда:";
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(21, 132);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(353, 19);
            this.progress_bar.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Загружено:";
            // 
            // l_uploaded
            // 
            this.l_uploaded.AutoSize = true;
            this.l_uploaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_uploaded.Location = new System.Drawing.Point(92, 101);
            this.l_uploaded.Name = "l_uploaded";
            this.l_uploaded.Size = new System.Drawing.Size(86, 13);
            this.l_uploaded.TabIndex = 9;
            this.l_uploaded.Text = "1,2MB из 1.4GB";
            // 
            // l_dest
            // 
            this.l_dest.AutoSize = true;
            this.l_dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_dest.Location = new System.Drawing.Point(92, 75);
            this.l_dest.Name = "l_dest";
            this.l_dest.Size = new System.Drawing.Size(101, 13);
            this.l_dest.TabIndex = 10;
            this.l_dest.Text = "(s3) /etc/files/clips/";
            // 
            // l_source
            // 
            this.l_source.AutoSize = true;
            this.l_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_source.Location = new System.Drawing.Point(92, 50);
            this.l_source.Name = "l_source";
            this.l_source.Size = new System.Drawing.Size(101, 13);
            this.l_source.TabIndex = 11;
            this.l_source.Text = "(s3) /etc/files/clips/";
            // 
            // l_filename
            // 
            this.l_filename.BackColor = System.Drawing.Color.Transparent;
            this.l_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_filename.ForeColor = System.Drawing.SystemColors.Window;
            this.l_filename.Location = new System.Drawing.Point(16, 11);
            this.l_filename.Name = "l_filename";
            this.l_filename.Size = new System.Drawing.Size(312, 19);
            this.l_filename.TabIndex = 12;
            this.l_filename.Text = "8_august_vesna2014.avi";
            // 
            // bgw1
            // 
            this.bgw1.WorkerSupportsCancellation = true;
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            this.bgw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // CopyFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(400, 206);
            this.Controls.Add(this.l_filename);
            this.Controls.Add(this.l_source);
            this.Controls.Add(this.l_dest);
            this.Controls.Add(this.l_uploaded);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyFileForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Подготовка к отправке файла";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CopyFileForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CopyFileForm_FormClosed);
            this.Load += new System.EventHandler(this.CopyFileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_bg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_bg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_uploaded;
        private System.Windows.Forms.Label l_dest;
        private System.Windows.Forms.Label l_source;
        private System.Windows.Forms.Label l_filename;
        private System.ComponentModel.BackgroundWorker bgw1;
    }
}