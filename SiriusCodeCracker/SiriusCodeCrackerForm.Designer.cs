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
			this.StartNewGameButton = new System.Windows.Forms.Button();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.HeaderButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ExtraLetterButton = new System.Windows.Forms.Button();
			this.StatisticsButton = new System.Windows.Forms.Button();
			this.WordDefinitionButton = new System.Windows.Forms.Button();
			this.CodeCrackerKeyBoard = new SiriusCodeCracker.KeyBoardUserControl();
			this.CrosswordGrid = new SiriusCodeCracker.GridDisplayUserControl();
			this.HeaderButtonsTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartNewGameButton
			// 
			this.StartNewGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.StartNewGameButton.Location = new System.Drawing.Point(16, 2);
			this.StartNewGameButton.Margin = new System.Windows.Forms.Padding(1);
			this.StartNewGameButton.Name = "StartNewGameButton";
			this.StartNewGameButton.Size = new System.Drawing.Size(90, 40);
			this.StartNewGameButton.TabIndex = 1;
			this.StartNewGameButton.Text = "Start New Game";
			this.StartNewGameButton.UseVisualStyleBackColor = true;
			this.StartNewGameButton.Click += new System.EventHandler(this.StartNewGameButton_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.SettingsButton.Location = new System.Drawing.Point(382, 2);
			this.SettingsButton.Margin = new System.Windows.Forms.Padding(1);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(90, 40);
			this.SettingsButton.TabIndex = 6;
			this.SettingsButton.Text = "Change Settings";
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// HeaderButtonsTableLayoutPanel
			// 
			this.HeaderButtonsTableLayoutPanel.ColumnCount = 5;
			this.HeaderButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.HeaderButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.HeaderButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.HeaderButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.HeaderButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.HeaderButtonsTableLayoutPanel.Controls.Add(this.ExtraLetterButton, 0, 0);
			this.HeaderButtonsTableLayoutPanel.Controls.Add(this.StatisticsButton, 1, 0);
			this.HeaderButtonsTableLayoutPanel.Controls.Add(this.StartNewGameButton, 0, 0);
			this.HeaderButtonsTableLayoutPanel.Controls.Add(this.SettingsButton, 3, 0);
			this.HeaderButtonsTableLayoutPanel.Controls.Add(this.WordDefinitionButton, 4, 0);
			this.HeaderButtonsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.HeaderButtonsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.HeaderButtonsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.HeaderButtonsTableLayoutPanel.Name = "HeaderButtonsTableLayoutPanel";
			this.HeaderButtonsTableLayoutPanel.RowCount = 1;
			this.HeaderButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.HeaderButtonsTableLayoutPanel.Size = new System.Drawing.Size(611, 44);
			this.HeaderButtonsTableLayoutPanel.TabIndex = 8;
			// 
			// ExtraLetterButton
			// 
			this.ExtraLetterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ExtraLetterButton.Location = new System.Drawing.Point(138, 2);
			this.ExtraLetterButton.Margin = new System.Windows.Forms.Padding(1);
			this.ExtraLetterButton.Name = "ExtraLetterButton";
			this.ExtraLetterButton.Size = new System.Drawing.Size(90, 40);
			this.ExtraLetterButton.TabIndex = 8;
			this.ExtraLetterButton.Text = "Extra Letter";
			this.ExtraLetterButton.UseVisualStyleBackColor = true;
			this.ExtraLetterButton.Click += new System.EventHandler(this.ExtraLetterButton_Click);
			// 
			// StatisticsButton
			// 
			this.StatisticsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.StatisticsButton.Location = new System.Drawing.Point(260, 2);
			this.StatisticsButton.Margin = new System.Windows.Forms.Padding(1);
			this.StatisticsButton.Name = "StatisticsButton";
			this.StatisticsButton.Size = new System.Drawing.Size(90, 40);
			this.StatisticsButton.TabIndex = 7;
			this.StatisticsButton.Text = "Statistics";
			this.StatisticsButton.UseVisualStyleBackColor = true;
			this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click);
			// 
			// WordDefinitionButton
			// 
			this.WordDefinitionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.WordDefinitionButton.Location = new System.Drawing.Point(504, 2);
			this.WordDefinitionButton.Margin = new System.Windows.Forms.Padding(1);
			this.WordDefinitionButton.Name = "WordDefinitionButton";
			this.WordDefinitionButton.Size = new System.Drawing.Size(90, 40);
			this.WordDefinitionButton.TabIndex = 9;
			this.WordDefinitionButton.Text = "Word Definition";
			this.WordDefinitionButton.UseVisualStyleBackColor = true;
			this.WordDefinitionButton.Click += new System.EventHandler(this.WordDefinitionButton_Click);
			// 
			// CodeCrackerKeyBoard
			// 
			this.CodeCrackerKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CodeCrackerKeyBoard.BackColor = System.Drawing.Color.Transparent;
			this.CodeCrackerKeyBoard.Location = new System.Drawing.Point(12, 542);
			this.CodeCrackerKeyBoard.Name = "CodeCrackerKeyBoard";
			this.CodeCrackerKeyBoard.Size = new System.Drawing.Size(587, 106);
			this.CodeCrackerKeyBoard.TabIndex = 7;
			// 
			// CrosswordGrid
			// 
			this.CrosswordGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CrosswordGrid.BackColor = System.Drawing.Color.White;
			this.CrosswordGrid.Location = new System.Drawing.Point(12, 47);
			this.CrosswordGrid.Name = "CrosswordGrid";
			this.CrosswordGrid.Size = new System.Drawing.Size(587, 489);
			this.CrosswordGrid.TabIndex = 0;
			// 
			// SiriusCodeCrackerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 660);
			this.Controls.Add(this.HeaderButtonsTableLayoutPanel);
			this.Controls.Add(this.CodeCrackerKeyBoard);
			this.Controls.Add(this.CrosswordGrid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "SiriusCodeCrackerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sirius Code Cracker";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SiriusCodeCrackerForm_KeyDown);
			this.Resize += new System.EventHandler(this.SiriusCodeCrackerForm_Resize);
			this.HeaderButtonsTableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private GridDisplayUserControl CrosswordGrid;
		private System.Windows.Forms.Button StartNewGameButton;
		private System.Windows.Forms.Button SettingsButton;
		private KeyBoardUserControl CodeCrackerKeyBoard;
		private System.Windows.Forms.TableLayoutPanel HeaderButtonsTableLayoutPanel;
		private System.Windows.Forms.Button StatisticsButton;
		private System.Windows.Forms.Button ExtraLetterButton;
		private System.Windows.Forms.Button WordDefinitionButton;
	}
}

