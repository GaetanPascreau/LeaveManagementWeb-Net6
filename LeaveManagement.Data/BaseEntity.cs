using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [Display(Name ="Date de Création")]
        public DateTime DateCreated { get; set; }

        [Display(Name ="Date de modification")]
        public DateTime DateModified { get; set; }
    }
}
