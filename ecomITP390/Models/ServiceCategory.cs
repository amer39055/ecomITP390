using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Service = new HashSet<Service>();
        }

        public int CatId { get; set; }
        [Display(Name = "رقم المنازعة")]
        public string Description { get; set; }

        public ICollection<Service> Service { get; set; }
    }
}
