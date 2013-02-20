using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class Enumerations
	{

		public enum eGameState
		{
			None,
			Active,
			Paused,
			Complete
		}

		public enum CellCharacterState
		{
			Empty,
			HorizontalBeside,
			VerticalBeside,
			Unusable,
			Letter
		}

		public enum CellGameState
		{
			Empty,
			Number,
			Letter,
			Given
		}
	}
}
