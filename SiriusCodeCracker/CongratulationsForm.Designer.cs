namespace SiriusCodeCracker
{
	partial class CongratulationsForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.DurationLabel = new System.Windows.Forms.Label();
			this.ExtraLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(17, 201);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(439, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "You have unravelled the code!";
			// 
			// DurationLabel
			// 
			this.DurationLabel.AutoSize = true;
			this.DurationLabel.BackColor = System.Drawing.Color.Transparent;
			this.DurationLabel.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DurationLabel.Location = new System.Drawing.Point(122, 9);
			this.DurationLabel.Name = "DurationLabel";
			this.DurationLabel.Size = new System.Drawing.Size(142, 40);
			this.DurationLabel.TabIndex = 1;
			this.DurationLabel.Text = "Duration";
			// 
			// ExtraLabel
			// 
			this.ExtraLabel.AutoSize = true;
			this.ExtraLabel.BackColor = System.Drawing.Color.Transparent;
			this.ExtraLabel.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExtraLabel.Location = new System.Drawing.Point(54, 50);
			this.ExtraLabel.Name = "ExtraLabel";
			this.ExtraLabel.Size = new System.Drawing.Size(115, 33);
			this.ExtraLabel.TabIndex = 2;
			this.ExtraLabel.Text = "Duration";
			// 
			// CongratulationsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::SiriusCodeCracker.Properties.Resources.Congratulations;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(720, 293);
			this.ControlBox = false;
			this.Controls.Add(this.ExtraLabel);
			this.Controls.Add(this.DurationLabel);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CongratulationsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Puzzle Complete";
			this.Click += new System.EventHandler(this.CongratulationsForm_Click);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label DurationLabel;
		private System.Windows.Forms.Label ExtraLabel;
	}
}