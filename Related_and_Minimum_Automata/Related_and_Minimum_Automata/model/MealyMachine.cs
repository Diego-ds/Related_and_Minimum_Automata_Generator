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

		public List<string> GetConnectedStates()
		{
			
		}

		public List<string> GetDisconnectedStates()
		{

		}

		public void RemoveDisconnectedStates()
		{

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
				for (int i = 1; i < row.Length - 2; i++)
				{
					string[] objectiveAndOutput = row[i].Split(',');
					AddTransition(row[0], objectiveAndOutput[0], Convert.ToString(i - 1), objectiveAndOutput[1]);
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
