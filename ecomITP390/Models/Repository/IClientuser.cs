using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomITP390.Models.Repository
{
   public interface IClientUser
    {
        int RateUser(int id);
        void ReportToadmin(int reprottype);
        void OpenDispute();
       
 
    }
}
