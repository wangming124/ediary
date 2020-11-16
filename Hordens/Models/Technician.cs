using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Define a model of Techinician  */
namespace Hordens
{
    public class Technician
    {
        public int id { get; set; }                 // Technician ID
        public string name { get; set; }          // Name
        public double workingHours { get; set; }  // Working Hours
        public DateTime date { get; set; }        // Date
    }
}
