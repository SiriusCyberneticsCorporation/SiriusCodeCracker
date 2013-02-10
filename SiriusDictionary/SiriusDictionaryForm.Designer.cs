namespace SiriusDictionary
{
	partial class SiriusDictionaryForm
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
			this.WordsTabControl = new System.Windows.Forms.TabControl();
			this.ThreeLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.ThreeLetterWordsListBox = new System.Windows.Forms.ListBox();
			this.FourLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.FourLetterWordsListBox = new System.Windows.Forms.ListBox();
			this.FiveLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.FiveLetterWordsListBox = new System.Windows.Forms.ListBox();
			this.SixLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.SixLetterWordsListBox = new System.Windows.Forms.ListBox();
			this.SevenLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.EightLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.NineLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.TenLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.ElevenLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.TwelveLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.ThirteenLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.FourteenLetterWordsTabPage = new System.Windows.Forms.TabPage();
			this.WordsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.SearchPanel = new System.Windows.Forms.Panel();
			this.SearchTextBox = new System.Windows.Forms.TextBox();
			this.SearchButton = new System.Windows.Forms.Button();
			this.WordsLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SelectedWordTextBox = new System.Windows.Forms.TextBox();
			this.DefinitionRichTextBox = new System.Windows.Forms.RichTextBox();
			this.FindDefinitionButton = new System.Windows.Forms.Button();
			this.DictionaryWordsListBox = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.WordsTabControl.SuspendLayout();
			this.ThreeLetterWordsTabPage.SuspendLayout();
			this.FourLetterWordsTabPage.SuspendLayout();
			this.FiveLetterWordsTabPage.SuspendLayout();
			this.SixLetterWordsTabPage.SuspendLayout();
			this.WordsTableLayoutPanel.SuspendLayout();
			this.SearchPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// WordsTabControl
			// 
			this.WordsTabControl.Controls.Add(this.ThreeLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.FourLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.FiveLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.SixLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.SevenLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.EightLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.NineLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.TenLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.ElevenLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.TwelveLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.ThirteenLetterWordsTabPage);
			this.WordsTabControl.Controls.Add(this.FourteenLetterWordsTabPage);
			this.WordsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WordsTabControl.Location = new System.Drawing.Point(0, 40);
			this.WordsTabControl.Margin = new System.Windows.Forms.Padding(0);
			this.WordsTabControl.Name = "WordsTabControl";
			this.WordsTabControl.Padding = new System.Drawing.Point(0, 3);
			this.WordsTabControl.SelectedIndex = 0;
			this.WordsTabControl.Size = new System.Drawing.Size(210, 434);
			this.WordsTabControl.TabIndex = 0;
			// 
			// ThreeLetterWordsTabPage
			// 
			this.ThreeLetterWordsTabPage.Controls.Add(this.ThreeLetterWordsListBox);
			this.ThreeLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.ThreeLetterWordsTabPage.Name = "ThreeLetterWordsTabPage";
			this.ThreeLetterWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.ThreeLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.ThreeLetterWordsTabPage.TabIndex = 0;
			this.ThreeLetterWordsTabPage.Text = " 3";
			this.ThreeLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// ThreeLetterWordsListBox
			// 
			this.ThreeLetterWordsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ThreeLetterWordsListBox.Location = new System.Drawing.Point(3, 3);
			this.ThreeLetterWordsListBox.Name = "ThreeLetterWordsListBox";
			this.ThreeLetterWordsListBox.Size = new System.Drawing.Size(196, 402);
			this.ThreeLetterWordsListBox.TabIndex = 0;
			this.ThreeLetterWordsListBox.SelectedIndexChanged += new System.EventHandler(this.LetterWordsListBox_SelectedIndexChanged);
			this.ThreeLetterWordsListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetterWordsListBox_KeyPress);
			// 
			// FourLetterWordsTabPage
			// 
			this.FourLetterWordsTabPage.Controls.Add(this.FourLetterWordsListBox);
			this.FourLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.FourLetterWordsTabPage.Name = "FourLetterWordsTabPage";
			this.FourLetterWordsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.FourLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.FourLetterWordsTabPage.TabIndex = 1;
			this.FourLetterWordsTabPage.Text = "4";
			this.FourLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// FourLetterWordsListBox
			// 
			this.FourLetterWordsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FourLetterWordsListBox.Location = new System.Drawing.Point(3, 3);
			this.FourLetterWordsListBox.Name = "FourLetterWordsListBox";
			this.FourLetterWordsListBox.Size = new System.Drawing.Size(196, 402);
			this.FourLetterWordsListBox.TabIndex = 1;
			this.FourLetterWordsListBox.SelectedIndexChanged += new System.EventHandler(this.LetterWordsListBox_SelectedIndexChanged);
			this.FourLetterWordsListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetterWordsListBox_KeyPress);
			// 
			// FiveLetterWordsTabPage
			// 
			this.FiveLetterWordsTabPage.Controls.Add(this.FiveLetterWordsListBox);
			this.FiveLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.FiveLetterWordsTabPage.Name = "FiveLetterWordsTabPage";
			this.FiveLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.FiveLetterWordsTabPage.TabIndex = 2;
			this.FiveLetterWordsTabPage.Text = "5";
			this.FiveLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// FiveLetterWordsListBox
			// 
			this.FiveLetterWordsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FiveLetterWordsListBox.Location = new System.Drawing.Point(0, 0);
			this.FiveLetterWordsListBox.Name = "FiveLetterWordsListBox";
			this.FiveLetterWordsListBox.Size = new System.Drawing.Size(202, 408);
			this.FiveLetterWordsListBox.TabIndex = 1;
			this.FiveLetterWordsListBox.SelectedIndexChanged += new System.EventHandler(this.LetterWordsListBox_SelectedIndexChanged);
			this.FiveLetterWordsListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetterWordsListBox_KeyPress);
			// 
			// SixLetterWordsTabPage
			// 
			this.SixLetterWordsTabPage.Controls.Add(this.SixLetterWordsListBox);
			this.SixLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.SixLetterWordsTabPage.Name = "SixLetterWordsTabPage";
			this.SixLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.SixLetterWordsTabPage.TabIndex = 3;
			this.SixLetterWordsTabPage.Text = "6";
			this.SixLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// SixLetterWordsListBox
			// 
			this.SixLetterWordsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SixLetterWordsListBox.Location = new System.Drawing.Point(0, 0);
			this.SixLetterWordsListBox.Name = "SixLetterWordsListBox";
			this.SixLetterWordsListBox.Size = new System.Drawing.Size(202, 408);
			this.SixLetterWordsListBox.TabIndex = 1;
			this.SixLetterWordsListBox.SelectedIndexChanged += new System.EventHandler(this.LetterWordsListBox_SelectedIndexChanged);
			this.SixLetterWordsListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetterWordsListBox_KeyPress);
			// 
			// SevenLetterWordsTabPage
			// 
			this.SevenLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.SevenLetterWordsTabPage.Name = "SevenLetterWordsTabPage";
			this.SevenLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.SevenLetterWordsTabPage.TabIndex = 4;
			this.SevenLetterWordsTabPage.Text = "7";
			this.SevenLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// EightLetterWordsTabPage
			// 
			this.EightLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.EightLetterWordsTabPage.Name = "EightLetterWordsTabPage";
			this.EightLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.EightLetterWordsTabPage.TabIndex = 5;
			this.EightLetterWordsTabPage.Text = "8";
			this.EightLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// NineLetterWordsTabPage
			// 
			this.NineLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.NineLetterWordsTabPage.Name = "NineLetterWordsTabPage";
			this.NineLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.NineLetterWordsTabPage.TabIndex = 6;
			this.NineLetterWordsTabPage.Text = "9";
			this.NineLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// TenLetterWordsTabPage
			// 
			this.TenLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.TenLetterWordsTabPage.Name = "TenLetterWordsTabPage";
			this.TenLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.TenLetterWordsTabPage.TabIndex = 7;
			this.TenLetterWordsTabPage.Text = "10";
			this.TenLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// ElevenLetterWordsTabPage
			// 
			this.ElevenLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.ElevenLetterWordsTabPage.Name = "ElevenLetterWordsTabPage";
			this.ElevenLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.ElevenLetterWordsTabPage.TabIndex = 8;
			this.ElevenLetterWordsTabPage.Text = "11";
			this.ElevenLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// TwelveLetterWordsTabPage
			// 
			this.TwelveLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.TwelveLetterWordsTabPage.Name = "TwelveLetterWordsTabPage";
			this.TwelveLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.TwelveLetterWordsTabPage.TabIndex = 9;
			this.TwelveLetterWordsTabPage.Text = "12";
			this.TwelveLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// ThirteenLetterWordsTabPage
			// 
			this.ThirteenLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.ThirteenLetterWordsTabPage.Name = "ThirteenLetterWordsTabPage";
			this.ThirteenLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.ThirteenLetterWordsTabPage.TabIndex = 10;
			this.ThirteenLetterWordsTabPage.Text = "13";
			this.ThirteenLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// FourteenLetterWordsTabPage
			// 
			this.FourteenLetterWordsTabPage.Location = new System.Drawing.Point(4, 22);
			this.FourteenLetterWordsTabPage.Name = "FourteenLetterWordsTabPage";
			this.FourteenLetterWordsTabPage.Size = new System.Drawing.Size(202, 408);
			this.FourteenLetterWordsTabPage.TabIndex = 11;
			this.FourteenLetterWordsTabPage.Text = "14";
			this.FourteenLetterWordsTabPage.UseVisualStyleBackColor = true;
			// 
			// WordsTableLayoutPanel
			// 
			this.WordsTableLayoutPanel.ColumnCount = 1;
			this.WordsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.WordsTableLayoutPanel.Controls.Add(this.SearchPanel, 0, 1);
			this.WordsTableLayoutPanel.Controls.Add(this.WordsTabControl, 0, 2);
			this.WordsTableLayoutPanel.Controls.Add(this.WordsLabel, 0, 0);
			this.WordsTableLayoutPanel.Location = new System.Drawing.Point(12, 310);
			this.WordsTableLayoutPanel.Name = "WordsTableLayoutPanel";
			this.WordsTableLayoutPanel.RowCount = 3;
			this.WordsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.WordsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.WordsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.WordsTableLayoutPanel.Size = new System.Drawing.Size(210, 176);
			this.WordsTableLayoutPanel.TabIndex = 0;
			// 
			// SearchPanel
			// 
			this.SearchPanel.Controls.Add(this.SearchTextBox);
			this.SearchPanel.Controls.Add(this.SearchButton);
			this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchPanel.Location = new System.Drawing.Point(0, 20);
			this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
			this.SearchPanel.Name = "SearchPanel";
			this.SearchPanel.Size = new System.Drawing.Size(210, 20);
			this.SearchPanel.TabIndex = 2;
			// 
			// SearchTextBox
			// 
			this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchTextBox.Location = new System.Drawing.Point(0, 0);
			this.SearchTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.SearchTextBox.Name = "SearchTextBox";
			this.SearchTextBox.Size = new System.Drawing.Size(135, 20);
			this.SearchTextBox.TabIndex = 0;
			this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
			this.SearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTextBox_KeyPress);
			// 
			// SearchButton
			// 
			this.SearchButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.SearchButton.Location = new System.Drawing.Point(135, 0);
			this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(75, 20);
			this.SearchButton.TabIndex = 1;
			this.SearchButton.Text = "Search";
			this.SearchButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.SearchButton.UseVisualStyleBackColor = true;
			// 
			// WordsLabel
			// 
			this.WordsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WordsLabel.Location = new System.Drawing.Point(3, 0);
			this.WordsLabel.Name = "WordsLabel";
			this.WordsLabel.Size = new System.Drawing.Size(204, 20);
			this.WordsLabel.TabIndex = 0;
			this.WordsLabel.Text = "Words";
			this.WordsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(250, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Selected Word";
			// 
			// SelectedWordTextBox
			// 
			this.SelectedWordTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.SelectedWordTextBox.Location = new System.Drawing.Point(334, 13);
			this.SelectedWordTextBox.Name = "SelectedWordTextBox";
			this.SelectedWordTextBox.ReadOnly = true;
			this.SelectedWordTextBox.Size = new System.Drawing.Size(159, 20);
			this.SelectedWordTextBox.TabIndex = 1;
			// 
			// DefinitionRichTextBox
			// 
			this.DefinitionRichTextBox.Location = new System.Drawing.Point(253, 39);
			this.DefinitionRichTextBox.Name = "DefinitionRichTextBox";
			this.DefinitionRichTextBox.Size = new System.Drawing.Size(389, 347);
			this.DefinitionRichTextBox.TabIndex = 2;
			this.DefinitionRichTextBox.Text = "";
			// 
			// FindDefinitionButton
			// 
			this.FindDefinitionButton.Location = new System.Drawing.Point(253, 392);
			this.FindDefinitionButton.Name = "FindDefinitionButton";
			this.FindDefinitionButton.Size = new System.Drawing.Size(116, 23);
			this.FindDefinitionButton.TabIndex = 5;
			this.FindDefinitionButton.Text = "Find Definition";
			this.FindDefinitionButton.UseVisualStyleBackColor = true;
			this.FindDefinitionButton.Click += new System.EventHandler(this.FindDefinitionButton_Click);
			// 
			// DictionaryWordsListBox
			// 
			this.DictionaryWordsListBox.FormattingEnabled = true;
			this.DictionaryWordsListBox.Location = new System.Drawing.Point(12, 22);
			this.DictionaryWordsListBox.Name = "DictionaryWordsListBox";
			this.DictionaryWordsListBox.Size = new System.Drawing.Size(210, 277);
			this.DictionaryWordsListBox.TabIndex = 6;
			this.DictionaryWordsListBox.SelectedIndexChanged += new System.EventHandler(this.LetterWordsListBox_SelectedIndexChanged);
			this.DictionaryWordsListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetterWordsListBox_KeyPress);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(567, 392);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Read";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(567, 463);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Write";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(402, 448);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// SiriusDictionaryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 498);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DictionaryWordsListBox);
			this.Controls.Add(this.FindDefinitionButton);
			this.Controls.Add(this.DefinitionRichTextBox);
			this.Controls.Add(this.SelectedWordTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.WordsTableLayoutPanel);
			this.Name = "SiriusDictionaryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sirius Dictionary";
			this.Load += new System.EventHandler(this.SiriusDictionaryForm_Load);
			this.WordsTabControl.ResumeLayout(false);
			this.ThreeLetterWordsTabPage.ResumeLayout(false);
			this.FourLetterWordsTabPage.ResumeLayout(false);
			this.FiveLetterWordsTabPage.ResumeLayout(false);
			this.SixLetterWordsTabPage.ResumeLayout(false);
			this.WordsTableLayoutPanel.ResumeLayout(false);
			this.SearchPanel.ResumeLayout(false);
			this.SearchPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl WordsTabControl;
		private System.Windows.Forms.TabPage ThreeLetterWordsTabPage;
		private System.Windows.Forms.TabPage FourLetterWordsTabPage;
		private System.Windows.Forms.TabPage FiveLetterWordsTabPage;
		private System.Windows.Forms.TabPage SixLetterWordsTabPage;
		private System.Windows.Forms.TabPage SevenLetterWordsTabPage;
		private System.Windows.Forms.TabPage EightLetterWordsTabPage;
		private System.Windows.Forms.TabPage NineLetterWordsTabPage;
		private System.Windows.Forms.TabPage TenLetterWordsTabPage;
		private System.Windows.Forms.TabPage ElevenLetterWordsTabPage;
		private System.Windows.Forms.TabPage TwelveLetterWordsTabPage;
		private System.Windows.Forms.TabPage ThirteenLetterWordsTabPage;
		private System.Windows.Forms.TabPage FourteenLetterWordsTabPage;
		private System.Windows.Forms.TableLayoutPanel WordsTableLayoutPanel;
		private System.Windows.Forms.Panel SearchPanel;
		private System.Windows.Forms.TextBox SearchTextBox;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.Label WordsLabel;
		private System.Windows.Forms.ListBox ThreeLetterWordsListBox;
		private System.Windows.Forms.ListBox FourLetterWordsListBox;
		private System.Windows.Forms.ListBox FiveLetterWordsListBox;
		private System.Windows.Forms.ListBox SixLetterWordsListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SelectedWordTextBox;
		private System.Windows.Forms.RichTextBox DefinitionRichTextBox;
		private System.Windows.Forms.Button FindDefinitionButton;
		private System.Windows.Forms.ListBox DictionaryWordsListBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}

