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
        public static SqlDataAdapter dataAdapter;
        public static SqlCommandBuilder commandBuilder;
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
  
        public static List<Booking> getBookings()
        {
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
                                loanCar = (string)reader.GetValue(11),
                                timeIn = (DateTime)reader.GetValue(12),
                                timeOut = (DateTime)reader.GetValue(13),
                                bookedBy = (string)reader.GetValue(14),
                                estimatedTime = (double)reader.GetValue(15),
                                timeRemaining = (double)reader.GetValue(16),
                                insuranceRequired = (string)reader.GetValue(17),
                                jobDescription = (string)reader.GetValue(18),
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
        /*public static void showDateGrid(string query, DataGridView dataGridView)
        {
            cmd = new SqlCommand(query, con);
            dataAdapter = new SqlDataAdapter(cmd);
            commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView.ReadOnly = true;
            dataGridView.DataSource = ds.Tables[0];            
        }

        public static void updateDataGrid(DataGridView dataGridView)
        {
            DataTable sTable = (DataTable)dataGridView.DataSource;
            dataAdapter.Update(sTable);
        }*/
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
