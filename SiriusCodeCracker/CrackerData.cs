using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;

namespace SiriusCodeCracker
{
	public class CrackerData
	{
		public static SiriusCodeCrackerConfiguration Configuration { get { return m_configuration; } }
		public static GridCharacter[,] CharacterGrid { get { return m_characterGrid; } }
		public static List<CodeWord> GridWords { get { return m_gridWords; } }
		public static KeyboardCharacter[,] Keyboard { get { return m_keyboardRows; } }
		public static Dictionary<char, KeyboardCharacter> KeyboardLookup { get { return m_keyboardLetterLookup; } }
		public static GridCharacter SelectedCharacter { get { return m_selectedCharacter; } }
		public static List<char> LettersUsed { get { return m_lettersUsed; } }

		public static int Corrections = 0;
		public static int GivenLetters = 0;
		public static Nullable<TimeSpan> GameDuration = null;
		public static DateTime StartTime = DateTime.MinValue;

		private static System.Drawing.Point m_selectedCell = new System.Drawing.Point(-1,-1);
		private static GridCharacter m_selectedCharacter = null;
		private static SiriusCodeCrackerConfiguration m_configuration = new SiriusCodeCrackerConfiguration();
		private static GridCharacter[,] m_characterGrid = null;
		private static List<CodeWord> m_gridWords = new List<CodeWord>();
		private static Dictionary<int, char> m_numbersForLetters = new Dictionary<int, char>();
		private static Dictionary<char, int> m_lettersForNumbers = new Dictionary<char, int>();
		private static Random m_randomiser = new Random(DateTime.Now.Millisecond);
		private static KeyboardCharacter[,] m_keyboardRows = new KeyboardCharacter[3,10];
		private static Dictionary<char, KeyboardCharacter> m_keyboardLetterLookup = new Dictionary<char, KeyboardCharacter>();
		private static List<char> m_lettersUsed = new List<char>();



		public static bool CheckCompletion()
		{
			int letterCount = 0;
			bool result = true;

			foreach (CodeWord gridWord in m_gridWords)
			{
				letterCount = 0;
				if (gridWord.Horizontal)
				{
					gridWord.Correct = true;
					for (int column = gridWord.Column; column < gridWord.Column + gridWord.Word.Length; column++)
					{
						if (m_characterGrid[column, gridWord.Row].SelectedLetter != gridWord.Word[column - gridWord.Column])
						{
							gridWord.Correct = false;
							result = false;
						}
						if (m_characterGrid[column, gridWord.Row].SelectedLetter != GridCharacter.NO_LETTER)
						{
							letterCount++;
						}
					}
				}
				else
				{
					gridWord.Correct = true;
					for (int row = gridWord.Row; row < gridWord.Row + gridWord.Word.Length; row++)
					{
						if (m_characterGrid[gridWord.Column, row].SelectedLetter != gridWord.Word[row - gridWord.Row])
						{
							gridWord.Correct = false;
							result = false;
						}
						if (m_characterGrid[gridWord.Column, row].SelectedLetter != GridCharacter.NO_LETTER)
						{
							letterCount++;
						}
					}
				}
				gridWord.Complete = (letterCount == gridWord.Word.Length);
			}

			if (result && GameDuration == null)
			{
				GameDuration = DateTime.Now.Subtract(StartTime);

				File.AppendAllText("Statistics.txt",
									string.Format("{0} - {1}x{2} grid completed in {3}:{4}:{5} with {6} corrections and {7} given letters.\r\n",
												DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
												m_configuration.Columns,
												m_configuration.Rows,
												GameDuration.Value.Hours.ToString("00"),
												GameDuration.Value.Minutes.ToString("00"),
												GameDuration.Value.Seconds.ToString("00"),
												Corrections,
												GivenLetters));
			}
			return result;
		}



		public static int GetNumber(char letter)
		{
			if (m_lettersForNumbers.ContainsKey(letter))
			{
				return m_lettersForNumbers[letter];
			}
			else
			{
				return 0;
			}
		}

		public static char GetLetter(int number)
		{
			if (m_numbersForLetters.ContainsKey(number))
			{
				return m_numbersForLetters[number];
			}
			else
			{
				return GridCharacter.NO_LETTER;
			}
		}

		private static void MarkLetterAsGiven(char letter)
		{
			GivenLetters++;

			for (int column = 0; column < m_configuration.Columns; column++)
			{
				for (int row = 0; row < m_configuration.Rows; row++)
				{
					if (m_characterGrid[column, row].CorrectLetter == letter)
					{
						m_characterGrid[column, row].SetAsGiven();
					}
				}
			}
			if (m_keyboardLetterLookup.ContainsKey(letter))
			{
				m_keyboardLetterLookup[letter].Given = true;
				m_keyboardLetterLookup[letter].Number = GetNumber(letter);
			}
		}

		public static void UnassignLetter(char letter)
		{
			if (m_selectedCharacter != null)
			{
				for (int column = 0; column < m_configuration.Columns; column++)
				{
					for (int row = 0; row < m_configuration.Rows; row++)
					{
						if (m_characterGrid[column, row].SelectedLetter == letter)
						{
							Corrections++;
							m_characterGrid[column, row].ResetSelection(); ;
						}
					}
				}
			}
		}

		public static void AssignLetter(char letter)
		{
			if (m_selectedCharacter != null)
			{
				for (int column = 0; column < m_configuration.Columns; column++)
				{
					for (int row = 0; row < m_configuration.Rows; row++)
					{
						if (m_characterGrid[column, row].CorrectLetter == m_selectedCharacter.CorrectLetter)
						{
							m_characterGrid[column, row].SelectedLetter = letter;
						}
					}
				}

				if (m_keyboardLetterLookup.ContainsKey(letter))
				{
					m_keyboardLetterLookup[letter].Used = true;
					m_keyboardLetterLookup[letter].Number = GetNumber(SelectedCharacter.CorrectLetter);
				}
			}
		}

		public static void MarkKeyboardLetterUnused(char letter)
		{
			if (m_keyboardLetterLookup.ContainsKey(letter))
			{
				Corrections++;
				m_keyboardLetterLookup[letter].Used = false;
				m_keyboardLetterLookup[letter].Number = -1;
			}
		}

		public static void ProvideExtraLetter()
		{
			char letter;
			List<char> alphabet = new List<char>();

			// Start by setting up the alphabet.
			for (letter = 'A'; letter <= 'Z'; letter++)
			{
				if (!m_keyboardLetterLookup[letter].Given)
				{
					alphabet.Add(letter);
				}
			}

			// Select a letter from the alphabet.
			letter = alphabet[m_randomiser.Next(0, alphabet.Count)];
			// Remove the letter so that it cannot be selected again.
			alphabet.Remove(letter);

			// While the selected letter in not one of the used ones, repeat the action.
			while (!m_lettersUsed.Contains(letter))
			{
				// Select another random letter.
				letter = alphabet[m_randomiser.Next(0, alphabet.Count)];
				// Remove the letter so that it cannot be selected again.
				alphabet.Remove(letter);
			}
			MarkLetterAsGiven(letter);
		}

		public static void AssignGivenLetters()
		{
			int random = 0;

			List<char> lettersOfUnusedLetters = new List<char>();

			// Start by filling the list with the alphabet.
			for (char letter = 'A'; letter <= 'Z'; letter++)
			{
				lettersOfUnusedLetters.Add(letter);
			}

			// Now remove all of the ones we have used.
			foreach (char letter in m_lettersUsed)
			{
				lettersOfUnusedLetters.Remove(letter);
			}

			// What is left is the list of un-used letters.
			foreach (char letter in lettersOfUnusedLetters)
			{
				m_keyboardLetterLookup[letter].NotRequired = true;
			}

			// For grouped number assignments we select a word at random from the assigned list
			// and then choose the required number of consecutive letters.
			if (m_configuration.GivenLettersGrouped)
			{
				while (true)
				{
					random = m_randomiser.Next(0, m_gridWords.Count - 1);

					if (m_gridWords[random].Word.Length > m_configuration.GivenLetters + 2)
					{
						string selectedWord = m_gridWords[random].Word;
						int start = m_randomiser.Next(0, selectedWord.Length - m_configuration.GivenLetters - 1);

						for (int index = start; index < Math.Min(start + m_configuration.GivenLetters, selectedWord.Length); index++)
						{
							MarkLetterAsGiven(selectedWord[index]);
						}
						break;
					}
				}
			}
			else
			{
				List<char> alphabet = new List<char>();

				// Start by setting up the alphabet.
				for (char letter = 'A'; letter <= 'Z'; letter++)
				{
					alphabet.Add(letter);
				}

				// now select the given letters.
				for (int i = 0; i < m_configuration.GivenLetters; i++)
				{
					// Select a letter from the alphabet.
					char letter = alphabet[m_randomiser.Next(0, alphabet.Count)];
					// Remove the letter so that it cannot be selected again.
					alphabet.Remove(letter);

					// While the selected letter in not one of the used ones, repeat the action.
					while (!m_lettersUsed.Contains(letter))
					{
						// Select another random letter.
						letter = alphabet[m_randomiser.Next(0, alphabet.Count)];
						// Remove the letter so that it cannot be selected again.
						alphabet.Remove(letter);
					}
					MarkLetterAsGiven(letter);
				}
			}
		}

		public static void SelectCell(int column, int row)
		{
			if (m_characterGrid != null)
			{
				if (m_selectedCell.X >= 0 && m_selectedCell.Y >= 0)
				{
					m_characterGrid[m_selectedCell.X, m_selectedCell.Y].Selected = false;
					m_selectedCharacter = null;
				}
				if (column < m_configuration.Columns && row < m_configuration.Rows)
				{
					if (m_characterGrid[column, row].IsLetter())
					{
						m_selectedCell.X = column;
						m_selectedCell.Y = row;
						m_characterGrid[m_selectedCell.X, m_selectedCell.Y].Selected = true;
						m_selectedCharacter = m_characterGrid[m_selectedCell.X, m_selectedCell.Y];
					}
				}
			}
		}

		public static int NextRandom(int min, int max)
		{
			return m_randomiser.Next(min, max);
		}

		public static void RandomiseLetters()
		{
			int random = 0;
			List<int> numbers = new List<int>();

			// Set up a list of numbers 1..26.
			for (int i = 1; i < 27; i++)
			{
				numbers.Add(i);
			}

			m_numbersForLetters.Clear();
			m_lettersForNumbers.Clear();

			// For each letter of the alphabet select a number at random from the list of numbers.
			// Associate the letter with the random number and remove it from the list.
			// Do this 26 times and you have a dictionary of letters each associated with a 
			// different random number between 1 and 26.
			for (char letter = 'A'; letter <= 'Z'; letter++)
			{
				random = NextRandom(0, numbers.Count-1);
				m_numbersForLetters.Add(numbers[random], letter);
				numbers.RemoveAt(random);
			}

			// Set up a second dictionary that associates the number back to the letter. 
			// This will speed things up later on.
			foreach (int number in m_numbersForLetters.Keys)
			{
				m_lettersForNumbers.Add(m_numbersForLetters[number], number);
			}
			random = 0;
		}

		public static void Reset()
		{
			m_characterGrid = null;
		}

		public static void ResetGrid()
		{
			GridWords.Clear();
			RandomiseLetters();

			Corrections = 0;
			GivenLetters = 0;
			GameDuration = null;
			StartTime = DateTime.Now;

			m_characterGrid = null;
			m_characterGrid = new GridCharacter[m_configuration.Columns, m_configuration.Rows];

			for (int column = 0; column < m_configuration.Columns; column++)
			{
				for (int row = 0; row < m_configuration.Rows; row++)
				{
					m_characterGrid[column, row] = new GridCharacter();
				}
			}

			foreach (char letter in m_keyboardLetterLookup.Keys)
			{
				m_keyboardLetterLookup[letter].Number = -1;
				m_keyboardLetterLookup[letter].Used = false;
				m_keyboardLetterLookup[letter].Given = false;
				m_keyboardLetterLookup[letter].Selected = false;
				m_keyboardLetterLookup[letter].NotRequired = false;
			}
		}
	}
}
