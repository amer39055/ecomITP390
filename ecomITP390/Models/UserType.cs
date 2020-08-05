using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class UserType
    {
        public UserType()
        {
            UserInfo = new HashSet<UserInfo>();
        }
       
            
        
        public int UserTypeId { get; set; }
        public string Descreption { get; set; }

        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
