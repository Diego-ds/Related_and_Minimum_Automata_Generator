using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    public class MooreTransition
    {
        public MooreState Objective { get; set; }
        public string Input { get; set; }
        public MooreTransition(MooreState objective, string input)
        {
            Objective = objective;
            Input = input;
        }
    }
}
