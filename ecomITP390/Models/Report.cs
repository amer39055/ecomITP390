using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Report
    {
        [Display(Name = "رقم البلاغ")]
        public int ReportId { get; set; }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "نوع البلاغ")]
        public int Type { get; set; }
        [Display(Name = "رقم الموظف")]
        public int EmpId { get; set; }
        [Display(Name = "مرفقات")]
        public byte[] Files { get; set; }

        public Employee Emp { get; set; }
        public ReportTypes TypeNavigation { get; set; }
        public UserInfo User { get; set; }
    }
}
