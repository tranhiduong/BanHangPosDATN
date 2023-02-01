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
    class XulyCuahang
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddCuahang(Cuahang Cuahang)
        {
            await client.SetAsync("Cuahang/" + Cuahang.Mach, Cuahang);
        }

        public static async Task DeleteCuahang(Cuahang Cuahang)
        {
            await client.DeleteAsync("Cuahang/" + Cuahang.Mach);
        }

        public static async Task UpdateCuahang(Cuahang Cuahang)
        {
            await client.UpdateAsync("Cuahang/" + Cuahang.Mach, Cuahang);
        }

        public static async Task<List<Cuahang>> GetCuahangs()
        {
            List<Cuahang> Cuahangs = new List<Cuahang>();
            var Cuahangt = await firebase
                .Child("Cuahang")
                .OnceAsync<Cuahang>();
            foreach (var i in Cuahangt)
            {
                Cuahangs.Add(i.Object);
            }
            return Cuahangs;
        }
    }
}
