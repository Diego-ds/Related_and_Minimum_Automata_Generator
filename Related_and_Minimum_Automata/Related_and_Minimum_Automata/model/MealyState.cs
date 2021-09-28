using System;
using System.Collections.Generic;

namespace Related_and_Minimum_Automata.model
{
	public class MealyState
	{
		private string identifier;
		List<MealyTransition> transitions;

		public MealyState(string identifier)
		{
			this.identifier = identifier;
			transitions = new List<MealyTransition>();
		}
	}
}
