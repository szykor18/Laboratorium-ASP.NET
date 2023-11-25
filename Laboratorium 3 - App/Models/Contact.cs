using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App.Models
{
    public class Contact
    {   
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz podać imię")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imię, wpisz max 50 znaków!")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }
        public int Priority { get; internal set; }
    }
}
