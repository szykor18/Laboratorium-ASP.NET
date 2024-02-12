using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("employees")]
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(11)]
        [Required]
        public string PESEL { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public int BranchId { get; set; }

        
        public BranchEntity? Branch { get; set; }

        [Required]
        public DateTime DateOfEmployment { get; set; }

        public DateTime? DateOfDismissal { get; set; }
    }
}
