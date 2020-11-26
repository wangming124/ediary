using System;
using System.Linq;
using System.Windows.Forms;

namespace Hordens
{
    public partial class NewBookingForm : Form
    {
        public NewBookingForm()
        {
            InitializeComponent();
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {            
            UIControl.showForm(UIControl.bookingGridForm);
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

            // Check if a job No already exists in the database
            Info.bookings = DatabaseControl.getBookings();
            var list = Info.bookings.Where(b => b.jobNO == jobNO_Txt.Text).ToList();
            if (list.Count > 0)
            {
                MessageBox.Show("The booking with Job No. " + jobNO_Txt.Text + " already exists! Please input another Job No.");
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
            var newBooking = new Booking
            {
                jobNO = jobNO_Txt.Text,
                jobType = jobType_Cmb.Text,
                customer = honor_Cmb.Text + ". " + customer_Txt.Text,
                address = address1_Txt.Text + ", " + address2_Txt.Text + ", " + address3_Txt.Text,
                postCode = postCode_Txt.Text,
                email = email_Txt.Text,
                tel = tel_Txt.Text,
                vehicleMake = vehicleMake_Txt.Text,
                vehicleModel = vehicleModel_Txt.Text,
                vehicleRegNo = vehicleRegNo_Txt.Text,
                loanCar = loanCar_Cmb.Text,
                timeIn = timeIn_Dt.Value,
                timeOut = timeOut_Dt.Value,
                bookedBy = bookedBy_Cmb.Text,
                estimatedTime = Convert.ToDouble(estimatedTime_Cmb.Text),
                timeRemaining = Info.workingHours - Convert.ToDouble(estimatedTime_Cmb.Text),
                insuranceRequired = insurance_Cmb.Text,
                jobDescription = jobDescription_Txt.Text,
                notes = notes_Txt.Text
            };
            if (DatabaseControl.addBooking(newBooking))
            {
                MessageBox.Show("New booking has been added succesfully!");
                UIControl.bookingGridForm.showBookings();
                clearFields();
            }
        }

        // Initialize list of "Job Types" and "Estimated Time" when loading this form
        private void NewBookingForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Info.jobTypes)
            {
                jobType_Cmb.Items.Add(item.typeName);
            }
            foreach (int time in Info.estimatedTime)
            {
                estimatedTime_Cmb.Items.Add(time.ToString());
            }
            clearFields();
        }

        private void clearFields()
        {
            jobNO_Txt.Text = "";
            if (jobType_Cmb.Items.Count > 0)
                jobType_Cmb.SelectedIndex = 0;
            customer_Txt.Text = "";
            address1_Txt.Text = "";
            address2_Txt.Text = "";
            address3_Txt.Text = "";
            postCode_Txt.Text = "";
            email_Txt.Text = "";
            tel_Txt.Text = "";
            vehicleMake_Txt.Text = "";
            vehicleModel_Txt.Text = "";
            vehicleRegNo_Txt.Text = "";
            loanCar_Cmb.SelectedIndex = 0;
            if (bookedBy_Cmb.Items.Count > 0)
                bookedBy_Cmb.SelectedIndex = 0;
            timeIn_Dt.Value = DateTime.Now;
            timeOut_Dt.Value = DateTime.Now;
            estimatedTime_Cmb.SelectedIndex = 0;
            insurance_Cmb.SelectedIndex = 1;
            jobDescription_Txt.Text = "";
            notes_Txt.Text = "";
        }

        public void updateJobTypes()
        {
            Info.jobTypes = DatabaseControl.getJobTypes();
            jobType_Cmb.Items.Clear();
            foreach(JobType job in Info.jobTypes)
            {
                jobType_Cmb.Items.Add(job.typeName);
            }
            jobType_Cmb.Text = "";
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
