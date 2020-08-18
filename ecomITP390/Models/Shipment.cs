using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            Order = new HashSet<Order>();
        }
        [Display(Name = "رقم الشحنة")]
        public int ShipmentId { get; set; }
        [Display(Name = "رقم الناقل")]
        public int TransporterId { get; set; }
        [Display(Name = "تاريخ الشحن")]
        public DateTime ShippingDate { get; set; }
        [Display(Name = "رسوم النقل")]
        public decimal ShippingFees { get; set; }
        [Display(Name ="عنوان الاستلام")]
        public string PickUpLocation { get; set; }
        [Display(Name="عنوان التسليم")]
        public string Deliverylocation { get; set; }

        public Transporter Transporter { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
