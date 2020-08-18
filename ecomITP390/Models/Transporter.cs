using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Transporter
    {
        public Transporter()
        {
            Shipment = new HashSet<Shipment>();
        }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "رقم الرخصة")]
        public int LicensId { get; set; }
        [Display(Name = "رقم رقم المركية")]
        public string VechileNo { get; set; }
        [Display(Name = "نوع المركبة")]
        public string VechileType { get; set; }
        [Display(Name = "تاريخ صلاحية الرخصة")]
        public DateTime? LicenseValidity { get; set; }

        public UserInfo User { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
