using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Employee = new HashSet<Employee>();
            Order = new HashSet<Order>();
            Report = new HashSet<Report>();
            Service = new HashSet<Service>();
        }
        [Display(Name ="الرقم الوطني")]
        [Required]
        public int NatId { get; set; }
        [Display(Name = "الاسم الاول")]
        [Required]
        public string Fname { get; set; }
        [Display(Name = "ايم الاب")]
        [Required]
        public string Fathername { get; set; }
        [Display(Name = "الكنية")]
        [Required]
        public string Lname { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Display(Name = "نوع المستخدم")]
        [Required]
        public int UserType { get; set; }
        [Display(Name = "الحالة")]
       
        public int Status { get; set; }
        [Display(Name = "مستوى التقييم")]
        
        public short? RatePoints { get; set; }
        [Display(Name = "رقم الجوال")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "الايميل")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "المحافظة")]
        [Required]
        public int GovId { get; set; }
        [Display(Name = "المدينة")]
        [Required]
        public string City { get; set; }
        [Display(Name = "العنوان")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "الموقع")]
        public string Homelocation { get; set; }
        [Display(Name = "الجنس")]
        [Required]
        public bool Gender { get; set; }


        public Governorate Gov { get; set; }
        public UserType UserTypeNavigation { get; set; }
        public Login Login { get; set; }
        public Transporter Transporter { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Report> Report { get; set; }
        public ICollection<Service> Service { get; set; }
    }
}
