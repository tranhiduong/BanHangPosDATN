using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp.Config;
using FireSharp;
namespace BanHangDATN.Models
{
    class XulyKhachhang
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddKhachhang(Khachhang kh)
        {
            await client.SetAsync("Khachhang/" + kh.Makh, kh);
        }

        public static async Task DeleteKhachhang(Khachhang kh)
        {
            await client.DeleteAsync("Khachhang/" + kh.Makh);
        }

        public static async Task UpdateKhachhang(Khachhang kh)
        {
            await client.UpdateAsync("Khachhang/" + kh.Makh, kh);
        }

        public static async Task<List<Khachhang>> GetKhachhangs()
        {
            List<Khachhang> khachhangs = new List<Khachhang>();
            var khachhangt = await firebase
                .Child("Khachhang")
                .OnceAsync<Khachhang>();
            foreach (var i in khachhangt)
            {
                khachhangs.Add(i.Object);
            }
            return khachhangs;
        }
    }
}
