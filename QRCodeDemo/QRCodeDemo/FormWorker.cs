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
    public partial class FormWorker : Form
    {
        SqlConnection tublecon = new SqlConnection(Class.tublecon);

        public FormWorker()
        {
            InitializeComponent();
        }

        private void FormWorker_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblWorkersBioData", tublecon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewAttendance.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }

        void Search()
        {
            if (Convert.ToString(comboBoxSelectCategory.SelectedItem) != "WorkersID" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "Schedule" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "CheckIn" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "ChackOut" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "Duration" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "Status" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "Day" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "Date" &&
                Convert.ToString(comboBoxSelectCategory.SelectedItem) != "AbsentCause")
            {
                //Search();
                MessageBox.Show("select a category");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblWorkersBioData WHERE @Category = @Search", tublecon);
                    cmd.Parameters.AddWithValue("@Category", comboBoxSelectCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Search", textBoxSearch.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    tublecon.Open();
                    da.Fill(ds, "Tuble");
                    tublecon.Close();
                    dataGridViewAttendance.DataSource = ds;
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }
    }
}
