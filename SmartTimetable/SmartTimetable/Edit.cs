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
    public partial class Edit : Form
    {
        int ID;
        DateTime start, end;
        string weekDay, content;

        private EditTKB mainForm;
        public Edit(Record record, Form callingForm)
        {
            this.ID = record.ID;
            this.start = record.startTime;
            this.end = record.endTime;
            this.weekDay = record.weekDay;
            this.content = record.content;
            this.mainForm = callingForm as EditTKB;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startTimePicker.Value > endTimePicker.Value) MessageBox.Show("Giờ bắt đầu không thể sau giờ kết thúc", "", MessageBoxButtons.OK);
            else if (cboThu.Text == "") MessageBox.Show("Ô \"Thứ\" chưa có nội dung", "", MessageBoxButtons.OK);
            else
            {
                int start = startTimePicker.Value.Hour * 60 + startTimePicker.Value.Minute,
                                    end = endTimePicker.Value.Hour * 60 + endTimePicker.Value.Minute;
                string command = "UPDATE MyTimetable SET Giờ_bắt_đầu='" + startTimePicker.Text
                                    + "', minute1=" + start.ToString()
                                    + ", Giờ_kết_thúc='" + endTimePicker.Text
                                    + "', minute2=" + end.ToString()
                                    + ", Thứ='" + cboThu.Text
                                    + "', Nội_dung='" + txtNoiDung.Text + "'"
                                    + " WHERE ID=" + ID.ToString();
                try
                {
                    ConnectSQLite.commandDB(command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK);
                }
                DataTable dataTable = new DataTable();
                ConnectSQLite.commandDB("SELECT * FROM Num", dataTable);
                string comm = "UPDATE Num SET Quantity=" + (Convert.ToInt32(dataTable.Rows[0][0].ToString()) + 1).ToString()
                    + " WHERE Quantity=" + dataTable.Rows[0][0].ToString();
                ConnectSQLite.commandDB(comm);
                mainForm.refresh();
                Close();
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            start=start.AddYears(startTimePicker.MinDate.Year);
            end=end.AddYears(endTimePicker.MinDate.Year);
            startTimePicker.Value = start;
            endTimePicker.Value = end;
            cboThu.Text = weekDay;
            txtNoiDung.Text = content;
        }
    }
}
