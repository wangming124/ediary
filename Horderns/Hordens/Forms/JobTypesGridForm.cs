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
    public partial class JobTypesGridForm : Form
    {
        class FilteredJobType
        {            
            public int id { get; set; }
            public string typeName { get; set; }   // Job Type Name
            public string background { get; set; } // Background color
        }
        public JobTypesGridForm()
        {
            InitializeComponent();
        }

        private void JobTypesGridForm_Load(object sender, EventArgs e)
        {
            showJobTypes();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Type Name";
            dataGridView1.Columns[2].HeaderText = "Background Color";
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
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            showJobTypes();
        }
        public void showJobTypes()
        {
            BindingSource bs = new BindingSource();
            GData.jobTypes = DatabaseControl.getJobTypes();
            bs.DataSource = GData.jobTypes.Select(j => new FilteredJobType()
            {
                id = j.id,
                typeName = j.typeName,
                background = j.background
            }).ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bs;
            
            UIControl.newBookingForm.updateJobTypes();
            UIControl.editBookingForm.updateJobTypes();
        }
        //public void addJobType(JobType newJobType)
        //{
        //    string query = String.Format("insert into JobType ([Type Name], [Background Color]) values ('{0}', '{1}')",
        //                    newJobType.typeName, newJobType.background);
        //    if (DatabaseControl.executeQuery(query))
        //    {
        //        Info.jobTypes.Add(newJobType);
        //        showJobTypes();
        //        MessageBox.Show("New Job Type has been added succesfully!");
        //    }
        //}

        //public void updateJobType(JobType jobType)
        //{
        //    string query = String.Format("UPDATE JobType SET [Type Name] = '{0}', [Background Color] = '{1}' WHERE [Id] = '{2}'",
        //        jobType.typeName, jobType.background, jobType.id);

        //    if (DatabaseControl.executeQuery(query))
        //    {
        //        showJobTypes();
        //    }
        //}
        private void add_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.newJobTypeForm);
        }
        private void del_Btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = (int)dataGridView1.Rows[index].Cells["ID"].Value;
                var result = MessageBox.Show("Are you sure want to deleted this job type?", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    JobType jobType = GData.jobTypes.Where(j => j.id == id).ToList()[0];
                    if (DatabaseControl.deleteJobType(jobType))
                    {
                        MessageBox.Show("Selected Job Type has been deleted!");
                        showJobTypes();
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

            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewEditButton"].Index)
            {
                UIControl.showForm(UIControl.editJobTypeForm);
                UIControl.editJobTypeForm.jobTypeToEdit = GData.jobTypes.Where(j => j.id == id).ToList()[0];
                UIControl.editJobTypeForm.getDescription();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["background"].Value != null)
                    row.Cells["background"].Style.BackColor = ColorTranslator.FromHtml(row.Cells["background"].Value.ToString());
            }
        }
    }
}
