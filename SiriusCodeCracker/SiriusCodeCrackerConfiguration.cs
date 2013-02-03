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
		public Color BackgroundColour { get { return m_backgroundColour; } set { m_backgroundColour = value; } }
		public Brush LetterBrush { get { return m_letterBrush; } set { m_letterBrush = value; } }
		public Brush UsedLetterBrush { get { return m_usedLetterBrush; } set { m_usedLetterBrush = value; } }
		public Pen GridPen { get { return m_gridPen; } set { m_gridPen = value; } }
		public Brush GridBrush { get { return m_gridBrush; } set { m_gridBrush = value; } }
		public Brush NumberBrush { get { return m_numberBrush; } set { m_numberBrush = value; } }
		public Brush GivenBrush { get { return m_givenBrush; } set { m_givenBrush = value; } }
		public Color HighlightColour { get { return m_highlightColour; } set { m_highlightColour = value; } }

		private int m_numberOfColumns = 13;
		private int m_numberOfRows = 13;
		private Color m_backgroundColour = Color.White;
		private Brush m_letterBrush = Brushes.Black;
		private Brush m_usedLetterBrush = Brushes.DarkGray;
		private Pen m_gridPen = Pens.Black;
		private Brush m_gridBrush = Brushes.Black;
		private Brush m_numberBrush = Brushes.Black;
		private Brush m_givenBrush = Brushes.Blue;
		private Color m_highlightColour = Color.Aquamarine;
	}
}
