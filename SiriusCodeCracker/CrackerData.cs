using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class CrackerData
	{
		public static SiriusCodeCrackerConfiguration Configuration { get { return m_configuration; } }
		public static GridCharacter[,] CharacterGrid { get { return m_characterGrid; } }
		public static List<CodeWord> GridWords { get { return m_gridWords; } }
		public static KeyboardCharacter[,] Keyboard { get { return m_keyboardRows; } }
		public static Dictionary<char, KeyboardCharacter> KeyboardLookup { get { return m_keyboardLetterLookup; } }

		private static SiriusCodeCrackerConfiguration m_configuration = new SiriusCodeCrackerConfiguration();
		private static GridCharacter[,] m_characterGrid = null;
		private static List<CodeWord> m_gridWords = new List<CodeWord>();
		private static Dictionary<int, char> m_numbersForLetters = new Dictionary<int, char>();
		private static Dictionary<char, int> m_lettersForNumbers = new Dictionary<char, int>();
		private static Random m_randomiser = new Random(DateTime.Now.Millisecond);
		private static KeyboardCharacter[,] m_keyboardRows = new KeyboardCharacter[3,10];
		private static Dictionary<char, KeyboardCharacter> m_keyboardLetterLookup = new Dictionary<char, KeyboardCharacter>();

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
				return (char)0;
			}
		}

		private static void MarkLetterAsGiven(char letter)
		{
			for (int column = 0; column < m_configuration.Columns; column++)
			{
				for (int row = 0; row < m_configuration.Rows; row++)
				{
					if (m_characterGrid[column, row].Letter == letter)
					{
						m_characterGrid[column, row].SetAsGiven();
					}
				}
			}
			if (m_keyboardLetterLookup.ContainsKey(letter))
			{
				m_keyboardLetterLookup[letter].Given = true;
			}
		}

		private static void MarkLetterAsUsed(char letter)
		{
			if (m_keyboardLetterLookup.ContainsKey(letter))
			{
				m_keyboardLetterLookup[letter].Used = true;
			}
		}

		public static void AssignGivenLetters(int numberOfLetters, bool grouped)
		{
			int random = 0;

			// For grouped number assignments we select a word at random from the assigned list
			// and then choose the required number of consecutive letters.
			if (grouped)
			{
				while (true)
				{
					random = m_randomiser.Next(0, m_gridWords.Count - 1);

					if (m_gridWords[random].Word.Length > numberOfLetters + 2)
					{
						string selectedWord = m_gridWords[random].Word;
						int start = m_randomiser.Next(0, selectedWord.Length - numberOfLetters - 1);

						for (int index = start; index < Math.Min(start + numberOfLetters, selectedWord.Length); index++)
						{
							MarkLetterAsGiven(selectedWord[index]);
						}
						break;
					}
				}
			}
			else
			{

				List<int> numbers = new List<int>();

				// Set up a list of numbers 1..26.
				for (int i = 1; i < 27; i++)
				{
					numbers.Add(i);
				}
			}

			//m_characterGrid			
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

		public static void SetGridSize(int numberOfRows, int numberOfColumns)
		{
			m_configuration.Columns = numberOfColumns;
			m_configuration.Rows = numberOfRows;

			GridWords.Clear();
			RandomiseLetters();

			m_characterGrid = null;
			m_characterGrid = new GridCharacter[m_configuration.Columns, m_configuration.Rows];

			for (int column = 0; column < m_configuration.Columns; column++)
			{
				for (int row = 0; row < m_configuration.Rows; row++)
				{
					m_characterGrid[column, row] = new GridCharacter();
				}
			}

			foreach (char letter in CrackerData.KeyboardLookup.Keys)
			{
				CrackerData.KeyboardLookup[letter].Used = false;
				CrackerData.KeyboardLookup[letter].Given = false;
				CrackerData.KeyboardLookup[letter].Selected = false;
			}
		}

	}
}
