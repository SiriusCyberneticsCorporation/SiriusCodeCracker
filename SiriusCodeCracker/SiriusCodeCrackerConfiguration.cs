using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SiriusCodeCracker
{
	public class SiriusCodeCrackerConfiguration
	{
		public int Columns { get { return m_numberOfColumns; } set { m_numberOfColumns = Math.Max(5, Math.Min(32, value)); } }
		public int Rows { get { return m_numberOfRows; } set { m_numberOfRows = Math.Max(5, Math.Min(32, value)); } }
		public int GivenLetters { get { return m_givenLetters; } set { m_givenLetters = value; } }
		public bool GivenLettersGrouped { get { return m_givenLettersGrouped; } set { m_givenLettersGrouped = value; } }
		public bool ShowAllErrors { get { return m_showAllErrors; } set { m_showAllErrors = value; } }
		public bool ShowIncorrectWords { get { return m_showIncorrectWords; } set { m_showIncorrectWords = value; } }
	
		public Color BackgroundColour { get { return m_backgroundColour; } set { m_backgroundColour = value; } }
		public Brush LetterBrush { get { return m_letterBrush; } set { m_letterBrush = value; } }
		public Brush UsedLetterBrush { get { return m_usedLetterBrush; } set { m_usedLetterBrush = value; } }
		public Pen GridPen { get { return m_gridPen; } set { m_gridPen = value; } }
		public Brush GridBrush { get { return m_gridBrush; } set { m_gridBrush = value; } }
		public Brush NumberBrush { get { return m_numberBrush; } set { m_numberBrush = value; } }
		public Brush GivenBrush { get { return m_givenBrush; } set { m_givenBrush = value; } }
		public Brush HighlightBrush { get { return m_highlightBrush; } set { m_highlightBrush = value; } }
		public Brush ErrorBrush { get { return m_errorBrush; } set { m_errorBrush = value; } }

		private int m_numberOfColumns = 18;
		private int m_numberOfRows = 18;
		private int m_givenLetters = 3;
		private bool m_givenLettersGrouped = false;
		private bool m_showAllErrors = true;
		private bool m_showIncorrectWords = false;

		private Color m_backgroundColour = Color.White;
		private Brush m_letterBrush = Brushes.Black;
		private Brush m_usedLetterBrush = Brushes.DimGray;
		private Pen m_gridPen = Pens.Black;
		private Brush m_gridBrush = Brushes.Black;
		private Brush m_numberBrush = Brushes.Black;
		private Brush m_givenBrush = Brushes.Blue;
		private Brush m_highlightBrush = Brushes.CornflowerBlue;
		private Brush m_errorBrush = Brushes.Pink;
	}
}
