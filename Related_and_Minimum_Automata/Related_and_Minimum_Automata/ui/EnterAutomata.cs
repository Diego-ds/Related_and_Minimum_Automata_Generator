using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Related_and_Minimum_Automata.ui
{
    public partial class EnterAutomata : UserControl
    {
        public EnterAutomata()
        {
            InitializeComponent();
        }

        public void CleanFields()
        {
            StatesTextBox.Text = "";
            InputsTextBox.Text = "";
        }

        public Tuple<string, Tuple<int, int>> GetMachineComponents()
        {
            string machineType = TypeAutomataComboBox.Text;
            Console.WriteLine(machineType);
            if (machineType != "Mealy" && machineType != "Moore") 
            {
                MessageBox.Show("Please select Mealy or Moore on the first field.", "Error: Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!StatesTextBox.Text.All(char.IsDigit) || !InputsTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please only enter integers in the states and inputs fields.", "Error: Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Tuple<int, int> statesAndInputs = new Tuple<int, int>(int.Parse(StatesTextBox.Text), int.Parse(InputsTextBox.Text));
                return new Tuple<string, Tuple<int, int>>(machineType, statesAndInputs);
            }
            return null; 
        }
    }
}
