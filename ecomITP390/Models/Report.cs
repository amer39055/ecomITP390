using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ecomITP390.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int EmpId { get; set; }
        public byte[] Files { get; set; }

        public Employee Emp { get; set; }
        public ReportTypes TypeNavigation { get; set; }
        public UserInfo User { get; set; }
    }
}
