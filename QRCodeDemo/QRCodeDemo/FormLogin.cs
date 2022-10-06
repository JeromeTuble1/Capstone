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
        SqlConnection con = new SqlConnection(Class.tublecon);
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        void SuccessLogIn(string EmployeeID) 
        {
            //MessageBox.Show(DateTime.Now.ToLongTimeString());
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblEmployeeTemp (EmployeeID,LoggedInDate,LoggedInTime) VALUES (@EmployeeID,@LoggedInDate,@LoggedInTime)", con);
            cmd.Parameters.AddWithValue("@EmployeeID", "2022-0001-DJAAS");
            cmd.Parameters.AddWithValue("@LoggedInDate", DateTime.Today.Date.ToShortDateString());
            cmd.Parameters.AddWithValue("@LoggedInTime", DateTime.Now.ToLongTimeString());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private static string FindEmployeeID(string username, string password, SqlConnection con) 
        {
            SqlCommand cmd = new SqlCommand("SELECT EmployeeID FROM tblLogin WHERE UserName = @Username AND Password = @Password", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0][0].ToString();
        }

        private static string FindEmployeePassword(string username, string password, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("SELECT Password FROM tblLogin WHERE UserName = @Username AND Password = @Password", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0][0].ToString();
        }

        void Login() {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLogin WHERE UserName = @Username AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Convert.ToInt16(dt.Rows[0][0].ToString()) > 0)
                {
                    //Find Employee ID
                    SuccessLogIn(FindEmployeeID(textBoxUserName.Text, textBoxPassword.Text, con));
                    Class.EmployeeID = FindEmployeeID(textBoxUserName.Text, textBoxPassword.Text, con);
                    Class.EmployeePassword = FindEmployeePassword(textBoxUserName.Text, textBoxPassword.Text, con);
                    //Login sucess Welcome to Homepage
                    FormMain db = new FormMain();
                    db.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked.Equals(true)) {
                textBoxPassword.PasswordChar = '\0';
            }
            else if (checkBoxShowPassword.Checked.Equals(false))
            {
                textBoxPassword.PasswordChar = '*';
            }
        }
    }
}
