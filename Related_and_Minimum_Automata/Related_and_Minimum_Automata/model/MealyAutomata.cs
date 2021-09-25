using System;
using System.model.MealyState;

public class MealyAutomata : IAutomata
{
	public MealyAutomata()
	{
		private List<MealyState> states;
		private List<string> inputs;
		private List<string> outputs;
		private MealyState initial;

		public MealyAutomata(List<State> states, List<string> inputs, List<string> outputs, State initial)
		{
			this.states = new List<State>();
			this.inputs = new List<string>();
			this.outputs = new List<string>();
			this.initial = initial;
		}

		public override List<string> GetConnectedStates()
		{
			
		}

		public override List<string> GetDisconnectedStates()
		{

		}

		public override void RemoveDisconnectedStates()
		{

		}
}