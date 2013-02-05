using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SiriusCodeCracker
{
	public class SiriusCodeCrackerConfiguration
	{
		public SiriusCodeCrackerConfiguration()
		{
			LetterColour = Properties.Settings.Default.LetterColour;
			UsedLetterColour = Properties.Settings.Default.UsedLetter;
			GridColour = Properties.Settings.Default.GridColour;
			NumberColour = Properties.Settings.Default.NumberColour;
			GivenColour = Properties.Settings.Default.GivenColour;
			HighlightColour = Properties.Settings.Default.HighlightColour;
			ErrorColour = Properties.Settings.Default.ErrorColour;
		}

		public int Columns { get { return m_numberOfColumns; } set { m_numberOfColumns = Math.Max(5, Math.Min(32, value)); } }
		public int Rows { get { return m_numberOfRows; } set { m_numberOfRows = Math.Max(5, Math.Min(32, value)); } }
		public int GivenLetters { get { return m_givenLetters; } set { m_givenLetters = value; } }
		public bool GivenLettersGrouped { get { return m_givenLettersGrouped; } set { m_givenLettersGrouped = value; } }
		public bool ShowAllErrors { get { return m_showAllErrors; } set { m_showAllErrors = value; } }
		public bool ShowIncorrectWords { get { return m_showIncorrectWords; } set { m_showIncorrectWords = value; } }

		public Color BackgroundColour
		{
			get { return Properties.Settings.Default.BackgroundColour; }
			set { Properties.Settings.Default.BackgroundColour = value; }
		}

		public Color LetterColour
		{
			get { return Properties.Settings.Default.LetterColour; }
			set 
			{ 
				Properties.Settings.Default.LetterColour = value;
				m_letterBrush = new SolidBrush(Properties.Settings.Default.LetterColour);
			}
		}

		public Color UsedLetterColour
		{
			get { return Properties.Settings.Default.UsedLetter; }
			set 
			{ 
				Properties.Settings.Default.UsedLetter = value;
				m_usedLetterBrush = new SolidBrush(Properties.Settings.Default.UsedLetter);
			}
		}

		public Color GridColour
		{
			get { return Properties.Settings.Default.GridColour; }
			set 
			{ 
				Properties.Settings.Default.GridColour = value;
				m_gridPen = new Pen(Properties.Settings.Default.GridColour);
				m_gridBrush = new SolidBrush(Properties.Settings.Default.GridColour);
			}
		}

		public Color NumberColour
		{
			get { return Properties.Settings.Default.NumberColour; }
			set 
			{ 
				Properties.Settings.Default.NumberColour = value;
				m_numberBrush = new SolidBrush(Properties.Settings.Default.NumberColour);
			}
		}

		public Color GivenColour
		{
			get { return Properties.Settings.Default.GivenColour; }
			set 
			{ 
				Properties.Settings.Default.GivenColour = value;
				m_givenBrush = new SolidBrush(Properties.Settings.Default.GivenColour);
			}
		}

		public Color HighlightColour
		{
			get { return Properties.Settings.Default.HighlightColour; }
			set 
			{ 
				Properties.Settings.Default.HighlightColour = value;
				m_highlightBrush = new SolidBrush(Properties.Settings.Default.HighlightColour);
			}
		}

		public Color ErrorColour
		{
			get { return Properties.Settings.Default.ErrorColour; }
			set 
			{ 
				Properties.Settings.Default.ErrorColour = value;
				m_errorBrush = new SolidBrush(Properties.Settings.Default.ErrorColour);
			}
		}

		public Brush LetterBrush { get { return m_letterBrush; } }
		public Brush UsedLetterBrush { get { return m_usedLetterBrush; } }
		public Pen GridPen { get { return m_gridPen; } }
		public Brush GridBrush { get { return m_gridBrush; } }
		public Brush NumberBrush { get { return m_numberBrush; } }
		public Brush GivenBrush { get { return m_givenBrush; } }
		public Brush HighlightBrush { get { return m_highlightBrush; } }
		public Brush ErrorBrush { get { return m_errorBrush; } }

		private int m_numberOfColumns = 18;
		private int m_numberOfRows = 18;
		private int m_givenLetters = 3;
		private bool m_givenLettersGrouped = true;
		private bool m_showAllErrors = false;
		private bool m_showIncorrectWords = true;

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
