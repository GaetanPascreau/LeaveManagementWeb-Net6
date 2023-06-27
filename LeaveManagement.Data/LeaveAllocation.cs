using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Data
{
    public class LeaveAllocation : BaseEntity
    {
        [Display(Name ="Nombre de jours")]
        public double NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")]
        [Display(Name ="Type de congés")]
        public LeaveType LeaveType { get; set; }

        [Display(Name ="Id du type de congés")]
        public int LeaveTypeId { get; set; }

        [Display(Name ="Id de l'employé")]
        public string EmployeeId { get; set; }
        public int Period { get; set; } // (= une année), peut être remplacé par 2 champs : StartPeriod, EndPeriod
    }
}
