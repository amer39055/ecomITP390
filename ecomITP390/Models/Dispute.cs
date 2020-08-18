using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecomITP390.Models
{
    public partial class Dispute
    {
        [Display(Name ="رقم المنازعة")]
        public int Disputid { get; set; }
        [Display(Name = "رقم الطلبية")]
        public int OrederId { get; set; }
        [Display(Name = "الموظف"] 
        public int ArbiterId { get; set; }
        [Display(Name = "النتيجة")]
        public string Result { get; set; }
        [Display(Name = "تايخ البدء")]      
        public DateTime StartDate { get; set; }
        [Display(Name = "تاريخ الاغلاق")]
        public DateTime FinishDate { get; set; }
        [Display(Name = "الحالة")]
        public string Status { get; set; }

        [Display(Name = "المهلة")]
        public DateTime TimeToFinish { get; set; }

        public Employee Arbiter { get; set; }
        public Order Oreder { get; set; }
    }
}
