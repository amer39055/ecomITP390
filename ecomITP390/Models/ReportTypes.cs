using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class ReportTypes
    {
        public ReportTypes()
        {
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        [Display(Name = "نوع البلاغ")]
        public string Description { get; set; }

        public ICollection<Report> Report { get; set; }
    }
}
