using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Governorate
    {
        public Governorate()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int GovId { get; set; }
        public string GovName { get; set; }

        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
