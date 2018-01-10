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
			this.P_WindowControls = new System.Windows.Forms.Panel();
			this.L_Title = new System.Windows.Forms.Label();
			this.TLP_4 = new System.Windows.Forms.TableLayoutPanel();
			this.TLP_Options = new System.Windows.Forms.TableLayoutPanel();
			this.L_Options = new System.Windows.Forms.Label();
			this.TLP_CheckBoxes = new System.Windows.Forms.TableLayoutPanel();
			this.P_Spacer_4 = new System.Windows.Forms.Panel();
			this.P_Spacer_3 = new System.Windows.Forms.Panel();
			this.P_Spacer_2 = new System.Windows.Forms.Panel();
			this.TLP_2 = new System.Windows.Forms.TableLayoutPanel();
			this.L_FolderPath = new System.Windows.Forms.Label();
			this.TB_FolderPath = new System.Windows.Forms.TextBox();
			this.TLP_1 = new System.Windows.Forms.TableLayoutPanel();
			this.L_IconPath = new System.Windows.Forms.Label();
			this.TB_IconPath = new System.Windows.Forms.TextBox();
			this.TLP_3 = new System.Windows.Forms.TableLayoutPanel();
			this.L_IconVersion = new System.Windows.Forms.Label();
			this.L_Version = new System.Windows.Forms.Label();
			this.L_IconsDetected = new System.Windows.Forms.Label();
			this.L_Icons = new System.Windows.Forms.Label();
			this.TLP_5 = new System.Windows.Forms.TableLayoutPanel();
			this.P_Spacer_1 = new System.Windows.Forms.Panel();
			this.browseDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.L_AppVersion = new System.Windows.Forms.Label();
			this.TLP_Main.SuspendLayout();
			this.P_Title.SuspendLayout();
			this.TLP_4.SuspendLayout();
			this.TLP_Options.SuspendLayout();
			this.TLP_2.SuspendLayout();
			this.TLP_1.SuspendLayout();
			this.TLP_3.SuspendLayout();
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
			this.TLP_Main.Size = new System.Drawing.Size(946, 546);
			this.TLP_Main.TabIndex = 0;
			// 
			// P_Title
			// 
			this.P_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.P_Title.Controls.Add(this.P_WindowControls);
			this.P_Title.Controls.Add(this.L_Title);
			this.P_Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Title.Location = new System.Drawing.Point(0, 0);
			this.P_Title.Margin = new System.Windows.Forms.Padding(0);
			this.P_Title.Name = "P_Title";
			this.P_Title.Size = new System.Drawing.Size(946, 50);
			this.P_Title.TabIndex = 0;
			// 
			// P_WindowControls
			// 
			this.P_WindowControls.AutoSize = true;
			this.P_WindowControls.Dock = System.Windows.Forms.DockStyle.Right;
			this.P_WindowControls.Location = new System.Drawing.Point(946, 0);
			this.P_WindowControls.Name = "P_WindowControls";
			this.P_WindowControls.Size = new System.Drawing.Size(0, 50);
			this.P_WindowControls.TabIndex = 1;
			this.P_WindowControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
			// 
			// L_Title
			// 
			this.L_Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.L_Title.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Title.Location = new System.Drawing.Point(0, 0);
			this.L_Title.Name = "L_Title";
			this.L_Title.Size = new System.Drawing.Size(946, 50);
			this.L_Title.TabIndex = 0;
			this.L_Title.Text = "Auto - Icons";
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
			this.TLP_4.Size = new System.Drawing.Size(940, 490);
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
			this.TLP_Options.Location = new System.Drawing.Point(30, 225);
			this.TLP_Options.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_Options.Name = "TLP_Options";
			this.TLP_Options.RowCount = 1;
			this.TLP_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
			this.TLP_Options.Size = new System.Drawing.Size(880, 161);
			this.TLP_Options.TabIndex = 8;
			// 
			// L_Options
			// 
			this.L_Options.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_Options.AutoSize = true;
			this.L_Options.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Options.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_Options.Location = new System.Drawing.Point(15, 69);
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
			this.TLP_CheckBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_CheckBoxes.Location = new System.Drawing.Point(178, 3);
			this.TLP_CheckBoxes.Name = "TLP_CheckBoxes";
			this.TLP_CheckBoxes.RowCount = 3;
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.TLP_CheckBoxes.Size = new System.Drawing.Size(699, 155);
			this.TLP_CheckBoxes.TabIndex = 1;
			this.TLP_CheckBoxes.Resize += new System.EventHandler(this.TLP_CheckBoxes_Resize);
			// 
			// P_Spacer_4
			// 
			this.P_Spacer_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_4.Location = new System.Drawing.Point(50, 389);
			this.P_Spacer_4.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_4.Name = "P_Spacer_4";
			this.P_Spacer_4.Size = new System.Drawing.Size(840, 3);
			this.P_Spacer_4.TabIndex = 7;
			// 
			// P_Spacer_3
			// 
			this.P_Spacer_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_3.Location = new System.Drawing.Point(50, 219);
			this.P_Spacer_3.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_3.Name = "P_Spacer_3";
			this.P_Spacer_3.Size = new System.Drawing.Size(840, 3);
			this.P_Spacer_3.TabIndex = 6;
			// 
			// P_Spacer_2
			// 
			this.P_Spacer_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_2.Location = new System.Drawing.Point(50, 145);
			this.P_Spacer_2.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_2.Name = "P_Spacer_2";
			this.P_Spacer_2.Size = new System.Drawing.Size(840, 3);
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
			this.TLP_2.Location = new System.Drawing.Point(30, 77);
			this.TLP_2.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_2.Name = "TLP_2";
			this.TLP_2.RowCount = 1;
			this.TLP_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_2.Size = new System.Drawing.Size(880, 65);
			this.TLP_2.TabIndex = 1;
			this.TLP_2.Resize += new System.EventHandler(this.TLP_2_Resize);
			// 
			// L_FolderPath
			// 
			this.L_FolderPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_FolderPath.AutoSize = true;
			this.L_FolderPath.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_FolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_FolderPath.Location = new System.Drawing.Point(15, 21);
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
			this.TB_FolderPath.Location = new System.Drawing.Point(205, 19);
			this.TB_FolderPath.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
			this.TB_FolderPath.Name = "TB_FolderPath";
			this.TB_FolderPath.Size = new System.Drawing.Size(470, 27);
			this.TB_FolderPath.TabIndex = 0;
			this.TB_FolderPath.TextChanged += new System.EventHandler(this.TB_FolderPath_TextChanged);
			this.TB_FolderPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyInput);
			// 
			// TLP_1
			// 
			this.TLP_1.ColumnCount = 3;
			this.TLP_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
			this.TLP_1.Controls.Add(this.L_IconPath, 0, 0);
			this.TLP_1.Controls.Add(this.TB_IconPath, 1, 0);
			this.TLP_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_1.Location = new System.Drawing.Point(30, 3);
			this.TLP_1.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_1.Name = "TLP_1";
			this.TLP_1.RowCount = 1;
			this.TLP_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
			this.TLP_1.Size = new System.Drawing.Size(880, 65);
			this.TLP_1.TabIndex = 0;
			this.TLP_1.Resize += new System.EventHandler(this.TLP_1_Resize);
			// 
			// L_IconPath
			// 
			this.L_IconPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.L_IconPath.AutoSize = true;
			this.L_IconPath.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_IconPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_IconPath.Location = new System.Drawing.Point(15, 21);
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
			this.TB_IconPath.Location = new System.Drawing.Point(205, 19);
			this.TB_IconPath.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
			this.TB_IconPath.Name = "TB_IconPath";
			this.TB_IconPath.Size = new System.Drawing.Size(470, 27);
			this.TB_IconPath.TabIndex = 100;
			this.TB_IconPath.TextChanged += new System.EventHandler(this.TB_IconPath_TextChanged);
			this.TB_IconPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyInput);
			this.TB_IconPath.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxPreviewKeyDown);
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
			this.TLP_3.Location = new System.Drawing.Point(30, 151);
			this.TLP_3.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_3.Name = "TLP_3";
			this.TLP_3.RowCount = 1;
			this.TLP_3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_3.Size = new System.Drawing.Size(880, 65);
			this.TLP_3.TabIndex = 2;
			// 
			// L_IconVersion
			// 
			this.L_IconVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.L_IconVersion.AutoSize = true;
			this.L_IconVersion.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_IconVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
			this.L_IconVersion.Location = new System.Drawing.Point(563, 21);
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
			this.L_Version.Location = new System.Drawing.Point(720, 21);
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
			this.L_IconsDetected.Location = new System.Drawing.Point(15, 21);
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
			this.L_Icons.Location = new System.Drawing.Point(190, 21);
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
			this.TLP_5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_5.Location = new System.Drawing.Point(30, 395);
			this.TLP_5.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
			this.TLP_5.Name = "TLP_5";
			this.TLP_5.RowCount = 1;
			this.TLP_5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_5.Size = new System.Drawing.Size(880, 92);
			this.TLP_5.TabIndex = 3;
			// 
			// P_Spacer_1
			// 
			this.P_Spacer_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(64)))));
			this.P_Spacer_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Spacer_1.Location = new System.Drawing.Point(50, 71);
			this.P_Spacer_1.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
			this.P_Spacer_1.Name = "P_Spacer_1";
			this.P_Spacer_1.Size = new System.Drawing.Size(840, 3);
			this.P_Spacer_1.TabIndex = 4;
			// 
			// browseDialog
			// 
			this.browseDialog.Description = "Select Folder";
			this.browseDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.browseDialog.ShowNewFolderButton = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// L_AppVersion
			// 
			this.L_AppVersion.AutoSize = true;
			this.L_AppVersion.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_AppVersion.Location = new System.Drawing.Point(5, 528);
			this.L_AppVersion.Name = "L_AppVersion";
			this.L_AppVersion.Size = new System.Drawing.Size(45, 16);
			this.L_AppVersion.TabIndex = 2;
			this.L_AppVersion.Text = "v 3.0.0";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(192)))), ((int)(((byte)(232)))));
			this.ClientSize = new System.Drawing.Size(950, 550);
			this.Controls.Add(this.L_AppVersion);
			this.Controls.Add(this.TLP_Main);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Auto-Icons";
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.TLP_Main.ResumeLayout(false);
			this.P_Title.ResumeLayout(false);
			this.P_Title.PerformLayout();
			this.TLP_4.ResumeLayout(false);
			this.TLP_Options.ResumeLayout(false);
			this.TLP_Options.PerformLayout();
			this.TLP_2.ResumeLayout(false);
			this.TLP_2.PerformLayout();
			this.TLP_1.ResumeLayout(false);
			this.TLP_1.PerformLayout();
			this.TLP_3.ResumeLayout(false);
			this.TLP_3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.FolderBrowserDialog browseDialog;
		private FlatButton B_IconPath;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private MyCheckBox CB_TurboMode;
		private MyCheckBox CB_DriveDependant;
		private MyCheckBox CB_IncSubs;
		private MyCheckBox CB_Folders;
		private MyCheckBox CB_Shortcuts;
		private FlatButton B_FolderPath;
		private FlatButton B_Auto;
		private FlatButton B_Reset;
		private FlatButton B_Change;
		private System.Windows.Forms.PictureBox PB_Icon;
		private System.Windows.Forms.PictureBox B_Close;
		private System.Windows.Forms.PictureBox B_Max;
		private System.Windows.Forms.PictureBox B_Min;
		private System.Windows.Forms.Label L_AppVersion;
	}
}

