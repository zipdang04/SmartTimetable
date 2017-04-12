using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTimetable
{
    public partial class EditTKB : Form
    {
        public EditTKB()
        {
            InitializeComponent();
        }
        private void EditTKB_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                string comm = @"Update Timetable Set ";
                for (int j = 2; j <= 7; j++)
                {
                    comm += @"Thứ_" + j.ToString() + @"='" + dataGridView1.Rows[i].Cells[j - 1].Value.ToString() + "'";
                    if (j != 7) comm += ",";
                }
                comm += @" where Tiết='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
                ConnDB.connAndSelSQL(comm);
            }
            MenuProg menu = new MenuProg();
            menu.Show();
        }

        private void EditTKB_Load(object sender, EventArgs e)
        {

            string comm = "Select Tiết,Thứ_2,Thứ_3,Thứ_4,Thứ_5,Thứ_6,Thứ_7 from Timetable";
            ConnDB.connAndSelSQL(comm, dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
