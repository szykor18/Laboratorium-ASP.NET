using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASPLab_P.Models
{
    public enum Position
    {
        [Display(Name = "Kierownik")] Manager = 1,
        [Display(Name = "Starszy specjalista")] Senior_specialist = 2,
        [Display(Name = "Specjalista")] Specialist = 3,
        [Display(Name = "Młodszy specjalista")] Junior_specialist = 4,
        [Display(Name = "Pracownik")] Employee = 5,
        [Display(Name = "Praktykant")] Apprentice = 6
    }
}
