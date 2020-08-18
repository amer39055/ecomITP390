using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Order
    {
        public Order()
        {
            Dispute = new HashSet<Dispute>();
        }
        [Display(Name = "رقم الطلبية")]
        public int OrderId { get; set; }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [Display(Name = "رقم الخدمة")]
        public int ServiceId { get; set; }
        [Display(Name = "رقم الشحنة")]
        public int ShippmentId { get; set; }
        [Display(Name = "الكمية")]
        public int Quantity { get; set; }
        [Display(Name = "وضع الطلبية")]
        public int OrderStatus { get; set; }
        [Display(Name = "تاريخ البدء")]
        public DateTime StartDate { get; set; }
        [Display(Name = "رقم الانتهاء")]
        public DateTime FinishDate { get; set; }
        [Display(Name = "كود الاغلاق")]
        public short CloseCode { get; set; }
        [Display(Name = "تقييم العملية")]
        public short RatePoint { get; set; }

        public Service Service { get; set; }
        public Shipment Shippment { get; set; }
        public UserInfo User { get; set; }
        public ICollection<Dispute> Dispute { get; set; }
    }
}
