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
    public partial class MenuProg : Form
    {
        public MenuProg()
        {
            InitializeComponent();
        }

        private void MenuProg_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            EditTKB ed = new EditTKB();
            ed.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            ChangePass ch = new ChangePass();
            ch.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            FindTKB fi = new FindTKB();
            fi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            WatchTKB wa = new WatchTKB();
            wa.Show();
        }

    }
}
