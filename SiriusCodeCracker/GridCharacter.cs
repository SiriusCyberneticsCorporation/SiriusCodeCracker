using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class GridCharacter
	{
		public int LetterNumber()
		{
			return m_letter - 65;
		}

		public bool IsLetter()
		{
			return m_charcterState == Enumerations.CellCharacterState.Letter;
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
		}

		public char Letter 
		{ 
			get { return m_letter; }
			set 
			{ 
				m_letter = char.ToUpper(value);
				m_charcterState = Enumerations.CellCharacterState.Letter;
			}
		}
		public Enumerations.CellCharacterState CharcterState { get { return m_charcterState; } }
		public Enumerations.CellVisualState VisualState { get { return m_visualState; } }
		public Enumerations.CellGameState GameState { get { return m_gameState; } }

		private char m_letter;
		private Enumerations.CellCharacterState m_charcterState = Enumerations.CellCharacterState.Empty;
		private Enumerations.CellVisualState m_visualState = Enumerations.CellVisualState.Empty;
		private Enumerations.CellGameState m_gameState = Enumerations.CellGameState.Number;
	}
}
