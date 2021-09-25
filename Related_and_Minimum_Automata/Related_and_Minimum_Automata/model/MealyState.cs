using System;

namespace MealyState.model
{
	public class MealyState
	{
		private string identifier;
		List<MealyTransition> transitions;

		public MooreState(string identifier)
		{
			this.identifier = identifier;
			transitions = new List<MealyTransition>();
		}
	}
}
