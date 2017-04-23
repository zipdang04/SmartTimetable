using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SmartTimetable
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        MenuProg menu;

        private void Form1_Load(object sender, EventArgs e)
        {
            string comm = "Select * from Name";

            try
            {
                ConnectSQLite.commandDB(comm, nameDataGridView);
            }
            catch
            {
                MessageBox.Show("Không thể tìm dữ liệu. Mời bạn thử lại.", "", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != nameDataGridView.Rows[0].Cells[1].Value.ToString())
            {
                MessageBox.Show("Sai mật khẩu", "", MessageBoxButtons.OK);
            }
            else
            {
                Hide();
                menu = new MenuProg();
                menu.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
