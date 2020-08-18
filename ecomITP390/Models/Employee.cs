using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "رقم الموظف")]
        public int EmpId { get; set; }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "رقم الضمان الاجتماعي")]
        public int SocialInsuranceId { get; set; }
        [Display(Name = "المؤهل العلمي")]
        public string Qualfication { get; set; }
        [Display(Name = "الجامعة/المعهد")]
        public string Institute { get; set; }
        [Display(Name = "مستوى الصلاحية")]
        public int AuthorityLevel { get; set; }
        [Display(Name = "المدير المشرف")]
        public int SupervisedBy { get; set; }

        public AuthorityLevel AuthorityLevelNavigation { get; set; }
        public Employee SupervisedByNavigation { get; set; }
        public UserInfo User { get; set; }
        public ICollection<Dispute> Dispute { get; set; }
        public ICollection<Employee> InverseSupervisedByNavigation { get; set; }
        public ICollection<Report> Report { get; set; }
    }
}
