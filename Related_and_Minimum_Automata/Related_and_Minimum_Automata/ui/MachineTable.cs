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


        public void LoadTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("prueba");
            table.Columns.Add("prueba2");
            table.Columns.Add("prueb");
            table.Columns.Add("pru");
            table.Columns.Add("prueba233");
            table.Columns.Add("prueba255");
            table.Columns.Add("prueba277");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            table.Rows.Add("ADSSSXAA", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd", "adsfdcd");
            TableMachine.DataSource = table;
        }
    }
}
