using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    class MealyMachine
    {
		private List<MealyState> states;
		private List<string> inputs;
		private List<string> outputs;
		private MealyState initial;
		
		public MealyMachine()
		{
			this.states = new List<MealyState>();
			this.inputs = new List<string>();
			this.outputs = new List<string>();
			this.initial = null;
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
	}
}
