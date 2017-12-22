using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace Auto_Icons_3
{
	[DefaultEvent("GridChanged")]
	public partial class TilePanel : FlowLayoutPanel
	{
		private int minimumWidth = 0;
		private int controlHeight = 0;
		private int targetWidth = 0;
		private bool center = true;
		private bool instantUpdate = false;

		public TilePanel()
		{
			Resize += TilePanel_LayoutChange;
			ControlAdded += TilePanel_ControlAdded;
		}

		public event EventHandler GridChanged;

		[Category("Layout")]
		public int MinimumWidth { get => minimumWidth; set => minimumWidth = value; }
		[Category("Layout")]
		public int ControlHeight { get => controlHeight; set => controlHeight = value; }
		[Category("Behavior")]
		public bool Center { get => center; set => center = value; }
		[Category("Behavior")]
		public bool InstantUpdate { get => instantUpdate; set => instantUpdate = value; }

		WaitIdentifier identifier = new WaitIdentifier();
		private void TilePanel_LayoutChange(object sender, EventArgs e)
		{
			if (Controls.Count == 0) return;
			if (instantUpdate)
				UpdateLayout();
			else
				identifier.Wait(new Action(() => Invoke(new Action(() => UpdateLayout()))), 80);
		}

		public void UpdateLayout()
		{
			if (Controls.Count == 0) return;
			SuspendLayout();

			var maxRows = Math.Floor(Width / (double)minimumWidth).Between(1, Controls.Count);
			var totCols = Math.Ceiling(Controls.Count / maxRows);

			if (center && maxRows % totCols < maxRows - 1)
				maxRows = Math.Ceiling(Controls.Count / totCols);

			var W = Width - (AutoScroll ? (maxRows * 5) : 0) - (((Controls[0].Height * totCols) > Height && AutoScroll) ? 15 : 0);
			targetWidth = (int)(Math.Floor(W / maxRows));
			foreach (Control item in Controls)
			{
				try { item.Invoke(new Action(() => item.Size = new Size(targetWidth, controlHeight))); }
				catch (Exception) { }
			}

			ResumeLayout();
			GridChanged?.Invoke(this, new EventArgs());
		}

		private void TilePanel_ControlAdded(object sender, ControlEventArgs e)
		{
			e.Control.Size = new Size(targetWidth, controlHeight);
			e.Control.Margin = new Padding(0);
		}

		public void RefreshControls()
		{
			foreach (Control item in Controls)
				item.Refresh();
		}

		private void TilePanel_Paint(object sender, PaintEventArgs e) => TilePanel_LayoutChange(null, null);
	}
}
