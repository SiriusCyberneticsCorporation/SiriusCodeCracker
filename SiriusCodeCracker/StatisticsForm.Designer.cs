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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.StatisticsDataGridView = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.StatisticsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// StatisticsDataGridView
			// 
			this.StatisticsDataGridView.AllowUserToAddRows = false;
			this.StatisticsDataGridView.AllowUserToDeleteRows = false;
			this.StatisticsDataGridView.AllowUserToResizeRows = false;
			this.StatisticsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StatisticsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.StatisticsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.StatisticsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
			this.StatisticsDataGridView.Location = new System.Drawing.Point(12, 12);
			this.StatisticsDataGridView.Name = "StatisticsDataGridView";
			this.StatisticsDataGridView.RowHeadersVisible = false;
			this.StatisticsDataGridView.Size = new System.Drawing.Size(602, 267);
			this.StatisticsDataGridView.TabIndex = 1;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "User";
			this.Column1.HeaderText = "Player";
			this.Column1.Name = "Column1";
			this.Column1.Width = 120;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "DateTime";
			this.Column2.HeaderText = "Date/Time";
			this.Column2.Name = "Column2";
			this.Column2.Width = 130;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "Rows";
			this.Column3.HeaderText = "Rows";
			this.Column3.Name = "Column3";
			this.Column3.Width = 50;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "Columns";
			this.Column4.HeaderText = "Columns";
			this.Column4.Name = "Column4";
			this.Column4.Width = 50;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "Time";
			dataGridViewCellStyle1.Format = "HH:mm:ss";
			dataGridViewCellStyle1.NullValue = null;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column5.HeaderText = "Time";
			this.Column5.Name = "Column5";
			this.Column5.Width = 70;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "Corrections";
			this.Column6.HeaderText = "Corrections";
			this.Column6.Name = "Column6";
			this.Column6.Width = 70;
			// 
			// Column7
			// 
			this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column7.DataPropertyName = "GivenWords";
			this.Column7.HeaderText = "Given Words";
			this.Column7.Name = "Column7";
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 291);
			this.Controls.Add(this.StatisticsDataGridView);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatisticsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "StatisticsForm";
			((System.ComponentModel.ISupportInitialize)(this.StatisticsDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView StatisticsDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
	}
}