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
    public partial class FormDashboard : Form
    {
        SqlConnection tublecon = new SqlConnection(Class.tublecon);

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //progressbarcount();
            //Present();
            //On_Time();
            //Late();
            //Absent();
            //Half_Day();
        }

        void progressbarcount()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkrsBioData", tublecon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString().Equals(""))
            {
                progressBarPresent.Maximum = 0;
                progressBarOnTime.Maximum = 0;
                progressBarLate.Maximum = 0;
                progressBarAbsent.Maximum = 0;
                progressBarHalfDay.Maximum = 0;
            }
            else
            {
                progressBarPresent.Maximum = Convert.ToInt16(dt.Rows[0][0]);
                progressBarOnTime.Maximum = Convert.ToInt16(dt.Rows[0][0]);
                progressBarLate.Maximum = Convert.ToInt16(dt.Rows[0][0]);
                progressBarAbsent.Maximum = Convert.ToInt16(dt.Rows[0][0]);
                progressBarHalfDay.Maximum = Convert.ToInt16(dt.Rows[0][0]);
            }
        }

        void Present()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkerAttendance WHERE Date=@Date AND AbsentCause=@AbsentCause AND Status NOT @Status", tublecon);

            string splitdatetime = DateTime.Now.Date.ToString();
            string[] consplitdatetime = splitdatetime.Split(' ');
            cmd.Parameters.AddWithValue("@Date", consplitdatetime[0]);
            cmd.Parameters.AddWithValue("@AbsentCause", "");
            cmd.Parameters.AddWithValue("@Status","Absent");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString().Equals("")) { progressBarPresent.Value = 0; }
            else { progressBarPresent.Value = Convert.ToInt16(dt.Rows[0][0]); }
        }

        void On_Time()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkerAttendance WHERE Status=@Status AND Date=@Date", tublecon);

            string splitdatetime = DateTime.Now.Date.ToString();
            string[] consplitdatetime = splitdatetime.Split(' ');
            cmd.Parameters.AddWithValue("@Date", consplitdatetime[0]);
            cmd.Parameters.AddWithValue("@Status", "OnTime");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString().Equals("")) { progressBarOnTime.Value = 0; }
            else { progressBarOnTime.Value = Convert.ToInt16(dt.Rows[0][0]); }
        }

        void Late()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkerAttendance WHERE Status=@Status AND Date=@Date", tublecon);

            string splitdatetime = DateTime.Now.Date.ToString();
            string[] consplitdatetime = splitdatetime.Split(' ');
            cmd.Parameters.AddWithValue("@Date", consplitdatetime[0]);
            cmd.Parameters.AddWithValue("@Status", "Late");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString().Equals("")) { progressBarLate.Value = 0; }
            else { progressBarLate.Value = Convert.ToInt16(dt.Rows[0][0]); }
        }

        void Absent()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkerAttendance WHERE Status=@Status AND Date=@Date", tublecon);

            string splitdatetime = DateTime.Now.Date.ToString();
            string[] consplitdatetime = splitdatetime.Split(' ');
            cmd.Parameters.AddWithValue("@Date", consplitdatetime[0]);
            cmd.Parameters.AddWithValue("@Status", "Absent");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString().Equals("")) { progressBarAbsent.Value = 0; }
            else { progressBarAbsent.Value = Convert.ToInt16(dt.Rows[0][0]); }
        }

        void Half_Day()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWorkerAttendance WHERE Status=@Status AND Date=@Date", tublecon);

            string splitdatetime = DateTime.Now.Date.ToString();
            string[] consplitdatetime = splitdatetime.Split(' ');
            cmd.Parameters.AddWithValue("@Date", consplitdatetime[0]);
            cmd.Parameters.AddWithValue("@Status", "HalfDay");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString().Equals("")) { progressBarHalfDay.Value = 0; }
            else { progressBarHalfDay.Value = Convert.ToInt16(dt.Rows[0][0]); }
        }
    }
}
