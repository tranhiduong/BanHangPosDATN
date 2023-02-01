using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangDATN.Models
{
    class Coupon
    {
        public int Giamtoida { get; set; }
        public string Macp { get; set; }
        public string Makh { get; set; }
        public string Mucgiam { get; set; }
        public DateTime? Ngaybatdau { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public int Soluong { get; set; }
    }
}
