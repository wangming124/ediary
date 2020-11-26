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
    public partial class BookingDetailForm : Form
    {
        public BookingDetailForm()
        {
            InitializeComponent();
        }

        private void backToList_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.bookingGridForm);
        }
        public void getDescription(Booking booking)
        {
            jobNO_Txt.Text = booking.jobNO;
            jobType_Txt.Text = booking.jobType;
            honor_Txt.Text = booking.customer.Split(new string[] { ". " }, StringSplitOptions.None)[0];
            customer_Txt.Text = booking.customer.Split(new string[] { ". " }, StringSplitOptions.None)[1];
            vehicleMake_Txt.Text = booking.vehicleMake;
            vehicleModel_Txt.Text = booking.vehicleModel;
            vehicleRegNo_Txt.Text = booking.vehicleRegNo;
            loanCar_Txt.Text = booking.loanCar;
            timeIn_Txt.Text = booking.timeIn.ToString();
            timeOut_Txt.Text = booking.timeOut.ToString();
            bookedBy_Txt.Text = booking.bookedBy;
            estimatedTime_Txt.Text = booking.estimatedTime.ToString();
            insurance_Txt.Text = booking.insuranceRequired;
            jobDetails_Txt.Text = booking.jobDescription;
            notes_Txt.Text = booking.notes;
        }
    }
}
