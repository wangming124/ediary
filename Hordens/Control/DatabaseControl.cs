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
        public static Boolean addBooking(Booking newBooking)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into Booking ([Job NO], [Job Type], [Customer], [Address], [Post Code], [Email], [Tel], " +
                "[Vehicle Make], [Vehicle Model], [Vehicle Reg.NO], [Loan Car], [Time In], [Time Out], [Booked By], [Estimated Time]," +
                " [Time Remaining], [Insurance Required], [Job Description], [Notes]) " +
                "values (@jobNo, @jobType, @customer, @address, @postCode, @email, @tel, @vehicleMake, @vehicleModel, @regNo, @loanCar, @timeIn, @timeOut," +
                "@bookedBy, @estimatedTime, @timeRemaining, @insuranceRequired, @jobDescription, @notes)";
                cmd.Parameters.AddWithValue("@jobNo", newBooking.jobNO);
                cmd.Parameters.AddWithValue("@jobType", newBooking.jobType);
                cmd.Parameters.AddWithValue("@customer", newBooking.customer);
                cmd.Parameters.AddWithValue("@address", newBooking.address);
                cmd.Parameters.AddWithValue("@postCode", newBooking.postCode);
                cmd.Parameters.AddWithValue("@email", newBooking.email);
                cmd.Parameters.AddWithValue("@tel", newBooking.tel);
                cmd.Parameters.AddWithValue("@vehicleMake", newBooking.vehicleMake);
                cmd.Parameters.AddWithValue("@vehicleModel", newBooking.vehicleModel);
                cmd.Parameters.AddWithValue("@regNo", newBooking.vehicleRegNo);
                cmd.Parameters.AddWithValue("@loanCar", newBooking.loanCar);
                cmd.Parameters.AddWithValue("@timeIn", newBooking.timeIn);
                cmd.Parameters.AddWithValue("@timeOut", newBooking.timeOut);
                cmd.Parameters.AddWithValue("@bookedBy", newBooking.bookedBy);
                cmd.Parameters.AddWithValue("@estimatedTime", newBooking.estimatedTime);
                cmd.Parameters.AddWithValue("@timeRemaining", newBooking.timeRemaining);
                cmd.Parameters.AddWithValue("@insuranceRequired", newBooking.insuranceRequired);
                cmd.Parameters.AddWithValue("@jobDescription", newBooking.jobDescription);
                cmd.Parameters.AddWithValue("@notes", newBooking.notes);

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
        public static Boolean updateBooking(Booking booking)
        {
            using (cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Booking SET [Job NO] = @jobNo, [Job Type] = @jobType, [Customer] = @customer, [Address]=@address, [Post Code] = @postCode," +
                    "[Email] = @email, [Tel] = @tel, [Vehicle Make] = @vehicleMake," +
                " [Vehicle Model] = @vehicleModel, [Vehicle Reg.NO] = @regNo, [Loan Car] = @loanCar, [Time In] = @timeIn, [Time Out] = @timeOut, [Booked By] = @bookedBy, " +
                "[Estimated Time] = @estimatedTime, [Insurance Required] = @insuranceRequired, [Job Description] = @description, [Notes] = @notes " +
                "WHERE [Id] = @id";
                cmd.Parameters.AddWithValue("@id", booking.id);
                cmd.Parameters.AddWithValue("@jobNo", booking.jobNO);
                cmd.Parameters.AddWithValue("@jobType", booking.jobType);
                cmd.Parameters.AddWithValue("@customer", booking.customer);
                cmd.Parameters.AddWithValue("@address", booking.address);
                cmd.Parameters.AddWithValue("@postCode", booking.postCode);
                cmd.Parameters.AddWithValue("@email", booking.email);
                cmd.Parameters.AddWithValue("@tel", booking.tel);
                cmd.Parameters.AddWithValue("@vehicleMake", booking.vehicleMake);
                cmd.Parameters.AddWithValue("@vehicleModel", booking.vehicleModel);
                cmd.Parameters.AddWithValue("@regNo", booking.vehicleRegNo);
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
        public static Boolean deleteBooking(Booking booking)
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
                                customer = (string)reader.GetValue(3),
                                address = (string)reader.GetValue(4),
                                postCode = (string)reader.GetValue(5),
                                email = (string)reader.GetValue(6),
                                tel = (string)reader.GetValue(7),
                                vehicleMake = (string)reader.GetValue(8),
                                vehicleModel = (string)reader.GetValue(9),
                                vehicleRegNo = (string)reader.GetValue(10),
                                jobDescription = (string)reader.GetValue(11),
                                loanCar = (string)reader.GetValue(12),
                                timeIn = (DateTime)reader.GetValue(13),
                                timeOut = (DateTime)reader.GetValue(14),
                                bookedBy = (string)reader.GetValue(15),
                                estimatedTime = (double)reader.GetValue(16),
                                timeRemaining = (double)reader.GetValue(17),
                                insuranceRequired = (string)reader.GetValue(18),
                                notes = (string)reader.GetValue(19)
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
        public static Boolean addJobType(JobType jobType)
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
        public static Boolean updateJobType(JobType jobType)
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
        public static Boolean deleteJobType(JobType jobType)
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
        public static Boolean addTechnician(Technician technician)
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
        public static Boolean updateTechnician(Technician technician)
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

        public static Boolean deleteTechnician(Technician technician)
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
    }
}
