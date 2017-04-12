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
    public partial class WatchTKB : Form
    {
        public WatchTKB()
        {
            InitializeComponent();
        }
        private void WatchTKB_FormClosed(object sender, FormClosedEventArgs e)
        {
                
                MenuProg menu = new MenuProg();
                menu.Show();
        }

        private void WatchTKB_Load(object sender, EventArgs e)
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
