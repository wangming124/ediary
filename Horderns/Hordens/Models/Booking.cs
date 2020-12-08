using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

/*  Define a model of Booking  */
namespace Hordens
{
    [Table(Name = "booking")]
    public class Booking
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }                   // Booking ID
        [Column(Name = "job_no", CanBeNull = false)]
        public string jobNO { get; set; }             // Job NO
        [Column(Name = "job_type", CanBeNull = false)]
        public string jobType {get; set; }            // Job Type
        [Column(Name = "customer_id", CanBeNull = false)]
        public int customerID { get; set; }           // Customer Name
        [Column(Name = "service_plan", CanBeNull = false)]
        public string servicePlan { get; set; }       // Service Plan
        [Column(Name = "vehicle_make", CanBeNull = false)]
        public string vehicleMake { get; set; }       // Vehicle Make
        [Column(Name = "vehicle_model", CanBeNull = false)]
        public string vehicleModel { get; set; }      // Vehicle Model
        [Column(Name = "reg_no", CanBeNull = false)]
        public string regNo { get; set; }      // Vehicle Reg.NO
        [Column(Name = "mileage", CanBeNull = false)]
        public double mileage { get; set; }           // Mileage
        [Column(Name = "loan_car", CanBeNull = false)]
        public string loanCar { get; set; }           // Loan Car(Yes, No)
        [Column(Name = "time_in", CanBeNull = false)]
        public DateTime timeIn { get; set; }            // Time In
        [Column(Name = "time_out", CanBeNull = false)]
        public DateTime timeOut { get; set; }           // Time Out
        [Column(Name = "booked_by", CanBeNull = false)]
        public string bookedBy { get; set; }          // Booked By
        [Column(Name = "estimated_time", CanBeNull = false)]
        public double estimatedTime { get; set; }     // Estimated Time
        [Column(Name = "time_remaining", CanBeNull = false)]
        public double timeRemaining { get; set; }     // Time Remaining
        [Column(Name = "insurance_requrired", CanBeNull = false)]
        public string insuranceRequired { get; set; } // Insurance Required (Yes, No)
        [Column(Name = "job_description", CanBeNull = false)]
        public string jobDescription { get; set; }    // Job Details
        [Column(Name = "notes", CanBeNull = false)]
        public string notes { get; set; }             // Notes
        [Column(Name = "booking_date", CanBeNull = false)]
        public DateTime bookingDate { get; set; }     // Booking date

    }
}
