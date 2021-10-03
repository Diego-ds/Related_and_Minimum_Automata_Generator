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
			foreach (MooreTransition trans in current.Transitions)
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

			States = connStates;
		}

		public void PartitionateMachine()
        {
			//List <MooreState> newPartition = Metodo de Diego 
			List <MooreState> prevPartition = new List<MooreState>();

			while (!PartitionsEquals(newPartition, prevPartition))
            {
				prevPartition = newPartition;
				newPartition = NextPartition(prevPartition);
            }
		}

		/*
 * ALGORTIMO DE PARTICION:
 * 1. Comparamos el primer estado de cada bloque con los otros estados de ese bloque
 *	1.1 Si se cumple f(q,s) y f(q',s), no hacer nada
 *	1.2 Si no se cumple, agregar el estado con que se esta comparando a un nuevo bloque D
 * 2. Comparamos con el primer estado de la lista D el resto de estados
 *	2.1 Si se cumple f(q,s) y f(q',s), no hacer nada
 *	2.2 Si no se cumple, agregar el estado con que se esta comparando a un nuevo bloque D'
 * 3. Si no resultan mas bloques D, agregar los bloques D a la particion y remover
 * los estados que pertenecen a los bloques D del bloque anterior
 * 4. Repetir hasta que se recorran todos los bloques de la particion
 * 5. Retornar la particion con los bloques D agregados
 */
		public List<List<MooreState>> NextPartition(List<List<MooreState>> prevPartition)
		{
			List<List<MooreState>> newBlocks = new List<List<MooreState>>();

			foreach (List<MooreState> block in prevPartition)
			{
				List<MooreState> differentStates = new List<MooreState>();

				for (int i = 1; i < block.Count; i++)
				{	
					if (!TransitionFunctionEquals(block[0], block[i],prevPartition))
					{
						differentStates.Add(block[i]);
					}
				}

				newBlocks.Add(differentStates);
				foreach
			}
		}

		public bool TransitionFunctionEquals(MooreState q1, MooreState q2, List<List<MooreState>> partition)
        {
			bool equal = true;
			List<MooreState> ts1 = new List<MooreState>();
			List<MooreState> ts2 = new List<MooreState>();

			for (int i = 0; i < q1.Transitions.Count; i++)
            {
				ts1.Add(q1.Transitions[i].Objective);
				ts2.Add(q2.Transitions[i].Objective);
			}
			foreach(List<MooreState> block in partition)
            {
				for (int i = 0; i < ts1.Count && equal; i++)
				{
					if (block.Contains(ts1[i]) && !block.Contains(ts2[i]) ||
							(!block.Contains(ts1[i]) && block.Contains(ts2[i])))
                    {
						equal = false;
                    }
				}
			}
			return equal;
		}

		public bool PartitionsEquals(List<List<MooreState>> p1, List<List<MooreState>> p2)
        {
			bool equal = true;

			if (p1.Count == p2.Count)
            {
				for (int i = 0; i < p1.Count && equal; i++)
				{
					if (!BlockEquals(p1[i], p2[i]))
                    {
						equal = false;
                    }
				}
			}
            else
            {
				equal = false;
            }

			return equal;
        }

		public bool BlockEquals(List<MooreState> b1, List<MooreState> b2)
        {
			bool equal = true;

			if (b1.Count == b2.Count)
            {
				foreach (MooreState state in b1)
				{
					if (!b2.Contains(state))
					{
						equal = false;
					}
				}
			}
			else
            {
				equal = false;
            }

			return equal;
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
			MooreState endState = SearchState(end);
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
				for (int i = 1; i < row.Length - 1; i++)
                {
					AddTransition(row[0], row[i], Convert.ToString(row.Length - 1));
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
