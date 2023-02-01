using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangDATN.Models
{
    public class Mon
    {
        public string Mamon { get; set; }
        public string Tenmon { get; set; }
        public string Tenrutgon { get; set; }
        public int  Dongia { get; set; }

        public string Maloai { get; set; }
        public override string ToString()
        {
            return Tenmon;
        }
    }
}
