using System;
using System.Collections.Generic;
namespace Related_and_Minimum_Automata.model
{
	public class MooreState
	{
		public string Identifier { get; set; }
		public string Output { get; set; }
		public List<MooreState> Transitions { get; set; }

		public MooreState(string identifier, string output)
		{
			this.Identifier = identifier;
			this.Output = output;
			Transitions = new List<MooreState>();
		}

		public void AddTransition(MooreState toAdd)
		{
			Transitions.Add(toAdd);
		}

		public void SearchState(string toSearch)
        {
            foreach ()
            {

            }
        }

		public List<MooreState> GetAllTransitions(List<MooreState> currentTransitions)
        {
			if (Transitions != null)
            {

            }
        }
	}
}

