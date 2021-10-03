using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
	///<summary>
	///Mealy machine class
	///</summary>
	///<remarks>
	///Manage the data of the mealy machine
	///</remarks>
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

		///<summary>
		///Get all the reachable states of the machine
		///</summary>
		///<return>
		///A list with all the reachable states of the machine
		///</return>
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

		///<summary>
		///Get all the reachable states of the machine by a determined state
		///</summary>
		///<return>
		///A list with the reachable states from a determined state
		///</return>
		///<param name="current">
		///Current state of the machine
		///</param>
		///<param name="connStates">
		///List of the previous reached states
		///</param>
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

		///<summary>
		///Remove the unreachable states from the machine
		///</summary>
		public void RemoveDisconnectedStates()
        {
			List<MealyState> connStates = ConnectedStates();

			States = connStates;
        }

		///<summary>
		///Get the minimum equivalent machine from the machine
		///</summary>
		///<return>
		///A table with the minimum equivalent machine from the machine
		///</return>
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

		///<summary>
		///Create a minimum equivalent machine
		///</summary>
		///<return>
		///List with the states of the minimum equivalent machine
		///</return>
		///<param name="minimumPartition">
		///Partition of the machine
		///</param>
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
					newStates[i].AddTransition(new MealyTransition(os.Item1, input, os.Item2));
				}
			}
			return newStates;
		}

		///<summary>
		///Find the objective state and output of a block of the partition to create a transition on the renamed states
		///</summary>
		///<return>
		///Tuple with the objective state and output of a transition
		///</return>
		///<param name="input">
		///Current input to look for
		///</param>
		///<param name="index">
		///Index of the block in the partition
		///</param>
		///<param name="newStates">
		///States of the minimum equivalent machine
		///</param>
		///<param name="minimumPartition">
		///Partition of the machine
		///</param>
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

		///<summary>
		///Get the final partition of the machine
		///</summary>
		///<return>
		///Matrix with the final partition of the machine
		///</return>
		public List<List<MealyState>> PartitionateMachine()
		{
			List<List<MealyState>> newPartition = FirstPartition();
			List<List<MealyState>> prevPartition = new List<List<MealyState>>();

			while (!PartitionsEquals(newPartition, prevPartition))
			{
				prevPartition = new List<List<MealyState>>(newPartition);
				newPartition = NextPartition(new List<List<MealyState>>(prevPartition));
			}
			return newPartition;
		}

		///<summary>
		///Get the next partition of a given partition
		///</summary>
		///<return>
		///Partition of the machine
		///</return>
		///<param name="prevPartition">
		///The previous partition to partitionate
		///</param>
		public List<List<MealyState>> NextPartition(List<List<MealyState>> prevPartition)
		{

			List<Tuple<int, List<MealyState>>> newBlocks = new List<Tuple<int, List<MealyState>>>();

			for (int i = 0; i < prevPartition.Count; i++)
			{
				Tuple<int, List<MealyState>> differentStates;

				if (i != prevPartition.Count - 1)
				{
					differentStates = new Tuple<int, List<MealyState>>(i + 1, new List<MealyState>());
				}
				else
				{
					differentStates = new Tuple<int, List<MealyState>>(-1, new List<MealyState>());
				}

				for (int j = 1; j < prevPartition[i].Count; j++)
				{
					if (!TransitionFunctionEquals(prevPartition[i][0], prevPartition[i][j], prevPartition))
					{
						differentStates.Item2.Add(prevPartition[i][j]);
					}
				}
				if (differentStates.Item2.Count >= 1)
				{
					foreach (MealyState dState in differentStates.Item2)
					{
						prevPartition[i].Remove(dState);
					}
					newBlocks.Add(differentStates);
				}
			}
			foreach (Tuple<int, List<MealyState>> newBlock in newBlocks)
			{
				if (newBlock.Item1 == -1)
				{
					prevPartition.Add(newBlock.Item2);
				}
				else
				{
					prevPartition.Insert(newBlock.Item1, newBlock.Item2);
				}
			}

			return prevPartition;
		}

		///<summary>
		///Checks if the transitions of two given states are in the block of the partition
		///</summary>
		///<return>
		///Boolean value
		///</return>
		///<param name="q1">
		///Given state
		///</param>
		///<param name="q2">
		///Given state
		///</param>
		///<param name="partition">
		///Partition of the machine
		///</param>
		public bool TransitionFunctionEquals(MealyState q1, MealyState q2, List<List<MealyState>> partition)
		{
			
			bool equal = true;
			List<MealyState> ts1 = new List<MealyState>();
			List<MealyState> ts2 = new List<MealyState>();

			for (int i = 0; i < q1.Transitions.Count; i++)
			{
				ts1.Add(q1.Transitions[i].Objective);
				ts2.Add(q2.Transitions[i].Objective);
			}
			foreach (List<MealyState> block in partition)
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

		///<summary>
		///Check if two partitions are equal
		///</summary>
		///<return>
		///Boolean value
		///</return>
		///<param name="p1">
		///Given partition
		///</param>
		///<param name="p2">
		///Given partition
		///</param>
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

		///<summary>
		///Check if two blocks of a partition are equal
		///</summary>
		///<return>
		///Boolean value
		///</return>
		///<param name="b1">
		///Given block
		///</param>
		///<param name="b2">
		///Given block
		///</param>
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

		///<summary>
		///Add a new state
		///</summary>
		///<param name="toAdd">
		///New state to add
		///</param>
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

		///<summary>
		///Add a new transition to the machine
		///</summary>
		///<return>
		///Boolean value indicating if the transition was added
		///</return>
		///<param name="initial">
		///Identifier of the initial state of the transition
		///</param>
		///<param name="final">
		///Identifier of the final state of the transition
		///</param>
		///<param name="input">
		///Input of the transition
		///</param>
		///<param name="output">
		///Output of the transition
		///</param>
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

		///<summary>
		///Search a state of the machine
		///</summary>
		///<return>
		///Found state
		///</return>
		///<param name="id">
		///Identifier of the state to look for
		///</param>
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

		///<summary>
		///Load a new machine
		///</summary>
		///<param name="rows">
		///Rows of the table of the new machine
		///</param>
		public void LoadMachine(List<string[]> rows)
		{
			foreach (string[] row in rows)
			{
				for (int i = 1; i < row.Length; i++)
				{
					if (row[i].Equals("") || row[i].Length < 4)
					{
						throw new ArgumentException("Please begin the state with a 'q', follow it " +
							"with integers and separate the output from the state with a comma.");
					}
					else if (!row[i].Contains(',') || row[i][row[i].Length - 1].Equals(','))
                    {
						throw new ArgumentException("Please separate the state and output with a comma.");
					}
	
					string[] checker = row[i].Split(',');
					if (checker.Length != 2)
                    {
						throw new ArgumentException("Please don't input more than 1 comma.");
					}
					else 
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
		}

		///<summary>
		///Get the first partition of the machine
		///</summary>
		///<return>
		///First partition of the machine
		///</return>
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

		///<summary>
		///Clear all the data of the machine
		///</summary>
		public void CleanMachine()
		{
			Inputs.Clear();
			States.Clear();
			Outputs.Clear();
			Initial = null;
		}
	}

}
