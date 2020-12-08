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
            GData.hostAddress = hostAddress_Txt.Text;
            if (GData.hostAddress == "")
            {
                MessageBox.Show("Please input Host Address");
                hostAddress_Txt.Focus();
                return;
            }

            GData.userID = user_Txt.Text;
            if (GData.userID == "")
            {
                MessageBox.Show("Please input User ID");
                user_Txt.Focus();
                return;
            }

            GData.password = password_Txt.Text;
            GData.port = port_Txt.Text;
            
            GData.conStr = "Data Source=" + GData.hostAddress + "\\SQLEXPRESS," + GData.port +
                ";Network Library=DBMSSOCN;User ID=" + GData.userID + ";Password=" + GData.password;

            GData.conStr1 = "Data Source=" + GData.hostAddress + "\\SQLEXPRESS," + GData.port +
                ";Network Library=DBMSSOCN;;Initial Catalog=HordernsDB;User ID=" + GData.userID + ";Password=" + GData.password;

            //string conStr = "Data Source=" + Info.hostAddress +
            //    ";Integrated Security=SSPI;Initial Catalog=" + Info.database + ";";

            // Connect to Database and get data of Booking, JobType, and Technicians
            if (DatabaseControl.CreateDBIfNotExists())
            {
                GData.bookings = DatabaseControl.getBookings();
                GData.jobTypes = DatabaseControl.getJobTypes();
                GData.technicians = DatabaseControl.getTechnicians();
                GData.customers = DatabaseControl.getCustomers();
                UIControl.mainForm.Show();
                this.Hide();
            }




        }
    }
}
