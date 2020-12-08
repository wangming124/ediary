using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hordens
{
    class DatabaseControl
    {
        public static bool CreateDBIfNotExists()
        {            
            try
            {
                HordernsDB hordernsDB = new HordernsDB(GData.conStr);
                if (!hordernsDB.DatabaseExists())
                    hordernsDB.CreateDatabase();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        // Add new booking into sql table
        public static bool addBooking(Booking newBooking)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            hordensDB.bookings.InsertOnSubmit(newBooking);
            try
            {
                hordensDB.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool updateBooking(Booking bookingToEdit)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Booking> bookings = hordensDB.GetTable<Booking>();
            var query =
                from booking in bookings
                where booking.id == bookingToEdit.id
                select booking;

            if (query.ToList().Count > 0)
            {
                Booking booking = query.ToList()[0];
                booking.jobNO = bookingToEdit.jobNO;
                booking.jobType = bookingToEdit.jobType;
                booking.customerID = bookingToEdit.customerID;
                booking.servicePlan = bookingToEdit.servicePlan;
                booking.vehicleMake = bookingToEdit.vehicleMake;
                booking.vehicleModel = bookingToEdit.vehicleModel;
                booking.regNo = bookingToEdit.regNo;
                booking.mileage = bookingToEdit.mileage;
                booking.loanCar = bookingToEdit.loanCar;
                booking.timeIn = bookingToEdit.timeIn;
                booking.timeOut = bookingToEdit.timeOut;
                booking.bookedBy = bookingToEdit.bookedBy;
                booking.estimatedTime = bookingToEdit.estimatedTime;
                booking.insuranceRequired = bookingToEdit.insuranceRequired;
                booking.jobDescription = bookingToEdit.jobDescription;
                booking.notes = bookingToEdit.notes;
                try
                {
                    hordensDB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }
        // Delete a booking from database
        public static bool deleteBooking(Booking bookingToDelete)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Booking> bookings = hordensDB.GetTable<Booking>();
            var query =
                from booking in bookings
                where booking.id == bookingToDelete.id
                select booking;

            if (query.ToList().Count > 0)
            {
                Booking booking = query.ToList()[0];
                hordensDB.bookings.DeleteOnSubmit(booking);
                try
                {
                    hordensDB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }
        // Move booking if not finished to next date
        public static void moveBookingToNextDate(Booking bookingToMove, double estimatedTime)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Booking> bookings = hordensDB.GetTable<Booking>();
            var query =
                from booking in bookings
                where booking.id == bookingToMove.id
                select booking;
            if (query.ToList().Count > 0)
            { 
                Booking booking = new Booking
                {
                    jobNO = bookingToMove.jobNO,
                    jobType = bookingToMove.jobType,
                    customerID = bookingToMove.customerID,
                    servicePlan = bookingToMove.servicePlan,
                    vehicleMake = bookingToMove.vehicleMake,
                    vehicleModel = bookingToMove.vehicleModel,
                    regNo = bookingToMove.regNo,
                    mileage = bookingToMove.mileage,
                    loanCar = bookingToMove.loanCar,
                    timeIn = bookingToMove.timeIn,
                    timeOut = bookingToMove.timeOut,
                    bookedBy = bookingToMove.bookedBy,
                    estimatedTime = estimatedTime,
                    timeRemaining = bookingToMove.timeRemaining,
                    insuranceRequired = bookingToMove.insuranceRequired,
                    jobDescription = bookingToMove.jobDescription,
                    notes = bookingToMove.notes,
                    bookingDate = bookingToMove.bookingDate.AddDays(1)
                };
                addBooking(booking);
            }
        }
        // Get all booking from database into Objects
        public static List<Booking> getBookings()
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Booking> bookings = hordensDB.GetTable<Booking>();
            return bookings.ToList();
        }

        // Add new job type into database
        public static bool addJobType(JobType jobType)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            hordensDB.jobTypes.InsertOnSubmit(jobType);
            try
            {
                hordensDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        // Update Job Type from database
        public static bool updateJobType(JobType jobTypeToEdit)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<JobType> jobTypes = hordensDB.GetTable<JobType>();
            var query =
                from jobType in jobTypes
                where jobType.id == jobTypeToEdit.id
                select jobType;

            if (query.ToList().Count > 0)
            {
                JobType jobType  = query.ToList()[0];
                jobType.typeName = jobTypeToEdit.typeName;
                jobType.background = jobTypeToEdit.background;

                try
                {
                    hordensDB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }

        // Delete Job Type from database
        public static bool deleteJobType(JobType jobTypeToDelete)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<JobType> jobTypes = hordensDB.GetTable<JobType>();
            var query =
                from jobType in jobTypes
                where jobType.id == jobTypeToDelete.id
                select jobType;

            if (query.ToList().Count > 0)
            {
                JobType jobType = query.ToList()[0];
                hordensDB.jobTypes.DeleteOnSubmit(jobType);
                try
                {
                    hordensDB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }

        // Get all job types from database and convert into object
        public static List<JobType> getJobTypes()
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<JobType> jobTypes = hordensDB.GetTable<JobType>();
            return jobTypes.ToList();
        }
        // Add new technician into database
        public static bool addTechnician(Technician technician)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            hordensDB.technicians.InsertOnSubmit(technician);
            try
            {
                hordensDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool updateTechnician(Technician technicianToEdit)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Technician> technicians = hordensDB.GetTable<Technician>();
            var query =
                from technician in technicians
                where technician.id == technicianToEdit.id
                select technician;

            if (query.ToList().Count > 0)
            {
                Technician technician = query.ToList()[0];
                technician.name = technicianToEdit.name;
                technician.date = technicianToEdit.date;
                technician.workingHours = technicianToEdit.workingHours;

                try
                {
                    hordensDB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }

        public static bool deleteTechnician(Technician technicianToDelete)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Technician> technicians = hordensDB.GetTable<Technician>();
            var query =
                from technician in technicians
                where technician.id == technicianToDelete.id
                select technician;

            if (query.ToList().Count > 0)
            {
                Technician technician = query.ToList()[0];
                hordensDB.technicians.DeleteOnSubmit(technician);
                try
                {
                    hordensDB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return false;
        }
        public static List<Technician> getTechnicians()
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Technician> technicians = hordensDB.GetTable<Technician>();
            return technicians.ToList();
        }

        public static int addCustomer(Customer customer)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            hordensDB.customers.InsertOnSubmit(customer);
            try
            {
                hordensDB.SubmitChanges();
                return customer.id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }            
        }
        public static void updateCustomer(Customer customerToUpdate, int id)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Customer> customers = hordensDB.GetTable<Customer>();
            var query =
                from customer in customers
                where customer.id == id
                select customer;

            if (query.ToList().Count > 0)
            {
                Customer customer = query.ToList()[0];
                customer.honor = customerToUpdate.honor;
                customer.name = customerToUpdate.name;
                customer.address1 = customerToUpdate.address1;
                customer.address2 = customerToUpdate.address2;
                customer.address3 = customerToUpdate.address3;
                customer.postCode = customerToUpdate.postCode;
                customer.email = customerToUpdate.email;
                customer.tel = customerToUpdate.tel;

                try
                {
                    hordensDB.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public static List<Customer> getCustomers()
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<Customer> customers = hordensDB.GetTable<Customer>();
            return customers.ToList();
        }

        public static Customer GetCustomer(int id)
        {
            GData.customers = getCustomers();
            List<Customer> customers = GData.customers.Where(c => c.id == id).ToList();
            if (customers.Count > 0)            
                return customers[0];            
            else
                return null;
        }
       
        public static void setBookingDates(DateTime date, double hours, string note)
        {
            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<BookingDate> bookingDates = hordensDB.GetTable<BookingDate>();
            var query =
                from bookingDate in bookingDates
                where bookingDate.date.Date == date.Date
                select bookingDate;

            if (query.ToList().Count > 0)
            {
                BookingDate bookingDate = query.ToList()[0];
                bookingDate.hours = hours;
                bookingDate.note = note;
            }
            else
            {
                BookingDate newBookingDate = new BookingDate
                {
                    date = date,
                    hours = hours,
                    note = note
                };
                hordensDB.bookingDates.InsertOnSubmit(newBookingDate);                
            }
            try
            {
                hordensDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            /*try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM BookingDates Where date = @date";
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    int count = 0;
                    count = Convert.ToInt32(cmd.ExecuteScalar());                    
                    if (count > 0)
                    {
                        cmd.CommandText = "UPDATE BookingDates SET hours=@hours, note=@note Where date=@date";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO BookingDates (date, hours, note) values (@date, @hours, @note);";
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@hours", hours);
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    cmd.Parameters.AddWithValue("@note", note);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }

        public static double getHoursOfBookingDate(DateTime date)
        {
            double hours = 0;

            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<BookingDate> bookingDates = hordensDB.GetTable<BookingDate>();
            var query =
                from bookingDate in bookingDates
                where bookingDate.date.Date == date.Date
                select bookingDate;
            if (query.ToList().Count > 0)
            {
                hours = query.ToList()[0].hours;
            }
            return hours;
            //try
            //{
            //    using (cmd = con.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT hours FROM BookingDates Where date = @date";
            //        cmd.Parameters.AddWithValue("@date", date.Date);
            //        hours = Convert.ToDouble(cmd.ExecuteScalar());
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
            //return hours;
        }

        public static string getBookingNote(DateTime date)
        {
            string note = "";

            HordernsDB hordensDB = new HordernsDB(GData.conStr1);
            Table<BookingDate> bookingDates = hordensDB.GetTable<BookingDate>();
            var query =
                from bookingDate in bookingDates
                where bookingDate.date.Date == date.Date
                select bookingDate;

            if (query.ToList().Count > 0)
            {
                note = query.ToList()[0].note;
            }
            return note;
        }
    }
}
