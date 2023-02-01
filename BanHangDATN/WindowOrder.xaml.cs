using BanHangDATN.Models;
using FireSharp.Config;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        string ban;
        Nhanvien nv;
        string luachon;
        string hashcodechange;
        public static FirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://banhangpos-42b12-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static FireSharp.FirebaseClient client = new FireSharp.FirebaseClient(config);
        public WindowOrder()
        {
            InitializeComponent();
        }
        public WindowOrder(Nhanvien nv)
        {
            InitializeComponent();
            this.nv = nv;
            LiveCall();
        }
        async void LiveCall()
        {
            while (true)
            {
                await Task.Delay(5000);
                if (Global.CheckInternet() == false)
                {
                    MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                    return;
                }
                FirebaseResponse res = await client.GetAsync(@"Order");
                if (hashcodechange == null)
                {
                    hashcodechange = res.Body.GetHashCode().ToString();
                    HienthiDongiaohang();
                }
                else
                {
                    if(hashcodechange!= res.Body.GetHashCode().ToString())
                    {
                        hashcodechange = res.Body.GetHashCode().ToString();
                        HienthiDongiaohang();
                    }
                }     
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn1.Content.ToString();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn2.Content.ToString();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn3.Content.ToString();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn4.Content.ToString();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn5.Content.ToString();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn6.Content.ToString();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn7.Content.ToString();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn8.Content.ToString();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn9.Content.ToString();
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn10.Content.ToString();
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn11.Content.ToString();
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn12.Content.ToString();
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn13.Content.ToString();
        }

        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn14.Content.ToString();
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            spnLuaChon.Visibility = Visibility.Visible;
            ban = btn15.Content.ToString();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            //MenuChon mnc = new MenuChon(ban, btnDelivery.Content.ToString(), nhanvien);
            //mnc.ShowDialog();
            //this.Show();

            //luachon = btnDelivery.Content.ToString();
            //SoBan.Visibility = Visibility.Visible;
            //spnLuaChon.Visibility = Visibility.Hidden;
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            spnLuaChon.Visibility = Visibility.Hidden;
            MenuChon menu = new MenuChon(btnDelivery.Content.ToString(), nv);
            menu.ShowDialog();
            //SoBan.Visibility = Visibility.Hidden;
            spnLuaChon.Visibility = Visibility.Visible;
            //this.Show();

        }

        private void btnStay_Click(object sender, RoutedEventArgs e)
        {
            //MenuChon mnc = new MenuChon(ban, btnStay.Content.ToString(), nhanvien);
            //mnc.ShowDialog();
            //this.Show();
            luachon = btnStay.Content.ToString();
            SoBan.Visibility = Visibility.Visible;

            spnLuaChon.Visibility = Visibility.Hidden;

        }

        private void btnTakeAway_Click(object sender, RoutedEventArgs e)
        {
            //MenuChon mnc = new MenuChon(ban, btnTakeAway.Content.ToString(), nhanvien);
            //mnc.ShowDialog();
            //this.Show();
            luachon = btnTakeAway.Content.ToString();
            SoBan.Visibility = Visibility.Visible;
            spnLuaChon.Visibility = Visibility.Hidden;
        }

        private void btnXemHoaDon_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            //XemHoaDon xemhoadon = new XemHoaDon();
            //xemhoadon.ShowDialog();
            //this.Show();
            XemDonGiaoHang.Visibility = Visibility.Visible;
            HienthiDongiaohang();
        }

        private void btnDieuKhien_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0;
            BangDieuKhien bkd = new BangDieuKhien();
            bkd.ShowDialog();
            this.Opacity = 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNgay.Text = DateTime.Today.ToShortDateString() + "\n" + DateTime.Today.ToShortTimeString();
            txtNV.Text = nv.Tennv;
            //dtpNgay.SelectedDate = DateTime.Today;
            Global.orders = new List<Order>();
            Global.chitietorders = new List<Chitietorder>();
            hienThi();
            HienthiDongiaohang();

        }
        public void hienThi()
        {
            icDonHang.ItemsSource = (Global.orders).OrderByDescending(e => e.Madh);

        }
        public void HienthiDongiaohang()
        {
            var orders = Task.Run(() => XuLyOrder.GetOrders()).Result;
            var ordershienthi= orders.Where(x => (x.Tinhtrang == true) && (x.Mach == nv.Mach));
            icDonGiaoHang.ItemsSource = ordershienthi;
            btnXemHoaDon.Content = "Giao hàng (" + ordershienthi.Count().ToString()+")";
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //spnLuaChon.Visibility = Visibility.Hidden;
            XemDonHang.Visibility = Visibility.Hidden;
            XemDonGiaoHang.Visibility = Visibility.Hidden;
            //SoBan.Visibility = Visibility.Hidden;
        }

        private void btnDonCho_Click(object sender, RoutedEventArgs e)
        {
            XemDonGiaoHang.Visibility = Visibility.Hidden;
            XemDonHang.Visibility = Visibility.Visible;
            hienThi();
        }

        private void btnDonHangCon_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            Button btn = sender as Button;
            MenuChon menu = new MenuChon("1", "Take away", nv, btn.DataContext.ToString());
            menu.ShowDialog();
            hienThi();
            //this.Show();

        }



        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            Button btn = sender as Button;
            MenuChon mnc = new MenuChon(btn.Content.ToString(), luachon, nv);
            mnc.ShowDialog();
            //this.Show();
            SoBan.Visibility = Visibility.Hidden;
            spnLuaChon.Visibility = Visibility.Visible;


        }

        private void btnDonGiaoHang_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            Button btn = sender as Button;
            MenuChon menu = new MenuChon(btnDelivery.Content.ToString(), nv, btn.DataContext.ToString());
            menu.ShowDialog();
            var orders = Task.Run(() => XuLyOrder.GetOrders()).Result;
            icDonGiaoHang.ItemsSource = orders.Where(x => (x.Tinhtrang == true) && (x.Mach == nv.Mach));
        }
    }
}
