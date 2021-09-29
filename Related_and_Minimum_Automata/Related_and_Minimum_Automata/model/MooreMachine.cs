using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    class MooreMachine
    {
		public List<MooreState> States { get; set; }
		public List<string> Inputs { get; set; }
		public List<string> Outputs { get; set; }
		public MooreState Initial { get; set; }

		public MooreMachine()
		{
			this.States = new List<MooreState>();
			this.Inputs = new List<string>();
			this.Outputs = new List<string>();
			this.Initial = null;
		}

		//Searches the connected states with DFS
		public List<MooreState> GetConnectedStates()
		{
			List<MooreState> connectedStates = new List<MooreState>();

			if (Initial != null)
            {
				connectedStates = Initial.GetAllTransitions();
            }

			return connectedStates;
		}

		public List<string> GetDisconnectedStates()
		{

		}

		public void RemoveDisconnectedStates()
		{

		}

		public bool RemoveState(string toRemove)
        {
			MooreState removedState = SearchState(toRemove);

			if (removedState != null)
            {
				States.Remove(removedState);
				return true;
            } 
			else
            {
				return false;
            }
        }

		public void addState(MooreState toAdd)
        {
			if (Initial == null)
            {
				Initial = toAdd;
				States.Add(Initial);
            }
			else
            {
				States.Add(toAdd);
            }
        }

		public bool AddTransition(string origin, string end)
        { 
			MooreState originState = SearchState(origin);
			MooreState endState = SearchState(origin);

			if (originState != null && endState != null)
            {
				originState.AddTransition(endState);
				return true;
            }
            else
            {
				return false;
			}	
		}

		public MooreState SearchState(string toSearch)
        {
			MooreState desiredState = null;

			foreach (MooreState state in States)
            {
				if (state.Identifier.Equals(toSearch))
                {
					desiredState = state;
					break;
                }
            }

			return desiredState;
        }
		public void CleanMachine()
		{
			Inputs.Clear();
			States.Clear();
			Outputs.Clear();
			Initial = null;
		}
	}
}
