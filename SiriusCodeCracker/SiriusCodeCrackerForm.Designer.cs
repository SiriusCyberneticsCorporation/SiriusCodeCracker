namespace SiriusCodeCracker
{
	partial class SiriusCodeCrackerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiriusCodeCrackerForm));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.CodeCrackerKeyBoard = new SiriusCodeCracker.KeyBoardUserControl();
			this.CrosswordGrid = new SiriusCodeCracker.GridDisplayUserControl();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.Location = new System.Drawing.Point(382, 18);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button2.Location = new System.Drawing.Point(463, 18);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Settings";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// CodeCrackerKeyBoard
			// 
			this.CodeCrackerKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CodeCrackerKeyBoard.BackColor = System.Drawing.Color.Transparent;
			this.CodeCrackerKeyBoard.Location = new System.Drawing.Point(12, 523);
			this.CodeCrackerKeyBoard.Name = "CodeCrackerKeyBoard";
			this.CodeCrackerKeyBoard.Size = new System.Drawing.Size(580, 106);
			this.CodeCrackerKeyBoard.TabIndex = 7;
			// 
			// CrosswordGrid
			// 
			this.CrosswordGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CrosswordGrid.BackColor = System.Drawing.Color.White;
			this.CrosswordGrid.Location = new System.Drawing.Point(12, 63);
			this.CrosswordGrid.Name = "CrosswordGrid";
			this.CrosswordGrid.Size = new System.Drawing.Size(580, 454);
			this.CrosswordGrid.TabIndex = 0;
			// 
			// SiriusCodeCrackerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 641);
			this.Controls.Add(this.CodeCrackerKeyBoard);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.CrosswordGrid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "SiriusCodeCrackerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sirius Code Cracker";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SiriusCodeCrackerForm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SiriusCodeCrackerForm_KeyPress);
			this.ResumeLayout(false);

		}

		#endregion

		private GridDisplayUserControl CrosswordGrid;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private KeyBoardUserControl CodeCrackerKeyBoard;
	}
}

