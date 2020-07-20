﻿using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class AuthorityLevel
    {
        public AuthorityLevel()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
