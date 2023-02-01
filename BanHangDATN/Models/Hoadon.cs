using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangDATN.Models
{
    class Hoadon
    {
        public string Mahd { get; set; }
        public DateTime Ngaytt { get; set; }
        public string Httt { get; set; }
        public string Giamgia { get; set; }
        public int Thanhtien { get; set; }
        public string Mach { get; set; }
        public override string ToString()
        {
            return Mahd;
        }
    }
}
