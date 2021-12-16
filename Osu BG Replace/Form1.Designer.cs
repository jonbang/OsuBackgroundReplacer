namespace Osu_BG_Replace
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbimgPath = new System.Windows.Forms.TextBox();
            this.tbOsuFolder = new System.Windows.Forms.TextBox();
            this.BackupFolder = new System.Windows.Forms.Label();
            this.osuPath = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Backup = new System.Windows.Forms.CheckBox();
            this.CustomBG = new System.Windows.Forms.CheckBox();
            this.tbBackup = new System.Windows.Forms.TextBox();
            this.imgPath = new System.Windows.Forms.Label();
            this.CacheClear = new System.Windows.Forms.Button();
            this.BR = new System.Windows.Forms.Button();
            this.Persistence = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbimgPath
            // 
            this.tbimgPath.Location = new System.Drawing.Point(93, 38);
            this.tbimgPath.Name = "tbimgPath";
            this.tbimgPath.Size = new System.Drawing.Size(100, 23);
            this.tbimgPath.TabIndex = 3;
            // 
            // tbOsuFolder
            // 
            this.tbOsuFolder.Location = new System.Drawing.Point(93, 7);
            this.tbOsuFolder.Name = "tbOsuFolder";
            this.tbOsuFolder.Size = new System.Drawing.Size(100, 23);
            this.tbOsuFolder.TabIndex = 2;
            this.tbOsuFolder.TextChanged += new System.EventHandler(this.tbOsuFolder_TextChanged);
            // 
            // BackupFolder
            // 
            this.BackupFolder.AutoSize = true;
            this.BackupFolder.Location = new System.Drawing.Point(5, 74);
            this.BackupFolder.Name = "BackupFolder";
            this.BackupFolder.Size = new System.Drawing.Size(82, 15);
            this.BackupFolder.TabIndex = 1;
            this.BackupFolder.Text = "Backup Folder";
            this.BackupFolder.Click += new System.EventHandler(this.label2_Click);
            // 
            // osuPath
            // 
            this.osuPath.AutoSize = true;
            this.osuPath.Location = new System.Drawing.Point(13, 10);
            this.osuPath.Name = "osuPath";
            this.osuPath.Size = new System.Drawing.Size(67, 15);
            this.osuPath.TabIndex = 0;
            this.osuPath.Text = "Osu! Folder";
            this.osuPath.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(402, 70);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(99, 23);
            this.btnReplace.TabIndex = 5;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // Backup
            // 
            this.Backup.AutoSize = true;
            this.Backup.Location = new System.Drawing.Point(237, 41);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(102, 19);
            this.Backup.TabIndex = 6;
            this.Backup.Text = "Make backup?";
            this.Backup.UseVisualStyleBackColor = true;
            this.Backup.CheckedChanged += new System.EventHandler(this.Backup_CheckedChanged);
            // 
            // CustomBG
            // 
            this.CustomBG.AutoSize = true;
            this.CustomBG.Location = new System.Drawing.Point(237, 10);
            this.CustomBG.Name = "CustomBG";
            this.CustomBG.Size = new System.Drawing.Size(91, 19);
            this.CustomBG.TabIndex = 7;
            this.CustomBG.Text = "Custom BG?";
            this.CustomBG.UseVisualStyleBackColor = true;
            this.CustomBG.CheckedChanged += new System.EventHandler(this.CustomBG_CheckedChanged);
            // 
            // tbBackup
            // 
            this.tbBackup.Location = new System.Drawing.Point(93, 70);
            this.tbBackup.Name = "tbBackup";
            this.tbBackup.Size = new System.Drawing.Size(100, 23);
            this.tbBackup.TabIndex = 9;
            this.tbBackup.TextChanged += new System.EventHandler(this.tbBackup_TextChanged);
            // 
            // imgPath
            // 
            this.imgPath.AutoSize = true;
            this.imgPath.Location = new System.Drawing.Point(11, 41);
            this.imgPath.Name = "imgPath";
            this.imgPath.Size = new System.Drawing.Size(67, 15);
            this.imgPath.TabIndex = 8;
            this.imgPath.Text = "Image Path";
            // 
            // CacheClear
            // 
            this.CacheClear.Location = new System.Drawing.Point(402, 7);
            this.CacheClear.Name = "CacheClear";
            this.CacheClear.Size = new System.Drawing.Size(99, 23);
            this.CacheClear.TabIndex = 12;
            this.CacheClear.Text = "Clear Cache";
            this.CacheClear.UseVisualStyleBackColor = true;
            this.CacheClear.Click += new System.EventHandler(this.CacheClear_Click);
            // 
            // BR
            // 
            this.BR.Location = new System.Drawing.Point(402, 38);
            this.BR.Name = "BR";
            this.BR.Size = new System.Drawing.Size(99, 23);
            this.BR.TabIndex = 13;
            this.BR.Text = "Restore Backup";
            this.BR.UseVisualStyleBackColor = true;
            this.BR.Click += new System.EventHandler(this.BR_Click);
            // 
            // Persistence
            // 
            this.Persistence.AutoSize = true;
            this.Persistence.Checked = true;
            this.Persistence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Persistence.Location = new System.Drawing.Point(237, 72);
            this.Persistence.Name = "Persistence";
            this.Persistence.Size = new System.Drawing.Size(153, 19);
            this.Persistence.TabIndex = 14;
            this.Persistence.Text = "Persistent Notifications?";
            this.Persistence.UseVisualStyleBackColor = true;
            this.Persistence.CheckedChanged += new System.EventHandler(this.Persistence_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 101);
            this.Controls.Add(this.Persistence);
            this.Controls.Add(this.BR);
            this.Controls.Add(this.CacheClear);
            this.Controls.Add(this.tbBackup);
            this.Controls.Add(this.imgPath);
            this.Controls.Add(this.CustomBG);
            this.Controls.Add(this.Backup);
            this.Controls.Add(this.tbimgPath);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.BackupFolder);
            this.Controls.Add(this.tbOsuFolder);
            this.Controls.Add(this.osuPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Osu! Background Replacer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label BackupFolder;
        private Label osuPath;
        private TextBox tbOsuFolder;
        private TextBox tbimgPath;
        private Button btnReplace;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckBox Backup;
        private CheckBox CustomBG;
        private TextBox tbBackup;
        private Label imgPath;
        private Button CC;
        private Button CacheClear;
        private Button BR;
        private CheckBox Persistence;
    }
}