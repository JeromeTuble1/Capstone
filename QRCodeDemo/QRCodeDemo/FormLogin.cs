using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRCodeDemo
{
    public partial class FormLogin : Form
    {
        SqlConnection con = new SqlConnection(Class.con);
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        void GetUserData() {
            SqlCommand cmd = new SqlCommand("SELECT UserID FROM tblLogin WHERE UserName = @Username AND Password = @Password AND Employee = @Employee", con);
            cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
            cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
            cmd.Parameters.AddWithValue("@Employee", Class.IsEmployee);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Class.UserID = dt.Rows[0][0].ToString();
        }

        void Login() {

            if (Class.Pick.Equals(true))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLogin WHERE UserName = @Username AND Password = @Password AND Employee = @Employee", con);
                cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                cmd.Parameters.AddWithValue("@Employee", Class.IsEmployee);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Convert.ToInt16(dt.Rows[0][0].ToString()) > 0)
                {
                    ///////////////////////////////////////
                    //DataSet ds = new DataSet();
                    //da.Fill(ds);
                    //Class.Picture = (Byte[])(ds.Tables[0].Rows[0]["Picture"]);
                    //Class.IsEmployee = Convert.ToBoolean(dt.Rows[2][0]);
                    ///////////////////////////////////////
                    //Login sucess Welcome to Homepage
                    GetUserData();
                    FormDashboard db = new FormDashboard();
                    db.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister FR = new FormRegister();
            FR.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBoxEmployee.Location == new Point(47, 88))
            {
                pictureBoxEmployee.Location = new Point(182, 88);
                panel1.Location = new Point(172, 79);
                pictureBoxVisitors.Visible = false;
                panel2.Visible = false;
                label3.Location = new Point(226, 243);
                label4.Visible = false;
                Class.IsEmployee = 1;
                Class.Pick = true;
                panel3.Visible = false;
            }
            else {
                pictureBoxEmployee.Location = new Point(47, 88); // For Side
                panel1.Location = new Point(36, 80);
                pictureBoxVisitors.Visible = true;
                panel2.Visible = true;
                label3.Location = new Point(84, 243);
                label4.Visible = true;
                Class.Pick = false;
                panel3.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBoxVisitors.Location == new Point(328, 88))
            {
                pictureBoxVisitors.Location = new Point(182, 88);
                panel2.Location = new Point(172, 79);
                pictureBoxEmployee.Visible = false;
                panel1.Visible = false;
                label4.Location = new Point(226, 243);
                label3.Visible = false;
                Class.IsEmployee = 0;
                Class.Pick = true;
                panel3.Visible = false;
            }
            else {
                pictureBoxVisitors.Location = new Point(328, 88); // For Side
                panel2.Location = new Point(317, 80);
                pictureBoxEmployee.Visible = true;
                panel1.Visible = true;
                label4.Location = new Point(378, 243);
                label3.Visible = true;
                Class.Pick = false;
                panel3.Visible = true;
            }
        }
    }
}
