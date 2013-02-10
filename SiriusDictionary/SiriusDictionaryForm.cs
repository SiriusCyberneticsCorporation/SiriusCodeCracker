using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using SiriusCodeCracker;

namespace SiriusDictionary
{
	public partial class SiriusDictionaryForm : Form
	{
		Dictionary<string, StringBuilder> m_wordsAndDefinitions = new Dictionary<string, StringBuilder>();

		public SiriusDictionaryForm()
		{
			InitializeComponent();
		}

		private void SiriusDictionaryForm_Load(object sender, EventArgs e)
		{
			//DictionaryWordsListBox
			/*
			foreach (string word in Words.TheWords)
			{
				if (word.Length > 6) break;
				switch (word.Length)
				{
					case 3:
						ThreeLetterWordsListBox.Items.Add(word);
						break;
					case 4:
						FourLetterWordsListBox.Items.Add(word);
						break;
					case 5:
						FiveLetterWordsListBox.Items.Add(word);
						break;
					case 6:
						SixLetterWordsListBox.Items.Add(word);
						break;
				}
			}
			*/
		}

		private void LetterWordsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox wordsListBox = (ListBox)sender;

			if (wordsListBox.SelectedIndex >= 0)
			{
				SelectedWordTextBox.Text = (string)wordsListBox.Items[wordsListBox.SelectedIndex];
			}
		}

		private void FindDefinitionButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			if (m_wordsAndDefinitions.ContainsKey(SelectedWordTextBox.Text))
			{
				DefinitionRichTextBox.Text = m_wordsAndDefinitions[SelectedWordTextBox.Text].ToString();
			}
			/*
			DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text);

			// If no definition was found and the word ends with 'S', 'ED' or 'ING' then try it without.
			if (DefinitionRichTextBox.Text.Length == 0)
			{
				if(SelectedWordTextBox.Text.Substring(SelectedWordTextBox.Text.Length - 1) == "S")
				{
					DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text.Substring(0, SelectedWordTextBox.Text.Length - 1));
				}
				else if(SelectedWordTextBox.Text.Substring(SelectedWordTextBox.Text.Length - 2) == "ED")
				{
					DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text.Substring(0, SelectedWordTextBox.Text.Length - 2));
				}
				else if (SelectedWordTextBox.Text.Substring(SelectedWordTextBox.Text.Length - 3) == "ING")
				{
					DefinitionRichTextBox.Text = FindDefinition(SelectedWordTextBox.Text.Substring(0, SelectedWordTextBox.Text.Length - 3));
				}
			}
			*/
			Cursor = Cursors.Default;
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
		
		private void LetterWordsListBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			ListBox wordsListBox = (ListBox)sender;

			// Flag that the event has been handled.  This prevents the auto-select.
			e.Handled = true;

			// check if the user hit the backspace key
			if (e.KeyChar == (char)Keys.Back)
			{
				if (SearchTextBox.Text.Length > 0)
				{
					SearchTextBox.Text = SearchTextBox.Text.Substring(0, SearchTextBox.Text.Length - 1);
				}
			}
			else
			{
				SearchTextBox.Text += e.KeyChar.ToString();

				// search the list box items
				int i = wordsListBox.FindString(SearchTextBox.Text);

				if (i != ListBox.NoMatches)
				{
					wordsListBox.SelectedIndex = i;
				}
			}
		}

		private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void SearchTextBox_TextChanged(object sender, EventArgs e)
		{
			int index = ListBox.NoMatches;
			ListBox wordsListBox = ThreeLetterWordsListBox;

			switch (SearchTextBox.Text.Length)
			{
				case 3:
					WordsTabControl.SelectTab(0);
					index = ThreeLetterWordsListBox.FindString(SearchTextBox.Text.ToUpper());
					wordsListBox = ThreeLetterWordsListBox;
					break;
				case 4:
					WordsTabControl.SelectTab(1);
					index = FourLetterWordsListBox.FindString(SearchTextBox.Text.ToUpper());
					wordsListBox = FourLetterWordsListBox;
					break;
				case 5:
					WordsTabControl.SelectTab(2);
					index = FiveLetterWordsListBox.FindString(SearchTextBox.Text.ToUpper());
					wordsListBox = FiveLetterWordsListBox;
					break;
				case 6:
					WordsTabControl.SelectTab(3);
					index = SixLetterWordsListBox.FindString(SearchTextBox.Text.ToUpper());
					wordsListBox = SixLetterWordsListBox;
					break;
			}

			if (index != ListBox.NoMatches)
			{
				wordsListBox.SelectedIndex = index;
			}
		}


		private void button1_Click(object sender, EventArgs e)
		{
			bool findNextWord = false;
			string line;
			string[] words = null;
			StringBuilder definition = new StringBuilder();

			// Read the file line by line.              
			using (StreamReader file = new StreamReader("Dictionary.txt"))
			{
				while ((line = file.ReadLine()) != null)
				{
					// Find a word/words
					if (findNextWord)
					{
						if (line.Length > 2 && char.IsLetter(line[0]) && char.IsLetter(line[1]) && char.IsLetter(line[2]) &&
							line.Substring(0, 3) == line.Substring(0, 3).ToUpper())
						{
							if (definition.Length > 0)
							{
								foreach (string word in words)
								{
									string trimmedWord = word.Trim();

									if (trimmedWord == "ZYTHEM")
									{
										MessageBox.Show(word);
									}
									if (!trimmedWord.Contains('-') && !trimmedWord.Contains(' '))
									{
										if (m_wordsAndDefinitions.ContainsKey(trimmedWord))
										{
											m_wordsAndDefinitions[trimmedWord].Append(definition);
										}
										else
										{
											m_wordsAndDefinitions.Add(trimmedWord, definition);
											DictionaryWordsListBox.Items.Add(trimmedWord);
										}
									}
								}
							}
							words = line.Split(';');
							definition = new StringBuilder();
						}
						else
						{
							definition.AppendLine(line.ToString());
						}
					}
					else if (line.Length > 2 && char.IsLetter(line[0]) && char.IsLetter(line[1]) && char.IsLetter(line[2]) &&
							 line.Substring(0, 3) == line.Substring(0, 3).ToUpper())
					{
						words = line.Split(';');
						findNextWord = true;
					}
				}
				if (definition.Length > 0)
				{
					foreach (string word in words)
					{
						string trimmedWord = word.Trim();

						if (trimmedWord == "ZYTHEM")
						{
							MessageBox.Show(word);
						}
						if (!trimmedWord.Contains('-') && !trimmedWord.Contains(' '))
						{
							if (m_wordsAndDefinitions.ContainsKey(trimmedWord))
							{
								m_wordsAndDefinitions[trimmedWord].Append(definition);
							}
							else
							{
								m_wordsAndDefinitions.Add(trimmedWord, definition);
								DictionaryWordsListBox.Items.Add(trimmedWord);
							}
						}
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			StreamWriter wordsFile = new StreamWriter("Words.txt");
			StreamWriter dictionaryFile = new StreamWriter("SiriusDictionary.txt");
						
			foreach (string word in m_wordsAndDefinitions.Keys)
			{
				wordsFile.WriteLine(word + ",");
				dictionaryFile.WriteLine(word);
				dictionaryFile.Write(m_wordsAndDefinitions[word]);
			}
			wordsFile.Close();
			dictionaryFile.Close();

			using (Stream fileStream = new FileStream("SiriusDictionary.bin", FileMode.Create, FileAccess.Write, FileShare.None))
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(fileStream, m_wordsAndDefinitions);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Dictionary<string, StringBuilder> wordsAndDefinitions = new Dictionary<string, StringBuilder>();

			// Open the file containing the data that you want to deserialize.
			FileStream fs = new FileStream("SiriusDictionary.bin", FileMode.Open);
			try
			{
				BinaryFormatter formatter = new BinaryFormatter();

				wordsAndDefinitions = (Dictionary<string, StringBuilder>)formatter.Deserialize(fs);
			}
			catch (SerializationException ex)
			{
				MessageBox.Show("Failed to deserialize. Reason: " + ex.Message);
			}

		}
	}
}
