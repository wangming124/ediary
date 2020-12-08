using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hordens
{
    [Table(Name = "bookingdate")]
    public class BookingDate
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column(Name = "date", CanBeNull = false)]
        public DateTime date { get; set; }
        [Column(Name = "hours", CanBeNull = false)]
        public double hours { get; set; }
        [Column(Name = "note", CanBeNull = false)]
        public string note { get; set; }
    }
}
