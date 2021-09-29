using System;


namespace Related_and_Minimum_Automata.model
{
	public class MealyTransition
	{
		public MealyState Objective { get; set; }
		public string Input { get; set; }
		public string Output { get; set; }

		public MealyTransition(MealyState objective, string input, string output)
		{
			Objective = objective;
			Input = input;
			Output = output;
		}
	}
}

