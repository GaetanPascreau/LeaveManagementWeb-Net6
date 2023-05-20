using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Data
{
    public class LeaveType : BaseEntity
    {
        [Display(Name = "Type de congés")]
        public string Name { get; set; }

        [Display(Name=" Jours par Défaut")]
        public int DefaultDays { get; set; }
    }
}
