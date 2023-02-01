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
    class XuLyNhanVien
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddNhanvien(Nhanvien nv)
        {
            await client.SetAsync("Nhanvien/" + nv.Manv, nv);
        }

        public static async Task DeleteNhanvien(Nhanvien nv)
        {
            await client.DeleteAsync("Nhanvien/" + nv.Manv);
        }

        public static async Task UpdateNhanvien(Nhanvien nv)
        {
            await client.UpdateAsync("Nhanvien/" + nv.Manv, nv);
        }

        public static async Task<List<Nhanvien>> GetNhanviens()
        {
            List<Nhanvien> nhanviens = new List<Nhanvien>();
            var nhanvient = await firebase
                .Child("Nhanvien")
                .OnceAsync<Nhanvien>();
            foreach (var i in nhanvient)
            {
                nhanviens.Add(i.Object);
            }
            return nhanviens;
        }

    }
}
