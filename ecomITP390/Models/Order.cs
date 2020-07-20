using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Order
    {
        public Order()
        {
            Dispute = new HashSet<Dispute>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int ShippmentId { get; set; }
        public int Quantity { get; set; }
        public int OrderStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public short CloseCode { get; set; }
        public short RatePoint { get; set; }

        public Service Service { get; set; }
        public Shipment Shippment { get; set; }
        public UserInfo User { get; set; }
        public ICollection<Dispute> Dispute { get; set; }
    }
}
