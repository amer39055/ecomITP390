using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ecomITP390.Models
{
    public partial class ReportTypes
    {
        public ReportTypes()
        {
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Report> Report { get; set; }
    }
}
