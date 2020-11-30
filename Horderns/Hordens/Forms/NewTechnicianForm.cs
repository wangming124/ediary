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
            if (hoursOnMonFri_Txt.Text == "")
            {
                MessageBox.Show("Working Hours can not be empty. Please input!");
                hoursOnMonFri_Txt.Focus();
                return;
            }

            

            // Create a new technician
            Technician newTechnician = new Technician
            {
                name = name_Txt.Text,
                workingHours = Convert.ToDouble(hoursOnMonFri_Txt.Text),
                date = DateTime.Now
            };

            if (DatabaseControl.addTechnician(newTechnician))
            {
                MessageBox.Show("New Technician has been added succesfully!");
                UIControl.technicianGridForm.showTechnicians();
                clearFields();
            }
        }
        private void clearFields()
        {
            name_Txt.Text = "";
            hoursOnMonFri_Txt.Text = "";
        }
        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.technicianGridForm);
        }

        private void NewTechnicianForm_Load(object sender, EventArgs e)
        {
            
        }

        private void hoursOnMonFri_Txt_TextChanged(object sender, EventArgs e)
        {
            // Check if a working hours on Mon-Fri is numeric value
            double d;
            if (!double.TryParse(hoursOnMonFri_Txt.Text, out d) || Convert.ToDouble(hoursOnMonFri_Txt.Text) < 0 || Convert.ToDouble(hoursOnMonFri_Txt.Text) > 24)
            {
                MessageBox.Show("Invalid Input! This value should be numeric!");
                hoursOnMonFri_Txt.Focus();
                hoursOnMonFri_Txt.Text = "0";
                return;
            }
        }

        private void hoursOnSat_Txt_TextChanged(object sender, EventArgs e)
        {
            // Check if a working hours on Saturday is numeric value
            double d;
            if (!double.TryParse(hoursOnSat_Txt.Text, out d) || Convert.ToDouble(hoursOnSat_Txt.Text) < 0 || Convert.ToDouble(hoursOnSat_Txt.Text) > 24)
            {
                MessageBox.Show("Invalid Input! This value should be numeric!");
                hoursOnSat_Txt.Focus();
                hoursOnSat_Txt.Text = "0";
                return;
            }
        }

        private void hoursOnSpec_Txt_TextChanged(object sender, EventArgs e)
        {
            // Check if a working hours on Specific is numeric value
            double d;
            if (!double.TryParse(hoursOnSpec_Txt.Text, out d) || Convert.ToDouble(hoursOnSpec_Txt.Text) < 0 || Convert.ToDouble(hoursOnSpec_Txt.Text) > 24)
            {
                MessageBox.Show("Invalid Input! This value should be numeric!");
                hoursOnSpec_Txt.Focus();
                hoursOnSpec_Txt.Text = "0";
                return;
            }
        }

        private void setTotalHours()
        {
            hoursTotal_Txt.Text = (Convert.ToDouble(hoursOnMonFri_Txt.Text) + Convert.ToDouble(hoursOnSat_Txt.Text) + Convert.ToDouble(hoursOnSpec_Txt.Text)).ToString();
        }
    }
}
