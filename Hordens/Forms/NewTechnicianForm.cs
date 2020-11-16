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
    public partial class NewTechnicianForm : Form
    {
        public NewTechnicianForm()
        {
            InitializeComponent();
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

            // Create a new technician
            Technician newTechnician = new Technician
            {
                name = name_Txt.Text,
                workingHours = Convert.ToDouble(workingHours_Txt.Text),
                date = DateTime.Now
            };

            UIControl.technicianGridForm.addTechnician(newTechnician);
            clearFields();
        }
        private void clearFields()
        {
            name_Txt.Text = "";
            workingHours_Txt.Text = "";
        }
        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.technicianGridForm);
        }

        private void NewTechnicianForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
