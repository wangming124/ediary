using System.Data.Linq;

namespace Hordens
{
    class HordernsDB : DataContext
    {
        public Table<Booking> bookings;
        public Table<Customer> customers;
        public Table<BookingDate> bookingDates;
        public Table<JobType> jobTypes;
        public Table<Technician> technicians;
        public HordernsDB(string connection) : base(connection) { }
    }
}
