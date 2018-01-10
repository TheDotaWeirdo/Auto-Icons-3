using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace Auto_Icons_3
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			CompleteInitialization();
			Data.MainForm = this;

			FormDesign.DesignChanged += MainForm_DesignChanged;
			TB_IconPath.LostFocus += TB_IconPath_LostFocus;
			TB_FolderPath.LostFocus += TB_FolderPath_LostFocus;
		}

		#region Additional Initialization
		void CompleteInitialization()
		{
			B_IconPath = new FlatButton
			{
				Anchor = AnchorStyles.None,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				BackColor = Color.FromArgb(36, 49, 64),
				BorderStyle = BorderStyle.Auto,
				Cursor = Cursors.Hand,
				Font = new Font("Century Gothic", 12.75F, FontStyle.Bold),
				ForeColor = Color.FromArgb(65, 71, 87),
				HueShade = null,
				Image = Properties.Resources.Icon_Search,
				Location = new Point(727, 15),
				Name = "B_IconPath",
				Size = new Size(130, 35),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 101,
				Text = "Browse"
			};
			B_IconPath.Click += new EventHandler(B_IconPath_Click);

			B_FolderPath = new FlatButton
			{
				Anchor = AnchorStyles.None,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				BackColor = Color.FromArgb(36, 49, 64),
				BorderStyle = BorderStyle.Auto,
				Cursor = Cursors.Hand,
				Font = new Font("Century Gothic", 12.75F, FontStyle.Bold),
				ForeColor = Color.FromArgb(65, 71, 87),
				HueShade = null,
				Image = Properties.Resources.Icon_Search,
				Location = new Point(727, 15),
				Name = "B_FolderPath",
				Size = new Size(130, 35),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 102,
				Text = "Browse"
			};
			B_FolderPath.Click += new EventHandler(B_FolderPath_Click);

			B_Auto = new FlatButton
			{
				Anchor = AnchorStyles.None,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				BackColor = Color.FromArgb(36, 49, 64),
				BorderStyle = BorderStyle.Auto,
				Cursor = Cursors.Hand,
				Font = new Font("Century Gothic", 12.75F, FontStyle.Bold),
				ForeColor = Color.FromArgb(65, 71, 87),
				HueShade = null,
				Image = Properties.Resources.Icon_Auto,
				Location = new Point(727, 15),
				Name = "B_FolderPath",
				Size = new Size(175, 40),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 102,
				Text = "Auto-Change"
			};
			B_Auto.Click += new EventHandler(B_Auto_Click);

			B_Change = new FlatButton
			{
				Anchor = AnchorStyles.None,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				BackColor = Color.FromArgb(36, 49, 64),
				BorderStyle = BorderStyle.Auto,
				Cursor = Cursors.Hand,
				Font = new Font("Century Gothic", 12.75F, FontStyle.Bold),
				ForeColor = Color.FromArgb(65, 71, 87),
				HueShade = null,
				Image = Properties.Resources.Icon_Paint,
				Location = new Point(727, 15),
				Name = "B_FolderPath",
				Size = new Size(175, 40),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 102,
				Text = "Change Icons"
			};
			B_Change.Click += new EventHandler(B_Change_Click);

			B_Reset = new FlatButton
			{
				Anchor = AnchorStyles.None,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				BackColor = Color.FromArgb(36, 49, 64),
				BorderStyle = BorderStyle.Auto,
				Cursor = Cursors.Hand,
				Font = new Font("Century Gothic", 12.75F, FontStyle.Bold),
				ForeColor = Color.FromArgb(65, 71, 87),
				HueShade = null,
				Image = Properties.Resources.Icon_Reset,
				Location = new Point(727, 15),
				Name = "B_FolderPath",
				Size = new Size(175, 40),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 102,
				Text = "Reset Icons"
			};
			B_Reset.Click += new EventHandler(B_Reset_Click);


			CB_Shortcuts = new MyCheckBox
			{
				Anchor = AnchorStyles.Left,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Checked = true,
				CheckedText = "Include Shortcuts",
				Location = new Point(3, 7),
				Name = "CB_Shortcuts",
				Size = new Size(122, 37),
				TabIndex = 0,
				UncheckedText = "Exclude Shortcuts"
			};
			CB_Shortcuts.CheckChanged += new EventHandler(CB_Shortcuts_CheckChanged);

			CB_Folders = new MyCheckBox
			{
				Anchor = AnchorStyles.Left,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Checked = true,
				CheckedText = "Include Folders",
				Location = new Point(352, 7),
				Name = "CB_Folders",
				Size = new Size(122, 37),
				TabIndex = 1,
				UncheckedText = "Exclude Folders"
			};
			CB_Folders.CheckChanged += new EventHandler(CB_Folders_CheckChanged);

			CB_IncSubs = new MyCheckBox
			{
				Anchor = AnchorStyles.Left,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Checked = true,
				CheckedText = "Change Sub-Folders",
				Location = new Point(3, 58),
				Name = "CB_IncSubs",
				Size = new Size(122, 37),
				TabIndex = 2,
				UncheckedText = "Only Change Top Folder"
			};

			CB_DriveDependant = new MyCheckBox
			{
				Anchor = AnchorStyles.Left,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Checked = true,
				CheckedText = "Local Drive Mode",
				Location = new Point(352, 58),
				Name = "CB_DriveDependant",
				Size = new Size(122, 37),
				TabIndex = 3,
				UncheckedText = "External Drive Mode"
			};

			CB_TurboMode = new MyCheckBox
			{
				Anchor = AnchorStyles.Left,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Checked = true,
				CheckedText = "Turbo Mode",
				Location = new Point(3, 110),
				Name = "CB_TurboMode",
				Size = new Size(122, 37),
				TabIndex = 4,
				UncheckedText = "Normal Mode"
			};

			PB_Icon = new PictureBox
			{
				Cursor = Cursors.Hand,
				Image = Properties.Resources.Icon,
				Location = new Point(2, 2),
				Name = "PB_Icon",
				Size = new Size(28, 28),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 3,
				TabStop = false
			};
			PB_Icon.Click += new EventHandler(PB_Icon_Click);

			B_Close = new PictureBox
			{
				Cursor = Cursors.Hand,
				Image = Properties.Resources.Circle,
				Location = new Point(57, 3),
				Name = "B_Close",
				Size = new Size(22, 22),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 5,
				TabStop = false
			};    
			B_Close.Click += new EventHandler(B_Close_Click);

			B_Max = new PictureBox
			{
				Cursor = Cursors.Hand,
				Image = Properties.Resources.Circle,
				Location = new Point(30, 3),
				Name = "B_Max",
				Size = new Size(22, 22),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 4,
				TabStop = false
			};      
			B_Max.Click += new EventHandler(B_Max_Click);

			B_Min = new PictureBox
			{
				Cursor = Cursors.Hand,
				Image = Properties.Resources.Circle,
				Location = new Point(3, 3),
				Name = "B_Min",
				Size = new Size(22, 22),
				SizeMode = PictureBoxSizeMode.Zoom,
				TabIndex = 3,
				TabStop = false
			};
			B_Min.Click += new EventHandler(B_Min_Click);

			P_WindowControls.Controls.Add(B_Close);
			P_WindowControls.Controls.Add(B_Max);
			P_WindowControls.Controls.Add(B_Min);
			TLP_5.Controls.Add(B_Reset, 0, 0);
			TLP_5.Controls.Add(B_Auto, 1, 0);
			TLP_5.Controls.Add(B_Change, 2, 0);
			P_Title.Controls.Add(PB_Icon);
			TLP_1.Controls.Add(B_IconPath, 2, 0);
			TLP_2.Controls.Add(B_FolderPath, 2, 0);
			TLP_CheckBoxes.Controls.Add(CB_TurboMode, 0, 2);
			TLP_CheckBoxes.Controls.Add(CB_DriveDependant, 1, 1);
			TLP_CheckBoxes.Controls.Add(CB_IncSubs, 0, 1);
			TLP_CheckBoxes.Controls.Add(CB_Folders, 1, 0);
			TLP_CheckBoxes.Controls.Add(CB_Shortcuts, 0, 0);
			PB_Icon.BringToFront();
		}
		#endregion

		private void MainForm_Load(object sender, EventArgs e)
		{
			L_AppVersion.Text = $"v {ProductVersion.ToString()}";
			MainForm_DesignChanged(FormDesign.Design);

			lastAddedChars = new Dictionary<TextBox, string>()
			{
				{ TB_IconPath, string.Empty },
				{ TB_FolderPath, string.Empty }
			};
			chosenIndex = new Dictionary<TextBox, int>()
			{
				{ TB_IconPath, 0 },
				{ TB_FolderPath, 0 }
			};

			if (Directory.Exists("C:\\Icons"))
			{
				TBChangeIdentifier.Enable();
				TB_IconPath.Text = "C:\\Icons";
				TBChangeIdentifier.Disable();
			}
		}

		#region DEBUGGING
#if DEBUG
		private int debugKeyCount = 0;
		public bool DebugMode => debugKeyCount >= 5;
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.F12 && !DebugMode)
			{
				debugKeyCount++;
				if (DebugMode)
					MessageBox.Show("Debug Mode Activated", "Debug Mode", MessageBoxButtons.OK);
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
#endif
		#endregion

		#region General Methods
		private void MainForm_DesignChanged(FormDesign design)
		{
			BackColor = FormState.Normal(FormIsActive).Color(design);
			TLP_Main.BackColor = L_AppVersion.BackColor = design.BackColor;
			ForeColor = L_AppVersion.ForeColor = design.ForeColor;
			P_Title.BackColor = design.TitleColor;
			L_Title.ForeColor = design.TitleForeColor;
			P_Spacer_1.BackColor = P_Spacer_2.BackColor = P_Spacer_3.BackColor = P_Spacer_4.BackColor = design.LightColor;
			L_FolderPath.ForeColor = L_IconPath.ForeColor = L_IconsDetected.ForeColor = L_IconVersion.ForeColor = L_Options.ForeColor = design.LabelColor;
			PB_Icon.Image = (PB_Icon.Image as Bitmap).Color(design.IconColor);
			B_Min.Image = (B_Min.Image as Bitmap).Color(design.GreenColor);
			B_Max.Image = (B_Max.Image as Bitmap).Color(design.YellowColor);
			B_Close.Image = (B_Close.Image as Bitmap).Color(design.RedColor);
		}

		private void CB_Shortcuts_CheckChanged(object sender, EventArgs e)
		{
			if (!CB_Shortcuts.Checked && !CB_Folders.Checked)
				CB_Folders.Checked = true;
		}

		private void CB_Folders_CheckChanged(object sender, EventArgs e)
		{
			if (!CB_Shortcuts.Checked && !CB_Folders.Checked)
				CB_Shortcuts.Checked = true;
		}

		public void ResetSession()
		{
			Data.Session = new SessionData();

			TBChangeIdentifier.Enable();
			TB_IconPath_TextChanged(this, EventArgs.Empty);
			TBChangeIdentifier.Disable();
		}

		private bool ValidationCheck(int level)
		{
			if (level == 0)
			{
				if (Directory.Exists(TB_FolderPath.Text))
					return DialogResult.Yes == MessageBox.Show($"Are you sure you want to reset all icons in {Path.GetFileName(TB_FolderPath.Text)}?", "Do you wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				else
				{
					MessageBox.Show("Folder Path is not valid, make sure the folder path exists or browse for the folder to reset its icons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}

			if (level == 1)
			{
				if (Data.Session.Icons.Count > 0)
					return DialogResult.Yes == MessageBox.Show($"Are you sure you want to automatically change all icons on your Desktop and other folders?", "Do you wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				else
				{
					MessageBox.Show("Icon Path is not valid, browse for a folder that contains icons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}

			if (level == 2)
			{
				if (Data.Session.Icons.Count > 0 && Directory.Exists(TB_FolderPath.Text))
				{
					if (Directory.GetParent(TB_FolderPath.Text) != null || !CB_IncSubs.Checked)
						return DialogResult.Yes == MessageBox.Show($"Are you sure you want to change all icons in {Path.GetFileName(TB_FolderPath.Text)}?", "Do you wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					else
						return DialogResult.Yes == MessageBox.Show($"Changing the icons of the whole {TB_FolderPath.Text[0]} drive will take a lot of time to process, are you sure you want to do that?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show("Folder or Icon Path is not valid, make sure that the icon folder contains icons and that the folder path exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}

			throw new Exception("Invalid Level");
		}

		private void SetCurrentSessionOptions()
		{
			Data.Session.O_ChangeFolders = CB_Folders.Checked;
			Data.Session.O_ChangeShortcuts = CB_Shortcuts.Checked;
			Data.Session.O_DriveDependant = CB_DriveDependant.Checked;
			Data.Session.O_IncludeSubFolders = CB_IncSubs.Checked;
			Data.Session.O_TurboMode = CB_TurboMode.Checked;
		}
		#endregion

		#region Click Events
		private void B_IconPath_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(TB_IconPath.Text))
				browseDialog.SelectedPath = TB_IconPath.Text;
			else
				browseDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (browseDialog.ShowDialog() == DialogResult.OK)
			{
				autoCompleteDisableIdentifier.Disable();
				TB_IconPath.Text = browseDialog.SelectedPath;
				autoCompleteDisableIdentifier.Enable();
			}
		}

		private void B_FolderPath_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(TB_FolderPath.Text))
				browseDialog.SelectedPath = TB_FolderPath.Text;
			else
				browseDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if (browseDialog.ShowDialog() == DialogResult.OK)
			{
				autoCompleteDisableIdentifier.Disable();
				TB_FolderPath.Text = browseDialog.SelectedPath;
				autoCompleteDisableIdentifier.Enable();
			}
		}

		private void B_Reset_Click(object sender, EventArgs e)
		{
			if (ValidationCheck(0))
			{
				Data.Session.SessionAction = SessionAction.Reset;
				Data.Session.WorkingPaths.Add(TB_FolderPath.Text);
				SetCurrentSessionOptions();

				(new WorkForm() { Size = Size, Location = Location }).Show();
				Hide();
			}				
		}

		private void B_Auto_Click(object sender, EventArgs e)
		{
			if (ValidationCheck(1))
			{
				Data.Session.SessionAction = SessionAction.Change;
				Data.Session.WorkingPaths.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
				if (ExtensionClass.IsAdministrator)
				{
					Data.Session.WorkingPaths.AddRange(new string[]
					{
						 @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs",
						$@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar",
						$@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\"
					});
				}
				SetCurrentSessionOptions();

				(new WorkForm() { Bounds = Bounds }).Show();
				Hide();
			}
		}

		private void B_Change_Click(object sender, EventArgs e)
		{
#if DEBUG
			if (DebugMode)
			{
				var itemFile = new ItemFile(TB_FolderPath.Text, out var error);

				IconMatcher.Match(itemFile);

				if(itemFile.Match == null && itemFile.Type != IconType.Normal)
				{
					IconMatcher.ReMatch(itemFile);
					MessageBox.Show($"'{itemFile}' was re-matched with '{itemFile.Match}'");
				}
				else
					MessageBox.Show($"'{itemFile}' was matched with '{itemFile.Match}'");
			}
#endif
			if (ValidationCheck(2))
			{
				Data.Session.SessionAction = SessionAction.Change;
				Data.Session.WorkingPaths.Add(TB_FolderPath.Text);
				SetCurrentSessionOptions();

				(new WorkForm() { Size = Size, Location = Location }).Show();
				Hide();
			}
		}

		private void PB_Icon_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			FormDesign.Switch();
			Cursor = Cursors.Default;
		}

		private void B_Close_Click(object sender, EventArgs e) => Close();

		private void B_Max_Click(object sender, EventArgs e) => WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;

		private void B_Min_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
		#endregion

		#region FormActive
		public bool FormIsActive = true;
		private FormState currentFormState = FormState.N_Focused;
		public FormState CurrentFormState
		{
			get => currentFormState;
			set { currentFormState = value; Invoke(new Action(() => { BackColor = value.Color(FormDesign.Design); })); }
		}

		private void Form_Activated(object sender, EventArgs e)
		{
			if (CurrentFormState.IsNormal)
				CurrentFormState = FormState.N_Focused;
			FormIsActive = true;
		}

		private void Form_Deactivate(object sender, EventArgs e)
		{
			if (CurrentFormState.IsNormal)
				CurrentFormState = FormState.N_Unfocused;
			FormIsActive = false;
		}
		#endregion

		#region Move/Resize
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public void Form_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		protected override void WndProc(ref Message m)
		{
			const int RESIZE_HANDLE_SIZE = 10;

			switch (m.Msg)
			{
				case 0x0084/*NCHITTEST*/ :
					base.WndProc(ref m);

					if ((int)m.Result == 0x01/*HTCLIENT*/)
					{
						Point screenPoint = new Point(m.LParam.ToInt32());
						Point clientPoint = PointToClient(screenPoint);
						if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
							else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
								m.Result = (IntPtr)12/*HTTOP*/ ;
							else
								m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
						}
						else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)10/*HTLEFT*/ ;
							else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
								m.Result = (IntPtr)2/*HTCAPTION*/ ;
							else
								m.Result = (IntPtr)11/*HTRIGHT*/ ;
						}
						else
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
							else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
								m.Result = (IntPtr)15/*HTBOTTOM*/ ;
							else
								m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
						}
					}
					return;
			}
			base.WndProc(ref m);
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= 0x20000; // <--- use 0x20000
				return cp;
			}
		}
		#endregion

		#region Resize Events
		private void TLP_1_Resize(object sender, EventArgs e) => TB_IconPath.Width = TLP_1.Width;

		private void TLP_2_Resize(object sender, EventArgs e) => TB_FolderPath.Width = TLP_2.Width;

		private void TLP_CheckBoxes_Resize(object sender, EventArgs e)
		{
			CB_Shortcuts.Margin = CB_Folders.Margin = CB_IncSubs.Margin = CB_TurboMode.Margin
				= CB_DriveDependant.Margin = new Padding((Width - 800) / 5, 3, 3, 3);
		}
		#endregion

		#region TextBox Handling
		private DisableIdentifier TBChangeIdentifier = new DisableIdentifier(false);
		private int lastLevel = 2;

		private void TB_IconPath_TextChanged(object sender, EventArgs e)
		{
			if (TBChangeIdentifier.Enabled || AutoCompletePath(TB_IconPath))
			{
				Cursor = Cursors.WaitCursor;
				Data.Session.Icons = BackEndWorker.GetIcons(TB_IconPath.Text);
				L_Icons.Text = $"{Data.Session.Icons.Count} Icons";
				L_Version.Text = BackEndWorker.GetIconsVersion(Data.Session.Icons);
				lastLevel = 2;
				Cursor = Cursors.Default;
			}
		}

		private void TB_IconPath_LostFocus(object sender, EventArgs e)
		{
			if (Directory.Exists(TB_IconPath.Text) && Data.Session.Icons.Count <= 10)
			{
				if (DialogResult.Yes == MessageBox.Show($"This folder does not contain {(Data.Session.Icons.Count == 0 ? "any" : "that many")} icons, would you like to search through all folders in this directory?", "Search Deeper?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
				{
					Cursor = Cursors.WaitCursor;
					Data.Session.Icons = BackEndWorker.GetIcons(TB_IconPath.Text, ++lastLevel);
					L_Icons.Text = $"{Data.Session.Icons.Count} Icons";
					L_Version.Text = BackEndWorker.GetIconsVersion(Data.Session.Icons);
					Cursor = Cursors.Default;
				}
			}
		}

		private void TB_FolderPath_TextChanged(object sender, EventArgs e) => AutoCompletePath(TB_FolderPath);

		private void TB_FolderPath_LostFocus(object sender, EventArgs e)
		{
			if (TB_FolderPath.Text != string.Empty && !Directory.Exists(TB_FolderPath.Text) && DialogResult.Yes ==
				MessageBox.Show("The folder path does not exist, would you like to search for another directory?", "Path Does Not Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
					B_FolderPath_Click(sender, e);
		}

		private Dictionary<TextBox, string> lastAddedChars;
		private Dictionary<TextBox, int>		chosenIndex;
		private DisableIdentifier				autoCompleteDisableIdentifier = new DisableIdentifier();

		private bool AutoCompletePath(TextBox textBox)
		{
			if (textBox.Text == string.Empty) return false;

			try
			{
				var parentPath = Directory.GetParent(textBox.Text)?.FullName;
				var oldText = textBox.Text;

				if (parentPath == null && (textBox.Text.EndsWith("\\") || textBox.Text.EndsWith("/")))
					parentPath = Path.GetFullPath(textBox.Text);

				if (autoCompleteDisableIdentifier.Enabled && parentPath != null
					&& (textBox.Text.EndsWith("\\") || textBox.Text.EndsWith("/")
					|| (!Directory.Exists(textBox.Text) && Directory.Exists(parentPath))))
				{
					var searchedDirectoryName = Regex.Match(textBox.Text, @"[/\\]([^/\\]+)$").Groups[1].Value;
					var selectedDirectory = Directory.GetDirectories(parentPath, "*", SearchOption.TopDirectoryOnly)
						.Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
							|| Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)))
						.FirstOrDefault();

					if (selectedDirectory != null)
					{
						var index = textBox.SelectionStart;

						autoCompleteDisableIdentifier.Disable();
						textBox.Text = selectedDirectory;
						textBox.Select(index, textBox.Text.Length - index);
						lastAddedChars[textBox] = textBox.SelectedText;
						chosenIndex[textBox] = 0;
						autoCompleteDisableIdentifier.Enable();
					}
				}
			}
			catch (Exception) { }

			return Directory.Exists(textBox.Text);
		}

		private void HandleKeyInput(object sender, KeyPressEventArgs e)
		{
			var tb = (sender as TextBox);

			var t = e.KeyChar;

			if (e.KeyChar == '\b' && tb.SelectionLength > 0 && tb.SelectedText == lastAddedChars[tb])
			{
				tb.SelectionStart--;
				tb.SelectionLength++;
			}

			if ((e.KeyChar == '\\' || e.KeyChar == '/') && Directory.Exists(tb.Text))
				tb.Select(tb.Text.Length, 0);

			if (e.KeyChar == '\t' && Directory.GetParent(tb.Text) != null)
			{
				var index = tb.SelectionStart;
				var searchedDirectoryName = Regex.Match(tb.Text.Substring(0, index), @"[/\\]([^/\\]+)$").Groups[1].Value;
				var directories = Directory.GetDirectories(Directory.GetParent(tb.Text).FullName, "*", SearchOption.TopDirectoryOnly)
					.Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
						|| Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)));

				chosenIndex[tb]++;
				if (chosenIndex[tb] >= directories.Count())
					chosenIndex[tb] = 0;

				autoCompleteDisableIdentifier.Disable();
				tb.Text = directories.ElementAt(chosenIndex[tb]);
				tb.Select(index, tb.Text.Length - index);
				lastAddedChars[tb] = tb.SelectedText;
				autoCompleteDisableIdentifier.Enable();
			}
		}

		private void TextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			var tb = (sender as TextBox);

#if DEBUG
			if(e.KeyData == Keys.F12 && !DebugMode)
			{
				debugKeyCount++;
				if (DebugMode)
					MessageBox.Show("Debug Mode Activated", "Debug Mode", MessageBoxButtons.OK);
			}
#endif

			if (tb.SelectedText != string.Empty && tb.Text.EndsWith(tb.SelectedText))
				e.IsInputKey = true;
		}
		#endregion
	}
}
