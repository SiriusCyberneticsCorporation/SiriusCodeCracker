namespace SiriusCodeCracker
{
	partial class WordDefinitionsForm
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
			this.DictionaryWordsListBox = new System.Windows.Forms.ListBox();
			this.DefinitionRichTextBox = new System.Windows.Forms.RichTextBox();
			this.SelectedWordTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.LookUpWordButton = new System.Windows.Forms.Button();
			this.TheCancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DictionaryWordsListBox
			// 
			this.DictionaryWordsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.DictionaryWordsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DictionaryWordsListBox.FormattingEnabled = true;
			this.DictionaryWordsListBox.ItemHeight = 15;
			this.DictionaryWordsListBox.Location = new System.Drawing.Point(12, 12);
			this.DictionaryWordsListBox.Name = "DictionaryWordsListBox";
			this.DictionaryWordsListBox.Size = new System.Drawing.Size(173, 379);
			this.DictionaryWordsListBox.Sorted = true;
			this.DictionaryWordsListBox.TabIndex = 0;
			this.DictionaryWordsListBox.SelectedIndexChanged += new System.EventHandler(this.DictionaryWordsListBox_SelectedIndexChanged);
			// 
			// DefinitionRichTextBox
			// 
			this.DefinitionRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DefinitionRichTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.DefinitionRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DefinitionRichTextBox.Location = new System.Drawing.Point(194, 38);
			this.DefinitionRichTextBox.Name = "DefinitionRichTextBox";
			this.DefinitionRichTextBox.ReadOnly = true;
			this.DefinitionRichTextBox.Size = new System.Drawing.Size(423, 355);
			this.DefinitionRichTextBox.TabIndex = 2;
			this.DefinitionRichTextBox.Text = "";
			// 
			// SelectedWordTextBox
			// 
			this.SelectedWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectedWordTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.SelectedWordTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.SelectedWordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SelectedWordTextBox.Location = new System.Drawing.Point(275, 12);
			this.SelectedWordTextBox.Name = "SelectedWordTextBox";
			this.SelectedWordTextBox.Size = new System.Drawing.Size(201, 21);
			this.SelectedWordTextBox.TabIndex = 1;
			this.SelectedWordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedWordTextBox_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(191, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Selected Word";
			// 
			// LookUpWordButton
			// 
			this.LookUpWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LookUpWordButton.Location = new System.Drawing.Point(498, 8);
			this.LookUpWordButton.Name = "LookUpWordButton";
			this.LookUpWordButton.Size = new System.Drawing.Size(119, 23);
			this.LookUpWordButton.TabIndex = 9;
			this.LookUpWordButton.Text = "Loop Up Word";
			this.LookUpWordButton.UseVisualStyleBackColor = true;
			this.LookUpWordButton.Click += new System.EventHandler(this.LookUpWordButton_Click);
			// 
			// TheCancelButton
			// 
			this.TheCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TheCancelButton.Location = new System.Drawing.Point(326, 229);
			this.TheCancelButton.Name = "TheCancelButton";
			this.TheCancelButton.Size = new System.Drawing.Size(75, 23);
			this.TheCancelButton.TabIndex = 10;
			this.TheCancelButton.Text = "Cancel";
			this.TheCancelButton.UseVisualStyleBackColor = true;
			this.TheCancelButton.Click += new System.EventHandler(this.TheCancelButton_Click);
			// 
			// WordDefinitionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 409);
			this.Controls.Add(this.LookUpWordButton);
			this.Controls.Add(this.DictionaryWordsListBox);
			this.Controls.Add(this.DefinitionRichTextBox);
			this.Controls.Add(this.SelectedWordTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TheCancelButton);
			this.MaximizeBox = false;
			this.Name = "WordDefinitionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Word Definitions";
			this.Load += new System.EventHandler(this.WordDefinitionsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox DictionaryWordsListBox;
		private System.Windows.Forms.RichTextBox DefinitionRichTextBox;
		private System.Windows.Forms.TextBox SelectedWordTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button LookUpWordButton;
		private System.Windows.Forms.Button TheCancelButton;
	}
}