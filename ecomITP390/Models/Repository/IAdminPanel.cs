﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomITP390.Models.Repository
{
    interface IAdminPanel
    {
        List<Employee> gettallemployee();
        void ChangeAuthority(int empid, int auth);
    }
}
