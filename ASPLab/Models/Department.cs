using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASPLab_P.Models
{
    public class Department
    {
        [HiddenInput(DisplayValue = false)]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is mandatory")]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Building number is required")]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}
