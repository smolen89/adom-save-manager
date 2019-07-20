namespace Adom_Save_Manager
{
	partial class MainWindow
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Wymagana metoda obsługi projektanta — nie należy modyfikować 
		/// zawartość tej metody z edytorem kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtLog = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.check_ShowDateSlot = new System.Windows.Forms.CheckBox();
			this.check_ShowLog = new System.Windows.Forms.CheckBox();
			this.btn_CreateProfile = new System.Windows.Forms.Button();
			this.btn_AdomSaveFileRefresh = new System.Windows.Forms.Button();
			this.list_AdomSaveFiles = new System.Windows.Forms.ListBox();
			this.box_Profile = new System.Windows.Forms.GroupBox();
			this.btn_RemoveSlot = new System.Windows.Forms.Button();
			this.check_AutoRestoreProfile = new System.Windows.Forms.CheckBox();
			this.btn_BackupDefault = new System.Windows.Forms.Button();
			this.btn_RestoreDefault = new System.Windows.Forms.Button();
			this.check_AutoBackupProfile = new System.Windows.Forms.CheckBox();
			this.btn_BackupNew = new System.Windows.Forms.Button();
			this.list_Slots = new System.Windows.Forms.ListBox();
			this.btn_BackupProfile = new System.Windows.Forms.Button();
			this.btn_RestoreProfile = new System.Windows.Forms.Button();
			this.check_AutoBackupDefault = new System.Windows.Forms.CheckBox();
			this.check_AutoRestoreDefault = new System.Windows.Forms.CheckBox();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.box_Profile.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtLog
			// 
			this.txtLog.BackColor = System.Drawing.Color.Black;
			this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtLog.ForeColor = System.Drawing.Color.Gray;
			this.txtLog.Location = new System.Drawing.Point(0, 261);
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.txtLog.Size = new System.Drawing.Size(714, 159);
			this.txtLog.TabIndex = 1;
			this.txtLog.Text = "------------------------------------------------------------\nAncient Domains Of M" +
    "ystery - Save Manager\n----------------------------------------------------------" +
    "--";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.check_ShowDateSlot);
			this.groupBox1.Controls.Add(this.check_ShowLog);
			this.groupBox1.Controls.Add(this.btn_CreateProfile);
			this.groupBox1.Controls.Add(this.btn_AdomSaveFileRefresh);
			this.groupBox1.Controls.Add(this.list_AdomSaveFiles);
			this.groupBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(205, 239);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Adom Save Files";
			// 
			// check_ShowDateSlot
			// 
			this.check_ShowDateSlot.AutoSize = true;
			this.check_ShowDateSlot.Checked = true;
			this.check_ShowDateSlot.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_ShowDateSlot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.check_ShowDateSlot.ForeColor = System.Drawing.SystemColors.ControlText;
			this.check_ShowDateSlot.Location = new System.Drawing.Point(9, 214);
			this.check_ShowDateSlot.Name = "check_ShowDateSlot";
			this.check_ShowDateSlot.Size = new System.Drawing.Size(158, 17);
			this.check_ShowDateSlot.TabIndex = 38;
			this.check_ShowDateSlot.Text = "Show Time in slot list";
			this.check_ShowDateSlot.UseVisualStyleBackColor = true;
			this.check_ShowDateSlot.CheckedChanged += new System.EventHandler(this.check_ShowDateSlot_CheckedChanged);
			// 
			// check_ShowLog
			// 
			this.check_ShowLog.AutoSize = true;
			this.check_ShowLog.Checked = true;
			this.check_ShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_ShowLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.check_ShowLog.ForeColor = System.Drawing.SystemColors.ControlText;
			this.check_ShowLog.Location = new System.Drawing.Point(9, 191);
			this.check_ShowLog.Name = "check_ShowLog";
			this.check_ShowLog.Size = new System.Drawing.Size(122, 17);
			this.check_ShowLog.TabIndex = 37;
			this.check_ShowLog.Text = "Show Console Log";
			this.check_ShowLog.UseVisualStyleBackColor = true;
			this.check_ShowLog.CheckedChanged += new System.EventHandler(this.check_ShowLog_CheckStateChanged);
			// 
			// btn_CreateProfile
			// 
			this.btn_CreateProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_CreateProfile.FlatAppearance.BorderSize = 2;
			this.btn_CreateProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_CreateProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_CreateProfile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_CreateProfile.ForeColor = System.Drawing.Color.DarkGreen;
			this.btn_CreateProfile.Location = new System.Drawing.Point(83, 16);
			this.btn_CreateProfile.Name = "btn_CreateProfile";
			this.btn_CreateProfile.Size = new System.Drawing.Size(112, 23);
			this.btn_CreateProfile.TabIndex = 6;
			this.btn_CreateProfile.Text = "Create Profile";
			this.btn_CreateProfile.UseVisualStyleBackColor = true;
			this.btn_CreateProfile.Click += new System.EventHandler(this.btn_CreateProfile_Click);
			// 
			// btn_AdomSaveFileRefresh
			// 
			this.btn_AdomSaveFileRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_AdomSaveFileRefresh.FlatAppearance.BorderSize = 2;
			this.btn_AdomSaveFileRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_AdomSaveFileRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_AdomSaveFileRefresh.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_AdomSaveFileRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_AdomSaveFileRefresh.Location = new System.Drawing.Point(9, 16);
			this.btn_AdomSaveFileRefresh.Name = "btn_AdomSaveFileRefresh";
			this.btn_AdomSaveFileRefresh.Size = new System.Drawing.Size(68, 23);
			this.btn_AdomSaveFileRefresh.TabIndex = 5;
			this.btn_AdomSaveFileRefresh.Text = "Refresh";
			this.btn_AdomSaveFileRefresh.UseVisualStyleBackColor = true;
			this.btn_AdomSaveFileRefresh.Click += new System.EventHandler(this.btn_AdomSaveFileRefresh_Click);
			// 
			// list_AdomSaveFiles
			// 
			this.list_AdomSaveFiles.BackColor = System.Drawing.Color.Gainsboro;
			this.list_AdomSaveFiles.FormattingEnabled = true;
			this.list_AdomSaveFiles.Location = new System.Drawing.Point(9, 45);
			this.list_AdomSaveFiles.Name = "list_AdomSaveFiles";
			this.list_AdomSaveFiles.Size = new System.Drawing.Size(186, 134);
			this.list_AdomSaveFiles.Sorted = true;
			this.list_AdomSaveFiles.TabIndex = 0;
			this.list_AdomSaveFiles.SelectedValueChanged += new System.EventHandler(this.list_AdomSaveFiles_SelectedValueChanged);
			// 
			// box_Profile
			// 
			this.box_Profile.Controls.Add(this.btn_RemoveSlot);
			this.box_Profile.Controls.Add(this.check_AutoRestoreProfile);
			this.box_Profile.Controls.Add(this.btn_BackupDefault);
			this.box_Profile.Controls.Add(this.btn_RestoreDefault);
			this.box_Profile.Controls.Add(this.check_AutoBackupProfile);
			this.box_Profile.Controls.Add(this.btn_BackupNew);
			this.box_Profile.Controls.Add(this.list_Slots);
			this.box_Profile.Controls.Add(this.btn_BackupProfile);
			this.box_Profile.Controls.Add(this.btn_RestoreProfile);
			this.box_Profile.Controls.Add(this.check_AutoBackupDefault);
			this.box_Profile.Controls.Add(this.check_AutoRestoreDefault);
			this.box_Profile.Enabled = false;
			this.box_Profile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.box_Profile.ForeColor = System.Drawing.SystemColors.GrayText;
			this.box_Profile.Location = new System.Drawing.Point(223, 12);
			this.box_Profile.Name = "box_Profile";
			this.box_Profile.Size = new System.Drawing.Size(479, 239);
			this.box_Profile.TabIndex = 3;
			this.box_Profile.TabStop = false;
			this.box_Profile.Text = "Profiles";
			// 
			// btn_RemoveSlot
			// 
			this.btn_RemoveSlot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_RemoveSlot.FlatAppearance.BorderSize = 2;
			this.btn_RemoveSlot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_RemoveSlot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_RemoveSlot.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_RemoveSlot.Location = new System.Drawing.Point(6, 196);
			this.btn_RemoveSlot.Name = "btn_RemoveSlot";
			this.btn_RemoveSlot.Size = new System.Drawing.Size(105, 30);
			this.btn_RemoveSlot.TabIndex = 35;
			this.btn_RemoveSlot.Text = "    Remove <<<<";
			this.btn_RemoveSlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_RemoveSlot.UseVisualStyleBackColor = true;
			this.btn_RemoveSlot.Click += new System.EventHandler(this.btn_RemoveSlot_Click);
			// 
			// check_AutoRestoreProfile
			// 
			this.check_AutoRestoreProfile.AutoSize = true;
			this.check_AutoRestoreProfile.ForeColor = System.Drawing.SystemColors.GrayText;
			this.check_AutoRestoreProfile.Location = new System.Drawing.Point(117, 168);
			this.check_AutoRestoreProfile.Name = "check_AutoRestoreProfile";
			this.check_AutoRestoreProfile.Size = new System.Drawing.Size(50, 17);
			this.check_AutoRestoreProfile.TabIndex = 28;
			this.check_AutoRestoreProfile.Text = "Auto";
			this.check_AutoRestoreProfile.UseVisualStyleBackColor = true;
			this.check_AutoRestoreProfile.CheckedChanged += new System.EventHandler(this.check_AutoRestoreProfile_CheckedChanged);
			// 
			// btn_BackupDefault
			// 
			this.btn_BackupDefault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_BackupDefault.FlatAppearance.BorderSize = 2;
			this.btn_BackupDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_BackupDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_BackupDefault.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_BackupDefault.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_BackupDefault.Location = new System.Drawing.Point(6, 16);
			this.btn_BackupDefault.Name = "btn_BackupDefault";
			this.btn_BackupDefault.Size = new System.Drawing.Size(105, 30);
			this.btn_BackupDefault.TabIndex = 30;
			this.btn_BackupDefault.Text = ">>> Default >>>";
			this.btn_BackupDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_BackupDefault.UseVisualStyleBackColor = true;
			this.btn_BackupDefault.Click += new System.EventHandler(this.btn_BackupDefault_Click);
			// 
			// btn_RestoreDefault
			// 
			this.btn_RestoreDefault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_RestoreDefault.FlatAppearance.BorderSize = 2;
			this.btn_RestoreDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_RestoreDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_RestoreDefault.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_RestoreDefault.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_RestoreDefault.Location = new System.Drawing.Point(6, 52);
			this.btn_RestoreDefault.Name = "btn_RestoreDefault";
			this.btn_RestoreDefault.Size = new System.Drawing.Size(105, 30);
			this.btn_RestoreDefault.TabIndex = 29;
			this.btn_RestoreDefault.Text = "<<< Default <<<";
			this.btn_RestoreDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_RestoreDefault.UseVisualStyleBackColor = true;
			this.btn_RestoreDefault.Click += new System.EventHandler(this.btn_RestoreDefault_Click);
			// 
			// check_AutoBackupProfile
			// 
			this.check_AutoBackupProfile.AutoSize = true;
			this.check_AutoBackupProfile.ForeColor = System.Drawing.SystemColors.GrayText;
			this.check_AutoBackupProfile.Location = new System.Drawing.Point(117, 132);
			this.check_AutoBackupProfile.Name = "check_AutoBackupProfile";
			this.check_AutoBackupProfile.Size = new System.Drawing.Size(50, 17);
			this.check_AutoBackupProfile.TabIndex = 27;
			this.check_AutoBackupProfile.Text = "Auto";
			this.check_AutoBackupProfile.UseVisualStyleBackColor = true;
			// 
			// btn_BackupNew
			// 
			this.btn_BackupNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_BackupNew.FlatAppearance.BorderSize = 2;
			this.btn_BackupNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_BackupNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_BackupNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_BackupNew.Location = new System.Drawing.Point(6, 88);
			this.btn_BackupNew.Name = "btn_BackupNew";
			this.btn_BackupNew.Size = new System.Drawing.Size(105, 30);
			this.btn_BackupNew.TabIndex = 24;
			this.btn_BackupNew.Text = ">>>>> New >>>>>";
			this.btn_BackupNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_BackupNew.UseVisualStyleBackColor = true;
			this.btn_BackupNew.Click += new System.EventHandler(this.btn_BackupNew_Click);
			// 
			// list_Slots
			// 
			this.list_Slots.BackColor = System.Drawing.Color.Gainsboro;
			this.list_Slots.Location = new System.Drawing.Point(173, 19);
			this.list_Slots.Name = "list_Slots";
			this.list_Slots.Size = new System.Drawing.Size(300, 212);
			this.list_Slots.TabIndex = 23;
			this.list_Slots.SelectedValueChanged += new System.EventHandler(this.list_Slots_SelectedValueChanged);
			this.list_Slots.DoubleClick += new System.EventHandler(this.list_Slots_DoubleClick);
			// 
			// btn_BackupProfile
			// 
			this.btn_BackupProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_BackupProfile.FlatAppearance.BorderSize = 2;
			this.btn_BackupProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_BackupProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_BackupProfile.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_BackupProfile.Location = new System.Drawing.Point(6, 124);
			this.btn_BackupProfile.Name = "btn_BackupProfile";
			this.btn_BackupProfile.Size = new System.Drawing.Size(105, 30);
			this.btn_BackupProfile.TabIndex = 21;
			this.btn_BackupProfile.Text = ">>>>>>>>>>>>>>>";
			this.btn_BackupProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_BackupProfile.UseVisualStyleBackColor = true;
			this.btn_BackupProfile.Click += new System.EventHandler(this.btn_BackupProfile_Click);
			// 
			// btn_RestoreProfile
			// 
			this.btn_RestoreProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_RestoreProfile.FlatAppearance.BorderSize = 2;
			this.btn_RestoreProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.btn_RestoreProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.btn_RestoreProfile.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_RestoreProfile.Location = new System.Drawing.Point(6, 160);
			this.btn_RestoreProfile.Name = "btn_RestoreProfile";
			this.btn_RestoreProfile.Size = new System.Drawing.Size(105, 30);
			this.btn_RestoreProfile.TabIndex = 22;
			this.btn_RestoreProfile.Text = "<<<<<<<<<<<<<<<";
			this.btn_RestoreProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_RestoreProfile.UseVisualStyleBackColor = true;
			this.btn_RestoreProfile.Click += new System.EventHandler(this.btn_RestoreProfile_Click);
			// 
			// check_AutoBackupDefault
			// 
			this.check_AutoBackupDefault.AutoSize = true;
			this.check_AutoBackupDefault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.check_AutoBackupDefault.ForeColor = System.Drawing.SystemColors.GrayText;
			this.check_AutoBackupDefault.Location = new System.Drawing.Point(117, 24);
			this.check_AutoBackupDefault.Name = "check_AutoBackupDefault";
			this.check_AutoBackupDefault.Size = new System.Drawing.Size(50, 17);
			this.check_AutoBackupDefault.TabIndex = 31;
			this.check_AutoBackupDefault.Text = "Auto";
			this.check_AutoBackupDefault.UseVisualStyleBackColor = true;
			// 
			// check_AutoRestoreDefault
			// 
			this.check_AutoRestoreDefault.AutoSize = true;
			this.check_AutoRestoreDefault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.check_AutoRestoreDefault.ForeColor = System.Drawing.SystemColors.GrayText;
			this.check_AutoRestoreDefault.Location = new System.Drawing.Point(117, 60);
			this.check_AutoRestoreDefault.Name = "check_AutoRestoreDefault";
			this.check_AutoRestoreDefault.Size = new System.Drawing.Size(50, 17);
			this.check_AutoRestoreDefault.TabIndex = 32;
			this.check_AutoRestoreDefault.Text = "Auto";
			this.check_AutoRestoreDefault.UseVisualStyleBackColor = true;
			this.check_AutoRestoreDefault.CheckedChanged += new System.EventHandler(this.check_AutoRestoreDefault_CheckedChanged);
			// 
			// Timer
			// 
			this.Timer.Interval = 1000;
			this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 420);
			this.Controls.Add(this.box_Profile);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtLog);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Ancient Domains Of Mystery - Save Manager";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.box_Profile.ResumeLayout(false);
			this.box_Profile.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.RichTextBox txtLog;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox list_AdomSaveFiles;
		private System.Windows.Forms.Button btn_AdomSaveFileRefresh;
		private System.Windows.Forms.GroupBox box_Profile;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.Button btn_CreateProfile;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btn_BackupProfile;
		private System.Windows.Forms.Button btn_RestoreProfile;
		private System.Windows.Forms.Button btn_BackupNew;
		private System.Windows.Forms.ListBox list_Slots;
		private System.Windows.Forms.CheckBox check_AutoRestoreProfile;
		private System.Windows.Forms.Button btn_BackupDefault;
		private System.Windows.Forms.Button btn_RestoreDefault;
		private System.Windows.Forms.CheckBox check_AutoBackupProfile;
		private System.Windows.Forms.CheckBox check_AutoBackupDefault;
		private System.Windows.Forms.CheckBox check_AutoRestoreDefault;
		private System.Windows.Forms.Button btn_RemoveSlot;
		private System.Windows.Forms.CheckBox check_ShowDateSlot;
		private System.Windows.Forms.CheckBox check_ShowLog;
	}
}

