using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using System.Text.RegularExpressions;

namespace Auto_Icons_3
{
	public enum ColorScheme { Active, Green }
	public partial class MyProgressBar : UserControl
	{
		private Control currentParent;
		private double perc = 0;
		private double targetPerc = 0;
		private double minStep = .5;
		private int GetWidth => (int)((perc * (Width - (2 * PB_C_0.Width)) / 100) + PB_C_0.Width);
		private ColorScheme scheme = ColorScheme.Active;
		private System.Timers.Timer timer = new System.Timers.Timer(35);

		public ColorScheme Scheme { get => scheme; set { scheme = value; Refresh(); } }
		public double Percentage { get => perc; set { targetPerc = Math.Min(100, value); timer.Start(); } }
		public double MinStep { get => minStep; set => minStep = value; }

		public MyProgressBar()
		{
			InitializeComponent();
			Size = new Size(500, 32);
			P_Bar.Width = PB_C_1.Width;
			(PB_C_1.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipX);
			(PB_C_2.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipXY);
			(PB_C_3.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipY);
		}

		private void RoundedPanel_Load(object sender, EventArgs e)
		{
			RoundedPanel_Resize(null, null);
			Refresh();
			timer.Elapsed += Timer_Elapsed;
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (targetPerc != perc || P_Bar.Width != GetWidth)
			{
				if (targetPerc - perc > 0)
					perc = Math.Min(targetPerc, perc + Math.Max(minStep, (targetPerc - perc) / 8d));
				else
					perc = Math.Max(targetPerc, perc - Math.Max(minStep, (perc - targetPerc) / 8d));
				try
				{
					Invoke(new Action(() =>
					{
						L_Perc.Text = Regex.Match(perc.ToString(), "^\\d{1,3}").Value + " %";
						P_Bar.Width = GetWidth;

						if (!L_Perc.Visible)
							L_Perc.Visible = true;

						if (perc > 0 && !PB_C_0.Visible)
							PB_C_0.Visible = PB_C_3.Visible = P_Bar.Visible = true;
						else if (perc == 0 && PB_C_0.Visible)
							PB_C_0.Visible = PB_C_3.Visible = P_Bar.Visible = false;

						if (perc < 5500 / Width)
						{
							L_Perc.Location = new Point(P_Bar.Width + 5, (Height - L_Perc.Height) / 2);
							L_Perc.BackColor = BackColor;
						}
						else
						{
							L_Perc.Location = new Point(P_Bar.Width - 5 - L_Perc.Width, (Height - L_Perc.Height) / 2);
							L_Perc.BackColor = (scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor);
						}

						if (perc == 100)
						{
							BackColor = (scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor);

							if (!PB_C_1.Visible)
								PB_C_1.Visible = PB_C_2.Visible = true;

							if (scheme != ColorScheme.Green)
								Scheme = ColorScheme.Green;
						}
						else
						{
							BackColor = Color.Empty;

							if (PB_C_1.Visible)
								PB_C_1.Visible = PB_C_2.Visible = false;

							if (scheme != ColorScheme.Active)
								Scheme = ColorScheme.Active;
						}

						PB_C_1.BackColor = PB_C_2.BackColor = perc != 100 ? Parent.BackColor : (scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor);
					}));
				}
				catch (Exception) { }

				if ((perc == 100 && targetPerc == 100) || (perc == 0 && targetPerc == 0))
					timer.Stop();
			}
		}

		private void RoundedPanel_Resize(object sender, EventArgs e)
		{
			PB_C_0.Size = PB_C_1.Size = PB_C_2.Size = PB_C_3.Size = new Size(Height.RelativeScale(35, 55, 10, 16), Height.RelativeScale(35, 55, 10, 16));
			PB_C_1.Location = new Point(Width - PB_C_1.Width, 0);
			PB_C_2.Location = new Point(Width - PB_C_2.Width, Height - PB_C_2.Height);
			PB_C_3.Location = new Point(0, Height - PB_C_2.Height);
			if (perc < 5500 / Width)
				L_Perc.Location = new Point(P_Bar.Width + 5, (Height - L_Perc.Height) / 2);
			else
				L_Perc.Location = new Point(P_Bar.Width - 5 - L_Perc.Width, (Height - L_Perc.Height) / 2); 
		}

		public override void Refresh()
		{
			if (Parent != null)
			{
				PB_C_0.Image = (PB_C_0.Image as Bitmap)?.Color(Parent.BackColor);
				PB_C_1.Image = (PB_C_1.Image as Bitmap)?.Color(Parent.BackColor);
				PB_C_2.Image = (PB_C_2.Image as Bitmap)?.Color(Parent.BackColor);
				PB_C_3.Image = (PB_C_3.Image as Bitmap)?.Color(Parent.BackColor);
			}
			PB_C_0.BackColor = PB_C_3.BackColor
				= P_Bar.BackColor = Scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor;
			if (perc != 100)
				PB_C_1.BackColor = PB_C_2.BackColor = Parent == null ? BackColor : Parent.BackColor;
			else
				PB_C_1.BackColor = PB_C_2.BackColor = Scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor;
			if (perc < 5500 / Width)
				L_Perc.BackColor = BackColor;
			else
				L_Perc.BackColor = (scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor);
			if (perc == 100)
				BackColor = (scheme == ColorScheme.Active ? FormDesign.Design.ActiveColor : FormDesign.Design.GreenColor);
			else
				BackColor = Color.Empty;
		}

		private void RoundedPanel_ParentChanged(object sender, EventArgs e)
		{
			if (currentParent != null)
				currentParent.BackColorChanged -= RoundedPanel_BackColorChanged;
			Refresh();
			currentParent = Parent;
			if (currentParent != null)
				currentParent.BackColorChanged += RoundedPanel_BackColorChanged;
		}

		private void RoundedPanel_BackColorChanged(object sender, EventArgs e) => Refresh();
	}
}
