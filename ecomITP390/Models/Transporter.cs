using System;
using System.Collections.Generic;

namespace ecomITP390.Models
{
    public partial class Transporter
    {
        public Transporter()
        {
            Shipment = new HashSet<Shipment>();
        }

        public int UserId { get; set; }
        public int LicensId { get; set; }
        public string VechileNo { get; set; }
        public string VechileType { get; set; }
        public DateTime? LicenseValidity { get; set; }

        public UserInfo User { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
