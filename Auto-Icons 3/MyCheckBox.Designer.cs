namespace Auto_Icons_3
{
	partial class MyCheckBox
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label = new Auto_Icons_3.MyLabel();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.ActiveColor = null;
			this.label.AutoSize = true;
			this.label.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.label.Bold = true;
			this.label.BringToFrontOnMouseDown = true;
			this.label.Center = false;
			this.label.ClickAction = null;
			this.label.Cursor = System.Windows.Forms.Cursors.Default;
			this.label.Image = global::Auto_Icons_3.Properties.Resources.Check_Checked;
			this.label.Location = new System.Drawing.Point(0, 0);
			this.label.MinimumIconSize = 26;
			this.label.MinimumSize = new System.Drawing.Size(0, 34);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(98, 34);
			this.label.TabIndex = 0;
			this.label.Text = "myLabel1";
			// 
			// MyCheckBox
			// 
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.label);
			this.Name = "MyCheckBox";
			this.Size = new System.Drawing.Size(101, 37);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MyLabel label;
	}
}
