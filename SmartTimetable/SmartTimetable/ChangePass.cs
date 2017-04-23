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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {
            string comm = "Select * from Name";
            //string path = System.IO.Directory.GetCurrentDirectory();
            //path = path.Remove(path.Length - 9, 9);

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
            if (txtOldPass.Text == nameDataGridView.Rows[0].Cells[1].Value.ToString())
            {
                if (txtNewPass.Text == txtConPass.Text)
                {
                    string comm = @"Update Name Set Mật_khẩu='" + txtNewPass.Text + "'";

                    try
                    {
                        ConnectSQLite.commandDB(comm);
                        MessageBox.Show("Cập nhật mật khẩu thành công", "", MessageBoxButtons.OK);
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Không thể cập nhật mật khẩu. Mời bạn thử lại.", "", MessageBoxButtons.OK);
                    }
                }
                else MessageBox.Show("Mật khẩu xác nhận không trùng khớp", "", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Mật khẩu cũ không đúng", "", MessageBoxButtons.OK);
        }

        private void ChangePass_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuProg me = new MenuProg();
            me.Show();
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
