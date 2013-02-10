using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class CrosswordGenerator
	{
		class GeneratorWord
		{
			public GeneratorWord(string newWord)
			{
				Word = newWord;
				Length = Word.Length;
			}
			public string Word = string.Empty;
			public int Length = 0;
			public bool Used = false;
		}

		int m_shortestWord = 999;
		int m_longestWord = 0;

		Dictionary<int, List<GeneratorWord>> m_wordsByLength = new Dictionary<int, List<GeneratorWord>>();
		Dictionary<int, List<GeneratorWord>>[,] m_characterPositions = new Dictionary<int, List<GeneratorWord>>[30, 26];

		public CrosswordGenerator()
		{
			foreach (string word in Words.TheWords)
			{
				int length = word.Length;
				GeneratorWord wordToAdd = new GeneratorWord(word);

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
					List<GeneratorWord> newList = new List<GeneratorWord>();
					newList.Add(wordToAdd);
					m_wordsByLength.Add(length, newList);
				}

				for (int letterPosition = 0; letterPosition < length; letterPosition++)
				{
					int letterNumber = word[letterPosition] - 65;

					if (m_characterPositions[letterPosition, letterNumber] == null)
					{
						m_characterPositions[letterPosition, letterNumber] = new Dictionary<int, List<GeneratorWord>>();
					}

					if (m_characterPositions[letterPosition, letterNumber].ContainsKey(length))
					{
						m_characterPositions[letterPosition, letterNumber][length].Add(wordToAdd);
					}
					else
					{
						List<GeneratorWord> newList = new List<GeneratorWord>();
						newList.Add(wordToAdd);
						m_characterPositions[letterPosition, letterNumber].Add(length, newList);
					}
				}
			}
		}

		public void Populate()
		{
			CrackerData.ResetGrid();

			int startRow = 0;
			int startColumn = 0;
			int charactersPlaced = 0;
			int preferredLength = 0;
			bool horizontal = true;

			for (int iteration = 0; iteration < 2; iteration++)
			{
				horizontal = true;
				for (startRow = 0; startRow < CrackerData.Configuration.Rows; startRow++)
				{
					for (startColumn = 0; startColumn < CrackerData.Configuration.Columns - m_shortestWord; )
					{
						if (iteration == 0)
						{
							startColumn += CrackerData.NextRandom(0, 3) / 2;
						}

						preferredLength = GetPreferredLength(iteration);

						charactersPlaced = PlaceWord(startRow, startColumn, horizontal, preferredLength);

						if (charactersPlaced > 0)
						{
							startColumn += charactersPlaced;
						}

						startColumn++;
					}

					horizontal = !horizontal;

					for (startColumn = 0; startColumn < CrackerData.Configuration.Columns - m_shortestWord; )
					{
						if (iteration == 0)
						{
							startColumn += CrackerData.NextRandom(0, 3) / 2;
						}

						preferredLength = GetPreferredLength(iteration);

						charactersPlaced = PlaceWord(startRow, startColumn, horizontal, preferredLength);

						if (iteration == 0)
						{
							startColumn += CrackerData.NextRandom(2, 10);
						}
						else
						{
							startColumn++;
						}
					}

					horizontal = !horizontal;
				}

				horizontal = false;
				for (startColumn = 0; startColumn < CrackerData.Configuration.Columns; startColumn++)
				{
					for (startRow = 0; startRow < CrackerData.Configuration.Rows - m_shortestWord; )
					{
						preferredLength = GetPreferredLength(iteration);

						charactersPlaced = PlaceWord(startRow, startColumn, horizontal, preferredLength);

						if (charactersPlaced > 0)
						{
							startRow += charactersPlaced;
						}

						startRow++;
					}

					horizontal = !horizontal;

					for (startRow = 0; startRow < CrackerData.Configuration.Rows - m_shortestWord; )
					{
						preferredLength = GetPreferredLength(iteration);

						charactersPlaced = PlaceWord(startRow, startColumn, horizontal, preferredLength);

						if (iteration == 0)
						{
							startRow += CrackerData.NextRandom(2, 10);
						}
						else
						{
							startRow++;
						}
					}

					horizontal = !horizontal;
				}
			}

			CrackerData.AssignGivenLetters();
		}

		private int GetPreferredLength(int iteration)
		{
			int preferredLength = 0;

			if (iteration == 0)
			{
				preferredLength = CrackerData.NextRandom(m_shortestWord * 2, m_longestWord);
			}

			return preferredLength;
		}
		
		private int PlaceWord(int startRow, int startColumn, bool horizontal)
		{
			return PlaceWord(startRow, startColumn, horizontal);
		}

		private int PlaceWord(int startRow, int startColumn, bool horizontal, int preferredLength = 0)
		{
			int maximumWordLength = 0;
			List<KeyValuePair<int, int>> existingLetters = new List<KeyValuePair<int, int>>();
			GeneratorWord word = null;

			if (horizontal)
			{
				if (startColumn >= CrackerData.Configuration.Columns-m_shortestWord)
				{
					return 0;
				}
				// If the cell immediately before this word has a letter in it then the cell is not useable.
				if (startColumn > 0 && CrackerData.CharacterGrid[startColumn - 1, startRow].IsLetter())
				{
					return 0;
				}
				// If the first two letters are used then we must be on an existing word.
				if (startColumn + 1 < CrackerData.Configuration.Columns &&
					CrackerData.CharacterGrid[startColumn, startRow].IsLetter() &&
					CrackerData.CharacterGrid[startColumn + 1, startRow].IsLetter())
				{
					return 0;
				}
				// If the current cell is not filled but either of the adjacent are then the cell is not useable;
				if (!CrackerData.CharacterGrid[startColumn, startRow].IsLetter() &&
					((startRow > 0 && CrackerData.CharacterGrid[startColumn, startRow - 1].IsLetter()) ||
					 (startRow + 1 < CrackerData.Configuration.Rows && CrackerData.CharacterGrid[startColumn, startRow + 1].IsLetter())))
				{
					return 0;
				}

				int maxColumn = CrackerData.Configuration.Columns;
				int aboveCount = 0;
				int belowCount = 0;
				for (int column = startColumn; column < CrackerData.Configuration.Columns; column++)
				{
					if (CrackerData.CharacterGrid[column, startRow].HasHorizontalBeside() ||
						CrackerData.CharacterGrid[column, startRow].IsUnusable())
					{
						maxColumn = column;
						break;
					}
					// If a word lies immediately above this word then limit the word length.
					if (startRow > 0)
					{
						if (CrackerData.CharacterGrid[column, startRow - 1].IsLetter())
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
					if (startRow + 1 < CrackerData.Configuration.Rows)
					{
						if (CrackerData.CharacterGrid[column, startRow + 1].IsLetter())
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
					return 0;
				}

				for (int column = startColumn; column < CrackerData.Configuration.Columns; column++)
				{
					if (CrackerData.CharacterGrid[column, startRow].IsLetter())
					{
						int letterNumber = CrackerData.CharacterGrid[column, startRow].LetterNumber();
						existingLetters.Add(new KeyValuePair<int, int>(column - startColumn, letterNumber));
					}
				}
			}
			else
			{
				if (startRow >= CrackerData.Configuration.Rows - m_shortestWord)
				{
					return 0;
				}
				// If the cell immediately before this word has a letter in it then the cell is not useable.
				if (startRow > 0 && CrackerData.CharacterGrid[startColumn, startRow - 1].IsLetter())
				{
					return 0;
				}
				// If the first two letters are used then we must be on an existing word.
				if (startRow + 1 < CrackerData.Configuration.Rows &&
					CrackerData.CharacterGrid[startColumn, startRow].IsLetter() &&
					CrackerData.CharacterGrid[startColumn, startRow + 1].IsLetter())
				{
					return 0;
				}
				// If the current cell is not filled but either of the adjacent are then the cell is not useable;
				if (!CrackerData.CharacterGrid[startColumn, startRow].IsLetter() &&
					((startColumn > 0 && CrackerData.CharacterGrid[startColumn - 1, startRow].IsLetter()) ||
					 (startColumn + 1 < CrackerData.Configuration.Columns && CrackerData.CharacterGrid[startColumn + 1, startRow].IsLetter())))
				{
					return 0;
				}

				int maxRow = CrackerData.Configuration.Rows;
				int leftCount = 0;
				int rightCount = 0;
				for (int row = startRow; row < CrackerData.Configuration.Rows; row++)
				{
					if (CrackerData.CharacterGrid[startColumn, row].HasVerticalBeside() ||
						CrackerData.CharacterGrid[startColumn, row].IsUnusable())
					{
						maxRow = row;
						break;
					}

					// If a word lies immediately left of this word then limit the word length.
					if (startColumn > 0)
					{
						if (CrackerData.CharacterGrid[startColumn - 1, row].IsLetter())
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
					if (startColumn + 1 < CrackerData.Configuration.Columns)
					{
						if (CrackerData.CharacterGrid[startColumn + 1, row].IsLetter())
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
					return 0;
				}

				for (int row = startRow; row < CrackerData.Configuration.Rows; row++)
				{
					if (CrackerData.CharacterGrid[startColumn, row].IsLetter())
					{
						int letterNumber = CrackerData.CharacterGrid[startColumn, row].LetterNumber();
						existingLetters.Add(new KeyValuePair<int, int>(row - startRow, letterNumber));
					}
				}
			}

			if (maximumWordLength < m_shortestWord)
			{
				return 0;
			}

			if (preferredLength > 0 && preferredLength < maximumWordLength)
			{
				maximumWordLength = preferredLength;
			}

			if (existingLetters.Count > 0)
			{
				// Find a word that fits
				List<Dictionary<int, List<GeneratorWord>>> listOfLists = new List<Dictionary<int, List<GeneratorWord>>>();

				foreach (KeyValuePair<int, int> pair in existingLetters)
				{
					if (m_characterPositions[pair.Key, pair.Value] != null)
					{
						listOfLists.Add(m_characterPositions[pair.Key, pair.Value]);
					}
				}
				if (listOfLists.Count > 1)
				{
					Dictionary<int, List<GeneratorWord>> wordList = listOfLists[0];

					int wordLength = maximumWordLength;

					while (wordLength > 0)
					{
						bool exitLoop = false;
						if (wordList.ContainsKey(wordLength))
						{
							for (int i = 0; i < wordList[wordLength].Count; i++)
							{
								if (wordList[wordLength][i].Used)
								{
									continue;
								}
								if (horizontal && startColumn + wordLength < CrackerData.Configuration.Columns &&
									CrackerData.CharacterGrid[startColumn + wordLength, startRow].IsLetter())
								{
									continue;
								}
								if (!horizontal && startRow + wordLength < CrackerData.Configuration.Rows &&
									CrackerData.CharacterGrid[startColumn, startRow + wordLength].IsLetter())
								{
									continue;
								}
								
								GeneratorWord matchingWord = wordList[wordLength][i];

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
						word = SelectWord(wordList, maximumWordLength, startRow, startColumn, horizontal);
					}
				}
				else if (listOfLists.Count > 0)
				{
					word = SelectWord(listOfLists[0], maximumWordLength, startRow, startColumn, horizontal);
				}
			}
			else
			{
				word = SelectWord(m_wordsByLength, maximumWordLength, startRow, startColumn, horizontal);
			}

			if (word != null)
			{
				AddWordToGrid(word, startRow, startColumn, horizontal);
			}

			return (word == null ? 0 : word.Length);
		}

		private GeneratorWord SelectWord(Dictionary<int, List<GeneratorWord>> wordDictionary, int maximumWordLength, int startRow, int startColumn, bool horizontal)
		{
			int wordLength = maximumWordLength;
			GeneratorWord word = null;

			while (wordLength > 0)
			{
				bool exitLoop = false;
				if (wordDictionary.ContainsKey(wordLength))
				{
					for (int i = 0; i < wordDictionary[wordLength].Count; i++)
					{
						int index = CrackerData.NextRandom(0, wordDictionary[wordLength].Count);

						if (wordDictionary[wordLength][index].Used)
						{
							continue;
						}
						if (horizontal && startColumn + wordLength < CrackerData.Configuration.Columns &&
									CrackerData.CharacterGrid[startColumn + wordLength, startRow].IsLetter())
						{
							continue;
						}
						if (!horizontal && startRow + wordLength < CrackerData.Configuration.Rows &&
							CrackerData.CharacterGrid[startColumn, startRow + wordLength].IsLetter())
						{
							continue;
						}
						word = wordDictionary[wordLength][index];

						if (word.Length <= maximumWordLength)
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

		private bool ExistsInAllLists(List<Dictionary<int, List<GeneratorWord>>> listOfLists, int level, GeneratorWord word)
		{
			bool result = false;

			if (listOfLists[level].ContainsKey(word.Length))
			{
				if (listOfLists[level][word.Length].Contains(word))
				{
					if (level + 1 < listOfLists.Count)
					{
						result = ExistsInAllLists(listOfLists, level + 1, word);
					}
					else
					{
						result = true;
					}
				}
			}
			else
			{
				result = true;
			}

			return result;
		}

		private bool AddWordToGrid(GeneratorWord word, int row, int column, bool horizontal)
		{
			if (horizontal)
			{
				for (int letter = 0; letter < word.Length; letter++)
				{
					if (CrackerData.CharacterGrid[column + letter, row].IsLetter() &&
						CrackerData.CharacterGrid[column + letter, row].CorrectLetter != word.Word[letter])
					{
						return false;
					}
				}
			}
			else
			{
				for (int letter = 0; letter < word.Length; letter++)
				{
					if (CrackerData.CharacterGrid[column, row + letter].IsLetter() &&
						CrackerData.CharacterGrid[column, row + letter].CorrectLetter != word.Word[letter])
					{
						return false;
					}
				}
			}

			word.Used = true;

			CrackerData.GridWords.Add(new CodeWord(word.Word, row, column, horizontal));

			if (horizontal)
			{
				if (column > 0)
				{
					CrackerData.CharacterGrid[column - 1, row].SetUnusable();
				}
				if (column + word.Length < CrackerData.Configuration.Columns)
				{
					CrackerData.CharacterGrid[column + word.Length, row].SetUnusable();
				}
				for (int letter = 0; letter < word.Length; letter++)
				{
					CrackerData.CharacterGrid[column + letter, row].CorrectLetter = word.Word[letter];

					if(!CrackerData.LettersUsed.Contains(word.Word[letter]))
					{
						CrackerData.LettersUsed.Add(word.Word[letter]);
					}

					if (row > 0)
					{
						if (CrackerData.CharacterGrid[column + letter, row - 1].IsEmpty())
						{
							CrackerData.CharacterGrid[column + letter, row - 1].SetHorizontalBeside();
						}
					}
					if (row + 1 < CrackerData.Configuration.Rows)
					{
						if (CrackerData.CharacterGrid[column + letter, row + 1].IsEmpty())
						{
							CrackerData.CharacterGrid[column + letter, row + 1].SetHorizontalBeside();
						}
					}
				}
			}
			else
			{
				if (row > 0)
				{
					CrackerData.CharacterGrid[column, row - 1].SetUnusable();
				}
				if (row + word.Length < CrackerData.Configuration.Rows)
				{
					CrackerData.CharacterGrid[column, row + word.Length].SetUnusable();
				}
				for (int letter = 0; letter < word.Length; letter++)
				{
					CrackerData.CharacterGrid[column, row + letter].CorrectLetter = word.Word[letter];
					if(!CrackerData.LettersUsed.Contains(word.Word[letter]))
					{
						CrackerData.LettersUsed.Add(word.Word[letter]);
					}

					if (column > 0)
					{
						if (CrackerData.CharacterGrid[column - 1, row + letter].IsEmpty())
						{
							CrackerData.CharacterGrid[column - 1, row + letter].SetVerticalBeside();
						}
					}
					if (column + 1 < CrackerData.Configuration.Rows)
					{
						if (CrackerData.CharacterGrid[column + 1, row + letter].IsEmpty())
						{
							CrackerData.CharacterGrid[column + 1, row + letter].SetVerticalBeside();
						}
					}
				}
			}
			return true;
		}
	}
}
