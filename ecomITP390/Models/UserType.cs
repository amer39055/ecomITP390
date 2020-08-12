using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class UserType
    {
        public UserType()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int UserTypeId { get; set; }
        [Display(Name="نوع المستخدم")]
        public string Descreption { get; set; }

        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
