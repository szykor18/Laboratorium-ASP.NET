using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASPLab_P.Models
{
    public class Employee
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Imię' nie może być puste")]
        [StringLength(maximumLength: 30, ErrorMessage = "Przekroczono max ilość znaków (max 30 znaków)")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwisko' nie może być puste")]
        [StringLength(maximumLength: 30, ErrorMessage = "Przekroczono max ilość znaków (max 30 znaków)")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole 'PESEL' nie może być puste")]
        [RegularExpression("^[0-9]{11,11}$", ErrorMessage = "Niepoprawny PESEL (wymagane 11 cyfr)")]
        [StringLength(11, ErrorMessage = "Niepoprawny PESEL (wymagane 11 cyfr)")]
        [Display(Name = "PESEL")]
        public string PESEL { get; set; }

        [Required(ErrorMessage = "Pole 'E-mail' nie może być puste")]
        [EmailAddress(ErrorMessage = "Podano nieprawidłowy adres E-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole 'Telefon' nie może być puste")]
        [Phone(ErrorMessage = "Podano nieprawidłowy numer telefonu")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Pole 'Stanowisko' nie może być puste")]
        [Display(Name = "Stanowisko")]
        public Position Position { get; set; }

        [HiddenInput]
        [Display(Name = "Oddział")]
        public int BranchId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Branches { get; set; }

        [Required(ErrorMessage = "Pole 'Data zatrudnienia' nie może być puste")]
        [DataType(DataType.Date, ErrorMessage = "Podano nieprawidłową Datę zatrudnienia")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Data zatrudnienia")]
        public DateTime DateOfEmployment { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Podano nieprawidłową Datę zwolnienia")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Data zwolnienia")]
        public DateTime? DateOfDismissal { get; set; }
    }
}
