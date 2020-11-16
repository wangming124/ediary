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
    public partial class EditJobTypeForm : Form
    {
        public JobType jobTypeToEdit;
        public EditJobTypeForm()
        {
            InitializeComponent();
        }
        public void getDescription()
        {
            name_Txt.Text = jobTypeToEdit.typeName;
            background_Lbl.Text = jobTypeToEdit.background;
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

            jobTypeToEdit.typeName = name_Txt.Text;
            jobTypeToEdit.background = background_Lbl.Text;

            UIControl.jobTypesGridForm.updateJobType(jobTypeToEdit);
            UIControl.showForm(UIControl.jobTypesGridForm);
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
