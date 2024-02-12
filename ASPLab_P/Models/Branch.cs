using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASPLab_P.Models
{
    public class Branch
    {
        [HiddenInput]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Pole 'Tytuł' nie może być puste")]
        [StringLength(maximumLength: 50, ErrorMessage = "Przekroczono maksymalną długość pola (maksymalnie 50 znaków)")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole 'Miasto' nie może być puste")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole 'Ulica' nie może być puste")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole 'Numer' nie może być puste")]
        [Display(Name = "Numer")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Pole 'Kod pocztowy' nie może być puste")]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Pole 'Region' nie może być puste")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Pole 'Kraj' nie może być puste")]
        [Display(Name = "Kraj")]
        public string Country { get; set; }
    }
}
