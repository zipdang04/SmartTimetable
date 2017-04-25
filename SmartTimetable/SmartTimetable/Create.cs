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
    public partial class Create : Form
    {
        private EditTKB mainForm;
        public Create(Form callingForm)
        {
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
                string command = "INSERT INTO MyTimetable(Giờ_bắt_đầu,minute1,Giờ_kết_thúc,minute2,Thứ,Nội_dung) VALUES ('" +
                                                startTimePicker.Text + "', " +
                                                start.ToString() + ", '" +
                                                endTimePicker.Text + "' ," +
                                                end.ToString() + ", '" +
                                                cboThu.Text + "' ,'" +
                                                txtNoiDung.Text + "')";
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

        private void Create_Load(object sender, EventArgs e)
        {
        }
    }
}
