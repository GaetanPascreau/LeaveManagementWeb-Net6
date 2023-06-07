using LeaveManagement.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }

        [Display(Name = "Type de congés")]
        public LeaveTypeVM LeaveType { get; set; }

        [Display(Name = "Date de la demande")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Etat")]
        public bool? Approved { get; set; } // lorsque cette propriété est nulle, la décision est en attente

        [Display(Name = "Annulé")]
        public bool Cancelled { get; set; }

        public string? RequestingEmployeeId { get; set; }
        public EmployeeListVM Employee { get; set; }
    }
}
