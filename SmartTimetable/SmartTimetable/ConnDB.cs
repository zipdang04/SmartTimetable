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
    class ConnDB
    {
        public static SqlConnection connectSQL()
        {
            string connString = @"Data Source=SHARE10S-PC;Initial Catalog=Timetable;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        public static void connAndSelSQL(string select, DataGridView dataGridView)
        {

            SqlConnection sqlConnection = connectSQL();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable tab = new DataTable("Timetable");
                sqlDataAdapter.Fill(tab);
                dataGridView.DataSource = tab;
                sqlCommand.Dispose();
                sqlCommand = null;
                tab.Dispose();
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static void connAndSelSQL(string select)
        {

            SqlConnection sqlConnection = connectSQL();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
