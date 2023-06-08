using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Nombre total de demandes")]
        public int TotalRequests { get; set; }

        [Display(Name = "Demandes approuvées")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Demandes en attente")]
        public int PendingRequests { get; set; }

        [Display(Name = "Demandes rejetées")]
        public int RejectedRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
