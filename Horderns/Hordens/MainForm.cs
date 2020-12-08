using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hordens
{
    public partial class MainForm : Form
    {       public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            UIControl.bookingDetailForm.TopLevel = false;
            UIControl.bookingDetailForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.bookingGridForm.TopLevel = false;
            UIControl.bookingGridForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.editBookingForm.TopLevel = false;
            UIControl.editBookingForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.newBookingForm.TopLevel = false;
            UIControl.newBookingForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.technicianGridForm.TopLevel = false;
            UIControl.technicianGridForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.newTechnicianForm.TopLevel = false;
            UIControl.newTechnicianForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.editTechnicianForm.TopLevel = false;
            UIControl.editTechnicianForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.jobTypesGridForm.TopLevel = false;
            UIControl.jobTypesGridForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.newJobTypeForm.TopLevel = false;
            UIControl.newJobTypeForm.Dock = System.Windows.Forms.DockStyle.Fill;
            UIControl.editJobTypeForm.TopLevel = false;
            UIControl.editJobTypeForm.Dock = System.Windows.Forms.DockStyle.Fill;
            contentPanel.Controls.Add(UIControl.bookingDetailForm);
            contentPanel.Controls.Add(UIControl.bookingGridForm);
            contentPanel.Controls.Add(UIControl.editBookingForm);
            contentPanel.Controls.Add(UIControl.newBookingForm);
            contentPanel.Controls.Add(UIControl.technicianGridForm);
            contentPanel.Controls.Add(UIControl.newTechnicianForm);
            contentPanel.Controls.Add(UIControl.editTechnicianForm);
            contentPanel.Controls.Add(UIControl.jobTypesGridForm);
            contentPanel.Controls.Add(UIControl.newJobTypeForm);
            contentPanel.Controls.Add(UIControl.editJobTypeForm);
            UIControl.showForm(UIControl.bookingGridForm);
            showClock();
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            showClock();
        }
        private void showClock()
        {
            clock_Lbl.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }
        private void mainForm_Closing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }             

        private void booking_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.bookingGridForm);
        }

        private void technician_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.technicianGridForm);
        }

        private void jobType_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.jobTypesGridForm);
        }

        private void close_Btn_Click(object sender, EventArgs e)
        {            
            Application.Exit();
        }      
    }
}
