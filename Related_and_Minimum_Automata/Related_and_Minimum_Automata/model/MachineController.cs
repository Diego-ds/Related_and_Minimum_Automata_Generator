using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
    ///<summary>
	///Controller class for Mealy and Moore machines
	///</summary>
    class MachineController
    {
        public MealyMachine MealyMachine { get; }
        public MooreMachine MooreMachine { get; }
        public string CurrentMachine { get; set; }
       
        public MachineController()
        {
            MealyMachine = new MealyMachine();
            MooreMachine = new MooreMachine();
            CurrentMachine = "";
        }

        ///<summary>
        ///Load the data from the table in the determined machine
        ///</summary>
        ///<param name="rows">
        ///Rows of the table
        ///</param>
        public void LoadMachine(List<string[]> rows)
        {
            if (CurrentMachine.Equals("Moore"))
            {
                MooreMachine.LoadMachine(rows);
            }
            else if (CurrentMachine.Equals("Mealy"))
            {
                MealyMachine.LoadMachine(rows);
            }
        }

        ///<summary>
        ///Load the states and inputs into the mealy machine
        ///</summary>
        ///<param name="states">
        ///Number of states of the table
        ///</param>
        ///<param name="inputs">
        ///Number of inputs of the table
        ///</param>
        public void SetMealyStatesAndInputs(int states,int inputs)
        {
            MealyMachine.CleanMachine();
            for(int i = 0; i < states; i++)
            {
                MealyMachine.AddState(new MealyState("q"+Convert.ToString(i)));
            }
            List<string> inputsToAdd = new List<string>();
            for(int j = 0; j < inputs; j++)
            {
                inputsToAdd.Add(Convert.ToString(j));
            }
            MealyMachine.Inputs = inputsToAdd;
            CurrentMachine = "Mealy";
        }

        ///<summary>
        ///Load the inputs into the moore machine
        ///</summary>
        ///<param name="inputs">
        ///Number of inputs
        ///</param>
        public void SetMooreInputs(int inputs)
        {
            MooreMachine.CleanMachine();
            List<string> inputsToAdd = new List<string>();
            for (int j = 0; j < inputs; j++)
            {
                inputsToAdd.Add(Convert.ToString(j));
            }
            MooreMachine.Inputs = inputsToAdd;
            CurrentMachine = "Moore";
        }

        ///<summary>
        ///Remove the unreachable states of a determined machine
        ///</summary>
        public void RemoveDisconnectedStates()
        {
            if (CurrentMachine.Equals("Mealy"))
            {
                MealyMachine.RemoveDisconnectedStates();
            }
            else if (CurrentMachine.Equals("Moore"))
            {
                MooreMachine.RemoveDisconnectedStates();
            }
        }

        ///<summary>
		///Get the minimum equivalent machine from a determined machine
		///</summary>
		///<return>
		///A table with the minimum equivalent of a determined machine
		///</return>
        public DataTable MinimumEquivalentMachine()
        {
            if (CurrentMachine.Equals("Mealy"))
            {
                return MealyMachine.ReduceMachine();
            }
            else if (CurrentMachine.Equals("Moore"))
            {
                return MooreMachine.ReduceMachine();
            }

            return null;
        }
    }
}
