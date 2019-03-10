using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalyearproject.cs
{
    public partial class decisionpage : Form
    {
        public decisionpage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stafflogin ss = new Stafflogin();
            ss.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendancepage ss = new attendancepage();
            ss.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendancepage ss = new attendancepage();
            ss.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Studentverification ss = new Studentverification();
            ss.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Studentverification ss = new Studentverification();
            ss.Show();
        }
    }
}
