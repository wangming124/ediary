using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hordens
{
    public partial class EditBookingForm : Form
    {
        public Booking bookingToEdit;
        public EditBookingForm()
        {
            InitializeComponent();
        }

        public void getDescription()
        {
            jobNO_Txt.Text = bookingToEdit.jobNO;
            jobType_Cmb.Text = bookingToEdit.jobType;
            honor_Cmb.Text = bookingToEdit.customer.Split(new string[] { ". " }, StringSplitOptions.None)[0];
            customer_Txt.Text = bookingToEdit.customer.Split(new string[] { ". " }, StringSplitOptions.None)[1];
            string[] adresss = bookingToEdit.address.Split(new string[] { ", " }, StringSplitOptions.None);
            address1_Txt.Text = adresss[0];
            address2_Txt.Text = adresss[1];
            address3_Txt.Text = adresss[2];
            postCode_Txt.Text = bookingToEdit.postCode;
            tel_Txt.Text = bookingToEdit.tel;
            email_Txt.Text = bookingToEdit.email;
            vehicleMake_Txt.Text = bookingToEdit.vehicleMake;
            vehicleModel_Txt.Text = bookingToEdit.vehicleModel;
            vehicleRegNo_Txt.Text = bookingToEdit.vehicleRegNo;
            loanCar_Cmb.Text = bookingToEdit.loanCar;
            timeIn_Dt.Value = bookingToEdit.timeIn;
            timeOut_Dt.Value = bookingToEdit.timeOut;
            bookedBy_Cmb.Text = bookingToEdit.bookedBy;
            estimatedTime_Cmb.Text = bookingToEdit.estimatedTime.ToString();
            insurance_Cmb.Text = bookingToEdit.insuranceRequired;
            jobDescription_Txt.Text = bookingToEdit.jobDescription;
            notes_Txt.Text = bookingToEdit.notes;
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            // Check if Job NO is not empty
            if (jobNO_Txt.Text == "")
            {
                MessageBox.Show("Job No can not be empty. Please input!");
                jobNO_Txt.Focus();
                return;
            }
            // Check if Job NO is not empty
            if (jobType_Cmb.Text == "")
            {
                MessageBox.Show("Job Type can not be empty. Please input!");
                jobType_Cmb.Focus();
                return;
            }
            // Check if a Customer filed is not empty
            if (customer_Txt.Text == "")
            {
                MessageBox.Show("Customer field can not be empty. Please input!");
                customer_Txt.Focus();
                return;
            }
            // Check if an Address filed is not empty.
            if (address1_Txt.Text == "")
            {
                MessageBox.Show("Address field can not be empty. Please input!");
                address1_Txt.Focus();
                return;
            }
            if (address2_Txt.Text == "")
            {
                MessageBox.Show("Address field can not be empty. Please input!");
                address2_Txt.Focus();
                return;
            }
            if (address3_Txt.Text == "")
            {
                MessageBox.Show("Address field can not be empty. Please input!");
                address3_Txt.Focus();
                return;
            }
            // Check if an Post Code filed is not empty.
            if (postCode_Txt.Text == "")
            {
                MessageBox.Show("Post Code can not be empty. Please input!");
                postCode_Txt.Focus();
                return;
            }
            // Check if an email filed is not empty.
            if (email_Txt.Text == "")
            {
                MessageBox.Show("Email field can not be empty. Please input!");
                email_Txt.Focus();
                return;
            }
            // Check if an Tel filed is not empty.
            if (tel_Txt.Text == "")
            {
                MessageBox.Show("Tel field can not be empty. Please input!");
                tel_Txt.Focus();
                return;
            }
            // Check if an Vehicle Model filed is not empty.
            if (vehicleModel_Txt.Text == "")
            {
                MessageBox.Show("Vehicle Model field can not be empty. Please input!");
                vehicleModel_Txt.Focus();
                return;
            }
            // Check if an Booked By filed is not empty.
            if (bookedBy_Cmb.Text == "")
            {
                MessageBox.Show("Booked By field can not be empty. Please input!");
                bookedBy_Cmb.Focus();
                return;
            }
            // Check if an Job Description filed is not empty.
            if (jobDescription_Txt.Text == "")
            {
                MessageBox.Show("Job Description field can not be empty. Please input!");
                jobDescription_Txt.Focus();
                return;
            }

            bookingToEdit.jobNO = jobNO_Txt.Text;
            bookingToEdit.jobType = jobType_Cmb.Text;
            bookingToEdit.customer = honor_Cmb.Text + ". " + customer_Txt.Text;
            bookingToEdit.address = address1_Txt.Text + ", " + address2_Txt.Text + ", " + address3_Txt.Text;
            bookingToEdit.postCode = postCode_Txt.Text;
            bookingToEdit.email = email_Txt.Text;
            bookingToEdit.tel = tel_Txt.Text;
            bookingToEdit.vehicleMake = vehicleMake_Txt.Text;
            bookingToEdit.vehicleModel = vehicleModel_Txt.Text;
            bookingToEdit.vehicleRegNo = vehicleRegNo_Txt.Text;
            bookingToEdit.loanCar = loanCar_Cmb.Text;
            bookingToEdit.timeIn = timeIn_Dt.Value;
            bookingToEdit.timeOut = timeOut_Dt.Value;
            bookingToEdit.bookedBy = bookedBy_Cmb.Text;
            bookingToEdit.estimatedTime = Convert.ToDouble(estimatedTime_Cmb.Text);
            bookingToEdit.timeRemaining = Info.workingHours - Convert.ToDouble(estimatedTime_Cmb.Text);
            bookingToEdit.insuranceRequired = insurance_Cmb.Text;
            bookingToEdit.jobDescription = jobDescription_Txt.Text;
            bookingToEdit.notes = notes_Txt.Text;

            if (DatabaseControl.updateBooking(bookingToEdit))
            {
                MessageBox.Show("Booking data has been updated succesfully!");
                UIControl.bookingGridForm.showBookings();
                UIControl.showForm(UIControl.bookingGridForm);
            }
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.bookingGridForm);
        }
        public void updateJobTypes()
        {
            Info.jobTypes = DatabaseControl.getJobTypes();
            jobType_Cmb.Items.Clear();
            foreach (JobType job in Info.jobTypes)
            {
                jobType_Cmb.Items.Add(job.typeName);
            }
            jobType_Cmb.Text = "";
        }

        private void EditBookingForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Info.jobTypes)
            {
                jobType_Cmb.Items.Add(item.typeName);
            }
            foreach (int time in Info.estimatedTime)
            {
                estimatedTime_Cmb.Items.Add(time.ToString());
            }
        }

        private void loanCar_Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If selected "Loan Car"
            if (loanCar_Cmb.SelectedIndex == 3)
            {
                insurance_Cmb.SelectedIndex = 0;
            }
            else
            {
                insurance_Cmb.SelectedIndex = 1;
            }
        }
    }
}
