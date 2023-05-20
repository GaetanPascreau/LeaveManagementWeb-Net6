using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
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
        public int DefaultDays { get; set; }
    }
}
