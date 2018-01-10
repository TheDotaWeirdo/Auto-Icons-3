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
	public enum BorderStyle { Auto = 0, Static = 1 }
	public enum DesignMode { Dark = 0, Light = 1 }

	[DefaultEvent("Click")]
	public partial class FlatButton : UserControl
	{
		private System.Timers.Timer ResetTimer = new System.Timers.Timer(10000);

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public new event EventHandler Click;
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override string Text { get => L_Label.Text; set { L_Label.Text = value; ForceResize(); } }

		private bool EnableGraphics = true;
		private float? hueShade = null;
		private int border = 3;
		private DesignMode[] designs = { Auto_Icons_3.DesignMode.Dark, Auto_Icons_3.DesignMode.Light, Auto_Icons_3.DesignMode.Dark };
		private BorderStyle borderStyle = BorderStyle.Auto;

		[Category("FormDesign.Design")]
		public PictureBoxSizeMode SizeMode { get => PB_Icon.SizeMode; set => PB_Icon.SizeMode = value; }
		[Category("Appearance")]
		public float? HueShade { get => hueShade; set => hueShade = value; }
		[Category("FormDesign.Design")]
		public new BorderStyle BorderStyle { get => borderStyle; set => borderStyle = value; }
		[Category("Appearance")]
		public Image Image { get => PB_Icon.Image; set { PB_Icon.Image = value; Refresh(FormDesign.Design); } }

		public FlatButton()
		{
			InitializeComponent();
			(PB_C_1.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipX);
			(PB_C_2.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipXY);
			(PB_C_3.Image as Bitmap).Rotate(RotateFlipType.RotateNoneFlipY);
		}

		public void ForceResize() => MyButton_Resize(null, null);

		public void Enable()
		{
			EnableGraphics = true;
			Cursor = PB_Icon.Cursor = L_Label.Cursor = Cursors.Hand;
		}

		public void Disable()
		{
			On_MouseLeave(this, null);
			EnableGraphics = false;
			Cursor = PB_Icon.Cursor = L_Label.Cursor = Cursors.Default;
		}

		private void MyButton_Resize(object sender, EventArgs e)
		{
			if (BorderStyle == BorderStyle.Auto)
				border = Width.RelativeScale(130, 220, 1, 3);
			PB_C_0.Size = PB_C_1.Size = PB_C_2.Size = PB_C_3.Size = new Size(Height.RelativeScale(35, 55, 10, 16), Height.RelativeScale(35, 55, 10, 16));
			PB_C_1.Location = new Point(Width - PB_C_1.Width, 0);
			PB_C_2.Location = new Point(Width - PB_C_2.Width, Height - PB_C_2.Height);
			PB_C_3.Location = new Point(0, Height - PB_C_2.Height);
			PB_Icon.Size = new Size(Math.Min(32, Height - 12), Math.Min(32, Height - 12));
			PB_Icon.Location = new Point(Width / 15, (Height - PB_Icon.Height) / 2);
			if (Image == null)
				L_Label.Location = new Point((Width - L_Label.Width) / 2, (Height - L_Label.Height) / 2);
			else
				L_Label.Location = new Point((Width - L_Label.Width - PB_Icon.Width - PB_Icon.Location.X) / 2 + PB_Icon.Width + PB_Icon.Location.X, (Height - L_Label.Height) / 2);
		}

		public void SetTooltip(ToolTip T, string Text)
		{
			T.SetToolTip(this, Text);
			T.SetToolTip(L_Label, Text);
			T.SetToolTip(PB_Icon, Text);
		}

		DisableIdentifier ClickIdentifier = new DisableIdentifier();
		private void OnClick(object sender, EventArgs e)
		{
			if (EnableGraphics && !ClickIdentifier.Disabled)
			{
				ClickIdentifier.Disable();
				new Action(() => Invoke(new Action(() =>
				{
					Click?.Invoke(this, e);
					ClickIdentifier.Enable();
				}))).RunInBackground(5);
			}
		}

		private void MyButton_FontChanged(object sender, EventArgs e)
		{
			L_Label.Font = Font;
			MyButton_Resize(this, e);
		}

		public void Refresh(FormDesign design)
		{
			switch (design.ID)
			{
				case 0: L_Label.ForeColor = design.ForeColor; BackColor = design.LightColor; break;
				case 1: L_Label.ForeColor = design.ForeColor; BackColor = design.LightColor; break;
				case 2: L_Label.ForeColor = design.ForeColor; BackColor = design.TitleColor.Tint(design.TitleColor, -2.5f); break;
				default:
					break;
			}
			if (Parent != null)
			{
				PB_C_0.Image = (PB_C_0.Image as Bitmap)?.Color(Parent.BackColor);
				PB_C_1.Image = (PB_C_1.Image as Bitmap)?.Color(Parent.BackColor);
				PB_C_2.Image = (PB_C_2.Image as Bitmap)?.Color(Parent.BackColor);
				PB_C_3.Image = (PB_C_3.Image as Bitmap)?.Color(Parent.BackColor);
			}
			PB_Icon.Image = (PB_Icon.Image as Bitmap)?.Color(L_Label.ForeColor);
			MyButton_Resize(null, null);
		}

		private void On_MouseEnter(object sender, EventArgs e)
		{
			if (!EnableGraphics) return;

			switch (FormDesign.Design.ID)
			{
				case 0: L_Label.ForeColor = FormDesign.Design.InfoColor.Tint(HueShade); BackColor = FormDesign.Design.DarkColor.Tint(HueShade); break;
				case 1: L_Label.ForeColor = FormDesign.Design.InfoColor.Tint(HueShade); BackColor = FormDesign.Design.TitleColor.Tint(HueShade); break;
				case 2: L_Label.ForeColor = FormDesign.Design.TitleForeColor.Tint(HueShade); BackColor = FormDesign.Design.LightColor.Tint(HueShade); break;
				default:
					break;
			}
			PB_Icon.Image = (PB_Icon.Image as Bitmap)?.Color(L_Label.ForeColor);
			ResetTimer.Stop();
		}

		private void On_MouseLeave(object sender, EventArgs e)
		{
			if (!EnableGraphics) return;

			switch (FormDesign.Design.ID)
			{
				case 0: L_Label.ForeColor = FormDesign.Design.ForeColor; BackColor = FormDesign.Design.LightColor; break;
				case 1: L_Label.ForeColor = FormDesign.Design.ForeColor; BackColor = FormDesign.Design.LightColor; break;
				case 2: L_Label.ForeColor = FormDesign.Design.ForeColor; BackColor = FormDesign.Design.TitleColor.Tint(FormDesign.Design.TitleColor, -2.5f); break;
				default:
					break;
			}
			PB_Icon.Image = (PB_Icon.Image as Bitmap)?.Color(L_Label.ForeColor);
			ResetTimer.Stop();
		}

		private void On_MouseDown(object sender, MouseEventArgs e)
		{
			if (!EnableGraphics) return;

			switch (FormDesign.Design.ID)
			{
				case 0: L_Label.ForeColor = FormDesign.Design.DarkColor.Tint(HueShade); BackColor = FormDesign.Design.ActiveColor.Tint(HueShade); break;
				case 1: L_Label.ForeColor = FormDesign.Design.ForeColor.Tint(HueShade); BackColor = FormDesign.Design.ActiveColor.Tint(HueShade); break;
				case 2: L_Label.ForeColor = FormDesign.Design.LightColor.Tint(HueShade); BackColor = FormDesign.Design.ActiveColor.Tint(HueShade); break;
				default:
					break;
			}
			PB_Icon.Image = (PB_Icon.Image as Bitmap)?.Color(L_Label.ForeColor);
			ResetTimer.Start();
		}

		private void On_MouseUp(object sender, MouseEventArgs e) => On_MouseEnter(sender, e);

		private void MyButton_Load(object sender, EventArgs e)
		{
			MyButton_Resize(this, e);
			FormDesign.DesignChanged += Refresh;
			Refresh(FormDesign.Design);
			ResetTimer.Elapsed += ResetTimer_Elapsed;
		}

		private void ResetTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) => On_MouseEnter(null, null);

		private void FlatButton_Layout(object sender, LayoutEventArgs e) => MyButton_Resize(sender, e);

		private Control lastParent;
		private void FlatButton_ParentChanged(object sender, EventArgs e)
		{
			if (lastParent != null)
				lastParent.BackColorChanged -= Parent_BackColorChanged;
			Parent.BackColorChanged += Parent_BackColorChanged;
			lastParent = Parent;
		}

		private void Parent_BackColorChanged(object sender, EventArgs e) => Refresh(FormDesign.Design);
	}
}
