using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Governorate
    {
        public Governorate()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int GovId { get; set; }
        [Display(Name = "المحافظة")]
        public string GovName { get; set; }

        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
