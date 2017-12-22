using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Data.DesignChanged += MainForm_DesignChanged;
			MainForm_DesignChanged(null, null);
			browseDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (Directory.Exists("C:\\Icons"))
				new Action(() => Invoke(new Action(() => TB_IconPath.Text = "C:\\Icons"))).RunInBackground(5);
		}

		private void MainForm_DesignChanged(object sender, EventArgs e)
		{
			BackColor = FormState.Normal(FormIsActive).Color(Data.Design);
			TLP_Main.BackColor = Data.Design.BackColor;
			ForeColor = Data.Design.ForeColor;
			P_Title.BackColor = Data.Design.TitleColor;
			L_Title.ForeColor = Data.Design.TitleForeColor;
			P_Spacer_1.BackColor = P_Spacer_2.BackColor = P_Spacer_3.BackColor = P_Spacer_4.BackColor = Data.Design.LightColor;
			L_FolderPath.ForeColor = L_IconPath.ForeColor = L_IconsDetected.ForeColor = L_IconVersion.ForeColor = L_Options.ForeColor = Data.Design.LabelColor;
			PB_Icon.Image = (PB_Icon.Image as Bitmap).Color(Data.Design.IconColor);
			B_Min.Image = (B_Min.Image as Bitmap).Color(Data.Design.GreenColor);
			B_Max.Image = (B_Max.Image as Bitmap).Color(Data.Design.YellowColor);
			B_Close.Image = (B_Close.Image as Bitmap).Color(Data.Design.RedColor);
		}

		#region Click Events
		private void B_IconPath_Click(object sender, EventArgs e)
		{
			browseDialog.ShowDialog().ToString();
			TB_IconPath.Text = browseDialog.SelectedPath;
		}

		private void B_FolderPath_Click(object sender, EventArgs e)
		{
			browseDialog.ShowDialog().ToString();
			TB_FolderPath.Text = browseDialog.SelectedPath;
		}

		private void PB_Icon_Click(object sender, EventArgs e) => Data.Design = Data.Design.Switch();

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
			set { currentFormState = value; Invoke(new Action(() => { BackColor = value.Color(Data.Design); })); }
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

		#region Move/Reize
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

		#region Resize Events
		private void TLP_1_Resize(object sender, EventArgs e) => TB_IconPath.Width = TLP_1.Width;

		private void TLP_2_Resize(object sender, EventArgs e) => TB_FolderPath.Width = TLP_2.Width;
		#endregion

		private void TB_FolderPath_TextChanged(object sender, EventArgs e)
		{
			double.TryParse(TB_FolderPath.Text, out var p);
			myProgressBar1.Percentage = p;
		}
	}
}
