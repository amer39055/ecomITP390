using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ecomITP390.Models
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Service = new HashSet<Service>();
        }

        public int CatId { get; set; }
        public string Description { get; set; }

        public ICollection<Service> Service { get; set; }
    }
}
