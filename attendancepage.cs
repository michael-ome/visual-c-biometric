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
    public partial class attendancepage : Form
    {
        public attendancepage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void verify_Click(object sender, EventArgs e)
        {
            this.Hide();
            verificationpage ss = new verificationpage();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendancelogoutconfirmation ss = new attendancelogoutconfirmation();
            ss.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Studentverification ss = new Studentverification();
            ss.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Studentverification ss = new Studentverification();
            ss.Show();
        }

        private void attendancepage_Load(object sender, EventArgs e)
        {

        }
    }
}
