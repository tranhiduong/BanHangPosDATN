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
    class XulyCoupon
    {
        public static string basePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public static Firebase.Database.FirebaseClient firebase = new Firebase.Database.FirebaseClient("https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);

        public static async Task AddCoupon(Coupon cp)
        {
            await client.SetAsync("Coupon/" + cp.Macp, cp);
        }

        public static async Task DeleteCoupon(Coupon cp)
        {
            await client.DeleteAsync("Coupon/" + cp.Macp);
        }

        public static async Task UpdateCoupon(Coupon cp)
        {
            await client.UpdateAsync("Coupon/" + cp.Macp, cp);
        }

        public static async Task<List<Coupon>> GetCoupons()
        {
            List<Coupon> coupons = new List<Coupon>();
            var coupont = await firebase
                .Child("Coupon")
                .OnceAsync<Coupon>();
            foreach (var i in coupont)
            {
                coupons.Add(i.Object);
            }
            return coupons;
        }
    }
}
