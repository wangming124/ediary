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
    public partial class TechnicianGridForm : Form
    {
        class FilteredTechnician
        {
            public int id { get; set; }
            public string name { get; set; }          // Name
            public double workingHours { get; set; }  // Working Hours
            public DateTime date { get; set; }        // Date
        }
        DateTime lastDate;
        public TechnicianGridForm()
        {
            InitializeComponent();
        }
        private void TechnicianGridForm_Load(object sender, EventArgs e)
        {
            showTechnicians();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Working Hours";
            dataGridView1.Columns[3].HeaderText = "Date";
            dataGridView1.Columns[0].Visible = false;
            // Add Edit button column in datagridview
            DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
            editCol.Name = "dataGridViewEditButton";
            editCol.HeaderText = "";
            editCol.Text = "Edit";
            editCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editCol);
            // Add Delete button column in datagridview
            //DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
            //deleteCol.Name = "dataGridViewDeleteButton";
            //deleteCol.HeaderText = "Delete";
            //deleteCol.Text = "Delete";
            //deleteCol.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Add(deleteCol);
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lastDate = dateTimePicker1.Value;
        }
        public void showTechnicians()
        {
            BindingSource bs = new BindingSource();
            GData.technicians = DatabaseControl.getTechnicians();
            bs.DataSource = GData.technicians.Select(s => new FilteredTechnician()
            {
                id = s.id,
                name = s.name,
                workingHours = s.workingHours,
                date = s.date
            }).Where(s => s.date.Date == dateTimePicker1.Value.Date).ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bs;
        }
        private void add_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.newTechnicianForm);
        }
        private void del_Btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = (int)dataGridView1.Rows[index].Cells["ID"].Value;
                var result = MessageBox.Show("Are you sure want to deleted this techinician?", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Technician technician = GData.technicians.Where(t => t.id == id).ToList()[0];
                    if (DatabaseControl.deleteTechnician(technician))
                    {
                        MessageBox.Show("Selected Technician has been deleted!");
                        showTechnicians();
                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

            //if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            //{
            //    var result = MessageBox.Show("Are you sure want to deleted this techinician?", "Warning!", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        string query = "DELETE FROM Technician WHERE [Id] = '" + id + "'";
            //        if (DatabaseControl.executeQuery(query))
            //        {
            //            dataGridView1.Rows.RemoveAt(e.RowIndex);
            //            Info.technicians = DatabaseControl.getTechnicians();
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewEditButton"].Index)
            {
                UIControl.showForm(UIControl.editTechnicianForm);
                UIControl.editTechnicianForm.technicianToEdit = GData.technicians.Where(b => b.id == id).ToList()[0];
                UIControl.editTechnicianForm.getDescription();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (DateTime dt in GData.blackoutDates)
            {
                if (dt.Date == dateTimePicker1.Value.Date)
                {
                    MessageBox.Show("Can not select holidays!");
                    dateTimePicker1.Value = lastDate;
                    return;
                }
            }
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Can not select Sundays!");
                dateTimePicker1.Value = lastDate;
                return;
            }
            lastDate = dateTimePicker1.Value;
            showTechnicians();
        }

       
    }
}
