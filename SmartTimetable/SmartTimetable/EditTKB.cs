using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SmartTimetable
{
    public partial class EditTKB : Form
    {
        public EditTKB()
        {
            InitializeComponent();
        }

        bool change = false;
        string command = "Select * from MyTimetable";

        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
            if (change)
            {
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
            }
            change = true;
        }

        private void EditTKB2_Load(object sender, EventArgs e)
        {
            ConnectSQLite.commandDB(command, dataGridView1);
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
            dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void EditTKB2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuProg me = new MenuProg();
            me.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            startTimePicker.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            endTimePicker.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cboThu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtNoiDung.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        public void showTimetable()
        {
            ConnectSQLite.commandDB(command, dataGridView1);
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
            dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Create cr = new Create();
            cr.Show();}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (startTimePicker.Value > endTimePicker.Value)
            {
                MessageBox.Show("Giờ bắt đầu không thể sau giờ kết thúc", "", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    int start = startTimePicker.Value.Hour * 60 + startTimePicker.Value.Minute,
                        end = endTimePicker.Value.Hour * 60 + endTimePicker.Value.Minute;
                    string command = "UPDATE MyTimetable SET Giờ_bắt_đầu='" + startTimePicker.Text
                                    + "', minute1=" + start.ToString()
                                    + ", Giờ_kết_thúc='" + endTimePicker.Text
                                    + "', minute2=" + end.ToString()
                                    + ", Thứ='" + cboThu.Text
                                    + "', Nội_dung='" + txtNoiDung.Text + "'"
                                    + " WHERE ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    try
                    {
                        ConnectSQLite.commandDB(command);
                        ConnectSQLite.commandDB(this.command, dataGridView1);
                        dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
                        dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK);
                    }
                }
                catch
                {
                    MessageBox.Show("Không có gì để sửa", "", MessageBoxButtons.OK);
                }
            }
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string command = "DELETE FROM MyTimetable WHERE ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString()
                                + " AND Giờ_bắt_đầu='" + dataGridView1.CurrentRow.Cells[1].Value.ToString()
                                + "' AND Giờ_kết_thúc='" + dataGridView1.CurrentRow.Cells[3].Value.ToString()
                                + "' AND Thứ='" + dataGridView1.CurrentRow.Cells[5].Value.ToString()
                                + "' AND Nội_dung='" + dataGridView1.CurrentRow.Cells[6].Value.ToString() + "'";
                    ConnectSQLite.commandDB(command);
                    ConnectSQLite.commandDB(this.command, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
                    dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK);
                }
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
                DataTable dataTable = new DataTable();
                ConnectSQLite.commandDB("SELECT * FROM Num", dataTable);
                string comm = "UPDATE Num SET Quantity=" + (Convert.ToInt32(dataTable.Rows[0][0].ToString()) - 1).ToString()
                    + " WHERE Quantity=" + dataTable.Rows[0][0].ToString();
                ConnectSQLite.commandDB(comm);
            }
        }

        private void txtEndTime_TextChanged(object sender, EventArgs e)
        {
            if (change)
            {
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
            }
            change = true;
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            if (change)
            {
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
            }
            change = true;
        }

        private void cboThu_TextChanged(object sender, EventArgs e)
        {
            if (change)
            {
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
            }
            change = true;
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

        private void txtNoiDung_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void cboThu_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void startTimePicker_Enter(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void endTimePicker_Enter(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void cboThuData_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboThuData.Text == "Tất cả")
            {
                command = "Select * from MyTimetable";
                ConnectSQLite.commandDB(command, dataGridView1);
                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
                dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
            }
            else
            {
                command = "Select * from MyTimetable where Thứ='" + cboThuData.Text + "'";
                ConnectSQLite.commandDB(command, dataGridView1);
                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
                dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
            }
        }
    }
}