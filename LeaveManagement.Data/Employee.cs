using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Data
{
    public class Employee : IdentityUser
    {
        [Display(Name ="Prénom")]
        public string? FirstName { get; set; }

        [Display(Name = "Nom")]
        public string? LastName { get; set; }

        [Display(Name = "Nom complet")]
        public string FullName
        {
            get { return $"{ FirstName} { LastName }"; }
        }

        [Display(Name ="Numéro de Sécurité sociale")]
        public string? SSN { get; set; }

        [Display(Name ="Date de naissance")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Date d'embauche")]
        public DateTime DateJoined { get; set; }

        [Display(Name ="Superviseur")]
        public string SupervisorId { get; set; }

        [Display(Name ="Employeur")]
        public string Employer { get; set; }
    }
}
