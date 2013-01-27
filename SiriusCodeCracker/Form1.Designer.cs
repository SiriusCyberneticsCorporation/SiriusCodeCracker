namespace SiriusCodeCracker
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.ColumnsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.RowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.button2 = new System.Windows.Forms.Button();
			this.keyBoardUserControl1 = new SiriusCodeCracker.KeyBoardUserControl();
			this.CrosswordGrid = new SiriusCodeCracker.GridDisplayUserControl();
			((System.ComponentModel.ISupportInitialize)(this.ColumnsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RowsNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.Location = new System.Drawing.Point(375, 18);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ColumnsNumericUpDown
			// 
			this.ColumnsNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ColumnsNumericUpDown.Location = new System.Drawing.Point(153, 21);
			this.ColumnsNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.ColumnsNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.ColumnsNumericUpDown.Name = "ColumnsNumericUpDown";
			this.ColumnsNumericUpDown.Size = new System.Drawing.Size(63, 20);
			this.ColumnsNumericUpDown.TabIndex = 2;
			this.ColumnsNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.ColumnsNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(100, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Columns";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(238, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Rows";
			// 
			// RowsNumericUpDown
			// 
			this.RowsNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.RowsNumericUpDown.Location = new System.Drawing.Point(286, 21);
			this.RowsNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.RowsNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.RowsNumericUpDown.Name = "RowsNumericUpDown";
			this.RowsNumericUpDown.Size = new System.Drawing.Size(63, 20);
			this.RowsNumericUpDown.TabIndex = 4;
			this.RowsNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.RowsNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button2.Location = new System.Drawing.Point(456, 18);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "NEXT";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// keyBoardUserControl1
			// 
			this.keyBoardUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.keyBoardUserControl1.BackColor = System.Drawing.Color.Transparent;
			this.keyBoardUserControl1.Location = new System.Drawing.Point(12, 504);
			this.keyBoardUserControl1.Name = "keyBoardUserControl1";
			this.keyBoardUserControl1.Size = new System.Drawing.Size(567, 106);
			this.keyBoardUserControl1.TabIndex = 7;
			// 
			// CrosswordGrid
			// 
			this.CrosswordGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CrosswordGrid.BackColor = System.Drawing.Color.White;
			this.CrosswordGrid.Location = new System.Drawing.Point(12, 63);
			this.CrosswordGrid.Name = "CrosswordGrid";
			this.CrosswordGrid.NumberOfColumns = 13;
			this.CrosswordGrid.NumberOfRows = 13;
			this.CrosswordGrid.Size = new System.Drawing.Size(567, 435);
			this.CrosswordGrid.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 622);
			this.Controls.Add(this.keyBoardUserControl1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RowsNumericUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ColumnsNumericUpDown);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.CrosswordGrid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.ColumnsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RowsNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GridDisplayUserControl CrosswordGrid;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown ColumnsNumericUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown RowsNumericUpDown;
		private System.Windows.Forms.Button button2;
		private KeyBoardUserControl keyBoardUserControl1;
	}
}

