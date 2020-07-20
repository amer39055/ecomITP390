using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Dispute = new HashSet<Dispute>();
            InverseSupervisedByNavigation = new HashSet<Employee>();
            Report = new HashSet<Report>();
        }

        public int EmpId { get; set; }
        public int UserId { get; set; }
        public int SocialInsuranceId { get; set; }
        public string Qualfication { get; set; }
        public string Institute { get; set; }
        public int AuthorityLevel { get; set; }
        public int SupervisedBy { get; set; }

        public AuthorityLevel AuthorityLevelNavigation { get; set; }
        public Employee SupervisedByNavigation { get; set; }
        public UserInfo User { get; set; }
        public ICollection<Dispute> Dispute { get; set; }
        public ICollection<Employee> InverseSupervisedByNavigation { get; set; }
        public ICollection<Report> Report { get; set; }
    }
}
