namespace SiriusCodeCracker
{
	partial class StatisticsForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.StatisticsListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// StatisticsListBox
			// 
			this.StatisticsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StatisticsListBox.FormattingEnabled = true;
			this.StatisticsListBox.Location = new System.Drawing.Point(12, 14);
			this.StatisticsListBox.Name = "StatisticsListBox";
			this.StatisticsListBox.Size = new System.Drawing.Size(599, 264);
			this.StatisticsListBox.TabIndex = 0;
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 291);
			this.Controls.Add(this.StatisticsListBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatisticsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "StatisticsForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox StatisticsListBox;
	}
}