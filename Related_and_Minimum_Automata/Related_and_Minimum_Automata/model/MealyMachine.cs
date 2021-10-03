using System;
using System.Collections.Generic;
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
			MealyState state = searchState(initial);
            if (state != null)
            {
				MealyState stateFinal = searchState(final);
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

		public MealyState searchState(string id)
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
					Outputs.Add(objectiveAndOutput[1]);
					Console.WriteLine(objectiveAndOutput[1]);
					AddTransition(row[0], objectiveAndOutput[0], Convert.ToString(i - 1), objectiveAndOutput[1]);
				}
			}
		}

		private List<List<MealyState>> firstPartition()
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
