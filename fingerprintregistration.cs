using System;
using System.Windows.Forms;
using UareUSampleCSharp;
//using UareUSampleCSharp.Enrollment;

namespace finalyearproject.cs
{
    public partial class fingerprintregistration : Form
    {
        public fingerprintregistration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            attendancepage ss = new attendancepage();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
           Enrollment ss = new Enrollment();
           ss.Show();
        }
    }
}
