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
        public string strAdd(string comm)
        {
            comm += " & (Thứ='1'";
            if (chkT2.Checked) comm += "|Thứ='2'";
            if (chkT3.Checked) comm += "|Thứ='3'";
            if (chkT4.Checked) comm += "|Thứ='4'";
            if (chkT5.Checked) comm += "|Thứ='5'";
            if (chkT6.Checked) comm += "|Thứ='6'";
            if (chkT7.Checked) comm += "|Thứ='7'";
            if (chkCN.Checked) comm += "|Thứ='CN'";
            return comm+")";//remember to change
        }

        private void FindTKB_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuProg menu = new MenuProg();
            menu.Show();
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboStartHour.Text) > Convert.ToInt32(cboEndHour.Text) || (Convert.ToInt32(cboStartHour.Text) == Convert.ToInt32(cboEndHour.Text) & Convert.ToInt32(cboStartMinute.Text) > Convert.ToInt32(cboEndMinute.Text)))
            {
                string s = cboStartHour.Text;
                cboStartHour.Text = cboEndHour.Text;
                cboEndHour.Text = s;
                s = cboStartMinute.Text;
                cboStartMinute.Text = cboEndMinute.Text;
                cboEndMinute.Text = s;
            }
            int start = Convert.ToInt32(cboStartHour.Text) * 60 + Convert.ToInt32(cboStartMinute.Text),
                    end = Convert.ToInt32(cboEndHour.Text) * 60 + Convert.ToInt32(cboEndMinute.Text);
            string comm = "SELECT * FROM MyTimetable WHERE (minute1 BETWEEN " + start.ToString()
                        + " AND " + end.ToString() + ")";
            if (txtNoiDung.Text != "")
            {
                comm += " & (Nội_dung='" + txtNoiDung.Text + "')";
            }
            comm = strAdd(comm);
            try
            {
                ConnectSQLite.commandDB(comm, dataGridView1);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBackToNormal1_Click(object sender, EventArgs e)
        {
            cboStartHour.Text = "00";
            cboStartMinute.Text = "00";
            cboEndHour.Text = "23";
            cboEndMinute.Text = "59";
        }

        private void FindTKB_Load(object sender, EventArgs e)
        {
            ConnectSQLite.commandDB("SELECT * FROM MyTimetable", dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
