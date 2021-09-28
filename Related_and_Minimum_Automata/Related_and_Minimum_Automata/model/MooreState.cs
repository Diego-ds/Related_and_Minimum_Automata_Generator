using System;
using System.Collections.Generic;
namespace Related_and_Minimum_Automata.model
{ 
	public class MooreState
	{
		private string identifier;
		private string output;
		public List<MooreState> transitions { get; set; }

		public MooreState(string identifier, string output)
		{
			this.identifier = identifier;
			this.output = output;
			transitions = new List<MooreState>();
		}

		public void AddTransition (MooreState toAdd)
        {
			transitions.Add(toAdd);
        }

		public void RemoveTransition(MooreState toRemove)
        {
			transitions.Remove(toRemove);
        }
	}
}

