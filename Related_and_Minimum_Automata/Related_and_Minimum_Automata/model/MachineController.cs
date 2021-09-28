using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    class MachineController
    {
        private MealyMachine mealyMachine;
        private MooreMachine mooreMachine;
       
        public MachineController()
        {
            mealyMachine = new MealyMachine();
            mooreMachine = new MooreMachine();
        }

        public void loadMachine()
        {

        }
    }
}
