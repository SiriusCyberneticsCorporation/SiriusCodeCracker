using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class CrosswordGenerator
	{
		class Crosswords
		{
			public Crosswords(string word, int length)
			{
				m_word = word;
				m_length = length;
			}

			public string m_word;
			public int m_length;
			public bool m_used;
			public bool m_horizontal;
			public int m_x;
			public int m_y;
		}

		int m_numberOfColumns = 0;
		int m_numberOfRows = 0;
		int m_shortestWord = 999;
		int m_longestWord = 0;
		
		public char[,] m_theGrid = null;
		
		Random m_randomiser = new Random(DateTime.Now.Millisecond);
		
		Dictionary<int, List<Crosswords>> m_wordsByLength = new Dictionary<int, List<Crosswords>>();
		Dictionary<int, List<Crosswords>>[,] m_characterPositions = new Dictionary<int, List<Crosswords>>[20, 26];

		public CrosswordGenerator()
		{
			foreach (string word in Words.TheWords)
			{
				int length = word.Length;
				Crosswords wordToAdd = new Crosswords(word, length);

				if (length < 3 || length > 14)
				{
					int x = 0;
				}
				if (length < m_shortestWord)
				{
					m_shortestWord = length;
				}
				if (length > m_longestWord)
				{
					m_longestWord = length;
				}

				if (m_wordsByLength.ContainsKey(length))
				{
					m_wordsByLength[length].Add(wordToAdd);
				}
				else
				{
					List<Crosswords> newList = new List<Crosswords>();
					newList.Add(wordToAdd);
					m_wordsByLength.Add(length, newList);
				}

				for (int letterPosition = 0; letterPosition < length; letterPosition++)
				{
					int letterNumber = word[letterPosition] - 65;

					if (m_characterPositions[letterPosition, letterNumber] == null)
					{
						m_characterPositions[letterPosition, letterNumber] = new Dictionary<int, List<Crosswords>>();
					}

					if (m_characterPositions[letterPosition, letterNumber].ContainsKey(length))
					{
						m_characterPositions[letterPosition, letterNumber][length].Add(wordToAdd);
					}
					else
					{
						List<Crosswords> newList = new List<Crosswords>();
						newList.Add(wordToAdd);
						m_characterPositions[letterPosition, letterNumber].Add(length, newList);
					}
				}
			}
		}

		public void SetGridSize(int numberOfColumns = 10, int numberOfRows = 10)
		{
			m_numberOfColumns = numberOfColumns;
			m_numberOfRows = numberOfRows;

			m_theGrid = new char[m_numberOfColumns, m_numberOfRows];
		}

		int m_startRow = 0;
		int m_startColumn = 0;
		bool m_horizontal = true;

		public void PlaceNext()
		{
			if (!m_horizontal)
			{
				for (int column = 0; column < m_numberOfColumns - m_shortestWord; column++)
				{
					if (PlaceWord(m_startRow, column, m_horizontal))
					{
						m_horizontal = !m_horizontal;
						break;
					}
				}
				m_startRow++;
				if (m_startRow >= m_numberOfRows)
				{
					m_startRow = 0;
					m_horizontal = true;
				}
			}
			else
			{
				for (int row = 0; row < m_numberOfRows - m_shortestWord; row++)
				{
					if (PlaceWord(row, m_startColumn, m_horizontal))
					{
						m_horizontal = !m_horizontal;
						break;
					}
				}
				m_startColumn++;
				if (m_startColumn >= m_numberOfColumns)
				{
					m_startColumn = 0;
					m_horizontal = false;
				}
			}
		}

		public void Populate()
		{
			InitialiseGrid();

			int startRow = 0;
			int startColumn = 0;
			bool horizontal = true;
			/*
			// Start off with 5 in the top left quadrant to improve coverage.
			int wordsToPlace = 5;
			while (wordsToPlace > 0)
			{
				startRow = m_randomiser.Next(0, m_numberOfRows/2);
				startColumn = m_randomiser.Next(0, m_numberOfColumns/2);
				horizontal = m_randomiser.Next(0, 100) > 50;

				if (PlaceWord(startRow, startColumn, horizontal))
				{
					wordsToPlace--;
				}
			}
			
			// Then place the remaining words anywhere on the grid.
			wordsToPlace = Math.Max(m_numberOfColumns, m_numberOfRows) - 5;
			while (wordsToPlace > 0)
			{
				startRow = m_randomiser.Next(0, m_numberOfRows - m_shortestWord);
				startColumn = m_randomiser.Next(0, m_numberOfColumns - m_shortestWord);
				horizontal = m_randomiser.Next(0, 100) > 50;

				if (PlaceWord(startRow, startColumn, horizontal))
				{
					wordsToPlace--;
				}
			}
			*/

			int charactersPlaced = 0;
			int preferredLength = 0;

			// Now go through twice working all cells horizontally and then vertically
			// in an attempt to fill up some of the gaps.
			for (int iterations = 0; iterations < 2; iterations++)
			{
				horizontal = true;
				for (startRow = 0; startRow < m_numberOfRows; startRow++)
				{
					for (startColumn = 0; startColumn < m_numberOfColumns - m_shortestWord; )
					{
						if (iterations == 0)
						{
							preferredLength = m_randomiser.Next(m_shortestWord, m_longestWord);
						}
						else
						{
							preferredLength = 0;
						}
						
						PlaceWord(startRow, startColumn, horizontal, out charactersPlaced, preferredLength);
						
						if(charactersPlaced > 0)
						{
							startColumn += charactersPlaced;
						}

						startColumn++;
					}
				}

				horizontal = false;
				for (startColumn = 0; startColumn < m_numberOfColumns; startColumn++)
				{
					for (startRow = 0; startRow < m_numberOfRows - m_shortestWord; ) 
					{
						if (iterations == 0)
						{
							preferredLength = m_randomiser.Next(m_shortestWord, m_longestWord);
						}
						else
						{
							preferredLength = 0;
						}
						
						PlaceWord(startRow, startColumn, horizontal, out charactersPlaced, preferredLength);

						if (charactersPlaced > 0)
						{
							startRow += charactersPlaced;
						}

						startRow++;
					}
				}
			}
		}

		private void InitialiseGrid()
		{
			for (int column = 0; column < m_numberOfColumns; column++)
			{
				for (int row = 0; row < m_numberOfRows; row++)
				{
					m_theGrid[column, row] = Definitions.EMPTY;
				}
			}
		}

		private void PlaceFirstWord(int startRow, int startColumn, bool horizontal)
		{
			int maximumWordLength = 0;
			Crosswords firstWord = null;

			if (horizontal)
			{
				maximumWordLength = m_numberOfColumns - startColumn;
			}
			else
			{
				maximumWordLength = m_numberOfRows - startRow;
			}

			maximumWordLength = Math.Min(maximumWordLength, m_longestWord);
			maximumWordLength = m_randomiser.Next(maximumWordLength - 3, maximumWordLength);

			while(maximumWordLength > 0)
			{
				if (m_wordsByLength.ContainsKey(maximumWordLength))
				{
					int index = m_randomiser.Next(0, m_wordsByLength[maximumWordLength].Count);

					firstWord = m_wordsByLength[maximumWordLength][index];
					
					break;
				}
			}

			if (firstWord != null)
			{
				AddWordToGrid(firstWord, startColumn, startRow, horizontal);
			}
		}

		private bool PlaceWord(int startRow, int startColumn, bool horizontal)
		{
			int charactersPlaced = 0;
			return PlaceWord(startRow, startColumn, horizontal, out charactersPlaced);
		}

		private bool PlaceWord(int startRow, int startColumn, bool horizontal, out int charactersPlaced, int preferredLength = 0)
		{
			int maximumWordLength = 0;
			bool result = false;
			List<KeyValuePair<int, int>> existingLetters = new List<KeyValuePair<int, int>>();
			Crosswords word = null;

			charactersPlaced = 0;

			if (horizontal)
			{
				// If the cell immediately before this word has a letter in it then the cell is not useable.
				if (startColumn > 0 && m_theGrid[startColumn - 1, startRow] >= Definitions.FIRST_LETTER)
				{
					return false;
				}
				// If the first two letters are used then we must be on an existing word.
				if (startColumn + 1 < m_numberOfColumns &&
					m_theGrid[startColumn, startRow] >= Definitions.FIRST_LETTER &&
					m_theGrid[startColumn + 1, startRow] >= Definitions.FIRST_LETTER)
				{
					return false;
				}
				// If the current cell is not filled but either of the adjacent are then the cell is not useable;
				if (m_theGrid[startColumn, startRow] < Definitions.FIRST_LETTER &&
					((startRow > 0 && m_theGrid[startColumn, startRow - 1] >= Definitions.FIRST_LETTER) ||
					 (startRow + 1 < m_numberOfRows && m_theGrid[startColumn, startRow + 1] >= Definitions.FIRST_LETTER)))
				{
					return false;
				}

				int maxColumn = m_numberOfColumns;
				int aboveCount = 0;
				int belowCount = 0;
				for (int column = startColumn; column < m_numberOfColumns; column++)
				{
					if (m_theGrid[column, startRow] == Definitions.HORIZONTAL_BESIDE ||
						m_theGrid[column, startRow] == Definitions.UNUSABLE)
					{
						maxColumn = column;
						break;
					}
					// If a word lies immediately above this word then limit the word length.
					if (startRow > 0)
					{
						if (m_theGrid[column, startRow - 1] >= Definitions.FIRST_LETTER)
						{
							aboveCount++;
						}
						else
						{
							aboveCount = 0;
						}
						if (aboveCount > 1)
						{
							maxColumn = column - aboveCount;
							break;
						}
					}
					// If a word lies immediately below this word then limit the word length.
					if (startRow + 1 < m_numberOfRows )
					{
						if( m_theGrid[column, startRow + 1] >= Definitions.FIRST_LETTER)
						{
							belowCount++;
						}
						else
						{
							belowCount = 0;
						}
						if (belowCount > 1)
						{
							maxColumn = column - belowCount;
							break;
						}
					}
				}
				maximumWordLength = maxColumn - startColumn;

				if (maximumWordLength < m_shortestWord)
				{
					return false;
				}
				
				for (int column = startColumn; column < m_numberOfColumns; column++)
				{
					if (m_theGrid[column, startRow] >= Definitions.FIRST_LETTER)
					{
						int letterNumber = m_theGrid[column, startRow] - 65;
						existingLetters.Add(new KeyValuePair<int,int>(column - startColumn, letterNumber));
					}
				}
			}
			else
			{
				// If the cell immediately before this word has a letter in it then the cell is not useable.
				if (startRow > 0 && m_theGrid[startColumn, startRow - 1] >= Definitions.FIRST_LETTER)
				{
					return false;
				}
				// If the first two letters are used then we must be on an existing word.
				if (startRow + 1 < m_numberOfRows &&
					m_theGrid[startColumn, startRow] >= Definitions.FIRST_LETTER &&
					m_theGrid[startColumn, startRow + 1] >= Definitions.FIRST_LETTER)
				{
					return false;
				}
				// If the current cell is not filled but either of the adjacent are then the cell is not useable;
				if (m_theGrid[startColumn, startRow] < Definitions.FIRST_LETTER &&
					((startColumn > 0 && m_theGrid[startColumn - 1, startRow] >= Definitions.FIRST_LETTER) ||
					 (startColumn + 1 < m_numberOfColumns && m_theGrid[startColumn + 1, startRow] >= Definitions.FIRST_LETTER)))
				{
					return false;
				}

				int maxRow = m_numberOfRows;
				int leftCount = 0;
				int rightCount = 0;
				for (int row = startRow; row < m_numberOfRows; row++)
				{
					if (m_theGrid[startColumn, row] == Definitions.VERTICAL_BESIDE ||
						m_theGrid[startColumn, row] == Definitions.UNUSABLE)
					{
						maxRow = row;
						break;
					}

					// If a word lies immediately left of this word then limit the word length.
					if (startColumn > 0)
					{
						if (m_theGrid[startColumn - 1, row] >= Definitions.FIRST_LETTER)
						{
							leftCount++;
						}
						else
						{
							leftCount = 0;
						}
						if (leftCount > 1)
						{
							maxRow = row - leftCount;
							break;
						}
					}
					// If a word lies immediately below this word then limit the word length.
					if (startColumn + 1 < m_numberOfColumns)
					{
						if (m_theGrid[startColumn + 1, row] >= Definitions.FIRST_LETTER)
						{
							rightCount++;
						}
						else
						{
							rightCount = 0;
						}
						if (rightCount > 1)
						{
							maxRow = row - rightCount;
							break;
						}
					}
				}
				maximumWordLength = maxRow - startRow;

				if (maximumWordLength < m_shortestWord)
				{
					return false;
				}

				for (int row = startRow; row < m_numberOfRows; row++)
				{
					if (m_theGrid[startColumn, row] >= Definitions.FIRST_LETTER)
					{
						int letterNumber = m_theGrid[startColumn, row] - 65;
						existingLetters.Add(new KeyValuePair<int, int>(row - startRow, letterNumber));
					}
				}
			}

			if (maximumWordLength < m_shortestWord)
			{
				return false;
			}

			if (existingLetters.Count > 0)
			{
				string message = string.Format("{0} existing letters - ", existingLetters.Count);
				for (int dd = 0; dd < existingLetters.Count; dd++)
				{
					message += string.Format("{0} at {1}, ", (char)(existingLetters[dd].Value + 65), existingLetters[dd].Key);
				}
				System.Diagnostics.Debug.WriteLine(message);

				// Find a word that fits
				List<Dictionary<int, List<Crosswords>>> listOfLists = new List<Dictionary<int, List<Crosswords>>>();

				foreach (KeyValuePair<int, int> pair in existingLetters)
				{
					if (m_characterPositions[pair.Key, pair.Value] != null)
					{
						listOfLists.Add(m_characterPositions[pair.Key, pair.Value]);
					}
				}
				if (listOfLists.Count > 1)
				{
					Dictionary<int, List<Crosswords>> wordList = listOfLists[0];

					int wordLength = maximumWordLength;

					while (wordLength > 0)
					{
						bool exitLoop = false;
						if (wordList.ContainsKey(wordLength))
						{
							for (int i = 0; i < wordList[wordLength].Count; i++)
							{
								if (wordList[wordLength][i].m_used)
								{
									continue;
								}
								if (horizontal && startColumn + wordLength < m_numberOfColumns &&
									m_theGrid[startColumn + wordLength, startRow] >= Definitions.FIRST_LETTER)
								{
									continue;
								}
								if (!horizontal && startRow + wordLength < m_numberOfRows &&
									m_theGrid[startColumn, startRow + wordLength] >= Definitions.FIRST_LETTER)
								{
									continue;
								}
								Crosswords matchingWord = wordList[wordLength][i];

								message = matchingWord.m_word + " matches at level 0";
								System.Diagnostics.Debug.WriteLine(message);
								
								if (ExistsInAllLists(listOfLists, 1, matchingWord))
								{
									word = matchingWord;
									exitLoop = true;
									break;
								}
							}
							if (exitLoop)
							{
								break;
							}
							else
							{
								word = null;
							}
						}
						wordLength--;
					}
					if (word == null && wordLength > m_shortestWord)
					{
						if (preferredLength > 0 && preferredLength < maximumWordLength)
						{
							word = SelectWord(wordList, preferredLength, startColumn, startRow, horizontal);
						}
						else
						{
							word = SelectWord(wordList, maximumWordLength, startColumn, startRow, horizontal);
						}
					}
				}
				else if (listOfLists.Count > 0)
				{
					word = SelectWord(listOfLists[0], maximumWordLength, startColumn, startRow, horizontal);
				}				
			}
			else
			{
				if (preferredLength > 0 && preferredLength < maximumWordLength)
				{
					word = SelectWord(m_wordsByLength, preferredLength, startColumn, startRow, horizontal);
				}
				else
				{
					word = SelectWord(m_wordsByLength, maximumWordLength, startColumn, startRow, horizontal);
				}
			}

			if (word != null)
			{
				if (AddWordToGrid(word, startColumn, startRow, horizontal))
				{
					charactersPlaced = word.m_length;
					result = true;
				}
			}

			return result;
		}

		private Crosswords SelectWord(Dictionary<int, List<Crosswords>> wordDictionary, int maximumWordLength, int startColumn, int startRow, bool horizontal)
		{
			int wordLength = maximumWordLength;
			Crosswords word = null;

			while (wordLength > 0)
			{
				bool exitLoop = false;
				if (wordDictionary.ContainsKey(wordLength))
				{
					for (int i = 0; i < wordDictionary[wordLength].Count; i++)
					{
						int index = m_randomiser.Next(0, wordDictionary[wordLength].Count);

						if (wordDictionary[wordLength][index].m_used)
						{
							continue;
						}
						if (horizontal && startColumn + wordLength < m_numberOfColumns &&
									m_theGrid[startColumn + wordLength, startRow] >= Definitions.FIRST_LETTER)
						{
							continue;
						}
						if (!horizontal && startRow + wordLength < m_numberOfRows &&
							m_theGrid[startColumn, startRow + wordLength] >= Definitions.FIRST_LETTER)
						{
							continue;
						}
						word = wordDictionary[wordLength][index];

						if (word.m_length <= maximumWordLength)
						{
							exitLoop = true;
							break;
						}
					}
					if (exitLoop)
					{
						break;
					}
					else
					{
						word = null;
					}
				}
				wordLength--;
			}

			return word;
		}

		private bool ExistsInAllLists(List<Dictionary<int, List<Crosswords>>> listOfLists, int level, Crosswords word)
		{
			bool result = false;

			if (listOfLists[level].ContainsKey(word.m_length))
			{
				if (listOfLists[level][word.m_length].Contains(word))
				{
					string message = word.m_word + " matches at level " + level.ToString();
					System.Diagnostics.Debug.WriteLine(message);

					if (level + 1 < listOfLists.Count)
					{
						result = ExistsInAllLists(listOfLists, level + 1, word);
					}
					else
					{
						message = word.m_word + " accepted - COMPLETE MATCH";
						System.Diagnostics.Debug.WriteLine(message);
						result = true;
					}
				}
			}
			else
			{
				string message = word.m_word + " accepted due to no more matches";
				System.Diagnostics.Debug.WriteLine(message);
				result = true;
			}

			return result;
		}

		private bool AddWordToGrid(Crosswords word, int column, int row, bool horizontal)
		{
			if (horizontal)
			{
				for (int letter = 0; letter < word.m_length; letter++)
				{
					if (m_theGrid[column + letter, row] >= Definitions.FIRST_LETTER &&
						m_theGrid[column + letter, row] != word.m_word[letter])
					{
						string message = word.m_word + " rejected due to letter clash.";
						System.Diagnostics.Debug.WriteLine(message);
						return false;
					}
				}
			}
			else
			{
				for (int letter = 0; letter < word.m_length; letter++)
				{
					if (m_theGrid[column, row + letter] >= Definitions.FIRST_LETTER &&
						m_theGrid[column, row + letter] != word.m_word[letter])
					{
						string message = word.m_word + " rejected due to letter clash.";
						System.Diagnostics.Debug.WriteLine(message);
						return false;
					}
				}
			}

			word.m_x = column;
			word.m_y = row;
			word.m_horizontal = horizontal;
			word.m_used = true;

			if (horizontal)
			{
				if (column > 0)
				{
					m_theGrid[column - 1, row] = Definitions.UNUSABLE;
				}
				if (column + word.m_length < m_numberOfColumns)
				{
					m_theGrid[column + word.m_length, row] = Definitions.UNUSABLE;
				}
				for (int letter = 0; letter < word.m_length; letter++)
				{
					if (m_theGrid[column + letter, row] >= Definitions.FIRST_LETTER &&
						m_theGrid[column + letter, row] != word.m_word[letter])
					{
						int x = 0;
					}
					m_theGrid[column + letter, row] = word.m_word[letter];
					
					if (row > 0 )
					{
						if (m_theGrid[column + letter, row - 1] == Definitions.EMPTY)
						{
							m_theGrid[column + letter, row - 1] = Definitions.HORIZONTAL_BESIDE;
						}
					}
					if (row+1 < m_numberOfRows)
					{
						if (m_theGrid[column + letter, row + 1] == Definitions.EMPTY)
						{
							m_theGrid[column + letter, row + 1] = Definitions.HORIZONTAL_BESIDE;
						}
					}
				}
			}
			else
			{
				if (row > 0)
				{
					m_theGrid[column, row - 1] = Definitions.UNUSABLE;
				}
				if (row + word.m_length < m_numberOfRows)
				{
					m_theGrid[column, row + word.m_length] = Definitions.UNUSABLE;
				}
				for (int letter = 0; letter < word.m_length; letter++)
				{
					if (m_theGrid[column, row + letter] >= Definitions.FIRST_LETTER &&
						m_theGrid[column, row + letter] != word.m_word[letter])
					{
						int x = 0;
					}
					m_theGrid[column, row + letter] = word.m_word[letter];

					if (column > 0)
					{
						if (m_theGrid[column - 1, row + letter] == Definitions.EMPTY)
						{
							m_theGrid[column - 1, row + letter] = Definitions.VERTICAL_BESIDE;
						}
					}
					if (column + 1 < m_numberOfRows)
					{
						if (m_theGrid[column + 1, row + letter] == Definitions.EMPTY)
						{
							m_theGrid[column + 1, row + letter] = Definitions.VERTICAL_BESIDE;
						}
					}
				}
			}
			return true;
		}
	}
}
