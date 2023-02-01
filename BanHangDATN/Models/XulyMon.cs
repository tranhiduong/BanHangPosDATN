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
    class XulyMon
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);



        public static async Task AddMon(Mon Mon)
        {
            await client.SetAsync("Mon/" + Mon.Mamon, Mon);
        }

        public static async Task DeleteMon(Mon mon)
        {
            await client.DeleteAsync("Mon/" + mon.Mamon);
        }

        public static async Task UpdateMon(Mon mon)
        {
            await client.UpdateAsync("Mon/" + mon.Mamon, mon);
        }

        public static async Task<List<Mon>> Getmons()
        {
            List<Mon> mons = new List<Mon>();
            var mont = await firebase
                .Child("Mon")
                .OnceAsync<Mon>();
            foreach (var i in mont)
            {
                mons.Add(i.Object);
            }
            return mons;
        }
    }
}
