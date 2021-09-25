using System;

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
