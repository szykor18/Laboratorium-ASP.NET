using System;

namespace Laboratorium2.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && BirthDate < DateTime.Now;
        }

        public int Age()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Month ||
                (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
                age--;

            return age;
        }
    }
}
