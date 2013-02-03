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
		}

		public string Word;
		public bool Horizontal;
		public int Column;
		public int Row;
	}
}
