using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SmartTimetable
{
    public partial class FindTKB : Form
    {
        public FindTKB()
        {
            InitializeComponent();
        }

        private void FindTKB_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuProg menu = new MenuProg();
            menu.Show();
        }
        

        

        private void btnNgay_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Remove(path.Length - 9, 9);
            try
            {
                string update = @"Select Tiết";
                if (comboBox1.Text == "Tất cả")
                {
                    update += @",Thứ_2,Thứ_3,Thứ_4,Thứ_5,Thứ_6,Thứ_7";
                }
                else update += "," + comboBox1.Text;
                update += " from Timetable";
                if (comboBox2.Text != "Tất cả")
                {
                    update += @" where Tiết='" + comboBox2.Text + @"'";
                }
                ConnDB.connAndSelSQL(update, dataGridView1);
            }
            catch
            {
                MessageBox.Show("Không thể tìm dữ liệu. Mời bạn thử lại.", "", MessageBoxButtons.OK);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
