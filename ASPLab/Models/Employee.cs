using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ASPLab_P.Models
{
    public class Employee
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, ErrorMessage = "First name cannot exceed 30 characters")]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(30, ErrorMessage = "Surname cannot exceed 30 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PESEL is mandatory")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must contain exactly 11 digits")]
        [Display(Name = "PESEL")]
        public string PESEL { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public Role Position { get; set; }

        [HiddenInput]
        public int BranchId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Branches { get; set; }

        [Required(ErrorMessage = "Employment date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Employment Date")]
        public DateTime DateOfEmployment { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Dismissal Date")]
        public DateTime? DateOfDismissal { get; set; }
    }
}
