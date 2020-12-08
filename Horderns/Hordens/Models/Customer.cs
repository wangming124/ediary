

using System.Data.Linq.Mapping;

namespace Hordens
{
    [Table(Name = "customer")]
    public class Customer
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column(Name = "honor", CanBeNull = false)]
        public string honor { get; set; }             // Honor Name
        [Column(Name = "name", CanBeNull = false)]
        public string name { get; set; }          // Customer Name
        [Column(Name = "address1", CanBeNull = false)]
        public string address1 { get; set; }           // Address1
        [Column(Name = "address2", CanBeNull = false)]
        public string address2 { get; set; }           // Address2
        [Column(Name = "address3", CanBeNull = false)]
        public string address3 { get; set; }           // Address3
        [Column(Name = "post_code", CanBeNull = false)]
        public string postCode { get; set; }          // Post Code
        [Column(Name = "email", CanBeNull = false)]
        public string email { get; set; }             // Email
        [Column(Name = "tel", CanBeNull = false)]
        public string tel { get; set; }               // Tel
    }
}
