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
        SqlConnection tublecon = new SqlConnection(Class.tublecon);
        public FormAttendance()
        {
            InitializeComponent();
        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblWorkersAttendance", tublecon);
                cmd.Parameters.AddWithValue("@Search", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dataGridViewAttendance.DataSource = ds;
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }

        void Search() {
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblWorkersAttendance WHERE @Category = @Search", tublecon);
                    cmd.Parameters.AddWithValue("@Category", comboBoxSelectCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Search", textBoxSearch.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    tublecon.Open();
                    da.Fill(ds, "TLR");
                    tublecon.Close();
                    dataGridViewAttendance.DataSource = ds;
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show(comboBoxSelectCategory.SelectedItem.ToString());
                Search();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMain db = new FormMain();
            db.ShowDialog();
        }

        private void buttonAddWorkers_Click(object sender, EventArgs e)
        {
            FormAttendanceAdd AA = new FormAttendanceAdd();
            AA.ShowDialog();
        }


        private void dataGridViewAttendance_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridViewAttendance.CurrentRow.Cells[1].Value.ToString());
            FormAttendanceEdit AE = new FormAttendanceEdit();
            AE.ShowDialog();
        }
    }
}
