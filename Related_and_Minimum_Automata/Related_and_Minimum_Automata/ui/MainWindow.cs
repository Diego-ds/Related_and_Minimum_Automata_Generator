using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Related_and_Minimum_Automata.model;

namespace Related_and_Minimum_Automata.ui
{
    public partial class FiniteStateMachine : Form
    {

        private MachineController controller;

        public FiniteStateMachine()
        {
            InitializeComponent();
            this.Text = "Equivalent and minimum machine generator";
            controller = new MachineController();
        }

        private void OpenTableButton_Click(object sender, EventArgs e)
        {
            Tuple<string, Tuple<int,int>> components = enterAutomata1.GetMachineComponents();
            
            if (components != null)
            {
                machineTable1.LoadTable(components);
                if (components.Item1.Equals("Mealy"))
                {
                    controller.SetMealyStatesAndInputs(components.Item2.Item1, components.Item2.Item2);
                }
                else
                {
                    controller.SetMooreInputs(components.Item2.Item2);
                }
                enterAutomata1.CleanFields();
                OpenTableButton.Visible = false;
                enterAutomata1.Visible = false;
                ReduceMachineButton.Visible = true;
                machineTable1.Visible = true;
                BackButton.Visible = true;
                TitleLabel.Visible = true;
                TitleLabel.Text = "Enter the transitions and outputs";
            }
        }

        private void ReduceMachineButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.LoadMachine(machineTable1.GetRowsData());
                controller.RemoveDisconnectedStates();
                machineTable1.SetNewTable(controller.MinimumEquivalentMachine());
                ReduceMachineButton.Visible = false;
                TitleLabel.Text = "Minimum Equivalent Machine";
            } catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error: Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GoBack();
            }       
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            OpenTableButton.Visible = true;
            enterAutomata1.Visible = true;
            ReduceMachineButton.Visible = false;
            machineTable1.Visible = false;
            BackButton.Visible = false;
            TitleLabel.Visible = false;
        }
    }
}
