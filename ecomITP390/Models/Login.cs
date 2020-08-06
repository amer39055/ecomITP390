using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Login
    {


        public int UserId { get; set; }
    
        [Display (Name ="اسم المستخدم")]
        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public UserInfo User { get; set; }
    }
}
