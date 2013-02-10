using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SiriusCodeCracker
{
	public partial class WordDefinitionsForm : Form
	{
		public WordDefinitionsForm()
		{
			InitializeComponent();
		}

		private void DictionaryWordsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox wordsListBox = (ListBox)sender;

			if (wordsListBox.SelectedIndex >= 0)
			{
				SelectedWordTextBox.Text = (string)wordsListBox.Items[wordsListBox.SelectedIndex];
				DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text);
			}
		}

		private string FindDefinition(string word)
		{
			bool findNextWord = false;
			string line;
			string result = string.Empty;
			StringBuilder definition = new StringBuilder();

			// Read the file line by line.              
			using (StreamReader file = new StreamReader("SiriusDictionary.txt"))
			{
				while ((line = file.ReadLine()) != null)
				{
					if (findNextWord)
					{
						if (line.Length > 2 && char.IsLetter(line[0]) && char.IsLetter(line[1]) && char.IsLetter(line[2]) &&
							line.Substring(0, 3) == line.Substring(0, 3).ToUpper())
						{
							result = definition.ToString();
							break;
						}
						definition.AppendLine(line.ToString());
					}
					else if (line == word)
					{
						findNextWord = true;
					}
				}
			}

			return result;
		}

		private void WordDefinitionsForm_Load(object sender, EventArgs e)
		{
			foreach (CodeWord word in CrackerData.GridWords)
			{
				DictionaryWordsListBox.Items.Add(word.Word);
			}
		}

		private void LookUpWordButton_Click(object sender, EventArgs e)
		{
			DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text.ToUpper());
		}

		private void SelectedWordTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text.ToUpper());
			}
		}
	}
}
