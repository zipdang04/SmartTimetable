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
                ConnDB.connAndSelSQL(comm, nameDataGridView);
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
                    string comm = @"Update Name Set Matkhau='" + txtNewPass.Text + @"' where Ten='Noname'";

                    try
                    {
                        ConnDB.connAndSelSQL(comm);
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
    }
}
