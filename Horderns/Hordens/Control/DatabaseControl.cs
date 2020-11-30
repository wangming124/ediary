using System;
using System.Collections.Generic;
using System.Data;
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
        public static SqlConnection con;
        public static SqlCommand cmd;
        //public static SqlDataAdapter dataAdapter;
        //public static SqlCommandBuilder commandBuilder;
        public static bool ConnectToDatabase(string conStr)
        {
            
            try
            {
                con = new SqlConnection(conStr);   
                con.Open();             
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool executeQuery(string query)
        {
            try
            {
                cmd = new SqlCommand(query, con);                
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        // Add new booking into sql table
        public static bool addBooking(Booking newBooking)
        {
            using (cmd = con.CreateCommand())
            {
                //Customer customer = Info.customers.Where(c => c.id == newBooking.customerID).ToList()[0];
                cmd.CommandText = "insert into Booking ([Job NO], [Job Type], [CustomerID], [Service Plan], " +
                "[Vehicle Make], [Vehicle Model], [Vehicle Reg.NO], [Mileage], [Loan Car], [Time In], [Time Out], [Booked By], [Estimated Time]," +
                " [Time Remaining], [Insurance Required], [Job Description], [Notes], [Booking Date]) " +
                "values (@jobNo, @jobType, @customerId, @servicePlan, @vehicleMake, @vehicleModel, @regNo, @mileage, @loanCar, @timeIn, @timeOut," +
                "@bookedBy, @estimatedTime, @timeRemaining, @insuranceRequired, @jobDescription, @notes, @bookingDate)";
                cmd.Parameters.AddWithValue("@jobNo", newBooking.jobNO);
                cmd.Parameters.AddWithValue("@jobType", newBooking.jobType);
                cmd.Parameters.AddWithValue("@customerId", newBooking.customerID);
                cmd.Parameters.AddWithValue("@servicePlan", newBooking.servicePlan);
                cmd.Parameters.AddWithValue("@vehicleMake", newBooking.vehicleMake);
                cmd.Parameters.AddWithValue("@vehicleModel", newBooking.vehicleModel);
                cmd.Parameters.AddWithValue("@regNo", newBooking.vehicleRegNo);
                cmd.Parameters.AddWithValue("@mileage", newBooking.mileage);
                cmd.Parameters.AddWithValue("@loanCar", newBooking.loanCar);
                cmd.Parameters.AddWithValue("@timeIn", newBooking.timeIn);
                cmd.Parameters.AddWithValue("@timeOut", newBooking.timeOut);
                cmd.Parameters.AddWithValue("@bookedBy", newBooking.bookedBy);
                cmd.Parameters.AddWithValue("@estimatedTime", newBooking.estimatedTime);
                cmd.Parameters.AddWithValue("@timeRemaining", newBooking.timeRemaining);
                cmd.Parameters.AddWithValue("@insuranceRequired", newBooking.insuranceRequired);
                cmd.Parameters.AddWithValue("@jobDescription", newBooking.jobDescription);
                cmd.Parameters.AddWithValue("@notes", newBooking.notes);
                cmd.Parameters.AddWithValue("@bookingDate", newBooking.bookingDate);

                try
                {
                    cmd.ExecuteNonQuery();
                    //Info.bookings = getBookings();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool updateBooking(Booking booking)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Booking SET [Job NO] = @jobNo, [Job Type] = @jobType, [CustomerID] = @customerId, [Service Plan] = @servicePlan, [Vehicle Make] = @vehicleMake," +
                " [Vehicle Model] = @vehicleModel, [Vehicle Reg.NO] = @regNo, [Mileage] = @mileage, [Loan Car] = @loanCar, [Time In] = @timeIn, [Time Out] = @timeOut, [Booked By] = @bookedBy, " +
                "[Estimated Time] = @estimatedTime, [Insurance Required] = @insuranceRequired, [Job Description] = @description, [Notes] = @notes " +
                "WHERE [Id] = @id";
                cmd.Parameters.AddWithValue("@id", booking.id);
                cmd.Parameters.AddWithValue("@jobNo", booking.jobNO);
                cmd.Parameters.AddWithValue("@jobType", booking.jobType);
                cmd.Parameters.AddWithValue("@customerId", booking.customerID);
                cmd.Parameters.AddWithValue("@servicePlan", booking.servicePlan);
                cmd.Parameters.AddWithValue("@vehicleMake", booking.vehicleMake);
                cmd.Parameters.AddWithValue("@vehicleModel", booking.vehicleModel);
                cmd.Parameters.AddWithValue("@regNo", booking.vehicleRegNo);
                cmd.Parameters.AddWithValue("@mileage", booking.mileage);
                cmd.Parameters.AddWithValue("@loanCar", booking.loanCar);
                cmd.Parameters.AddWithValue("@timeIn", booking.timeIn);
                cmd.Parameters.AddWithValue("@timeOut", booking.timeOut);
                cmd.Parameters.AddWithValue("@bookedBy", booking.bookedBy);
                cmd.Parameters.AddWithValue("@estimatedTime", booking.estimatedTime);
                cmd.Parameters.AddWithValue("@insuranceRequired", booking.insuranceRequired);
                cmd.Parameters.AddWithValue("@description", booking.jobDescription);
                cmd.Parameters.AddWithValue("@notes", booking.notes);
                try
                {
                    cmd.ExecuteNonQuery();
                    //Info.bookings = getBookings();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        // Delete a booking from database
        public static bool deleteBooking(Booking booking)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "Delete From Booking WHERE [Id] = @id";
                cmd.Parameters.AddWithValue("@id", booking.id);

                try
                {
                    cmd.ExecuteNonQuery();
                    //Info.bookings = getBookings();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        // Get all booking from database into Objects
        public static List<Booking> getBookings()
        {
            Info.jobTypes = getJobTypes();
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Booking";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                            var booking = new Booking
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                jobNO = (string)reader.GetValue(1),
                                jobType = (string)reader.GetValue(2),
                                customerID = Convert.ToInt32(reader.GetValue(3)),
                                servicePlan = (string)reader.GetValue(4),
                                vehicleMake = (string)reader.GetValue(5),
                                vehicleModel = (string)reader.GetValue(6),
                                vehicleRegNo = (string)reader.GetValue(7),
                                mileage = Convert.ToDouble(reader.GetValue(8)),
                                jobDescription = (string)reader.GetValue(9),
                                loanCar = (string)reader.GetValue(10),
                                timeIn = Convert.ToDouble(reader.GetValue(11)),
                                timeOut = Convert.ToDouble(reader.GetValue(12)),
                                bookedBy = (string)reader.GetValue(13),
                                estimatedTime = (double)reader.GetValue(14),
                                timeRemaining = (double)reader.GetValue(15),
                                insuranceRequired = (string)reader.GetValue(16),
                                notes = (string)reader.GetValue(17),
                                bookingDate = (DateTime) reader.GetValue(18)
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return bookings;

        }

        // Add new job type into database
        public static bool addJobType(JobType jobType)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO JobType([Type Name], [Background Color]) values(@typeName, @background)";
                cmd.Parameters.AddWithValue("@typeName", jobType.typeName);
                cmd.Parameters.AddWithValue("@background", jobType.background);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        // Update Job Type from database
        public static bool updateJobType(JobType jobType)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE JobType SET [Type Name] = @typeName, [Background Color] = @background where [Id] = @id";
                cmd.Parameters.AddWithValue("@id", jobType.id);
                cmd.Parameters.AddWithValue("@typeName", jobType.typeName);
                cmd.Parameters.AddWithValue("@background", jobType.background);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        // Delete Job Type from database
        public static bool deleteJobType(JobType jobType)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "Delete From JobType WHERE [Id] = @id";
                cmd.Parameters.AddWithValue("@id", jobType.id);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        // Get all job types from database and convert into object
        public static List<JobType> getJobTypes()
        {
            List<JobType> jobTypes = new List<JobType>();
            try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM JobType";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobType job = new JobType
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                typeName = (string)reader.GetValue(1),
                                background = (string)reader.GetValue(2)
                            };
                            jobTypes.Add(job);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return jobTypes;
        }
        // Add new technician into database
        public static bool addTechnician(Technician technician)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Technician ([Name], [Working Hours], [Date]) values (@name, @workingHours, @date)";
                cmd.Parameters.AddWithValue("@name", technician.name);
                cmd.Parameters.AddWithValue("@workingHours", technician.workingHours);
                cmd.Parameters.AddWithValue("@date", technician.date);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static bool updateTechnician(Technician technician)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Technician SET [Name] = @name, [Working Hours] = @workingHours, [Date] = @date where [Id] = @id";
                cmd.Parameters.AddWithValue("@id", technician.id);
                cmd.Parameters.AddWithValue("@name", technician.name);
                cmd.Parameters.AddWithValue("@workingHours", technician.workingHours);
                cmd.Parameters.AddWithValue("@date", technician.date);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        public static bool deleteTechnician(Technician technician)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "Delete From Technician WHERE [Id] = @id";
                cmd.Parameters.AddWithValue("@id", technician.id);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        public static List<Technician> getTechnicians()
        {
            List<Technician> technicians = new List<Technician>();
            try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Technician";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Technician technician = new Technician
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = (string)reader.GetValue(1),
                                workingHours = (double)reader.GetValue(2),
                                date = (DateTime)reader.GetValue(3)
                            };
                            technicians.Add(technician);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return technicians;
        }

        public static void closeDatabase()
        {
            con.Close();
        }
        
        public static bool CreateDatabase(SqlConnection connection, string txtDatabase)
        {
            String CreateDatabase;
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            GrantAccess(appPath); //Need to assign the permission for current application to allow create database on server (if you are in domain).
            bool IsExits = CheckDatabaseExists(connection, txtDatabase); //Check database exists in sql server.
            if (!IsExits)
            {
                CreateDatabase = "CREATE DATABASE " + txtDatabase + " ; ";
                SqlCommand command = new SqlCommand(CreateDatabase, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Please Check Server and Database name.Server and Database name are incorrect .", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                return true;
            }
            return false;
        }

        public static int addCustomer(Customer customer)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Customer ([Honor], [Name], [Address1], [Address2], [Address3], [Post Code], [Tel], [Email]) " +
                    "values (@honor, @name, @address1, @address2, @address3, @postCode, @tel, @email);" +
                    "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@honor", customer.honor);
                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@address1", customer.address1);
                cmd.Parameters.AddWithValue("@address2", customer.address2);
                cmd.Parameters.AddWithValue("@address3", customer.address3);
                cmd.Parameters.AddWithValue("@postCode", customer.postCode);
                cmd.Parameters.AddWithValue("@tel", customer.tel);
                cmd.Parameters.AddWithValue("@email", customer.email);
                try
                {
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return -1;
                }
            }
        }
        public static void updateCustomer(Customer customer, int id)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Customer SET [Honor] = @honor, [Name] = @name, [Address1] = @address1, [Address2] = @address2, [Address3] = @address3, " +
                    "[Post Code] = @postCode, [Tel] = @tel, [Email] = @email where [Id] = @id";
                cmd.Parameters.AddWithValue("@honor", customer.honor);
                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@address1", customer.address1);
                cmd.Parameters.AddWithValue("@address2", customer.address2);
                cmd.Parameters.AddWithValue("@address3", customer.address3);
                cmd.Parameters.AddWithValue("@postCode", customer.postCode);
                cmd.Parameters.AddWithValue("@tel", customer.tel);
                cmd.Parameters.AddWithValue("@email", customer.email);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public static List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Customer";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                honor = (string)reader.GetValue(1),
                                name = (string)reader.GetValue(2),
                                address1 = (string)reader.GetValue(3),
                                address2 = (string)reader.GetValue(4),
                                address3 = (string)reader.GetValue(5),
                                postCode = (string)reader.GetValue(6),
                                tel = (string)reader.GetValue(7),
                                email = (string)reader.GetValue(8)
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return customers;
        }

        public static Customer GetCustomer(int id)
        {
            Info.customers = getCustomers();
            List<Customer> customers = Info.customers.Where(c => c.id == id).ToList();
            if (customers.Count > 0)            
                return customers[0];            
            else
                return null;
        }
        public static bool GrantAccess(string fullPath)
        {
            DirectoryInfo info = new DirectoryInfo(fullPath);
            WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
            DirectorySecurity ds = info.GetAccessControl();
            ds.AddAccessRule(new FileSystemAccessRule(self.Name,
            FileSystemRights.FullControl,
            InheritanceFlags.ObjectInherit |
            InheritanceFlags.ContainerInherit,
            PropagationFlags.None,
            AccessControlType.Allow));
            info.SetAccessControl(ds);
            return true;
        }
        public static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    tmpConn.Close();
                    result = (databaseID > 0);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static void setBookingDates(DateTime date, double hours, string note)
        {
            try
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
            }
        }

        public static double getBookingDates(DateTime date)
        {
            double hours = 0;
            try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT hours FROM BookingDates Where date = @date";
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    hours = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
            }
            return hours;
        }

        public static string getBookingNote(DateTime date)
        {
            string note = "";
            try
            {
                using (cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT note FROM BookingDates Where date = @date";
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    note = (string)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
            }
            return note;
        }
        public int count()
        {
            string stmt = "SELECT COUNT(*) FROM dbo.tablename";
            int count = 0;

            using (SqlConnection thisConnection = new SqlConnection("Data Source=DATASOURCE"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
    }
}
