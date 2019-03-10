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
    public partial class staffregistration : Form
    {
        public staffregistration()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\$ammy.G-Official\Documents\Base.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Login Where STAFFID = '" +txtstaffid.Text+"' AND  USERNAME ='" +txtcurrentusername.Text+ "' AND PASSWORD = '" +txtcurrentpassword.Text+ "' " , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            errorProvider1.Clear();
                    if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtnewpassword.Text == txtconfirmpassword.Text)
                {
                    SqlDataAdapter cc = new SqlDataAdapter("update Login set STAFFID = '" +txtnewstaffid.Text+ "' , USERNAME = '" +txtnewusername.Text+"' , PASSWORD= '" +txtnewpassword.Text+ "' where STAFFID = '"+txtstaffid.Text+"' AND USERNAME = '" +txtcurrentusername.Text+"'  AND PASSWORD= '" +txtcurrentpassword.Text+"' ", con);
                    DataTable DF = new DataTable();
                    cc.Fill(DF); 
                    MessageBox.Show("Details Changed Successfully!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    errorProvider1.SetError(txtnewpassword, "unmatch password");
                    errorProvider1.SetError(txtconfirmpassword, "unmatch password");
                }
            }
          else
            {
                errorProvider1.SetError(txtstaffid, "incorrect staffid");
                errorProvider1.SetError(txtcurrentusername, "incorrect username");
                errorProvider1.SetError(txtcurrentpassword, "incorrect password");
            }
            clear();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stafflogin ss = new Stafflogin();
            ss.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        void clear()
        {
            txtstaffid.Text = txtcurrentusername.Text = txtnewpassword.Text = txtcurrentpassword.Text = txtnewstaffid.Text = txtnewusername.Text = txtconfirmpassword.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtconfirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnewpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}