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
    class XuLyChiTietOrder
    {

        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddChitietorder(Chitietorder ct)
        {
            await client.SetAsync("Chitietorder/" + ct.Madh+"-"+ct.Mamon, ct);
        }

        public static async Task DeleteChitietorder(Chitietorder ct)
        {
            await client.DeleteAsync("Chitietorder/" + ct.Madh + "-" + ct.Mamon);
        }

        public static async Task UpdateChitietorder(Chitietorder ct)
        {
            await client.UpdateAsync("Chitietorder/" + ct.Madh + "-" + ct.Mamon, ct);
        }

        public static async Task<List<Chitietorder>> GetChitietorders()
        {
            List<Chitietorder> chitietorders = new List<Chitietorder>();
            var chitietorderts = await firebase
                .Child("Chitietorder")
                .OnceAsync<Chitietorder>();
            foreach (var i in chitietorderts)
            {
                chitietorders.Add(i.Object);
            }
            return chitietorders;
        }
    }
}

