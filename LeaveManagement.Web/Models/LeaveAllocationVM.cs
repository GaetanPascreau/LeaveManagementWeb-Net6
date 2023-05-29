using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nombre de jours")]
        [Required]
        [Range(1,50, ErrorMessage = "Veuillez entrer un nombre valide.")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Période d'allocation")]
        [Required]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }
    }
}