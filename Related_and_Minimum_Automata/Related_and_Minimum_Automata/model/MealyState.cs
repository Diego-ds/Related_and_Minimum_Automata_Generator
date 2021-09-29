using System;
using System.Collections.Generic;

namespace Related_and_Minimum_Automata.model
{
	public class MealyState
	{
		public string Identifier { get; set; }
		List<MealyTransition> Transitions;

		public MealyState(string identifier)
		{
			Identifier = identifier;
			Transitions = new List<MealyTransition>();
		}

		public void AddTransition(MealyTransition toAdd)
        {
			Transitions.Add(toAdd);
        }

		public void RemoveTransition(string id)
        {
			MealyTransition toRemove = searchTransition(id);
			Transitions.Remove(toRemove);
        }

		public MealyTransition searchTransition(string identifier)
        {
			MealyTransition mealy = null;
			foreach(MealyTransition found in Transitions)
            {
                if (found.Objective.Identifier.Equals(identifier))
                {
					mealy = found;
                }
            }
			return mealy;
        }
	}
}
