using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hordens
{
    class UIControl
    {
        public static MainForm mainForm = new MainForm();
        public static BookingDetailForm bookingDetailForm = new BookingDetailForm();
        public static BookingGridForm bookingGridForm = new BookingGridForm();
        public static EditBookingForm editBookingForm = new EditBookingForm();
        public static NewBookingForm newBookingForm = new NewBookingForm();
        public static TechnicianGridForm technicianGridForm = new TechnicianGridForm();
        public static NewTechnicianForm newTechnicianForm = new NewTechnicianForm();
        public static EditTechnicianForm editTechnicianForm = new EditTechnicianForm();
        public static JobTypesGridForm jobTypesGridForm = new JobTypesGridForm();
        public static NewJobTypeForm newJobTypeForm = new NewJobTypeForm();
        public static EditJobTypeForm editJobTypeForm = new EditJobTypeForm();
        public UIControl()
        {          
        }

        // Hide all forms but a specific form "showForm"
        public static void showForm(Form showForm)
        {
            bookingDetailForm.Hide();
            bookingGridForm.Hide();
            editBookingForm.Hide();
            newBookingForm.Hide();
            technicianGridForm.Hide();
            newTechnicianForm.Hide();
            editTechnicianForm.Hide();
            jobTypesGridForm.Hide();
            newJobTypeForm.Hide();
            editJobTypeForm.Hide();
            showForm.Show();
        }        
    }
}
