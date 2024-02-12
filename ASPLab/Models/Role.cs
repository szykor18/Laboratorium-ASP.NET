using System.ComponentModel.DataAnnotations;

namespace ASPLab_P.Models
{
    public enum Role
    {
        [Display(Name = "Team Leader")]
        TeamLeader = 10,
        [Display(Name = "Lead Expert")]
        LeadExpert = 20,
        [Display(Name = "Core Member")]
        CoreMember = 30,
        [Display(Name = "Associate Member")]
        AssociateMember = 40,
        [Display(Name = "Support Staff")]
        SupportStaff = 50,
        [Display(Name = "Intern")]
        Intern = 60
    }
}
