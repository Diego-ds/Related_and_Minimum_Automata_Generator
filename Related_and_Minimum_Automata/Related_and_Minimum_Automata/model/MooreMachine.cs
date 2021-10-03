using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Related_and_Minimum_Automata.model
{
	///<summary>
	///Moore machine class
	///</summary>
	///<remarks>
	///Manage the data of the moore machine
	///</remarks>
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

		///<summary>
		///Get all the reachable states of the machine
		///</summary>
		///<return>
		///A list with all the reachable states of the machine
		///</return>
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

		///<summary>
		///Remove the unreachable states from the machine
		///</summary>
		public void RemoveDisconnectedStates()
		{
			List<MooreState> connStates = ConnectedStates();

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
			List<List<MooreState>> minimumPartition = PartitionateMachine();
			List<MooreState> minimumMachine = CreateMinimumEquivalent(minimumPartition);
			DataTable table = new DataTable();
			table.Columns.Add("States");
			for (int i = 0; i < Inputs.Count; i++)
			{
				table.Columns.Add(Convert.ToString(i));
			}
			table.Columns.Add("Outputs");
			
			for (int j = 0; j < minimumMachine.Count; j++)
			{
				table.Rows.Add();
			}
			int rowNum = 0;
			foreach (DataRow row in table.Rows)
			{

				for (int i = 0; i < Inputs.Count + 2; i++)
				{
					if (i == 0)
					{
						row[i] = "q" + Convert.ToString(rowNum + 1);
					}
					else if (i == Inputs.Count + 1)
					{
						row[i] = minimumMachine[rowNum].Output;
					}
					else
					{
						row[i] = minimumMachine[rowNum].Transitions[i-1].Objective.Identifier;
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
		public List<MooreState> CreateMinimumEquivalent(List<List<MooreState>> minimumPartition)
        {
			List<MooreState> newStates = new List<MooreState>();
			for (int i = 0; i < minimumPartition.Count; i++)
            {
				newStates.Add(new MooreState("q" + Convert.ToString(i+1),minimumPartition[i][0].Output));
			}

			foreach (string input in Inputs)
			{
				for (int i = 0; i < newStates.Count; i++)
				{
					MooreState objectiveState = FindNewTransition(input, i, newStates, minimumPartition);
					newStates[i].AddTransition(new MooreTransition(objectiveState, input));
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
		public MooreState FindNewTransition(string input, int index, List<MooreState> newStates, List<List<MooreState>> minimumPartition)
        {
			List<MooreTransition> transitions = minimumPartition[index][0].Transitions;
		
            foreach (MooreTransition transition in transitions)
            {

				if (transition.Input.Equals(input))
                {
					for (int i = 0; i < minimumPartition.Count; i++)
                    {
						if (minimumPartition[i].Contains(transition.Objective))
                        {
							return newStates[i];
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
		public List<List<MooreState>> PartitionateMachine()
        {
			List<List<MooreState>> newPartition = FirstPartition();
			List<List<MooreState>> prevPartition = new List<List<MooreState>>();

			while (!PartitionsEquals(newPartition, prevPartition))
            {
				prevPartition = new List<List<MooreState>>(newPartition);
				newPartition = NextPartition(new List<List<MooreState>>(prevPartition));
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
		public List<List<MooreState>> NextPartition(List<List<MooreState>> prevPartition)
		{
			List<Tuple<int, List<MooreState>>> newBlocks = new List<Tuple<int, List<MooreState>>>();

			for (int i = 0; i < prevPartition.Count; i++)
			{
				Tuple<int, List<MooreState>> differentStates;

				if (i != prevPartition.Count - 1)
                {
					differentStates = new Tuple<int, List<MooreState>>(i + 1, new List<MooreState>());
				}
                else
                {
					differentStates = new Tuple<int, List<MooreState>>(-1, new List<MooreState>());
				}

				for (int j = 1; j < prevPartition[i].Count; j++)
				{
					if (!TransitionFunctionEquals(prevPartition[i][0], prevPartition[i][j],prevPartition))
					{
						differentStates.Item2.Add(prevPartition[i][j]);
					}
				}
				
				if (differentStates.Item2.Count >= 1)
                {
					foreach (MooreState dState in differentStates.Item2)
                    {
						prevPartition[i].Remove(dState);
                    }
					newBlocks.Add(differentStates);
				}
			}
			foreach (Tuple<int, List<MooreState>> newBlock in newBlocks)
            {
				if (newBlock.Item1 == -1)
                {
					prevPartition.Add(newBlock.Item2);
                }
                else
                {
					prevPartition.Insert(newBlock.Item1,newBlock.Item2);
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

		///<summary>
		///Add a new state
		///</summary>
		///<param name="toAdd">
		///New state to add
		///</param>
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

		///<summary>
		///Add a new transition to the machine
		///</summary>
		///<return>
		///Boolean value indicating if the transition was added
		///</return>
		///<param name="origin">
		///Identifier of the initial state of the transition
		///</param>
		///<param name="end">
		///Identifier of the final state of the transition
		///</param>
		///<param name="input">
		///Input of the transition
		///</param>
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

		///<summary>
		///Search a state of the machine
		///</summary>
		///<return>
		///Found state
		///</return>
		///<param name="toSearch">
		///Identifier of the state to look for
		///</param>
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

		///<summary>
		///Load a new machine
		///</summary>
		///<param name="rows">
		///Rows of the table of the new machine
		///</param>
		public void LoadMachine(List<string[]> rows)
        {
			LoadStates(rows);
			LoadTransitions(rows);
		}

		public void LoadStates(List<string[]> rows)
        {
			foreach (string[] row in rows)
			{
                if (row[row.Length - 1].Equals(""))
                {
					throw new ArgumentException("Please input a valid output.");
                }
                else 
				{
					MooreState newState = new MooreState(row[0], row[row.Length - 1]);
					if (!Outputs.Contains(row[row.Length - 1]))
					{
						Outputs.Add(row[row.Length - 1]);
					}

					AddState(newState);
				}
			}
		}

		///<summary>
		///Load the transitions of a new machine
		///</summary>
		///<param name="rows">
		///Rows of the table of the new machine
		///</param>
		public void LoadTransitions(List<string[]> rows)
        {
			foreach (string[] row in rows)
			{
				
				for (int i = 1; i < row.Length - 1; i++)
                {
					if (row[i].Equals("") || row[i].Length < 2)
					{
						throw new ArgumentException("Please begin the state with a 'q' and follow it with integers.");
					}
					else if (!row[i][0].Equals('q') || Regex.IsMatch(row[i].Substring(1, row[i].Length - 1), @"[^A-Za-z0-9]"))
					{
						throw new ArgumentException("Please begin the state with a 'q' and follow it with integers.");
					}
					else if (Convert.ToInt32(row[i].Substring(1, row[i].Length - 1)) > rows.Count - 1)
                    {
						throw new ArgumentException("Please do not exceed the number of the last state");
					}
                    else
                    {
						AddTransition(row[0], row[i], Convert.ToString(i - 1));
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
		private List<List<MooreState>> FirstPartition()
		{
			Dictionary<string, List<MooreState>> dictionary = new Dictionary<string, List<MooreState>>();
			List<List<MooreState>> partition = new List<List<MooreState>>();

			foreach (MooreState state in States)
			{
				string output = state.Output;

				if (dictionary.ContainsKey(output))
				{
					dictionary[output].Add(state);
				}
				else
				{
					List<MooreState> newList = new List<MooreState>
					{
						state
					};
					dictionary.Add(output, newList);
				}

			}

			foreach (List<MooreState> partitions in dictionary.Values)
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
