using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Hordens
{
    public partial class BookingGridForm : Form
    {
        private class FilteredBooking
        {
            public int id { get; set; }
            public string jobNO { get; set; }
            public string jobType { get; set; }
            public string customer { get; set; }
            public string vehicleModel { get; set; }
            public string bookedBy { get; set; }
            public string loanCar { get; set; }
            public string jobDescription { get; set; }
            public DateTime timeIn { get; set; }
        }
        public BookingGridForm()
        {
            InitializeComponent();
        }
        private void BookingGridForm_Load(object sender, EventArgs e)
        {
            Info.bookings = DatabaseControl.getBookings();
            showBookings();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Job NO";
            dataGridView1.Columns[2].HeaderText = "Job Type";
            dataGridView1.Columns[3].HeaderText = "Customer";
            dataGridView1.Columns[4].HeaderText = "Vehicle Model";
            dataGridView1.Columns[5].HeaderText = "Booked By";
            dataGridView1.Columns[6].HeaderText = "Loan Car";
            dataGridView1.Columns[7].HeaderText = "Job Description";
            dataGridView1.Columns[8].HeaderText = "Time In";
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
        }

        // Show booking grid with booking list from SQL Table
        public void showBookings()
        {
            BindingSource bs = new BindingSource();

            bs.DataSource = Info.bookings.Select(b => new FilteredBooking()
            {
                id = b.id,
                jobNO = b.jobNO,
                jobType = b.jobType,
                customer = b.customer,
                vehicleModel = b.vehicleModel,
                bookedBy = b.bookedBy,
                loanCar = b.loanCar,
                jobDescription = b.jobDescription,
                timeIn = b.timeIn
            }).Where(b => b.timeIn.Date == dateTimePicker1.Value.Date).ToList();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bs;
        }

        // Add a new booking
        public void addBooking(Booking newBooking)
        {                       
            string query = String.Format("insert into Booking ([Job NO], [Job Type], [Customer], [Address], [Post Code], [Email], [Tel], " +
                "[Vehicle Make], [Vehicle Model], [Vehicle Reg.NO], [Loan Car], [Time In], [Time Out], [Booked By], [Estimated Time]," +
                " [Time Remaining], [Insurance Required], [Job Description], [Notes]) " +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
                "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}')",
                newBooking.jobNO, newBooking.jobType, newBooking.customer, newBooking.address, newBooking.postCode, newBooking.email, newBooking.tel, 
                newBooking.vehicleMake, newBooking.vehicleModel, newBooking.vehicleRegNo, newBooking.loanCar, newBooking.timeIn, newBooking.timeOut, newBooking.bookedBy,
                newBooking.estimatedTime, newBooking.timeRemaining, newBooking.insuranceRequired, newBooking.jobDescription, newBooking.notes);
            if (DatabaseControl.executeQuery(query))
            {
                Info.bookings.Add(newBooking);
                MessageBox.Show("New booking has been added succesfully!");
                showBookings();
            }
        }

        // Update booking of selected Row
        public void updateBooking(Booking booking)
        {
            //string query = String.Format("UPDATE Booking ([Job NO], [Job Type], [Customer], [Vehicle Make], [Vehicle Model], [Vehicle Reg.NO]," +
            //    "[Loan Car], [Time In], [Time Out], [Booked By], [Estimated Time], [Time Remaining], [Insurance Required], [Job Description], [Notes]) " +
            //    "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}') WHERE [Job NO] = '{0}'", 
            //    booking.jobNO, booking.jobType, booking.customer, booking.vehicleMake, booking.vehicleModel, booking.vehicleRegNo, booking.loanCar, booking.timeIn, 
            //    booking.timeOut, booking.bookedBy, booking.estimatedTime, booking.timeRemaining, booking.insuranceRequired, booking.jobDescription, booking.notes);

            string query = String.Format("UPDATE Booking SET [Job NO] = '{0}', [Job Type] = '{1}', [Customer] = '{2}', [Vehicle Make] = '{3}'," +
                " [Vehicle Model] = '{4}', [Vehicle Reg.NO] = '{5}', [Loan Car] = '{6}', [Time In] = '{7}', [Time Out] = '{8}', [Booked By] = '{9}', " +
                "[Estimated Time] = '{10}', [Time Remaining] = '{11}', [Insurance Required] = '{12}', [Job Description] = '{13}', [Notes] = '{14}' " +
                "WHERE [Id] = '{15}'", booking.jobNO, booking.jobType, booking.customer, booking.vehicleMake, booking.vehicleModel,
                booking.vehicleRegNo, booking.loanCar, booking.timeIn, booking.timeOut, booking.bookedBy, booking.estimatedTime, booking.timeRemaining,
                booking.insuranceRequired, booking.jobDescription, booking.notes, booking.id);

            if (DatabaseControl.executeQuery(query))
            {
                showBookings();
            }
        }
        private void add_Btn_Click(object sender, EventArgs e)
        {
            UIControl.showForm(UIControl.newBookingForm);
        }

       

        // When double click cell in the datagridview, navigate to the BookingDetailForm
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows[0].IsNewRow)
                return;

            UIControl.showForm(UIControl.bookingDetailForm);
            Booking booking = Info.bookings[dataGridView1.SelectedRows[0].Index];
            UIControl.bookingDetailForm.getDescription(booking);

        }

        // Edit and Delete bookings by click buttons.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                var result = MessageBox.Show("Are you sure want to deleted this booking?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Booking WHERE [Id] = '" + id + "'";
                    if (DatabaseControl.executeQuery(query))
                    {    
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        Info.bookings = DatabaseControl.getBookings();
                    }
                }
                else
                {
                    return;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["dataGridViewEditButton"].Index)
            {
                UIControl.showForm(UIControl.editBookingForm);                
                UIControl.editBookingForm.bookingToEdit = Info.bookings.Where(b => b.id == id).ToList()[0];
                UIControl.editBookingForm.getDescription();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(dateTimePicker1.Value);
            showBookings();
        }
        private void print_Btn_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog(); //make a printDialog object

            //PrintDocument printDocument = new PrintDocument(); // make a print doc object

            //printDialog.Document = printDocument; //document for printing is printDocument

            //printDocument.PrintPage += printDocument_PrintPage; //event handler fire



            //DialogResult result = printDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}

            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 10);
            PaperSize psz = new PaperSize("A3", 297, 420);
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psz;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;
            pdoc.DefaultPageSettings.PaperSize.Width = 700;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            DialogResult res = pd.ShowDialog();
            if (res == DialogResult.OK)
            {
                PrintPreviewDialog prv = new PrintPreviewDialog();
                prv.Document = pdoc;
                res = prv.ShowDialog();
                if (res == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }
        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 50;
            int startY = 65;
            int Offset = 40;
            graphics.DrawString("Welcome to Bakery Shop", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            string underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            int a = dataGridView1.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                graphics.DrawString(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                graphics.DrawString("\t" + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }
        }
        public void printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Graphics graphic = ev.Graphics;
            string text = "";
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name != "dataGridViewDeleteButton" && col.Name != "dataGridViewEditButton")
                    text += string.Format("{0,-15}", col.HeaderText);
            }
            text += "\n";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != "Delete" && cell.Value != "Edit")
                    text += string.Format("{0,-15}",cell.Value.ToString()); //or whatever you want from the current row
                }
                text += "\n";
            }
            graphic.DrawString(text, new Font("Times New Roman", 11, FontStyle.Bold), Brushes.Black, 20, 225);
            
        }
    }
}
