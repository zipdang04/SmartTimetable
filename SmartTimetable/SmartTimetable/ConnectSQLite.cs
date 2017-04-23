using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace SmartTimetable
{
    class ConnectSQLite
    {

        private static SQLiteConnection sqliteConnection;

        private static void connectDB()
        {
            //SQLiteConnection.CreateFile("Timetable.db");
            string conn = @"data source=" + Directory.GetCurrentDirectory() + @"\Timetable.sqlite; Version=3;";
            sqliteConnection = new SQLiteConnection(conn);
        }

        public static void commandDB(string comm)
        {
            connectDB();
            sqliteConnection.Open();
            SQLiteCommand sqliteCommand = new SQLiteCommand(comm, sqliteConnection);
            sqliteCommand.ExecuteNonQuery();
            sqliteConnection.Close();
        }

        public static void commandDB(string comm, DataGridView dataGridView)
        {
            connectDB();
            sqliteConnection.Open();
            SQLiteCommand sqliteCommand = new SQLiteCommand(comm, sqliteConnection);
            try
            {
                SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
                DataTable dataTable = new DataTable();
                sqliteDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                sqliteCommand.Dispose();
                dataTable.Dispose();
            }
            catch
            {

            }
            finally
            {
                sqliteConnection.Close();
            }
        }

        public static void commandDB(string comm, DataTable dataTable)
        {
            connectDB();
            sqliteConnection.Open();
            SQLiteCommand sqliteCommand = new SQLiteCommand(comm, sqliteConnection);
            try
            {
                SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
                sqliteDataAdapter.Fill(dataTable);
                sqliteCommand.Dispose();
            }
            catch
            {
                MessageBox.Show("Không thể truy cập dữ liệu", "", MessageBoxButtons.OK);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }
    }
}
