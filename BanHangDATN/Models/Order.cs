using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangDATN.Models
{
   public class Order
    {
        public string Madh { get; set; }
        public string Mach { get; set; }
        public string Manv { get; set; }
        public string Makh { get; set; }
        public bool Tinhtrang { get; set; }
        public string Coupon { get; set; }
        public string Diachigh { get; set; }
        public string Sdtgh { get; set; }

        public override string ToString()
        {
            return Madh;

        }
    }
}
