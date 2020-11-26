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
    public partial class EditTechnicianForm : Form
    {
        public Technician technicianToEdit;
        public EditTechnicianForm()
        {
            InitializeComponent();
        }
        public void getDescription()
        {
            name_Txt.Text = technicianToEdit.name;
            workingHours_Txt.Text = technicianToEdit.workingHours.ToString();
            dateTimePicker1.Value = technicianToEdit.date;
        }
        private void save_Btn_Click(object sender, EventArgs e)
        {
            // Check if a technician name is not empty
            if (name_Txt.Text == "")
            {
                MessageBox.Show("Name field can not be empty. Please input!");
                name_Txt.Focus();
                return;
            }

            // Check if a working hours is not empty
            if (workingHours_Txt.Text == "")
            {
                MessageBox.Show("Working Hours can not be empty. Please input!");
                workingHours_Txt.Focus();
                return;
            }

            // Check if a working hours is numeric value
            double d;
            if (!double.TryParse(workingHours_Txt.Text, out d))
            {
                MessageBox.Show("Invalid Input! Working hours should be numeric value. Please input!");
                workingHours_Txt.Focus();
                return;
            }
            technicianToEdit.name = name_Txt.Text;
            technicianToEdit.workingHours = Convert.ToDouble(workingHours_Txt.Text);
            technicianToEdit.date = dateTimePicker1.Value;

            if (DatabaseControl.updateTechnician(technicianToEdit))
            {
                MessageBox.Show("Technician data has been updated successfully!");
                UIControl.technicianGridForm.showTechnicians();
                UIControl.showForm(UIControl.technicianGridForm);
            }
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.technicianGridForm);
        }
    }
}
