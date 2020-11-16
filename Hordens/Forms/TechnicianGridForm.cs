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
        public TechnicianGridForm()
        {
            InitializeComponent();
        }
        private void TechnicianGridForm_Load(object sender, EventArgs e)
        {
            Info.technicians = DatabaseControl.getTechnicians();
            showTechnicians();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Working Hours";
            // Add Edit button column in datagridview
            DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
            editCol.Name = "dataGridViewEditButton";
            editCol.HeaderText = "Edit";
            editCol.Text = "Edit";
            editCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editCol);

            // Add Delete button column in datagridview
            DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
            deleteCol.Name = "dataGridViewDeleteButton";
            deleteCol.HeaderText = "Delete";
            deleteCol.Text = "Delete";
            deleteCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteCol);
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void showTechnicians()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Info.technicians.Select(s => new FilteredTechnician()
            {
                id = s.id,
                name = s.name,
                workingHours = s.workingHours,
                date = s.date
            }).Where(s => s.date.Date == dateTimePicker1.Value.Date).ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bs;
        }

        public void addTechnician(Technician newTechnician)
        {
            string query = String.Format("insert into Technician ([Name], [Working Hours], [Date]) values ('{0}', '{1}', '{2}')",
                            newTechnician.name, newTechnician.workingHours, newTechnician.date);
            if (DatabaseControl.executeQuery(query))
            {
                Info.technicians.Add(newTechnician);
                showTechnicians();
                MessageBox.Show("New Technician has been added succesfully!");
            }

        }

        public void updateTechnician(Technician technician)
        {
            string query = String.Format("UPDATE Technician SET [Name] = '{0}', [Working Hours] = '{1}' WHERE [Id] = '{2}'",
                technician.name, technician.workingHours, technician.id);

            if (DatabaseControl.executeQuery(query))
            {
                showTechnicians();
            }
        }
        private void add_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.newTechnicianForm);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                var result = MessageBox.Show("Are you sure want to deleted this techinician?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Technician WHERE [Id] = '" + id + "'";
                    if (DatabaseControl.executeQuery(query))
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        Info.technicians = DatabaseControl.getTechnicians();
                    }
                }
                else
                {
                    return;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["dataGridViewEditButton"].Index)
            {
                UIControl.showForm(UIControl.editTechnicianForm);
                UIControl.editTechnicianForm.technicianToEdit = Info.technicians.Where(b => b.id == id).ToList()[0];
                UIControl.editTechnicianForm.getDescription();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            showTechnicians();
        }
    }
}
