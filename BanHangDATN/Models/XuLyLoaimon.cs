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
    class XuLyLoaimon
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);
        public static async Task<List<Loaimon>> GetLoaimons()
        {
            List<Loaimon> loaimons = new List<Loaimon>();
            var loaimont = await firebase
                .Child("Loaimon")
                .OnceAsync<Loaimon>();
            foreach (var i in loaimont)
            {

                loaimons.Add(i.Object);
            }
            return loaimons;

        }
        public static async Task AddLoaimon(Loaimon loaimon)
        {
            await client.SetAsync("Loaimon/" + loaimon.Maloai, loaimon);
        }

        public static async Task DeleteLoaimon(Loaimon loaimon)
        {
            await client.DeleteAsync("Loaimon/" + loaimon.Maloai);

        }

        public static async Task UpdateLoaimon(Loaimon loaimon)
        {
            await client.UpdateAsync("Loaimon/" + loaimon.Maloai, loaimon);
        }
    }
}
