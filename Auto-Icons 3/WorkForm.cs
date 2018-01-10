using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Extensions;

namespace Auto_Icons_3
{
	public partial class WorkForm : Form
	{
		private static int MAX_RUNS = Math.Max(3, Environment.ProcessorCount - 4);
		private static ThreadPriority THREAD_PRIORITY => Data.Session.O_TurboMode ? ThreadPriority.Highest : ThreadPriority.Normal;

		private List<Thread> WorkingThreads = new List<Thread>();

		public WorkForm()
		{
			InitializeComponent();
			PGB_Shortcuts = GetProgressBar;
			PGB_Folders = GetProgressBar;
			PGB_SecondPass = GetProgressBar;
			PGB_ApplyChanges = GetProgressBar;
			B_Abort = new FlatButton
			{
				Anchor = AnchorStyles.None,
				BackColor = Color.FromArgb(36, 49, 64),
				BorderStyle = BorderStyle.Auto,
				Cursor = Cursors.Hand,
				Font = new Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0),
				ForeColor = Color.FromArgb(65, 71, 87),
				Image = Properties.Resources.Icon_Stop,
				Size = new Size(140, 35),
				SizeMode = PictureBoxSizeMode.Zoom,
				Text = "Abort"
			};
			B_Abort.Click += B_Abort_Click;
			TLP_Shortcuts_Bar.Controls.Add(PGB_Shortcuts, 1, 0);
			TLP_Folders_Bar.Controls.Add(PGB_Folders, 1, 0);
			TLP_SecondPass_Bar.Controls.Add(PGB_SecondPass, 1, 0);
			TLP_Apply_Bar.Controls.Add(PGB_ApplyChanges, 1, 0);
			TLP_Content.Controls.Add(B_Abort, 0, 8);
		}

		private MyProgressBar GetProgressBar => new MyProgressBar
		{
			Anchor = AnchorStyles.None,
			Font = new Font("Century Gothic", 14.25F),
			MinStep = 0.5D,
			Percentage = 0D,
			Scheme = ColorScheme.Active,
			Margin = new Padding(3, 3, 30, 3),
			Size = new Size(897, 32)
		};

		private void WorkForm_Load(object sender, EventArgs e)
		{
			FormDesign.DesignChanged += WorkForm_DesignChanged;
			WorkForm_DesignChanged(FormDesign.Design);
			new Action(Start).RunInBackground();
		}

		private void WorkForm_DesignChanged(FormDesign design)
		{
			BackColor = FormState.Normal(FormIsActive).Color(design);
			TLP_Main.BackColor = design.BackColor;
			ForeColor = design.ForeColor;
			P_Title.BackColor = design.TitleColor;
			L_Title.ForeColor = design.TitleForeColor;
			if (Data.Session.Stage != 5)
				B_Abort.HueShade = design.RedColor.GetHue();
			L_Shortcuts_Info.ForeColor = Data.Session.StageErrors[1] > 0 ? design.RedColor : Data.Session.Stage >= 1 ? design.InfoColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			L_Folders_Info.ForeColor = Data.Session.StageErrors[2] > 0 ? design.RedColor : Data.Session.Stage >= 2 ? design.InfoColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			L_SecondPass_Info.ForeColor = Data.Session.StageErrors[3] > 0 ? design.RedColor : Data.Session.Stage >= 3 ? design.InfoColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			L_ApplyChanges_Info.ForeColor = Data.Session.StageErrors[4] > 0 ? design.RedColor : Data.Session.Stage >= 4 ? design.InfoColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			if (Data.Session.Stage != 0)
				PB_Icon.Image = (PB_Icon.Image as Bitmap).Color(design.IconColor);
			else
				PB_Icon.Image = design.ID == 2 ? Properties.Resources.GIF_Ring_B : Properties.Resources.GIF_Ring_W;
			B_Min.Image = (B_Min.Image as Bitmap).Color(design.GreenColor);
			B_Max.Image = (B_Max.Image as Bitmap).Color(design.YellowColor);
			B_Close.Image = (B_Close.Image as Bitmap).Color(design.RedColor);
			PB_Shortcuts.Image = PB_Folders.Image = PB_SecondPass.Image = PB_Final.Image
				= design.ID == 2 ? Properties.Resources.GIF_Ring_B : Properties.Resources.GIF_Ring_W;

			ColorLabels(design);
		}

		private void ColorLabels(FormDesign design)
		{
			L_Shortcuts.ForeColor	 =	Data.Session.Stage >= 1 ? design.LabelColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			L_Folders.ForeColor		 =	Data.Session.Stage >= 2 ? design.LabelColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			L_SecondPass.ForeColor	 =	Data.Session.Stage >= 3 ? design.LabelColor : design.ID == 2 ? design.DarkColor : design.LightColor;
			L_ApplyChanges.ForeColor = Data.Session.Stage >= 4 ? design.LabelColor : design.ID == 2 ? design.DarkColor : design.LightColor;
		}

		#region Stages
		private void Start()
		{
			var enumerationsDone = 0;

			if (Data.Session.O_ChangeFolders)
				foreach (var item in Data.Session.WorkingPaths)
				{
					var file = new ItemFile(item, out var error);
					if (!error)
						Data.Session.Files.Add(file);
				}
				
			foreach (var folder in Data.Session.WorkingPaths)
			{
				WorkingThreads.Add(new Action(() =>
				{
					if (Data.Session.O_ChangeShortcuts)
					{
						try
						{
							foreach (var file in Directory.EnumerateFiles(folder, "*.lnk"
								, Data.Session.O_IncludeSubFolders ? SearchOption.AllDirectories
								: SearchOption.TopDirectoryOnly))
							{
								var item = new ItemFile(file, out var error);
								if (!error)
									Data.Session.Files.Add(item);
							}

							enumerationsDone++;

							if (enumerationsDone == Data.Session.WorkingPaths.Count * (Data.Session.O_ChangeShortcuts &&
								Data.Session.O_ChangeFolders ? 2 : 1))
								Stage_1();
						}
						catch (Exception ex)
						{
							Data.Session.StageErrors[0]++;
#if DEBUG
							Data.Session.Exceptions.Add(ex);
#endif
						}
					}

					if (Data.Session.O_ChangeFolders)
					{
						try
						{
							foreach (var file in Directory.EnumerateDirectories(folder, "*"
							, Data.Session.O_IncludeSubFolders ? SearchOption.AllDirectories
							: SearchOption.TopDirectoryOnly))
							{
								var item = new ItemFile(file, out var error);
								if (!error)
									Data.Session.Files.Add(item);
							}

							enumerationsDone++;

							if (enumerationsDone == Data.Session.WorkingPaths.Count * (Data.Session.O_ChangeShortcuts &&
								Data.Session.O_ChangeFolders ? 2 : 1))
								Stage_1();
						}
						catch (Exception ex)
						{
							Data.Session.StageErrors[0]++;
#if DEBUG
							Data.Session.Exceptions.Add(ex);
#endif
						}
					}
				}).RunInBackground(ThreadPriority.Highest));
			}

			if (Data.Session.WorkingPaths.Count == 0 || (!Data.Session.O_ChangeFolders && !Data.Session.O_ChangeShortcuts))
				Stage_1();
			else
				Invoke(new Action(() => TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Indeterminate)));
		}

#region Stage 1 - Shortcut Matching
		private void Stage_1()
		{
			Data.Session.Stage = 1;
			ColorLabels(FormDesign.Design);

			Data.Session.Icons = Data.Session.Icons.Where(x => x != null).ToList();
			Data.Session.Files = Data.Session.Files.Where(x => x != null).ToList();
			if (Data.Session.O_ChangeShortcuts)
				Data.Session.Shortcuts.AddRange(Data.Session.Files.Where(x => x?.Type == IconType.Normal));
			if (Data.Session.O_ChangeFolders)
				Data.Session.Folders.AddRange(Data.Session.Files.Where(x => x?.Type != IconType.Normal));

			Invoke(new Action(() =>
			{
				PB_Icon.Image = Properties.Resources.Icon.Color(FormDesign.Design.IconColor);
				L_Title.Text = "Auto - Icons";
				L_Title.Font = new Font("Century Gothic", 17.25F, FontStyle.Bold);
				L_Shortcuts_Info.ForeColor = FormDesign.Design.InfoColor;
				PB_Shortcuts.Show();
				TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Normal);
			}));

			for (int i = 0; i < (Data.Session.Shortcuts.Count / 500).Between(1, MAX_RUNS); i++)
				WorkingThreads.Add(new Action(S1_Work).RunInBackground(THREAD_PRIORITY));
		}

		private void S1_Work()
		{
			while (Data.Session.Stage == 1 && Data.Session.Shortcuts.Count >= Data.Session.LastShortcut + 1)
			{
				if (Data.Session.LastShortcut >= Data.Session.Shortcuts.Count)
					break;

				var item = Data.Session.Shortcuts[Data.Session.LastShortcut++];

				Invoke(new Action(() =>
				{
					L_Shortcuts_Info.Text = item.Name;
					TaskbarProgress.SetValue(Handle, 2500d * Data.Session.LastShortcut / Data.Session.Shortcuts.Count, 10000);
				}));

				var error = IconMatcher.Match(item);

				PGB_Shortcuts.Percentage = 100d * Data.Session.LastShortcut / Data.Session.Shortcuts.Count;

				if (error != null)
				{
					Data.Session.StageErrors[0]++;
#if DEBUG
					Data.Session.Exceptions.Add(error);
#endif
				}
			}

			if (Data.Session.Stage == 1)
				Stage_2();
		}
#endregion

#region Stage 2 - Folder Matching
		private void Stage_2()
		{
			Data.Session.Stage = 2;
			Thread.Sleep(250);
			ColorLabels(FormDesign.Design);

			PGB_Shortcuts.Percentage = 100;
			Invoke(new Action(() => 
			{
				if (Data.Session.Shortcuts.Count > 0)
					L_Shortcuts_Info.Text = $"Done, {Data.Session.Shortcuts.Where(x => x.Match != null).Count()} / {Data.Session.Shortcuts.Count} matches found";
				else
					L_Shortcuts_Info.Text = $"Done, no Shortcuts to match";
				L_Folders_Info.ForeColor = FormDesign.Design.InfoColor;
				if (Data.Session.StageErrors[1] > 0)
					L_Shortcuts_Info.ForeColor = FormDesign.Design.RedColor;
				L_Shortcuts_Info.Text += Data.Session.StageErrors[1] == 0 ? "." : $", {Data.Session.StageErrors[1]} errors occurred.";
				PB_Shortcuts.Hide();
				PB_Folders.Show();
			}));

			for (int i = 0; i < (Data.Session.Folders.Count / 500).Between(1, MAX_RUNS); i++)
				WorkingThreads.Add(new Action(S2_Work).RunInBackground(THREAD_PRIORITY));
		}

		private void S2_Work()
		{
			while (Data.Session.Stage == 2 && Data.Session.Folders.Count >= Data.Session.LastFolder + 1)
			{
				if (Data.Session.LastFolder >= Data.Session.Folders.Count)
					break;

				var item = Data.Session.Folders[Data.Session.LastFolder++];

				Invoke(new Action(() =>
				{
					L_Folders_Info.Text = item.Name;
					TaskbarProgress.SetValue(Handle, 2500 + 2500d * Data.Session.LastFolder / Data.Session.Folders.Count, 10000);
				}));

				var error = IconMatcher.Match(item);

				PGB_Folders.Percentage = 100d * Data.Session.LastFolder / Data.Session.Folders.Count;

				if (error != null)
				{
					Data.Session.StageErrors[2]++;
#if DEBUG
					Data.Session.Exceptions.Add(error);
#endif
				}
			}

			if (Data.Session.Stage == 2)
				Stage_3();
		}
#endregion

#region Stage 3 - Second Pass Matching
		private void Stage_3()
		{
			Data.Session.Stage = 3;
			Thread.Sleep(250);
			ColorLabels(FormDesign.Design);

			PGB_Folders.Percentage = 100;
			Invoke(new Action(() => 
			{
				if (Data.Session.Folders.Count > 0)
					L_Folders_Info.Text = $"Done, {Data.Session.Folders.Where(x => x.Match != null).Count()} / {Data.Session.Folders.Count} matches found";
				else
					L_Folders_Info.Text = $"Done, no Folders to match";
				L_SecondPass_Info.ForeColor = FormDesign.Design.InfoColor;
				if (Data.Session.StageErrors[2] > 0)
					L_Folders_Info.ForeColor = FormDesign.Design.RedColor;
				L_Folders_Info.Text += Data.Session.StageErrors[2] == 0 ? "." : $", {Data.Session.StageErrors[2]} errors occurred.";
				PB_Folders.Hide();
				PB_SecondPass.Show();
			}));

			Data.Session.SecondPassFolders.AddRange(Data.Session.Folders.Where(x => x?.Match == null));

			for (int i = 0; i < (Data.Session.SecondPassFolders.Count / 500).Between(1, MAX_RUNS); i++)
				WorkingThreads.Add(new Action(S3_Work).RunInBackground(THREAD_PRIORITY));
		}

		private void S3_Work()
		{
			while (Data.Session.Stage == 3 && Data.Session.SecondPassFolders.Count >= Data.Session.LastSecondPass + 1)
			{
				if (Data.Session.LastSecondPass >= Data.Session.SecondPassFolders.Count)
					break;

				var item = Data.Session.SecondPassFolders[Data.Session.LastSecondPass++];
				
				Invoke(new Action(() => 
				{
					L_SecondPass_Info.Text = item.Name;
					TaskbarProgress.SetValue(Handle, 5000 + 2500d * Data.Session.LastSecondPass / Data.Session.SecondPassFolders.Count, 10000);
				}));

				var error = IconMatcher.ReMatch(item);

				PGB_SecondPass.Percentage = 100d * Data.Session.LastSecondPass / Data.Session.SecondPassFolders.Count;

				if (error != null)
				{
					Data.Session.StageErrors[3]++;
#if DEBUG
					Data.Session.Exceptions.Add(error);
#endif
				}
			}

			if (Data.Session.Stage == 3)
				Stage_4();
		}
#endregion

#region Stage 4 - Apply
		private void Stage_4()
		{
			Data.Session.Stage = 4;
			Thread.Sleep(250);
			ColorLabels(FormDesign.Design);

			PGB_SecondPass.Percentage = 100;
			Invoke(new Action(() =>
			{
				if (Data.Session.SecondPassFolders.Count > 0)
					L_SecondPass_Info.Text = $"Done, {Data.Session.SecondPassFolders.Where(x => x.Match != null).Count()} / {Data.Session.SecondPassFolders.Count} matches found.";
				else
					L_SecondPass_Info.Text = $"Done, no need for Second Pass.";
				L_ApplyChanges_Info.ForeColor = FormDesign.Design.InfoColor;
				if (Data.Session.StageErrors[3] > 0)
					L_SecondPass_Info.ForeColor = FormDesign.Design.RedColor;
				L_SecondPass_Info.Text += Data.Session.StageErrors[3] == 0 ? "." : $", {Data.Session.StageErrors[3]} errors occurred.";
				PB_SecondPass.Hide();
				PB_Final.Show();
			}));

			try { BackEndWorker.CloseExplorerWindows(); }
			catch (Exception) { }

			for (int i = 0; i < (Data.Session.Files.Count / 500).Between(1, MAX_RUNS); i++)
				WorkingThreads.Add(new Action(S4_Work).RunInBackground(THREAD_PRIORITY));
		}

		private void S4_Work()
		{
			while (Data.Session.Stage == 4 && Data.Session.Files.Count >= Data.Session.LastProccessedFile + 1)
			{
				if (Data.Session.LastProccessedFile >= Data.Session.Files.Count)
					break;

				var item = Data.Session.Files[Data.Session.LastProccessedFile++];

				Invoke(new Action(() =>
				{
					L_ApplyChanges_Info.Text = item.Name;
					TaskbarProgress.SetValue(Handle, 7500 + 2500d * Data.Session.LastProccessedFile / Data.Session.Files.Count, 10000);
				}));

				var error = BackEndWorker.SetIcon(item);

				PGB_ApplyChanges.Percentage = 100d * Data.Session.LastProccessedFile / Data.Session.Files.Count;

				if (error != null)
				{
					Data.Session.StageErrors[4]++;
#if DEBUG
					Data.Session.Exceptions.Add(error);
#endif
				}
			}

			if (Data.Session.Stage == 4)
				End();
		}
#endregion

		private void End()
		{
			Data.Session.Stage = 5;
			try { BackEndWorker.RefreshIcons(); }
			catch (Exception) { }
			Thread.Sleep(250);

			Invoke(new Action(() =>
			{
				PGB_ApplyChanges.Percentage = 100;
				if (Data.Session.Errors == 0)
					L_ApplyChanges_Info.Text = "Done";
				else
					L_ApplyChanges_Info.Text = $"Done, {Data.Session.Errors}{(Data.Session.Errors == Data.Session.StageErrors[4] ? "" : " total")} errors occurred.";
				if (Data.Session.Errors > 0)
					L_ApplyChanges_Info.ForeColor = FormDesign.Design.RedColor;
				B_Abort.HueShade = null;
				B_Abort.Text = "Done";
				B_Abort.Image = Properties.Resources.Icon_Checkmark;
				PB_Final.Hide();
				TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.NoProgress);

				if (!FormIsActive)
					FlashWindow.Flash(this, 5);
			}));

#if DEBUG
			try
			{
				File.WriteAllText(@"C:\Users\DotCa\Desktop\AIC_LastMatches.txt", Data.Session.Files.Where(x => x.Match != null).Convert(x => "{\r\n" + $"    {x.ToString()}\r\n    {(x.Match == null ? "NULL" : x.Match.ToString())}" + "\r\n}\r\n").ListStrings());
				File.WriteAllText(@"C:\Users\DotCa\Desktop\AIC_Errors.txt", Data.Session.Exceptions.Where(x => x != null).Convert(x => $"--------------------------------------\r\n{x.ToString()}\r\n--------------------------------------\r\n\r\n").ListStrings());
			}
			catch (Exception) { }
#endif
		}
#endregion

		private void Exit()
		{
			Invoke(new Action(() =>
			{
				Data.MainForm.Show();
				Data.MainForm.Bounds = Bounds;

				foreach (var t in WorkingThreads)
					t.Abort();
			}));
			Thread.Sleep(5);
			Invoke(new Action(() => { Data.MainForm.ResetSession(); Close(); }));
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (Data.Session.Stage == 5 && !(B_Abort.Focused && keyData == Keys.Enter))
				Exit();
			return base.ProcessCmdKey(ref msg, keyData);
		}

#region Click Events
		private void B_Abort_Click(object sender, EventArgs e) => Exit();

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
						Point clientPoint = this.PointToClient(screenPoint);
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

		private void WorkForm_Resize(object sender, EventArgs e)
		{
			PGB_ApplyChanges.Width = PGB_Folders.Width = PGB_SecondPass.Width = PGB_Shortcuts.Width
				= Math.Min(Width * 9 / 10, 1500);
		}
	}
}
