using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    class MealyMachine
    {
		public List<MealyState> States { get; set; }
		public List<string> Inputs { get; set; }
		public List<string> Outputs { get; set; }
		public MealyState Initial { get; set; }
		
		public MealyMachine()
		{
			States = new List<MealyState>();
			Inputs = new List<string>();
			Outputs = new List<string>();
			Initial = null;
		}

		private List<MealyState> ConnectedStates()
        {
			List<MealyState> connStates = new List<MealyState>();
            if (Initial == null)
            {
				return null;
            }
            else
            {
				return GetConnectedStates(Initial,connStates);
            }

        }

		private List<MealyState> GetConnectedStates(MealyState current, List<MealyState> connStates)
        {
			connStates.Add(current);
			foreach (MealyTransition t in current.Transitions)
            {
                if (!connStates.Contains(t.Objective))
                {
					connStates =  GetConnectedStates(t.Objective, connStates);
                }
            }

			return connStates;
        }

		public void RemoveDisconnectedStates()
        {
			List<MealyState> connStates = ConnectedStates();

			States = connStates;
        }

		public DataTable ReduceMachine()
		{
			List<List<MealyState>> minimumPartition = PartitionateMachine();
			List<MealyState> minimumMachine = CreateMinimumEquivalent(minimumPartition);
			DataTable table = new DataTable(); 

			table.Columns.Add("States");
			for (int i = 0; i < Inputs.Count; i++)
			{
				table.Columns.Add(Convert.ToString(i));
			}

			for (int j = 0; j < minimumMachine.Count; j++)
			{
				table.Rows.Add();
			}

			int rowNum = 0;
			foreach (DataRow row in table.Rows)
			{
				for (int i = 0; i < Inputs.Count + 1; i++)
				{
					if (i == 0)
					{
						row[i] = "q" + Convert.ToString(rowNum+1);
					}
					else
					{
						row[i] = minimumMachine[rowNum].Transitions[i-1].Objective.Identifier+","+ minimumMachine[rowNum].Transitions[i-1].Output;
					}
				}
				rowNum++;
			}
			return table;
			
		}

		public List<MealyState> CreateMinimumEquivalent(List<List<MealyState>> minimumPartition)
		{

			string finalpart = "";
            foreach (List<MealyState> s in minimumPartition )
            {
				foreach(MealyState m in s)
                {
					finalpart += m.Identifier + " ";
                }
				finalpart += "\n";
            }
			Console.WriteLine("Particion final: " + finalpart);
			List<MealyState> newStates = new List<MealyState>();
			for (int i = 0; i < minimumPartition.Count; i++)
			{
				newStates.Add(new MealyState("q" + Convert.ToString(i+1)));
			}

			foreach (string input in Inputs)
			{
				for (int i = 0; i < newStates.Count; i++)
				{
					Tuple<MealyState,string> os = FindNewTransition(input, i, newStates, minimumPartition);
					Console.WriteLine("State: " + newStates[i].Identifier + " Input: " + input + " Objective: " + os.Item1.Identifier + " Output: " + os.Item2);
					newStates[i].AddTransition(new MealyTransition(os.Item1, input, os.Item2));
				}
			}
			return newStates;
		}

		public Tuple<MealyState,string> FindNewTransition(string input, int index, List<MealyState> newStates, List<List<MealyState>> minimumPartition)
		{
			List<MealyTransition> transitions = minimumPartition[index][0].Transitions;

			foreach (MealyTransition transition in transitions)
			{
				if (transition.Input.Equals(input))
				{
					for (int i = 0; i < minimumPartition.Count; i++)
					{
						if (minimumPartition[i].Contains(transition.Objective))
						{
							return new Tuple<MealyState,string>(newStates[i], transition.Output);
						}
					}
				}
			}
			return null;
		}

		public List<List<MealyState>> PartitionateMachine()
		{
			List<List<MealyState>> newPartition = FirstPartition();
			string partitions = "";
            /*foreach (List<MealyState> p in newPartition)
            {
				foreach(MealyState s in p)
                {
					partitions += s.Identifier + " ";
                }
				partitions += "\n";
            }
			Console.WriteLine(partitions);*/
			List<List<MealyState>> prevPartition = new List<List<MealyState>>();

			while (!PartitionsEquals(newPartition, prevPartition))
			{
				prevPartition = new List<List<MealyState>>(newPartition);
				newPartition = NextPartition(new List<List<MealyState>>(prevPartition));
			}
			return newPartition;
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
		public List<List<MealyState>> NextPartition(List<List<MealyState>> prevPartition)
		{
			List<List<MealyState>> newBlocks = new List<List<MealyState>>();
			int indexPartition = 0;
			string p = "";
			foreach (List<MealyState> block in prevPartition)
			{
				List<MealyState> differentStates = new List<MealyState>();

				for (int i = 1; i < block.Count; i++)
				{
					if (!TransitionFunctionEquals(block[0], block[i], prevPartition))
					{
						differentStates.Add(block[i]);						
					}
				}				
				foreach(MealyState s in differentStates)
                {
					p += s.Identifier + " ";
                }
				p += "\n";
				if (differentStates.Count >= 1)
				{
					foreach(MealyState s in differentStates)
                    {
						block.Remove(s);
                    }
					newBlocks.Add(differentStates);
					indexPartition++;
				}
				
			}
			Console.WriteLine(p);
					
			prevPartition.InsertRange(indexPartition,newBlocks);
			
			return prevPartition;
		}

		public bool TransitionFunctionEquals(MealyState q1, MealyState q2, List<List<MealyState>> partition)
		{
			Console.WriteLine("Q1: " + q1.Identifier);
			Console.WriteLine("Q2: " + q2.Identifier);
			bool equal = true;
			List<MealyState> ts1 = new List<MealyState>();
			List<MealyState> ts2 = new List<MealyState>();

			for (int i = 0; i < q1.Transitions.Count; i++)
			{
				ts1.Add(q1.Transitions[i].Objective);
				ts2.Add(q2.Transitions[i].Objective);
				Console.WriteLine("TS1 EN INPUT " + i + ": " + q1.Transitions[i].Objective.Identifier);
				Console.WriteLine("TS2 EN INPUT " + i + ": " + q2.Transitions[i].Objective.Identifier);
			}
			foreach (List<MealyState> block in partition)
			{
				for (int i = 0; i < ts1.Count && equal; i++)
				{
					if (block.Contains(ts1[i]) && !block.Contains(ts2[i]) ||
							(!block.Contains(ts1[i]) && block.Contains(ts2[i])))
					{
						Console.WriteLine("FALSO EN ts1: " + ts1[i].Identifier);
						Console.WriteLine("FALSO EN ts2: " + ts2[i].Identifier);
						equal = false;
					}
				}
			}
			Console.WriteLine("------------------------------");
			return equal;
		}

		public bool PartitionsEquals(List<List<MealyState>> p1, List<List<MealyState>> p2)
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

		public bool BlockEquals(List<MealyState> b1, List<MealyState> b2)
		{
			bool equal = true;

			if (b1.Count == b2.Count)
			{
				foreach (MealyState state in b1)
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

		public void AddState(MealyState toAdd)
        {
            if (Initial==null)
            {
				Initial = toAdd;
				States.Add(Initial);
            }
            else
            {
				States.Add(toAdd);
            }
        }

		public bool AddTransition(string initial,string final,string input,string output)
        {
			MealyState state = SearchState(initial);
            if (state != null)
            {
				MealyState stateFinal = SearchState(final);
                if (final != null)
                {
					state.AddTransition(new MealyTransition(stateFinal, input, output));
					return true;
                }
                else
                {
					return false;
                }

            }
            else
            {
				return false;
            }
        }

		public MealyState SearchState(string id)
        {
			MealyState m = null;
			foreach(MealyState found in States)
            {
                if (found.Identifier.Equals(id))
                {
					m = found;
					break;
                }
            }
			return m;
        }

		public void LoadMachine(List<string[]> rows)
		{
			LoadTransitions(rows);
		}

		public void LoadTransitions(List<string[]> rows)
		{
			foreach (string[] row in rows)
			{
				for (int i = 1; i < row.Length; i++)
				{
					string[] objectiveAndOutput = row[i].Split(',');
                    if (!Outputs.Contains(objectiveAndOutput[1]))
                    {
						Outputs.Add(objectiveAndOutput[1]);
					}										
					AddTransition(row[0], objectiveAndOutput[0], Convert.ToString(i - 1), objectiveAndOutput[1]);
				}
			}
		}

		private List<List<MealyState>> FirstPartition()
		{ 
			Dictionary<string,List<MealyState>> dictionary = new Dictionary<string,List <MealyState>>();
			List<List<MealyState>> partition = new List<List<MealyState>>();

			for(int i= 0;i<States.Count;i++)
            {
				string output = "";
				foreach(MealyTransition transition in States[i].Transitions)
                {
					output += transition.Output;
                }

                if (dictionary.ContainsKey(output))
                {
					dictionary[output].Add(States[i]);
                }
                else
                {
                    List<MealyState> newList = new List<MealyState>
                    {
                        States[i]
                    };
                    dictionary.Add(output, newList);
                }

            }

			foreach(List<MealyState> partitions in dictionary.Values)
            {
				partition.Add(partitions);
            }

			return partition;

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
