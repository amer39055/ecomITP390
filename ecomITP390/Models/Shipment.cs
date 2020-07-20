using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            Order = new HashSet<Order>();
        }

        public int ShipmentId { get; set; }
        public int TransporterId { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal ShippingFees { get; set; }
        public string PickUpLocation { get; set; }
        public string Deliverylocation { get; set; }

        public Transporter Transporter { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
