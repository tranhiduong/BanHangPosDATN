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
    class XuLyOrder
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddOrder(Order dh)
        {
            await client.SetAsync("Order/" + dh.Madh, dh);
        }

        public static async Task DeleteOrder(Order dh)
        {
            await client.DeleteAsync("Order/" + dh.Madh);
        }

        public static async Task UpdateOrder(Order dh)
        {
            await client.UpdateAsync("Order/" + dh.Madh, dh);
        }

        public static async Task<List<Order>> GetOrders()
        {
            List<Order> dhachhangs = new List<Order>();
            var dhachhangt = await firebase
                .Child("Order")
                .OnceAsync<Order>();
            foreach (var i in dhachhangt)
            {
                dhachhangs.Add(i.Object);
            }
            return dhachhangs;
        }
    }
}

