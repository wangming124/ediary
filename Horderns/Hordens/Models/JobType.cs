
/*  Define Job Types  */
using System.Data.Linq.Mapping;

namespace Hordens
{
    [Table(Name = "jobtype")]
    public class JobType
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column(Name = "type_name", CanBeNull = false)]
        public string typeName { get; set; }
        [Column(Name = "background", CanBeNull = false)]
        public string background { get; set; }
        
    }
}
