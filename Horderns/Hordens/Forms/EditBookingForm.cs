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
        private Customer customer;
        public EditBookingForm()
        {
            InitializeComponent();
        }
        private void EditBookingForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Info.jobTypes)
            {
                jobType_Cmb.Items.Add(item.typeName);
            }            
        }
        public void getDescription()
        {
            jobNO_Txt.Text = bookingToEdit.jobNO;
            jobType_Cmb.Text = bookingToEdit.jobType;
            customer = Info.customers.Where(c => c.id == bookingToEdit.customerID).ToList()[0];
            honor_Cmb.Text = customer.honor;
            customerName_Txt.Text = customer.name;            
            address1_Txt.Text = customer.address1;
            address2_Txt.Text = customer.address2;
            address3_Txt.Text = customer.address3;
            postCode_Txt.Text = customer.postCode;
            servicePlan_Cmb.Text = bookingToEdit.servicePlan;
            tel_Txt.Text = customer.tel;
            email_Txt.Text = customer.email;
            vehicleMake_Txt.Text = bookingToEdit.vehicleMake;
            vehicleModel_Txt.Text = bookingToEdit.vehicleModel;
            vehicleRegNo_Txt.Text = bookingToEdit.vehicleRegNo;
            mileage_Txt.Text = string.Format("{0:###,###.00}", double.Parse(bookingToEdit.mileage.ToString())); ;
            loanCar_Cmb.Text = bookingToEdit.loanCar;
            timeIn_Txt.Text = bookingToEdit.timeIn.ToString();
            timeOut_Txt.Text = bookingToEdit.timeOut.ToString();
            bookedBy_Cmb.Text = bookingToEdit.bookedBy;
            estimatedTime_Txt.Text = bookingToEdit.estimatedTime.ToString();
            insurance_Cmb.Text = bookingToEdit.insuranceRequired;
            jobDescription_Txt.Text = bookingToEdit.jobDescription;
            notes_Txt.Text = bookingToEdit.notes;
            updateCustomers();
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
            if (customerName_Txt.Text == "")
            {
                MessageBox.Show("Customer field can not be empty. Please input!");
                customerName_Txt.Focus();
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
                MessageBox.Show("Work Title field can not be empty. Please input!");
                jobDescription_Txt.Focus();
                return;
            }
            // Check if a timeIn is valid number
            double d;
            if (!double.TryParse(timeIn_Txt.Text, out d))
            {
                MessageBox.Show("Time in should be numeric value. Please input!");
                timeIn_Txt.Text = "0";
                timeIn_Txt.Focus();
                return;
            }

            if (!double.TryParse(timeOut_Txt.Text, out d))
            {
                MessageBox.Show("Time in should be numeric value. Please input!");
                timeOut_Txt.Text = "0";
                timeOut_Txt.Focus();
                return;
            }
            // Compare Time in and Time Out
            if (Convert.ToDouble(timeIn_Txt.Text) > Convert.ToDouble(timeOut_Txt.Text))
            {
                MessageBox.Show("Time in should be less than Time Out!");
                timeIn_Txt.Focus();
                return;
            }

            int customerId = 0;
            Customer customer = new Customer
            {
                honor = honor_Cmb.Text,
                name = customerName_Txt.Text,
                address1 = address1_Txt.Text,
                address2 = address2_Txt.Text,
                address3 = address3_Txt.Text,
                postCode = postCode_Txt.Text,
                email = email_Txt.Text,
                tel = tel_Txt.Text
            };
            if (existingCustomer_Cmb.SelectedIndex == 0)
            {
                customerId = DatabaseControl.addCustomer(customer);
            }
            else
            {
                customerId = Info.customers[existingCustomer_Cmb.SelectedIndex - 1].id;
                DatabaseControl.updateCustomer(customer, customerId);
            }
            bookingToEdit.jobNO = jobNO_Txt.Text;
            bookingToEdit.jobType = jobType_Cmb.Text;
            bookingToEdit.customerID = customerId;
            bookingToEdit.servicePlan = servicePlan_Cmb.Text;
            bookingToEdit.vehicleMake = vehicleMake_Txt.Text;
            bookingToEdit.vehicleModel = vehicleModel_Txt.Text;
            bookingToEdit.vehicleRegNo = vehicleRegNo_Txt.Text;
            bookingToEdit.mileage = Convert.ToDouble(mileage_Txt.Text);
            bookingToEdit.loanCar = loanCar_Cmb.Text;
            bookingToEdit.timeIn = Convert.ToDouble(timeIn_Txt.Text);
            bookingToEdit.timeOut = Convert.ToDouble(timeOut_Txt.Text);
            
            bookingToEdit.bookedBy = bookedBy_Cmb.Text;
            bookingToEdit.estimatedTime = bookingToEdit.timeOut - bookingToEdit.timeIn;
            bookingToEdit.timeRemaining = DatabaseControl.getBookingDates(bookingToEdit.bookingDate.Date) - bookingToEdit.estimatedTime;
            if (bookingToEdit.timeRemaining < 0)
                bookingToEdit.timeRemaining = 0;
            bookingToEdit.insuranceRequired = insurance_Cmb.Text;
            bookingToEdit.jobDescription = jobDescription_Txt.Text;
            bookingToEdit.notes = notes_Txt.Text;

            if (DatabaseControl.updateBooking(bookingToEdit))
            {
                MessageBox.Show("Booking data has been updated succesfully!");
                UIControl.bookingGridForm.showBookings();
                UIControl.showForm(UIControl.bookingGridForm);
                updateCustomers();
                UIControl.newBookingForm.updateCustomers();
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

        private void existingCustomer_Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (existingCustomer_Cmb.SelectedIndex == 0)
            {
                honor_Cmb.SelectedIndex = 0;
                customerName_Txt.Text = "";
                address1_Txt.Text = "";
                address2_Txt.Text = "";
                address3_Txt.Text = "";
                postCode_Txt.Text = "";
                tel_Txt.Text = "";
                email_Txt.Text = "";
                honor_Cmb.Enabled = true;
                customerName_Txt.Enabled = true;

            }
            else
            {
                customer = Info.customers[existingCustomer_Cmb.SelectedIndex - 1];
                honor_Cmb.Text = customer.honor;
                customerName_Txt.Text = customer.name;
                address1_Txt.Text = customer.address1;
                address2_Txt.Text = customer.address2;
                address3_Txt.Text = customer.address3;
                postCode_Txt.Text = customer.postCode;
                tel_Txt.Text = customer.tel;
                email_Txt.Text = customer.email;
            }
        }
        public void updateCustomers()
        {
            Info.customers = DatabaseControl.getCustomers();
            existingCustomer_Cmb.Items.Clear();
            existingCustomer_Cmb.Items.Add("(New)");
            foreach (Customer customer in Info.customers)
            {
                existingCustomer_Cmb.Items.Add(customer.name);
            }
            if (customerName_Txt.Text != "")
            {
                existingCustomer_Cmb.Text = customerName_Txt.Text;
            }
            else
            {
                existingCustomer_Cmb.SelectedIndex = 0;
            }
        }

        private void mileage_Txt_Leave(object sender, EventArgs e)
        {
            try
            {
                mileage_Txt.Text = string.Format("{0:###,###.00}", double.Parse(mileage_Txt.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid number format!");
                mileage_Txt.Text = "0";
            }
        }

        private void setTimeRemaining()
        {
            estimatedTime_Txt.Text = (Convert.ToDouble(timeOut_Txt.Text) - Convert.ToDouble(timeIn_Txt.Text)).ToString();
        }

        private void timeIn_Txt_Leave(object sender, EventArgs e)
        {
            // Check if a timeIn is valid number
            double d;
            if (!double.TryParse(timeIn_Txt.Text, out d))
            {
                MessageBox.Show("Time in should be numeric value. Please input!");
                timeIn_Txt.Text = "0";
                timeIn_Txt.Focus();
                return;
            }
            setTimeRemaining();
        }

        private void timeOut_Txt_Leave(object sender, EventArgs e)
        {
            double d;
            if (!double.TryParse(timeOut_Txt.Text, out d))
            {
                MessageBox.Show("Time in should be numeric value. Please input!");
                timeOut_Txt.Text = "0";
                timeOut_Txt.Focus();
                return;
            }
            setTimeRemaining();
        }
    }   
}
