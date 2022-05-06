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
    public partial class FormAttendance : Form
    {
        SqlConnection con = new SqlConnection(Class.con);
        public FormAttendance()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData() {
            SqlCommand cmd = new SqlCommand("SELECT * FROM <TABLENAME>", con);
            cmd.Parameters.AddWithValue("@Search", textBoxSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "TLR");
            con.Close();
            dataGridView1.DataSource = ds;
        }

        void Search() {
            SqlCommand cmd = new SqlCommand("SELECT * FROM <TABLENAME> WHERE <ROWNAME> = @Search OR <ROWNAME> = @Search", con);
            cmd.Parameters.AddWithValue("@Search", textBoxSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds,"TLR");
            con.Close();
            dataGridView1.DataSource = ds;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormDashboard db = new FormDashboard();
            this.Hide();
            db.ShowDialog();
        }
    }
}
