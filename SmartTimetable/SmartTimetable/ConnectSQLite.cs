<<<<<<< HEAD
﻿using System;
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
        private static SQLiteCommand sqliteCommand;
        private static void connectDB()
        {
            sqliteConnection = new SQLiteConnection("Data Source="+Directory.GetCurrentDirectory()+@"\Database\Timetable.sqlite; Version=3;");
        }

        public static void commandDB(string command)
        {
            try
            {
                connectDB();
                sqliteConnection.Open();
                sqliteCommand = new SQLiteCommand(command, sqliteConnection);
                sqliteCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Mời bạn thử lại", "Có lỗi trong khi xử lý dữ liệu", MessageBoxButtons.OK);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }

        public static void commandDB(string command, DataGridView dataGridView)
        {
            try
            {
                connectDB();
                sqliteConnection.Open();
                sqliteCommand = new SQLiteCommand(command, sqliteConnection);
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
                DataTable dataTable = new DataTable();
                sqliteDataAdapter.Fill(dataTable);
                sqliteDataAdapter.Dispose();
                dataGridView.DataSource = dataTable;
                dataTable.Dispose();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
                MessageBox.Show("Mời bạn thử lại", "Có lỗi trong khi thêm dữ liệu", MessageBoxButtons.OK);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }

    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SmartTimetable
{
    class ConnectSQLite
    {
        private static SQLiteConnection sqliteConnection;
        private static SQLiteCommand sqliteCommand;
        public static void connectDB()
        {
            string path = Application.StartupPath + @"\Database\Timetable.sqlite";
            sqliteConnection = new SQLiteConnection("Data Source=" + path + "; Version=3;");
        }

        public static void insertDB(string command)
        {
            try
            {
                sqliteConnection.Open();
                sqliteCommand = new SQLiteCommand(command, sqliteConnection);
                sqliteCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Mời bạn thử lại", "Có lỗi trong khi thêm dữ liệu", MessageBoxButtons.OK);
            }
            finally
            {
                sqliteConnection.Close();
            }
        }


    }
}
>>>>>>> origin/master
