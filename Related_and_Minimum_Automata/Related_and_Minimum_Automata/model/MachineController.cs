﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Related_and_Minimum_Automata.model
{
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

        public void loadMachine()
        {

        }
        
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

    }
}
