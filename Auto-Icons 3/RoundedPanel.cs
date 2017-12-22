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

namespace Auto_Icons_3
{
	public partial class RoundedPanel : UserControl
	{
		private Control currentParent;
		private Control[] AssosiatedControls;
		private Func<Color> GetBackColor;

		public RoundedPanel()
		{
			InitializeComponent();
			(PB_C_1.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipX);
			(PB_C_2.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipXY);
			(PB_C_3.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipY);
		}

		private RoundedPanel(Control[] control, Func<Color> backColor)
		{
			InitializeComponent();
			(PB_C_1.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipX);
			(PB_C_2.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipXY);
			(PB_C_3.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipY);
			AssosiatedControls = control;
			GetBackColor = backColor;
			BackColor = GetBackColor();
			foreach (var item in AssosiatedControls)
			{
				item.BackColor = GetBackColor();


				item.BackColorChanged += (S, E) =>
				{
					if (!Disposing && Visible)
						item.BackColor = BackColor = GetBackColor();
				};
				item.Disposed += (s, et) => { Dispose(); };
				item.Layout += (l, t) =>
				{
					if (!Disposing)
					{
						Location = new Point(AssosiatedControls.Min(x => x.Location.X) - 5, AssosiatedControls.Min(x => x.Location.Y) - 5);
						Size = new Size(AssosiatedControls.Max(x => x.Location.X + x.Width) - Location.X + 5, AssosiatedControls.Max(x => x.Location.Y + x.Height) - Location.Y + 5);
					}
				};
			}
		}

		private static Dictionary<Control, RoundedPanel> dictionary = new Dictionary<Control, RoundedPanel>();
		public static void AddBackground(Control[] control, Func<Color> backColor)
		{
			if (!dictionary.ContainsKey(control.First()))
			{
				var pan = new RoundedPanel(control, backColor);
				dictionary.Add(control.First(), pan);
				control.First().Parent?.Controls.Add(pan);
				pan.Show();
				pan.BringToFront();
				foreach (var item in control)
					item.BringToFront();
				pan.Location = new Point(control.Min(x => x.Location.X) - 5, control.Min(x => x.Location.Y) - 5);
				pan.Size = new Size(control.Max(x => x.Location.X + x.Width) - pan.Location.X + 5, control.Max(x => x.Location.Y + x.Height) - pan.Location.Y + 5);
			}
			else
				dictionary[control.First()].Show();
		}

		public static void RemoveBackground(Control[] control)
		{
			if (dictionary.ContainsKey(control.First()))
			{
				dictionary[control.First()].Hide();
			}
		}

		private void RoundedPanel_Resize(object sender, EventArgs e)
		{
			PB_C_0.Size = PB_C_1.Size = PB_C_2.Size = PB_C_3.Size = new Size(Height.RelativeScale(35, 55, 10, 16), Height.RelativeScale(35, 55, 10, 16));
			PB_C_1.Location = new Point(Width - PB_C_1.Width, 0);
			PB_C_2.Location = new Point(Width - PB_C_2.Width, Height - PB_C_2.Height);
			PB_C_3.Location = new Point(0, Height - PB_C_2.Height);
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
		}

		private void RoundedPanel_Load(object sender, EventArgs e)
		{
			RoundedPanel_Resize(this, e);
			Refresh();
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

		private void RoundedPanel_VisibleChanged(object sender, EventArgs e)
		{
			if (AssosiatedControls != null)
				if (Visible)
					foreach (var item in AssosiatedControls)
						item.BackColor = GetBackColor();
				else
					foreach (var item in AssosiatedControls)
						item.BackColor = Color.Empty;
		}
	}
}
