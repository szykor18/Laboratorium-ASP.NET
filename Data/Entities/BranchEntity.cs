using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("branches")]
    public class BranchEntity
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string Title { get; set; }

        public Address? Address { get; set; }

        public ISet<EmployeeEntity> Employees { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
