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
using System.Drawing.Imaging;

namespace Auto_Icons_3
{
	public partial class MyLabel : UserControl
	{
		private bool bold;
		private Func<Color> activeColor;
		private Action clickAction = null;
		private int minimumIconSize = 24;
		private bool enableGraphics = true;
		private bool center = false;
		private bool selected = false;
		private bool bringToFrontOnMouseDown = true;

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override string Text { get => Label.Text; set { Label.Text = value; Label.Visible = value != ""; ForceResize(); } }

		public bool Bold { get => bold; set { bold = value; Refresh(); } }

		public Func<Color> ActiveColor { get => activeColor; set => activeColor = value; }

		public Action ClickAction
		{
			get => clickAction;
			set
			{
				clickAction = value;
				Cursor = Icon.Cursor = Label.Cursor = RoundedBack.Cursor = value != null && enableGraphics ? Cursors.Hand : Cursors.Default;
			}
		}

		public Image Image
		{
			get => Icon.Image;
			set { Icon.Image = value; Icon.Visible = value != null; ForceResize(); Refresh(); }
		}

		private bool EnableGraphics => enableGraphics && clickAction != null;

		private bool IsPicture => Image == null || Image.RawFormat.Guid != ImageFormat.Gif.Guid;

		public int MinimumIconSize { get => minimumIconSize; set { minimumIconSize = value; MinimumSize = new Size(0, value + 8); } }

		public bool Center { get => center; set { center = value; ForceResize(); } }

		public bool BringToFrontOnMouseDown { get => bringToFrontOnMouseDown; set => bringToFrontOnMouseDown = value; }

		public MyLabel()
		{
			InitializeComponent();
		}

		public void Enable()
		{
			enableGraphics = true;
			Cursor = Icon.Cursor = Label.Cursor = RoundedBack.Cursor = clickAction != null && enableGraphics ? Cursors.Hand : Cursors.Default;
		}

		public void Disable()
		{
			enableGraphics = false;
			Cursor = Icon.Cursor = Label.Cursor = RoundedBack.Cursor = clickAction != null && enableGraphics ? Cursors.Hand : Cursors.Default;
		}

		public void Select_()
		{
			Refresh();
			MyLabel_MouseDown(null, null);
			selected = true;
		}

		public void Deselect_()
		{
			selected = false;
			Refresh();
		}

		public void ForceResize() => MyLabel_Resize(null, null);

		private void MyLabel_Load(object sender, EventArgs e)
		{
			Refresh();
			ForceResize();
			Label.MouseEnter += MyLabel_MouseEnter;
			Icon.MouseEnter += MyLabel_MouseEnter;
			RoundedBack.MouseEnter += MyLabel_MouseEnter;
			Label.MouseLeave += MyLabel_MouseLeave;
			Icon.MouseLeave += MyLabel_MouseLeave;
			RoundedBack.MouseLeave += MyLabel_MouseLeave;
			Label.MouseDown += MyLabel_MouseDown;
			Icon.MouseDown += MyLabel_MouseDown;
			RoundedBack.MouseDown += MyLabel_MouseDown;
			Label.MouseUp += MyLabel_MouseUp;
			Icon.MouseUp += MyLabel_MouseUp;
			RoundedBack.MouseUp += MyLabel_MouseUp;
			Label.Click += MyLabel_Click;
			Icon.Click += MyLabel_Click;
			RoundedBack.Click += MyLabel_Click;
		}

		private void MyLabel_Resize(object sender, EventArgs e)
		{
			Icon.Size = new Size(Math.Max(MinimumIconSize, Height - 8), Math.Max(MinimumIconSize, Height - 8));
			if (center && MinimumSize.Width != 0)
			{
				if (Image == null)
					Label.Location = new Point(5 + (Width - Label.Width) / 2, (Height - Label.Height) / 2);
				else
					Label.Location = new Point(5 + (Width - Label.Width - Icon.Width - 4) / 2 + Icon.Width + 4, (Height - Label.Height) / 2);
			}
			else
			{
				if (Image == null)
					Label.Location = new Point(9, (Height - Label.Height) / 2);
				else
					Label.Location = new Point(5 + Icon.Width + 4, (Height - Label.Height) / 2);
			}
		}

		public override void Refresh()
		{
			if (!selected)
			{
				RoundedBack.BackColor = Label.BackColor = Icon.BackColor = Label.ForeColor = Color.Empty;
				Label.Font = new Font(Font, Bold ? FontStyle.Bold : FontStyle.Regular);
			}
			else
			{
				selected = false;
				MyLabel_MouseDown(null, null);
				selected = true;
			}
			if (IsPicture)
				Icon.Image = (Icon.Image as Bitmap).Color(ForeColor);
		}

		private void MyLabel_MouseEnter(object sender, EventArgs e)
		{
			if (EnableGraphics && !selected)
			{
				Label.Font = new Font(Font, FontStyle.Underline | (Bold ? FontStyle.Bold : FontStyle.Regular));
				if (IsPicture && activeColor != null)
					Icon.Image = (Icon.Image as Bitmap).Color(activeColor());
				if (activeColor != null)
					Label.ForeColor = activeColor();
			}
		}

		private void MyLabel_MouseDown(object sender, MouseEventArgs e)
		{
			if (EnableGraphics && !selected)
			{
				if (BringToFrontOnMouseDown)
					BringToFront();
				if (Parent != null && Parent.BackColor == FormDesign.Design.LightColor)
				{
					if (activeColor != null)
						RoundedBack.BackColor = Label.BackColor = Icon.BackColor = (FormDesign.Design.ID != 2 ? FormDesign.Design.BackColor : FormDesign.Design.DarkColor).Tint(ActiveColor());
					else
						RoundedBack.BackColor = Label.BackColor = Icon.BackColor = FormDesign.Design.ID != 2 ? FormDesign.Design.BackColor : FormDesign.Design.DarkColor;
				}
				else
				{
					if (activeColor != null)
						RoundedBack.BackColor = Label.BackColor = Icon.BackColor = (FormDesign.Design.ID != 2 ? FormDesign.Design.LightColor : FormDesign.Design.DarkColor).Tint(ActiveColor());
					else
						RoundedBack.BackColor = Label.BackColor = Icon.BackColor = FormDesign.Design.ID != 2 ? FormDesign.Design.LightColor : FormDesign.Design.DarkColor;
				}
			}
		}

		private void MyLabel_MouseUp(object sender, MouseEventArgs e)
		{
			if (EnableGraphics && !selected)
				RoundedBack.BackColor = Label.BackColor = Icon.BackColor = Color.Empty;
		}

		private void MyLabel_MouseLeave(object sender, EventArgs e)
		{
			if (enableGraphics)
				Refresh();
		}

		private void MyLabel_Click(object sender, EventArgs e)
		{
			if (EnableGraphics)
				clickAction?.Invoke();
		}

		private void MyLabel_FontChanged(object sender, EventArgs e) => Refresh();
	}
}
