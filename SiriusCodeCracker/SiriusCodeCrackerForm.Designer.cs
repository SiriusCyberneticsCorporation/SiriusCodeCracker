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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiriusCodeCrackerForm));
			this.StartNewGameButton = new System.Windows.Forms.Button();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.ExtraLetterButton = new System.Windows.Forms.Button();
			this.StatisticsButton = new System.Windows.Forms.Button();
			this.WordDefinitionButton = new System.Windows.Forms.Button();
			this.PlayerPanel = new System.Windows.Forms.Panel();
			this.PlayerComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CurrentGameLabel = new System.Windows.Forms.Label();
			this.SecondTimer = new System.Windows.Forms.Timer(this.components);
			this.GridPanel = new System.Windows.Forms.Panel();
			this.CrosswordGrid = new SiriusCodeCracker.GridDisplayUserControl();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.CodeCrackerKeyBoard = new SiriusCodeCracker.KeyBoardUserControl();
			this.PlayerPanel.SuspendLayout();
			this.GridPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartNewGameButton
			// 
			this.StartNewGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.StartNewGameButton.Location = new System.Drawing.Point(2, 4);
			this.StartNewGameButton.Margin = new System.Windows.Forms.Padding(2);
			this.StartNewGameButton.Name = "StartNewGameButton";
			this.StartNewGameButton.Size = new System.Drawing.Size(94, 30);
			this.StartNewGameButton.TabIndex = 1;
			this.StartNewGameButton.Text = "New Game";
			this.StartNewGameButton.UseVisualStyleBackColor = true;
			this.StartNewGameButton.Click += new System.EventHandler(this.StartNewGameButton_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.SettingsButton.Location = new System.Drawing.Point(296, 4);
			this.SettingsButton.Margin = new System.Windows.Forms.Padding(2);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(94, 30);
			this.SettingsButton.TabIndex = 6;
			this.SettingsButton.Text = "Settings";
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// ExtraLetterButton
			// 
			this.ExtraLetterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.ExtraLetterButton.Location = new System.Drawing.Point(100, 4);
			this.ExtraLetterButton.Margin = new System.Windows.Forms.Padding(2);
			this.ExtraLetterButton.Name = "ExtraLetterButton";
			this.ExtraLetterButton.Size = new System.Drawing.Size(94, 30);
			this.ExtraLetterButton.TabIndex = 8;
			this.ExtraLetterButton.Text = "Extra Letter";
			this.ExtraLetterButton.UseVisualStyleBackColor = true;
			this.ExtraLetterButton.Click += new System.EventHandler(this.ExtraLetterButton_Click);
			// 
			// StatisticsButton
			// 
			this.StatisticsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.StatisticsButton.Location = new System.Drawing.Point(198, 4);
			this.StatisticsButton.Margin = new System.Windows.Forms.Padding(2);
			this.StatisticsButton.Name = "StatisticsButton";
			this.StatisticsButton.Size = new System.Drawing.Size(94, 30);
			this.StatisticsButton.TabIndex = 7;
			this.StatisticsButton.Text = "Statistics";
			this.StatisticsButton.UseVisualStyleBackColor = true;
			this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click);
			// 
			// WordDefinitionButton
			// 
			this.WordDefinitionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.WordDefinitionButton.Location = new System.Drawing.Point(394, 4);
			this.WordDefinitionButton.Margin = new System.Windows.Forms.Padding(2);
			this.WordDefinitionButton.Name = "WordDefinitionButton";
			this.WordDefinitionButton.Size = new System.Drawing.Size(94, 30);
			this.WordDefinitionButton.TabIndex = 9;
			this.WordDefinitionButton.Text = "Word Definition";
			this.WordDefinitionButton.UseVisualStyleBackColor = true;
			this.WordDefinitionButton.Click += new System.EventHandler(this.WordDefinitionButton_Click);
			// 
			// PlayerPanel
			// 
			this.PlayerPanel.AutoSize = true;
			this.PlayerPanel.Controls.Add(this.PlayerComboBox);
			this.PlayerPanel.Controls.Add(this.label1);
			this.PlayerPanel.Location = new System.Drawing.Point(494, 4);
			this.PlayerPanel.Margin = new System.Windows.Forms.Padding(4);
			this.PlayerPanel.Name = "PlayerPanel";
			this.PlayerPanel.Size = new System.Drawing.Size(263, 30);
			this.PlayerPanel.TabIndex = 10;
			// 
			// PlayerComboBox
			// 
			this.PlayerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlayerComboBox.FormattingEnabled = true;
			this.PlayerComboBox.Location = new System.Drawing.Point(66, 4);
			this.PlayerComboBox.Name = "PlayerComboBox";
			this.PlayerComboBox.Size = new System.Drawing.Size(194, 23);
			this.PlayerComboBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Player";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CurrentGameLabel
			// 
			this.CurrentGameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.CurrentGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CurrentGameLabel.Location = new System.Drawing.Point(765, 4);
			this.CurrentGameLabel.Margin = new System.Windows.Forms.Padding(4);
			this.CurrentGameLabel.Name = "CurrentGameLabel";
			this.CurrentGameLabel.Size = new System.Drawing.Size(314, 28);
			this.CurrentGameLabel.TabIndex = 2;
			this.CurrentGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CurrentGameLabel.Visible = false;
			// 
			// SecondTimer
			// 
			this.SecondTimer.Enabled = true;
			this.SecondTimer.Interval = 1000;
			this.SecondTimer.Tick += new System.EventHandler(this.SecondTimer_Tick);
			// 
			// GridPanel
			// 
			this.GridPanel.Controls.Add(this.CrosswordGrid);
			this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridPanel.Location = new System.Drawing.Point(0, 38);
			this.GridPanel.Name = "GridPanel";
			this.GridPanel.Size = new System.Drawing.Size(1097, 516);
			this.GridPanel.TabIndex = 9;
			this.GridPanel.SizeChanged += new System.EventHandler(this.GridPanel_SizeChanged);
			// 
			// CrosswordGrid
			// 
			this.CrosswordGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CrosswordGrid.BackColor = System.Drawing.Color.White;
			this.CrosswordGrid.Location = new System.Drawing.Point(18, 0);
			this.CrosswordGrid.Name = "CrosswordGrid";
			this.CrosswordGrid.Size = new System.Drawing.Size(955, 510);
			this.CrosswordGrid.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.StartNewGameButton);
			this.flowLayoutPanel1.Controls.Add(this.ExtraLetterButton);
			this.flowLayoutPanel1.Controls.Add(this.StatisticsButton);
			this.flowLayoutPanel1.Controls.Add(this.SettingsButton);
			this.flowLayoutPanel1.Controls.Add(this.WordDefinitionButton);
			this.flowLayoutPanel1.Controls.Add(this.PlayerPanel);
			this.flowLayoutPanel1.Controls.Add(this.CurrentGameLabel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1097, 38);
			this.flowLayoutPanel1.TabIndex = 10;
			// 
			// CodeCrackerKeyBoard
			// 
			this.CodeCrackerKeyBoard.BackColor = System.Drawing.Color.Transparent;
			this.CodeCrackerKeyBoard.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.CodeCrackerKeyBoard.Location = new System.Drawing.Point(0, 554);
			this.CodeCrackerKeyBoard.Name = "CodeCrackerKeyBoard";
			this.CodeCrackerKeyBoard.Size = new System.Drawing.Size(1097, 106);
			this.CodeCrackerKeyBoard.TabIndex = 7;
			// 
			// SiriusCodeCrackerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1097, 660);
			this.Controls.Add(this.GridPanel);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.CodeCrackerKeyBoard);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "SiriusCodeCrackerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sirius Code Cracker";
			this.Activated += new System.EventHandler(this.SiriusCodeCrackerForm_Activated);
			this.Deactivate += new System.EventHandler(this.SiriusCodeCrackerForm_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiriusCodeCrackerForm_FormClosing);
			this.Load += new System.EventHandler(this.SiriusCodeCrackerForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SiriusCodeCrackerForm_KeyDown);
			this.Resize += new System.EventHandler(this.SiriusCodeCrackerForm_Resize);
			this.PlayerPanel.ResumeLayout(false);
			this.GridPanel.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GridDisplayUserControl CrosswordGrid;
		private System.Windows.Forms.Button StartNewGameButton;
		private System.Windows.Forms.Button SettingsButton;
		private KeyBoardUserControl CodeCrackerKeyBoard;
		private System.Windows.Forms.Button StatisticsButton;
		private System.Windows.Forms.Button ExtraLetterButton;
		private System.Windows.Forms.Button WordDefinitionButton;
		private System.Windows.Forms.Panel PlayerPanel;
		private System.Windows.Forms.Label CurrentGameLabel;
		private System.Windows.Forms.ComboBox PlayerComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer SecondTimer;
		private System.Windows.Forms.Panel GridPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}

