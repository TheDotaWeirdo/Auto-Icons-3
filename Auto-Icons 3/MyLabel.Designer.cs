namespace Auto_Icons_3
{
	partial class MyLabel
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
			this.Label = new System.Windows.Forms.Label();
			this.Icon = new System.Windows.Forms.PictureBox();
			this.RoundedBack = new Auto_Icons_3.RoundedPanel();
			((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
			this.SuspendLayout();
			// 
			// Label
			// 
			this.Label.AutoSize = true;
			this.Label.Location = new System.Drawing.Point(46, 17);
			this.Label.Name = "Label";
			this.Label.Size = new System.Drawing.Size(35, 13);
			this.Label.TabIndex = 0;
			this.Label.Text = "label1";
			// 
			// Icon
			// 
			this.Icon.Location = new System.Drawing.Point(4, 4);
			this.Icon.Name = "Icon";
			this.Icon.Size = new System.Drawing.Size(35, 38);
			this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Icon.TabIndex = 1;
			this.Icon.TabStop = false;
			// 
			// RoundedBack
			// 
			this.RoundedBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.RoundedBack.BackColor = System.Drawing.Color.Violet;
			this.RoundedBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RoundedBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RoundedBack.Font = new System.Drawing.Font("Century Gothic", 14.25F);
			this.RoundedBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.RoundedBack.Location = new System.Drawing.Point(0, 0);
			this.RoundedBack.Name = "RoundedBack";
			this.RoundedBack.Size = new System.Drawing.Size(84, 45);
			this.RoundedBack.TabIndex = 2;
			// 
			// MyLabel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.Label);
			this.Controls.Add(this.Icon);
			this.Controls.Add(this.RoundedBack);
			this.Name = "MyLabel";
			this.Size = new System.Drawing.Size(84, 45);
			this.Load += new System.EventHandler(this.MyLabel_Load);
			this.FontChanged += new System.EventHandler(this.MyLabel_FontChanged);
			this.ForeColorChanged += new System.EventHandler(this.MyLabel_FontChanged);
			this.Click += new System.EventHandler(this.MyLabel_Click);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseDown);
			this.MouseEnter += new System.EventHandler(this.MyLabel_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.MyLabel_MouseLeave);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseUp);
			this.Resize += new System.EventHandler(this.MyLabel_Resize);
			((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Label;
		private System.Windows.Forms.PictureBox Icon;
		private RoundedPanel RoundedBack;
	}
}
