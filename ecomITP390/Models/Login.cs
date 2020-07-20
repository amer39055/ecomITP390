using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Login
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserInfo User { get; set; }
    }
}
