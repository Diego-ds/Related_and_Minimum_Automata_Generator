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
		private List<MooreState> ConnectedStates()
		{
			List<MooreState> connectedStates = new List<MooreState>();

			if (Initial != null)
			{
				if (Initial.Transitions.Count() == 0)
                {
					connectedStates.Add(Initial);
                }
				else
                {
					connectedStates = GetConnectedStates(Initial, connectedStates);
                }
			}

			return connectedStates;
		}

		private List<MooreState> GetConnectedStates(MooreState current, List<MooreState> connStates)
        {
			connStates.Add(current);
			Console.WriteLine("Estado Agregado: " + current.Identifier);
			foreach(MooreTransition trans in current.Transitions)
            {
				if (!connStates.Contains(trans.Objective))
                {
					connStates = GetConnectedStates(trans.Objective, connStates);
				}
            }
			return connStates;
        }

		public void RemoveDisconnectedStates()
		{
			List<MooreState> connStates = ConnectedStates();

            foreach (MooreState state in States)
            {
				if (!connStates.Contains(state))
                {
					RemoveState(state.Identifier);
				}
            }
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

		public void AddState(MooreState toAdd)
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

		public bool AddTransition(string origin, string end, string input)
		{
			MooreState originState = SearchState(origin);
			MooreState endState = SearchState(origin);
			if (originState != null && endState != null)
			{
				originState.AddTransition(new MooreTransition(endState, input));
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

		public void LoadMachine(List<string[]> rows)
        {
			LoadStates(rows);

			LoadTransitions(rows);
		}

		public void LoadStates(List<string[]> rows)
        {
			foreach (string[] row in rows)
			{
				MooreState newState = new MooreState(row[0], row[row.Length - 1]);
				AddState(newState);
			}
		}

		public void LoadTransitions(List<string[]> rows)
        {
			foreach (string[] row in rows)
			{
				for (int i = 1; i < row.Length - 2; i++)
                {
					AddTransition(row[0], row[i], Convert.ToString(i - 1));
				}
			}
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
