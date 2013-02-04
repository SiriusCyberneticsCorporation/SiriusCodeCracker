using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class GridCharacter
	{
		public static char NO_LETTER = (char)0;

		public int LetterNumber()
		{
			return m_correctLetter - 65;
		}

		public bool IsLetter()
		{
			return m_charcterState == Enumerations.CellCharacterState.Letter;
		}

		public bool IsGameLetter()
		{
			return m_gameState == Enumerations.CellGameState.Letter;
		}

		public bool IsGiven()
		{
			return m_gameState == Enumerations.CellGameState.Given;
		}

		public bool IsEmpty()
		{
			return m_charcterState == Enumerations.CellCharacterState.Empty;
		}

		public bool IsUnusable()
		{
			return m_charcterState == Enumerations.CellCharacterState.Unusable;
		}

		public bool HasHorizontalBeside()
		{
			return m_charcterState == Enumerations.CellCharacterState.HorizontalBeside;
		}

		public bool HasVerticalBeside()
		{
			return m_charcterState == Enumerations.CellCharacterState.VerticalBeside;
		}


		public void SetHorizontalBeside()
		{
			m_charcterState = Enumerations.CellCharacterState.HorizontalBeside;
		}

		public void SetVerticalBeside()
		{
			m_charcterState = Enumerations.CellCharacterState.VerticalBeside;
		}

		public void SetUnusable()
		{
			m_charcterState = Enumerations.CellCharacterState.Unusable;
		}

		public void SetAsGiven()
		{
			m_gameState = Enumerations.CellGameState.Given;
			m_selectedLetter = m_correctLetter;
		}

		public char CorrectLetter
		{
			get { return m_correctLetter; }
			set
			{
				m_correctLetter = char.ToUpper(value);
				m_charcterState = Enumerations.CellCharacterState.Letter;
			}
		}

		public char SelectedLetter
		{
			get { return m_selectedLetter; }
			set
			{
				m_selectedLetter = char.ToUpper(value);
				m_gameState = Enumerations.CellGameState.Letter;
			}
		}

		public void ResetSelection()
		{
			m_selectedLetter = NO_LETTER;
			m_gameState = Enumerations.CellGameState.Number;
		}
	
		public bool Selected { get { return m_selected; } set { m_selected = value; } }
		public Enumerations.CellCharacterState CharcterState { get { return m_charcterState; } }
		public Enumerations.CellGameState GameState { get { return m_gameState; } }

		private char m_correctLetter;
		private char m_selectedLetter;
		private bool m_selected = false;
		private Enumerations.CellCharacterState m_charcterState = Enumerations.CellCharacterState.Empty;
		private Enumerations.CellGameState m_gameState = Enumerations.CellGameState.Number;
	}
}
