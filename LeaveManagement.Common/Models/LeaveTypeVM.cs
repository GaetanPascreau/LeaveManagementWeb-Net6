using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name="Type de congés")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "Nombre de Jours par Défaut")]
        [Required]
        [Range(1,50, ErrorMessage ="Veuillez entrer un nombre valide.")]
        public double DefaultDays { get; set; }
    }
}
