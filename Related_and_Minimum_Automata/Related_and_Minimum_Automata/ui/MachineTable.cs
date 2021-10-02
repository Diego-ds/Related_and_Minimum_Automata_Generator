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
    public partial class MachineTable : UserControl
    {
        
        public MachineTable()
        {
            InitializeComponent();
        }


        public void LoadTable(Tuple<string,Tuple<int,int>> components)
        {
            if (components.Item1.Equals("Moore"))
            {
                OpenMooreTable(components.Item2.Item1,components.Item2.Item2);
            }
            else
            {
                OpenMealyTable(components.Item2.Item1, components.Item2.Item2);
            }
        }

        //Moore table is created to enter the transitions
        public void OpenMooreTable(int states, int inputs)
        {
            DataTable table = new DataTable();
            table.Columns.Add("States");
            for (int i = 0; i < inputs; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            table.Columns.Add("Outputs");
            for(int j = 0; j < states; j++)
            {
                table.Rows.Add();
            }
            int rowNum = 0;
            foreach (DataRow row in table.Rows)
            {

                for (int i = 0; i < inputs + 2; i++)
                {
                    if (i == 0)
                    {
                        row[i] = "q" + Convert.ToString(rowNum);
                    }
                    else if(i == inputs+1)
                    {
                        row[i] = "0";
                    }
                    else
                    {
                        row[i] = "q0";
                    }

                }
                rowNum++;
            }
            table.Columns[0].ReadOnly = true;
            TableMachine.DataSource = table;
            foreach (DataGridViewColumn column in TableMachine.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //Mealy table is created to enter the transitions
        public void OpenMealyTable(int states, int inputs)
        {
            DataTable table = new DataTable();
            table.Columns.Add("States");
            for (int i = 0; i < inputs; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }

            for (int j = 0; j < states; j++)
            {
                table.Rows.Add();
            }
            int rowNum = 0;
            foreach (DataRow row in table.Rows)
            {
                for(int i = 0; i < inputs + 1; i++)
                {
                    if (i == 0)
                    {
                        row[i] = "q" + Convert.ToString(rowNum);
                    }
                    else
                    {
                        row[i] = "q0,0";
                    }                
                }
                rowNum++;
            }
            table.Columns[0].ReadOnly = true;
            TableMachine.DataSource = table;
            foreach (DataGridViewColumn column in TableMachine.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public List<string[]> GetRowsData()
        {
            List<string[]> rows = new List<string[]>();
            foreach (DataGridViewRow row in TableMachine.Rows)
            {
                string[] rowToAdd = new string[row.Cells.Count];
                for(int i = 0; i < row.Cells.Count; i++)
                {
                    rowToAdd[i] = row.Cells[i].Value.ToString();
                    Console.WriteLine("celda " + Convert.ToString(i) +" "+ row.Cells[i].Value.ToString());
                }
                rows.Add(rowToAdd);
            }
            return rows;
        }
    }
}
