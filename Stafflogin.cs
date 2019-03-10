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

namespace finalyearproject.cs
{
    public partial class Stafflogin : Form
    {
        public Stafflogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\$ammy.G-Official\Documents\Base.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login where staffid = '"+textBox1.Text+"' and Username= '" + textBox2.Text + "' and Password = '" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                decisionpage ss = new decisionpage();
                ss.Show();
            }
            else
            {
                MessageBox.Show("please check your username and password and staffid");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            staffregistration ss = new staffregistration();
            ss.Show();
        }
    }
}
