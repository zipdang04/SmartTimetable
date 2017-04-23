using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTimetable
{
    public partial class MenuProg : Form
    {
        public MenuProg()
        {
            InitializeComponent();
        }

        private void MenuProg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            EditTKB ed = new EditTKB();
            ed.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            ChangePass ch = new ChangePass();
            ch.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            FindTKB fi = new FindTKB();
            fi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            WatchTKB wa = new WatchTKB();
            wa.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditTKB ee = new EditTKB();
            ee.Show();
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            int timeNow = Convert.ToInt32(dtNow.Hour.ToString()) * 60 + Convert.ToInt32(dtNow.Minute.ToString());
            DataTable dataTable = new DataTable();
            DataTable dbQuan = new DataTable();
            ConnectSQLite.commandDB("Select Giờ_bắt_đầu,Nội_dung from MyTimetable", dataTable);
            ConnectSQLite.commandDB("SELECT * FROM Num", dbQuan);
            int n = Convert.ToInt32(dbQuan.Rows[0][0].ToString());
            for (int i = 0; i < n; i++)
            {
                string time = dataTable.Rows[i][0].ToString();
                int timeDB = Convert.ToInt32(time[0].ToString() + time[1].ToString()) * 60
                    + Convert.ToInt32(time[3].ToString() + time[4].ToString());
                if (timeDB - timeNow <= 60 * 30)
                {
                    MessageBox.Show("Còn khoảng " + Math.Truncate(Convert.ToDouble((timeDB - timeNow) / 60)).ToString() + "phút nữa là tới:" + dataTable.Rows[i][1].ToString(), "", MessageBoxButtons.OK);
                }
            }
        }
    }
}
