using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Dispute
    {
        
        public int Disputid { get; set; }
        public int OrederId { get; set; }
        public int ArbiterId { get; set; }
        public string Result { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Status { get; set; }
        public DateTime TimeToFinish { get; set; }

        public Employee Arbiter { get; set; }
        public Order Oreder { get; set; }
    }
}
