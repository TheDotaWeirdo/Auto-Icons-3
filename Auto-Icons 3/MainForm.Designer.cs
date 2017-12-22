namespace Auto_Icons_3
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
			this.P_Title = new System.Windows.Forms.Panel();
			this.PB_Icon = new System.Windows.Forms.PictureBox();
			this.P_WindowControls = new System.Windows.Forms.Panel();
			this.B_Close = new System.Windows.Forms.PictureBox();
			this.B_Max = new System.Windows.Forms.PictureBox();
			this.B_Min = new System.Windows.Forms.PictureBox();
			this.L_Title = new System.Windows.Forms.Label();
			this.TLP_4 = new System.Windows.Forms.TableLayoutPanel();
			this.TLP_Options = new System.Windows.Forms.TableLayoutPanel();
			this.L_Options = new System.Windows.Forms.Label();
			this.TLP_CheckBoxes = new System.Windows.Forms.TableLayoutPanel();
			this.myProgressBar1 = new Auto_Icons_3.MyProgressBar();
			this.P_Spacer_4 = new System.Windows.Forms.Panel();
			this.P_Spacer_3 = new System.Windows.Forms.Panel();
			this.P_Spacer_2 = new System.Windows.Forms.Panel();
			this.TLP_2 = new System.Windows.Forms.TableLayoutPanel();
			this.L_FolderPath = new System.Windows.Forms.Label();
			this.TB_FolderPath = new System.Windows.Forms.TextBox();
			this.TLP_1 = new System.Windows.Forms.TableLayoutPanel();
			this.B_IconPath = new Auto_Icons_3.FlatButton();
			this.L_IconPath = new System.Windows.Forms.Label();
			this.TB_IconPath = new System.Windows.Forms.TextBox();
			this.TLP_3 = new System.Windows.Forms.TableLayoutPanel();
			this.L_IconVersion = new System.Windows.Forms.Label();
			this.L_Version = new System.Windows.Forms.Label();
			this.L_IconsDetected = new System.Windows.Forms.Label();
			this.L_Icons = new System.Windows.Forms.Label();
			this.TLP_5 = new System.Windows.Forms.TableLayoutPanel();
			this.B_Change = new Auto_Icons_3.FlatButton();
			this.B_Auto = new Auto_Icons_3.FlatButton();
			this.B_Reset = new Auto_Icons_3.FlatButton();
			this.P_Spacer_1 = new System.Windows.Forms.Panel();
			this.browseDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.TLP_Main.SuspendLayout();
			this.P_Title.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_Icon)).BeginInit();
			this.P_WindowControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.B_Close)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.B_Max)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.B_Min)).BeginInit();
			this.TLP_4.SuspendLayout();
			this.TLP_Options.SuspendLayout();
			this.TLP_CheckBoxes.SuspendLayout();
			this.TLP_2.SuspendLayout();
			this.TLP_1.SuspendLayout();
			this.TLP_3.SuspendLayout();
			this.TLP_5.SuspendLayout();
			this.SuspendLayout();
			// 
			// TLP_Main
			// 
			this.TLP_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.TLP_Main.ColumnCount = 1;
			this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Main.Controls.Add(this.P_Title, 0, 0);
			this.TLP_Main.Controls.Add(this.TLP_4, 0, 1);
			this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_Main.Location = new System.Drawing.Point(2, 2);
			this.TLP_Main.Name = "TLP_Main";
			this.TLP_Main.RowCount = 2;
			this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Main.Size = new System.Drawing.Size(1208, 624);
			this.TLP_Main.TabIndex = 0;
			// 
			// P_Title
			// 
			this.P_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.P_Title.Controls.Add(this.PB_Icon);
			this.P_Title.Controls.Add(this.P_WindowControls);
			this.P_Title.Controls.Add(this.L_Title);
			this.P_Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Title.Location = new System.Drawing.Point(3, 3);
			this.P_Title.Name = "P_Title";
			this.P_Title.Size = new System.Drawing.Size(1202, 44);
			this.P_Title.TabIndex = 0;
			// 
			// PB_Icon
			// 
			this.PB_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PB_Icon.Image = global::Auto_Icons_3.Properties.Resources.Icon;
			this.PB_Icon.Location = new System.Drawing.Point(2, 2);
			this.PB_Icon.Name = "PB_Icon";
			this.PB_Icon.Size = new System.Drawing.Size(28, 28);
			this.PB_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_Icon.TabIndex = 2;
			this.PB_Icon.TabStop = false;
			this.PB_Icon.Click += new System.EventHandler(this.PB_Icon_Click);
			// 
			// P_WindowControls
			// 
			this.P_WindowControls.AutoSize = true;
			this.P_WindowControls.Controls.Add(this.B_Close);
			this.P_WindowControls.Controls.Add(this.B_Max);
			this.P_WindowControls.Controls.Add(this.B_Min);
			this.P_WindowControls.Dock = System.Windows.Forms.DockStyle.Right;
			this.P_WindowControls.Location = new System.Drawing.Point(1120, 0);
			this.P_WindowControls.Name = "P_WindowControls";
			this.P_WindowControls.Size = new System.Drawing.Size(82, 44);
			this.P_WindowControls.TabIndex = 1;
			this.P_WindowControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
			// 
			// B_Close
			// 
			this.B_Close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Close.Image = ((System.Drawing.Image)(resources.GetObject("B_Close.Image")));
			this.B_Close.Location = new System.Drawing.Point(57, 3);
			this.B_Close.Name = "B_Close";
			this.B_Close.Size = new System.Drawing.Size(22, 22);
			this.B_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_Close.TabIndex = 5;
			this.B_Close.TabStop = false;
			this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
			// 
			// B_Max
			// 
			this.B_Max.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Max.Image = ((System.Drawing.Image)(resources.GetObject("B_Max.Image")));
			this.B_Max.Location = new System.Drawing.Point(30, 3);
			this.B_Max.Name = "B_Max";
			this.B_Max.Size = new System.Drawing.Size(22, 22);
			this.B_Max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_Max.TabIndex = 4;
			this.B_Max.TabStop = false;
			this.B_Max.Click += new System.EventHandler(this.B_Max_Click);
			// 
			// B_Min
			// 
			this.B_Min.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Min.Image = ((System.Drawing.Image)(resources.GetObject("B_Min.Image")));
			this.B_Min.Location = new System.Drawing.Point(3, 3);
			this.B_Min.Name = "B_Min";
			this.B_Min.Size = new System.Drawing.Size(22, 22);
			this.B_Min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_Min.TabIndex = 3;
			this.B_Min.TabStop = false;
			this.B_Min.Click += new System.EventHandler(this.B_Min_Click);
			// 
			// L_Title
			// 
			this.L_Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.L_Title.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Title.Location = new System.Drawing.Point(0, 0);
			this.L_Title.Name = "L_Title";
			this.L_Title.Size = new System.Drawing.Size(1202, 44);
			this.L_Title.TabIndex = 0;
			this.L_Title.Text = "Auto-Icons";
			this.L_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.L_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
			// 
			// TLP_4
			// 
			this.TLP_4.ColumnCount = 1;
			this.TLP_4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_4.Controls.Add(this.TLP_Options, 0, 6);
			this.TLP_4.Controls.Add(this.P_Spacer_4, 0, 7);
			this.TLP_4.Controls.Add(this.P_Spacer_3, 0, 5);
			this.TLP_4.Controls.Add(this.P_Spacer_2, 0, 3);
			this.TLP_4.Controls.Add(this.TLP_2, 0, 2);
			this.TLP_4.Controls.Add(this.TLP_1, 0, 0);
			this.TLP_4.Controls.Add(this.TLP_3, 0, 4);
			this.TLP_4.Controls.Add(this.TLP_5, 0, 8);
			this.TLP_4.Controls.Add(this.P_Spacer_1, 0, 1);
			this.TLP_4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_4.Location = new System.Drawing.Point(3, 53);
			this.TLP_4.Name = "TLP_4";
			this.TLP_4.RowCount = 9;
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
			this.TLP_4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TLP_4.Size = new System.Drawing.Size(1202, 568);
			this.TLP_4.TabIndex = 1;
			// 
			// TLP_Options
			// 
			this.TLP_Options.ColumnCount = 2;
			this.TLP_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_Options.Controls.Add(this.L_Options, 0, 0);
			this.TLP_Options.Controls.Add(this.TLP_CheckBoxes, 1, 0);
			this.TLP_Options.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_Options.Location = new System.Drawing.Point(30, 261);
			this.TLP_Options.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_Options.Name = "TLP_Options";
			this.TLP_Options.RowCount = 1;
			this.TLP_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
			this.TLP_Options.Size = new System.Drawing.Size(1142, 188);
			this.TLP_Options.TabIndex = 8;
			// 
			// L_Options
			// 
			this.L_Options.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_Options.AutoSize = true;
			this.L_Options.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Options.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_Options.Location = new System.Drawing.Point(15, 82);
			this.L_Options.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.L_Options.Name = "L_Options";
			this.L_Options.Size = new System.Drawing.Size(86, 23);
			this.L_Options.TabIndex = 0;
			this.L_Options.Text = "Options:";
			// 
			// TLP_CheckBoxes
			// 
			this.TLP_CheckBoxes.ColumnCount = 2;
			this.TLP_CheckBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TLP_CheckBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TLP_CheckBoxes.Controls.Add(this.myProgressBar1, 0, 2);
			this.TLP_CheckBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_CheckBoxes.Location = new System.Drawing.Point(178, 3);
			this.TLP_CheckBoxes.Name = "TLP_CheckBoxes";
			this.TLP_CheckBoxes.RowCount = 4;
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.Size = new System.Drawing.Size(961, 182);
			this.TLP_CheckBoxes.TabIndex = 1;
			// 
			// myProgressBar1
			// 
			this.myProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.myProgressBar1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.myProgressBar1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.myProgressBar1.Font = new System.Drawing.Font("Century Gothic", 14.25F);
			this.myProgressBar1.ForeColor = System.Drawing.Color.White;
			this.myProgressBar1.Location = new System.Drawing.Point(62, 100);
			this.myProgressBar1.MinStep = 0.4D;
			this.myProgressBar1.Name = "myProgressBar1";
			this.myProgressBar1.Percentage = 0D;
			this.myProgressBar1.Scheme = Auto_Icons_3.ColorScheme.Active;
			this.myProgressBar1.Size = new System.Drawing.Size(356, 24);
			this.myProgressBar1.TabIndex = 7;
			// 
			// P_Spacer_4
			// 
			this.P_Spacer_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_4.Location = new System.Drawing.Point(50, 452);
			this.P_Spacer_4.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_4.Name = "P_Spacer_4";
			this.P_Spacer_4.Size = new System.Drawing.Size(1102, 3);
			this.P_Spacer_4.TabIndex = 7;
			// 
			// P_Spacer_3
			// 
			this.P_Spacer_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_3.Location = new System.Drawing.Point(50, 255);
			this.P_Spacer_3.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_3.Name = "P_Spacer_3";
			this.P_Spacer_3.Size = new System.Drawing.Size(1102, 3);
			this.P_Spacer_3.TabIndex = 6;
			// 
			// P_Spacer_2
			// 
			this.P_Spacer_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_2.Location = new System.Drawing.Point(50, 169);
			this.P_Spacer_2.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_2.Name = "P_Spacer_2";
			this.P_Spacer_2.Size = new System.Drawing.Size(1102, 3);
			this.P_Spacer_2.TabIndex = 5;
			// 
			// TLP_2
			// 
			this.TLP_2.ColumnCount = 3;
			this.TLP_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_2.Controls.Add(this.L_FolderPath, 0, 0);
			this.TLP_2.Controls.Add(this.TB_FolderPath, 1, 0);
			this.TLP_2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_2.Location = new System.Drawing.Point(30, 89);
			this.TLP_2.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_2.Name = "TLP_2";
			this.TLP_2.RowCount = 1;
			this.TLP_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_2.Size = new System.Drawing.Size(1142, 77);
			this.TLP_2.TabIndex = 1;
			this.TLP_2.Resize += new System.EventHandler(this.TLP_2_Resize);
			// 
			// L_FolderPath
			// 
			this.L_FolderPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_FolderPath.AutoSize = true;
			this.L_FolderPath.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_FolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_FolderPath.Location = new System.Drawing.Point(15, 27);
			this.L_FolderPath.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.L_FolderPath.Name = "L_FolderPath";
			this.L_FolderPath.Size = new System.Drawing.Size(118, 23);
			this.L_FolderPath.TabIndex = 0;
			this.L_FolderPath.Text = "Folder Path:";
			// 
			// TB_FolderPath
			// 
			this.TB_FolderPath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.TB_FolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.TB_FolderPath.Location = new System.Drawing.Point(323, 25);
			this.TB_FolderPath.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
			this.TB_FolderPath.Name = "TB_FolderPath";
			this.TB_FolderPath.Size = new System.Drawing.Size(495, 27);
			this.TB_FolderPath.TabIndex = 0;
			this.TB_FolderPath.TextChanged += new System.EventHandler(this.TB_FolderPath_TextChanged);
			// 
			// TLP_1
			// 
			this.TLP_1.ColumnCount = 3;
			this.TLP_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_1.Controls.Add(this.B_IconPath, 2, 0);
			this.TLP_1.Controls.Add(this.L_IconPath, 0, 0);
			this.TLP_1.Controls.Add(this.TB_IconPath, 1, 0);
			this.TLP_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_1.Location = new System.Drawing.Point(30, 3);
			this.TLP_1.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_1.Name = "TLP_1";
			this.TLP_1.RowCount = 1;
			this.TLP_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
			this.TLP_1.Size = new System.Drawing.Size(1142, 77);
			this.TLP_1.TabIndex = 0;
			this.TLP_1.Resize += new System.EventHandler(this.TLP_1_Resize);
			// 
			// B_IconPath
			// 
			this.B_IconPath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.B_IconPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_IconPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.B_IconPath.BorderStyle = Auto_Icons_3.BorderStyle.Auto;
			this.B_IconPath.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_IconPath.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.B_IconPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.B_IconPath.HueShade = null;
			this.B_IconPath.Image = global::Auto_Icons_3.Properties.Resources.Icon_Search;
			this.B_IconPath.Location = new System.Drawing.Point(989, 21);
			this.B_IconPath.Name = "B_IconPath";
			this.B_IconPath.Size = new System.Drawing.Size(130, 35);
			this.B_IconPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_IconPath.TabIndex = 101;
			this.B_IconPath.Text = "Browse";
			this.B_IconPath.Click += new System.EventHandler(this.B_IconPath_Click);
			// 
			// L_IconPath
			// 
			this.L_IconPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_IconPath.AutoSize = true;
			this.L_IconPath.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_IconPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_IconPath.Location = new System.Drawing.Point(15, 27);
			this.L_IconPath.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.L_IconPath.Name = "L_IconPath";
			this.L_IconPath.Size = new System.Drawing.Size(109, 23);
			this.L_IconPath.TabIndex = 0;
			this.L_IconPath.Text = "Icons Path:";
			// 
			// TB_IconPath
			// 
			this.TB_IconPath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.TB_IconPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.TB_IconPath.Location = new System.Drawing.Point(323, 25);
			this.TB_IconPath.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
			this.TB_IconPath.Name = "TB_IconPath";
			this.TB_IconPath.Size = new System.Drawing.Size(495, 27);
			this.TB_IconPath.TabIndex = 100;
			// 
			// TLP_3
			// 
			this.TLP_3.ColumnCount = 4;
			this.TLP_3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_3.Controls.Add(this.L_IconVersion, 0, 0);
			this.TLP_3.Controls.Add(this.L_Version, 0, 0);
			this.TLP_3.Controls.Add(this.L_IconsDetected, 0, 0);
			this.TLP_3.Controls.Add(this.L_Icons, 0, 0);
			this.TLP_3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_3.Location = new System.Drawing.Point(30, 175);
			this.TLP_3.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_3.Name = "TLP_3";
			this.TLP_3.RowCount = 1;
			this.TLP_3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_3.Size = new System.Drawing.Size(1142, 77);
			this.TLP_3.TabIndex = 2;
			// 
			// L_IconVersion
			// 
			this.L_IconVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.L_IconVersion.AutoSize = true;
			this.L_IconVersion.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_IconVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_IconVersion.Location = new System.Drawing.Point(825, 27);
			this.L_IconVersion.Margin = new System.Windows.Forms.Padding(3, 0, 15, 0);
			this.L_IconVersion.Name = "L_IconVersion";
			this.L_IconVersion.Size = new System.Drawing.Size(127, 23);
			this.L_IconVersion.TabIndex = 4;
			this.L_IconVersion.Text = "Icon Version:";
			// 
			// L_Version
			// 
			this.L_Version.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_Version.AutoSize = true;
			this.L_Version.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Version.Location = new System.Drawing.Point(982, 27);
			this.L_Version.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.L_Version.Name = "L_Version";
			this.L_Version.Size = new System.Drawing.Size(107, 23);
			this.L_Version.TabIndex = 3;
			this.L_Version.Text = "#SHARP v2";
			// 
			// L_IconsDetected
			// 
			this.L_IconsDetected.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_IconsDetected.AutoSize = true;
			this.L_IconsDetected.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_IconsDetected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_IconsDetected.Location = new System.Drawing.Point(15, 27);
			this.L_IconsDetected.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.L_IconsDetected.Name = "L_IconsDetected";
			this.L_IconsDetected.Size = new System.Drawing.Size(154, 23);
			this.L_IconsDetected.TabIndex = 2;
			this.L_IconsDetected.Text = "Icons Detected:";
			// 
			// L_Icons
			// 
			this.L_Icons.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_Icons.AutoSize = true;
			this.L_Icons.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Icons.Location = new System.Drawing.Point(190, 27);
			this.L_Icons.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.L_Icons.Name = "L_Icons";
			this.L_Icons.Size = new System.Drawing.Size(74, 23);
			this.L_Icons.TabIndex = 1;
			this.L_Icons.Text = "0 Icons";
			// 
			// TLP_5
			// 
			this.TLP_5.ColumnCount = 3;
			this.TLP_5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TLP_5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TLP_5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TLP_5.Controls.Add(this.B_Change, 0, 0);
			this.TLP_5.Controls.Add(this.B_Auto, 0, 0);
			this.TLP_5.Controls.Add(this.B_Reset, 0, 0);
			this.TLP_5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_5.Location = new System.Drawing.Point(30, 458);
			this.TLP_5.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_5.Name = "TLP_5";
			this.TLP_5.RowCount = 1;
			this.TLP_5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_5.Size = new System.Drawing.Size(1142, 107);
			this.TLP_5.TabIndex = 3;
			// 
			// B_Change
			// 
			this.B_Change.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.B_Change.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Change.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.B_Change.BorderStyle = Auto_Icons_3.BorderStyle.Auto;
			this.B_Change.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Change.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.B_Change.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.B_Change.HueShade = null;
			this.B_Change.Image = global::Auto_Icons_3.Properties.Resources.Icon_Paint;
			this.B_Change.Location = new System.Drawing.Point(861, 33);
			this.B_Change.Name = "B_Change";
			this.B_Change.Size = new System.Drawing.Size(180, 40);
			this.B_Change.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_Change.TabIndex = 7;
			this.B_Change.Text = "Change Icons";
			// 
			// B_Auto
			// 
			this.B_Auto.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.B_Auto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Auto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.B_Auto.BorderStyle = Auto_Icons_3.BorderStyle.Auto;
			this.B_Auto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Auto.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.B_Auto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.B_Auto.HueShade = null;
			this.B_Auto.Image = global::Auto_Icons_3.Properties.Resources.Icon_Auto;
			this.B_Auto.Location = new System.Drawing.Point(480, 33);
			this.B_Auto.Name = "B_Auto";
			this.B_Auto.Size = new System.Drawing.Size(180, 40);
			this.B_Auto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_Auto.TabIndex = 6;
			this.B_Auto.Text = "Auto-Change";
			// 
			// B_Reset
			// 
			this.B_Reset.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.B_Reset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.B_Reset.BorderStyle = Auto_Icons_3.BorderStyle.Auto;
			this.B_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Reset.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.B_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.B_Reset.HueShade = null;
			this.B_Reset.Image = global::Auto_Icons_3.Properties.Resources.Icon_Reset;
			this.B_Reset.Location = new System.Drawing.Point(100, 33);
			this.B_Reset.Name = "B_Reset";
			this.B_Reset.Size = new System.Drawing.Size(180, 40);
			this.B_Reset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.B_Reset.TabIndex = 5;
			this.B_Reset.Text = "Reset Icons";
			// 
			// P_Spacer_1
			// 
			this.P_Spacer_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_1.Location = new System.Drawing.Point(50, 83);
			this.P_Spacer_1.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_1.Name = "P_Spacer_1";
			this.P_Spacer_1.Size = new System.Drawing.Size(1102, 3);
			this.P_Spacer_1.TabIndex = 4;
			// 
			// browseDialog
			// 
			this.browseDialog.Description = "Select Folder";
			this.browseDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.browseDialog.ShowNewFolderButton = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(192)))), ((int)(((byte)(232)))));
			this.ClientSize = new System.Drawing.Size(1212, 628);
			this.Controls.Add(this.TLP_Main);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "Auto-Icons";
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.TLP_Main.ResumeLayout(false);
			this.P_Title.ResumeLayout(false);
			this.P_Title.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_Icon)).EndInit();
			this.P_WindowControls.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.B_Close)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.B_Max)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.B_Min)).EndInit();
			this.TLP_4.ResumeLayout(false);
			this.TLP_Options.ResumeLayout(false);
			this.TLP_Options.PerformLayout();
			this.TLP_CheckBoxes.ResumeLayout(false);
			this.TLP_2.ResumeLayout(false);
			this.TLP_2.PerformLayout();
			this.TLP_1.ResumeLayout(false);
			this.TLP_1.PerformLayout();
			this.TLP_3.ResumeLayout(false);
			this.TLP_3.PerformLayout();
			this.TLP_5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel TLP_Main;
		private System.Windows.Forms.Panel P_Title;
		private System.Windows.Forms.Panel P_WindowControls;
		private System.Windows.Forms.Label L_Title;
		private System.Windows.Forms.TableLayoutPanel TLP_4;
		private System.Windows.Forms.TableLayoutPanel TLP_Options;
		private System.Windows.Forms.Label L_Options;
		private System.Windows.Forms.TableLayoutPanel TLP_CheckBoxes;
		private MyCheckBox CB_3;
		private MyCheckBox CB_2;
		private MyCheckBox CB_1;
		private MyCheckBox CB_4;
		private System.Windows.Forms.Panel P_Spacer_4;
		private System.Windows.Forms.Panel P_Spacer_3;
		private System.Windows.Forms.Panel P_Spacer_2;
		private System.Windows.Forms.TableLayoutPanel TLP_2;
		private System.Windows.Forms.Label L_FolderPath;
		private System.Windows.Forms.TextBox TB_FolderPath;
		private System.Windows.Forms.TableLayoutPanel TLP_1;
		private System.Windows.Forms.Label L_IconPath;
		private System.Windows.Forms.TextBox TB_IconPath;
		private System.Windows.Forms.TableLayoutPanel TLP_3;
		private System.Windows.Forms.Label L_IconVersion;
		private System.Windows.Forms.Label L_Version;
		private System.Windows.Forms.Label L_IconsDetected;
		private System.Windows.Forms.Label L_Icons;
		private System.Windows.Forms.TableLayoutPanel TLP_5;
		private System.Windows.Forms.Panel P_Spacer_1;
		private FlatButton B_FolderPath;
		private FlatButton B_IconPath;
		private FlatButton B_Reset;
		private FlatButton B_Auto;
		private FlatButton B_Change;
		private System.Windows.Forms.PictureBox PB_Icon;
		private System.Windows.Forms.PictureBox B_Close;
		private System.Windows.Forms.PictureBox B_Max;
		private System.Windows.Forms.PictureBox B_Min;
		private System.Windows.Forms.FolderBrowserDialog browseDialog;
		private MyProgressBar myProgressBar1;
	}
}

