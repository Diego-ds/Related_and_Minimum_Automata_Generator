using System;
using System.Collections.Generic;
namespace Related_and_Minimum_Automata.model
{
	public class MooreState
	{
		public string Identifier { get; set; }
		public string Output { get; set; }
		public List<MooreTransition> Transitions { get; set; }

		public List<int> Input;
		public MooreState(string identifier, string output)
		{
			this.Identifier = identifier;
			this.Output = output;
			Transitions = new List<MooreTransition>();
		}

		public void AddTransition(MooreTransition toAdd)
		{
			Transitions.Add(toAdd);
		}

		public void SearchState(string toSearch)
        {
            foreach ()
            {

            }
        }

		public List<MooreState> GetAllTransitions(List<MooreTransition> currentTransitions)
        {
			if (Transitions != null)
            {

            }
        }
	}
}

