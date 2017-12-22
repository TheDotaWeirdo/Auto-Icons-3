namespace Auto_Icons_3
{
	partial class MyProgressBar
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
			this.PB_C_0 = new System.Windows.Forms.PictureBox();
			this.PB_C_1 = new System.Windows.Forms.PictureBox();
			this.PB_C_3 = new System.Windows.Forms.PictureBox();
			this.PB_C_2 = new System.Windows.Forms.PictureBox();
			this.P_Bar = new System.Windows.Forms.Panel();
			this.L_Perc = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_0)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_2)).BeginInit();
			this.SuspendLayout();
			// 
			// PB_C_0
			// 
			this.PB_C_0.Image = global::Auto_Icons_3.Properties.Resources.Corner;
			this.PB_C_0.Location = new System.Drawing.Point(0, 0);
			this.PB_C_0.Name = "PB_C_0";
			this.PB_C_0.Size = new System.Drawing.Size(16, 16);
			this.PB_C_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_C_0.TabIndex = 8;
			this.PB_C_0.TabStop = false;
			// 
			// PB_C_1
			// 
			this.PB_C_1.Image = global::Auto_Icons_3.Properties.Resources.Corner;
			this.PB_C_1.Location = new System.Drawing.Point(164, 3);
			this.PB_C_1.Name = "PB_C_1";
			this.PB_C_1.Size = new System.Drawing.Size(16, 16);
			this.PB_C_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_C_1.TabIndex = 9;
			this.PB_C_1.TabStop = false;
			// 
			// PB_C_3
			// 
			this.PB_C_3.Image = global::Auto_Icons_3.Properties.Resources.Corner;
			this.PB_C_3.Location = new System.Drawing.Point(2, 74);
			this.PB_C_3.Name = "PB_C_3";
			this.PB_C_3.Size = new System.Drawing.Size(16, 16);
			this.PB_C_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_C_3.TabIndex = 11;
			this.PB_C_3.TabStop = false;
			// 
			// PB_C_2
			// 
			this.PB_C_2.Image = global::Auto_Icons_3.Properties.Resources.Corner;
			this.PB_C_2.Location = new System.Drawing.Point(164, 77);
			this.PB_C_2.Name = "PB_C_2";
			this.PB_C_2.Size = new System.Drawing.Size(16, 16);
			this.PB_C_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_C_2.TabIndex = 10;
			this.PB_C_2.TabStop = false;
			// 
			// P_Bar
			// 
			this.P_Bar.Dock = System.Windows.Forms.DockStyle.Left;
			this.P_Bar.Location = new System.Drawing.Point(0, 0);
			this.P_Bar.Name = "P_Bar";
			this.P_Bar.Size = new System.Drawing.Size(158, 93);
			this.P_Bar.TabIndex = 12;
			// 
			// L_Perc
			// 
			this.L_Perc.AutoSize = true;
			this.L_Perc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.L_Perc.Location = new System.Drawing.Point(144, 38);
			this.L_Perc.Name = "L_Perc";
			this.L_Perc.Size = new System.Drawing.Size(36, 19);
			this.L_Perc.TabIndex = 0;
			this.L_Perc.Text = "0 %";
			this.L_Perc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MyProgressBar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.L_Perc);
			this.Controls.Add(this.PB_C_0);
			this.Controls.Add(this.PB_C_1);
			this.Controls.Add(this.PB_C_3);
			this.Controls.Add(this.PB_C_2);
			this.Controls.Add(this.P_Bar);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("Century Gothic", 14.25F);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.Name = "MyProgressBar";
			this.Size = new System.Drawing.Size(182, 93);
			this.Load += new System.EventHandler(this.RoundedPanel_Load);
			this.BackColorChanged += new System.EventHandler(this.RoundedPanel_BackColorChanged);
			this.Resize += new System.EventHandler(this.RoundedPanel_Resize);
			this.ParentChanged += new System.EventHandler(this.RoundedPanel_ParentChanged);
			((System.ComponentModel.ISupportInitialize)(this.PB_C_0)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PB_C_2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PB_C_0;
		private System.Windows.Forms.PictureBox PB_C_1;
		private System.Windows.Forms.PictureBox PB_C_3;
		private System.Windows.Forms.PictureBox PB_C_2;
		private System.Windows.Forms.Panel P_Bar;
		private System.Windows.Forms.Label L_Perc;
	}
}
