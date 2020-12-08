using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Define a model of Techinician  */
namespace Hordens
{
    [Table(Name = "technician")]
    public class Technician
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }                 // Technician ID
        [Column(Name = "name", CanBeNull = false)]
        public string name { get; set; }          // Name
        [Column(Name = "working_hours", CanBeNull = false)]
        public double workingHours { get; set; }  // Working Hours
        [Column(Name = "date", CanBeNull = false)]
        public DateTime date { get; set; }        // Date
    }
}
