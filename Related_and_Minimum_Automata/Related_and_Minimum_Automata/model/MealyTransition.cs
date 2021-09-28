using System;


namespace Related_and_Minimum_Automata.model
{
	public class MealyTransition
	{
		private MealyState objective;
		private String input;
		private String output;

		public MealyTransition(MealyState objective, String input, String output)
		{
			this.objective = objective;
			this.input = input;
			this.output = output;
		}
	}
}

