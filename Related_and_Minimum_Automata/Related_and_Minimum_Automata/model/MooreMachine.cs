using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    class MooreMachine
    {
		private List<MooreState> states;
		private List<string> inputs;
		private List<string> outputs;
		private MooreState initial;

		public MooreMachine()
		{
			this.states = new List<MooreState>();
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

		public void setMachine(List<MooreState> states, List<string> inputs, )
        {

        }
	}
}
