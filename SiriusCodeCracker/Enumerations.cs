using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class Enumerations
	{
		public enum CellCharacterState
		{
			Empty,
			HorizontalBeside,
			VerticalBeside,
			Unusable,
			Letter
		}
		/*
		public enum CellVisualState
		{
			Empty,
			None,
			Selected,
			Highlighted
		}
		*/
		public enum CellGameState
		{
			Empty,
			Number,
			Letter,
			Given
		}
	}
}
