using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hordens
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
            MainForm mainForm = new MainForm();
        }

        private void connect_Bt_Click(object sender, EventArgs e)
        {
            Info.hostAddress = hostAddress_Txt.Text;
            if (Info.hostAddress == "")
            {
                MessageBox.Show("Please input Host Address");
                hostAddress_Txt.Focus();
                return;
            }

            Info.userID = user_Txt.Text;
            if (Info.userID == "")
            {
                MessageBox.Show("Please input User ID");
                user_Txt.Focus();
                return;
            }

            Info.password = password_Txt.Text;
            Info.port = port_Txt.Text;
            Info.database = database_Txt.Text;
            if (Info.database == "")
            {
                MessageBox.Show("Please input Database Name");
                database_Txt.Focus();
                return;
            }
            string conStr = "Data Source=" + Info.hostAddress + "\\SQLEXPRESS," + Info.port +
                ";Network Library=DBMSSOCN;Initial Catalog=" + Info.database +
                ";User ID=" + Info.userID + ";Password=" + Info.password;

            //string conStr = "Data Source=" + Info.hostAddress +
            //    ";Integrated Security=SSPI;Initial Catalog=" + Info.database + ";";

            // Connect to Database and get data of Booking, JobType, and Technicians
            if (DatabaseControl.ConnectToDatabase(conStr))
            {
                Info.bookings = DatabaseControl.getBookings();
                Info.jobTypes = DatabaseControl.getJobTypes();
                Info.technicians = DatabaseControl.getTechnicians();
                Info.customers = DatabaseControl.getCustomers();
                UIControl.mainForm.Show();
                this.Hide();
            }




        }
    }
}
