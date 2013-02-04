using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class CodeWord
	{
		public CodeWord(string word, int row, int column, bool horizontal)
		{
			Word = word;
			Column = column;
			Row = row;
			Horizontal = horizontal;
			Correct = false;
			Complete = false;
		}

		public int Row;
		public int Column;
		public bool Horizontal;
		public bool Correct;
		public bool Complete;
		public string Word;
	}
}
