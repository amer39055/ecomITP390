using System;
using System.Collections.Generic;

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

        public int NatId { get; set; }
        public string Fname { get; set; }
        public string Fathername { get; set; }
        public string Lname { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserType { get; set; }
        public int Status { get; set; }
        public short? RatePoints { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int GovId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Homelocation { get; set; }
        public bool Gender { get; set; }

        public Governorate Gov { get; set; }
        public UserType UserTypeNavigation { get; set; }
        public Login Login { get; set; }
        public Transporter Transporter { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Report> Report { get; set; }
        public ICollection<Service> Service { get; set; }
         
        public string getGender()
        {
            return (Gender == true) ? "male" : "Female";

        }
    }
}
