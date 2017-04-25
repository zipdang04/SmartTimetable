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
    enum GridViewIndex { GridViewIndexID, GridViewIndexStartTime, GridViewIndexMinute1, GridViewIndexEndTime, GridViewIndexMinute2, GridViewIndexWeekDay, GridViewIndexContent };
    public partial class EditTKB : Form
    {
        public EditTKB()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            showTimetable();
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
            showTimetable();
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
            Create cr = new Create(this);
            cr.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strStart = getCellValueAtIndex(GridViewIndex.GridViewIndexStartTime);
                string strEnd = getCellValueAtIndex(GridViewIndex.GridViewIndexEndTime);
                DateTime dtStart = new DateTime(), dtEnd = new DateTime();
                int ID = Convert.ToInt32(getCellValueAtIndex(GridViewIndex.GridViewIndexID));
                dtStart = dtStart.AddHours(Convert.ToInt32(getHourFromTimeString(strStart)));
                dtStart = dtStart.AddMinutes(Convert.ToInt32(getMinuteFromTimeString(strStart)));
                dtEnd = dtEnd.AddHours(Convert.ToInt32(getHourFromTimeString(strEnd)));
                dtEnd = dtEnd.AddMinutes(Convert.ToInt32(getMinuteFromTimeString(strEnd)));
                string weekDay = getCellValueAtIndex(GridViewIndex.GridViewIndexWeekDay);
                string content = getCellValueAtIndex(GridViewIndex.GridViewIndexContent);
                Record record = new Record(ID, dtStart, dtEnd, weekDay, content);
                Edit ed = new Edit(record, this);
                ed.Show();
            }
            catch
            {
                MessageBox.Show("Không có hàng nào được chọn", "", MessageBoxButtons.OK);
            }
        }

        private string getCellValueAtIndex(GridViewIndex index)
        {
            return dataGridView1.CurrentRow.Cells[(int)index].Value.ToString();
        }

        private string getHourFromTimeString(string timeString)
        {
            return timeString.Substring(0, 2);
        }

        private string getMinuteFromTimeString(string timeString)
        {
            return timeString.Substring(3, 2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string command = "DELETE FROM MyTimetable WHERE ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    ConnectSQLite.commandDB(command);
                    showTimetable();
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



        private void cboThuData_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboThuData.Text == "Tất cả")
            {
                command = "Select * from MyTimetable";
                showTimetable();
            }
            else
            {
                command = "Select * from MyTimetable where Thứ='" + cboThuData.Text + "'";
                showTimetable();
            }
        }
    }
}
