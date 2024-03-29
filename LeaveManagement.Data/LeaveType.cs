﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Data
{
    public class LeaveType : BaseEntity
    {
        [Display(Name = "Type de congés")]
        public string Name { get; set; }

        [Display(Name=" Jours par Défaut")]
        public double DefaultDays { get; set; }
    }
}
