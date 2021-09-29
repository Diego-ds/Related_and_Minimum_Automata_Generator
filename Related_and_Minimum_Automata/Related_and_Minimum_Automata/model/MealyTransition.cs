using System;


namespace Related_and_Minimum_Automata.model
{
	public class MealyTransition
	{
		public MealyState Objective { get; set; }
		public String Input { get; set; }
		public String Output { get; set; }

		public MealyTransition(MealyState objective, String input, String output)
		{
			Objective = objective;
			Input = input;
			Output = output;
		}
	}
}

