using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Icons_3
{
	[DefaultEvent("CheckChanged")]
	public partial class MyCheckBox : UserControl
	{
		private bool _checked = true;
		private string checkedText = "Checked";
		private string uncheckedText = "Unchecked";

		public bool Checked
		{
			get => _checked;

			set
			{
				if (_checked != value)
				{
					_checked = value;
					label.Image = _checked ? Properties.Resources.Check_Checked : Properties.Resources.Check_Unchecked;
					label.Text = _checked ? checkedText : uncheckedText;
					CheckChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public string UncheckedText { get => uncheckedText; set { uncheckedText = value; Text = _checked ? checkedText : uncheckedText; } }

		public string CheckedText { get => checkedText; set { checkedText = value; Text = _checked ? checkedText : uncheckedText; } }

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public event EventHandler CheckChanged;

		public MyCheckBox()
		{
			InitializeComponent();
			Load += MyCheckBox_Load;
		}

		private void MyCheckBox_Load(object sender, EventArgs e)
		{
			label.ClickAction = new Action(OnClick);
			label.ActiveColor = () => Data.Design.ActiveColor;
			label.Text = _checked ? checkedText : uncheckedText;
		}

		private void OnClick() => Checked = !Checked;
	}
}
