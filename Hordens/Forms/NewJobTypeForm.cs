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
    public partial class NewJobTypeForm : Form
    {
        public NewJobTypeForm()
        {
            InitializeComponent();            
        }

        private void clearFields()
        {
            name_Txt.Text = "";
            background_Lbl.Text = "";
            background_Lbl.BackColor = SystemColors.Control;
        }
        private void save_Btn_Click(object sender, EventArgs e)
        {
            // Check if a Job Type name is not empty
            if (name_Txt.Text == "")
            {
                MessageBox.Show("Job Type Name can not be empty. Please input!");
                name_Txt.Focus();
                return;
            }

            // Check if a background color is not empty
            if (background_Lbl.Text == "")
            {
                MessageBox.Show("Background Color field can not be empty. Please input!");
                background_Lbl.Focus();
                return;
            }

            //// Check if a working hours is numeric value
            //double d;
            //if (!double.TryParse(workingHours_Txt.Text, out d))
            //{
            //    MessageBox.Show("Invalid Input! Working hours should be numeric value. Please input!");
            //    workingHours_Txt.Focus();
            //    return;
            //}

            // Create a new technician
            JobType newJobType = new JobType
            {
                typeName = name_Txt.Text,
                background = background_Lbl.Text
            };

            UIControl.jobTypesGridForm.addJobType(newJobType);
            clearFields();
        }

        private void cancel_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.jobTypesGridForm);
        }        

        private void background_Lbl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                background_Lbl.BackColor = colorDialog1.Color;
                background_Lbl.Text = "#" + (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }
        }
    }
}
