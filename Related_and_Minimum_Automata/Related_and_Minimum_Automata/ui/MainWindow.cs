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
    public partial class FiniteStateMachine : Form
    {
        public FiniteStateMachine()
        {
            InitializeComponent();
            this.Text = "Equivalent and minimum machine generator";
        }

        private void OpenTableButton_Click(object sender, EventArgs e)
        {
            Tuple<string, Tuple<int,int>> components = enterAutomata1.GetMachineComponents();
            
            if (components != null)
            {
                machineTable1.LoadTable(components);
                enterAutomata1.CleanFields();
                OpenTableButton.Visible = false;
                enterAutomata1.Visible = false;
                ReduceMachineButton.Visible = true;
                machineTable1.Visible = true;
                BackButton.Visible = true;
            }
        }

        private void ReduceMachineButton_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            OpenTableButton.Visible = true;
            enterAutomata1.Visible = true;
            ReduceMachineButton.Visible = false;
            machineTable1.Visible = false;
            BackButton.Visible = false;
        }
    }
}
