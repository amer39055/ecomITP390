using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Service
    {
        public Service()
        {
            Order = new HashSet<Order>();
        }

        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public int CatId { get; set; }
        public string Desc { get; set; }
        public bool Physicalitems { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Price { get; set; }

        public ServiceCategory Cat { get; set; }
        public UserInfo User { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
