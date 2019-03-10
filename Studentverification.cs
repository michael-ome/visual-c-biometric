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
    public partial class Studentverification : Form
    {
        Image file;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\$ammy.G-Official\Documents\bankz.mdf;Integrated Security=True;Connect Timeout=30";
        public Studentverification()
        {
            InitializeComponent();
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
  
        {
            using (SqlConnection SqlCon = new SqlConnection(connectionString))
                if (txtmatricno.Text == "" || txtdepartment.Text == "" || txtemail.Text == "" || txtlastname.Text == "" || txtsex.Text == "" || txtcourse.Text == "" || txtprogramme.Text == "" || txtmobileno.Text == "" || txtsemester.Text == "" || txtschool.Text == "" || txtsession.Text == "" || txtsurname.Text == "")
                    MessageBox.Show("please fill mandatory fields");
            else
            {
                SqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("USERADD", SqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MatricNo", txtmatricno.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Surname ", txtsurname.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lastname", txtlastname.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Sex", txtsex.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Course", txtcourse.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Department", txtdepartment.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Programme", txtprogramme.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@School", txtschool.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Session", txtsession.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Semester", txtsemester.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MobileNumber", txtmobileno.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtemail.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(" REGISTRATION IS SUCCESSFUL");
                clear();
            }

               

        }
        void clear()
        {
          txtsemester.Text =  txtmatricno.Text = txtdepartment.Text = txtemail.Text = txtlastname.Text = txtsex.Text = txtcourse.Text = txtprogramme.Text = txtmobileno.Text = txtschool.Text = txtsession.Text = txtsurname.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            fingerprintregistration ss = new fingerprintregistration();
            ss.Show();
            
        }

        private void Studentverification_Load(object sender, EventArgs e)
        {

        }
    }
}
