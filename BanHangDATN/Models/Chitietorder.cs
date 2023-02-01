using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangDATN.Models
{
    public class Chitietorder
    {
        public string Madh { get; set; }
        public string Mamon { get; set; }
        public int Soluong { get; set; }
        public override string ToString()
        {
            return Madh;
        }
    }
}
