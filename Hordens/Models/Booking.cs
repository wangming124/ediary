using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Define a model of Booking  */
namespace Hordens
{
    public class Booking
    {
        public int id { get; set; }                     // Booking ID
        public string jobNO { get; set; }             // Job NO
        public string jobType {get; set; }            // Job Type
        public string customer { get; set; }          // Customer Name
        public string address { get; set; }           // Address
        public string postCode { get; set; }          // Post Code
        public string email { get; set; }             // Email
        public string tel { get; set; }               // Tel
        public string vehicleMake { get; set; }       // Vehicle Make
        public string vehicleModel { get; set; }      // Vehicle Model
        public string vehicleRegNo { get; set; }      // Vehicle Reg.NO
        public string loanCar { get; set; }           // Loan Car(Yes, No)
        public DateTime timeIn { get; set; }          // Time In
        public DateTime timeOut { get; set; }         // Time Out
        public string bookedBy { get; set; }          // Booked By
        public double estimatedTime { get; set; }     // Estimated Time
        public double timeRemaining { get; set; }     // Time Remaining
        public string insuranceRequired { get; set; } // Insurance Required (Yes, No)
        public string jobDescription { get; set; }        // Job Details
        public string notes { get; set; }             // Notes

    }
}
