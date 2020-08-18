using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Service
    {
        public Service()
        {
            Order = new HashSet<Order>();
        }
        [Display(Name = "رقم الخدمة")]
        public int ServiceId { get; set; }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "صنف الخدمة")]
        public int CatId { get; set; }
        [Display(Name = "وصف الخدمة")]
        public string Desc { get; set; }
        [Display(Name = "بضاعة / خدمة")]
        public bool Physicalitems { get; set; }
        [Display(Name = "زمن التسليم ")]
        public DateTime DeliveryTime { get; set; }
        [Display(Name = "السعر")]
        public decimal Price { get; set; }

        public ServiceCategory Cat { get; set; }
        public UserInfo User { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
