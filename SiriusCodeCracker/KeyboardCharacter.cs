using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class KeyboardCharacter
	{
		public KeyboardCharacter(char letter)
		{
			m_letter = letter;
		}

		public char Letter { get { return m_letter; } }
		public int Number { get { return m_number; } set { m_number = value; } }
		public bool NotRequired { get { return m_notRequired; } set { m_notRequired = value; } }
		public bool Used { get { return m_used; } set { m_used = value; } }
		public bool Given { get { return m_given; } set { m_given = value; } }
		public bool Selected { get { return m_selected; } set { m_selected = value; } }

		private char m_letter;
		private int m_number = -1;
		private bool m_notRequired = false;
		private bool m_used = false;
		private bool m_given = false;
		private bool m_selected = false;
	}
}
