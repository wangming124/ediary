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
            customer_Txt.Text = bookingToEdit.customer;
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
            bookingToEdit.customer = customer_Txt.Text;
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
           
            UIControl.bookingGridForm.updateBooking(bookingToEdit);
            UIControl.showForm(UIControl.bookingGridForm);
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.bookingGridForm);
        }
    }
}
