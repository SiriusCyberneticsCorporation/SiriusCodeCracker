﻿namespace SiriusCodeCracker
{
	partial class GridDisplayUserControl
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
			this.SuspendLayout();
			// 
			// GridDisplayUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.DoubleBuffered = true;
			this.Name = "GridDisplayUserControl";
			this.Size = new System.Drawing.Size(738, 559);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GridDisplayUserControl_Paint);
			this.Enter += new System.EventHandler(this.GridDisplayUserControl_Enter);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridDisplayUserControl_MouseClick);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
