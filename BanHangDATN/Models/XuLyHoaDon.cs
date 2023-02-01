using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp.Config;
using FireSharp;
using System.Text.RegularExpressions;


namespace BanHangDATN.Models
{
    class XuLyHoaDon
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddHoadon(Hoadon hd)
        {
            await client.SetAsync("Hoadon/" + hd.Mahd, hd);
        }

        public static async Task DeleteHoadon(Hoadon hd)
        {
            await client.DeleteAsync("Hoadon/" + hd.Mahd);
        }

        public static async Task UpdateHoadon(Hoadon hd)
        {
            await client.UpdateAsync("Hoadon/" + hd.Mahd, hd);
        }

        public static async Task<List<Hoadon>> GetHoadons()
        {
            List<Hoadon> hoadons = new List<Hoadon>();
            var hoadont = await firebase
                .Child("Hoadon")
                .OnceAsync<Hoadon>();
            foreach (var i in hoadont)
            {
                hoadons.Add(i.Object);
            }
            return hoadons;
        }
    }
}
