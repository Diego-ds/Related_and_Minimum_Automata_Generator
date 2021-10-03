using System;
using System.Collections.Generic;
namespace Related_and_Minimum_Automata.model
{
	public class MooreState
	{
		public string Identifier { get; set; }
		public string Output { get; set; }
		public List<MooreTransition> Transitions { get; set; }

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

		public MooreTransition SearchTransition(string toSearch)
        {
			MooreTransition moore = null;
			foreach (MooreTransition found in Transitions)
			{
				if (found.Objective.Identifier.Equals(toSearch))
				{
					moore = found;
				}
			}
			return moore;	
        }
	}
}

