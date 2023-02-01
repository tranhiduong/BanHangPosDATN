using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BanHangDATN.Models;
namespace BanHangDATN
{
    public class Global
    {
        public static List<Order> orders { get; set; }
        public static List<Chitietorder> chitietorders { get; set; }
        public static bool CheckInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
