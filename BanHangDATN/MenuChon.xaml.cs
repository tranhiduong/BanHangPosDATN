using BanHangDATN.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for MenuChon.xaml
    /// </summary>
    public partial class MenuChon : Window
    {
        List<Mon> dsMon;
        List<Mon> dsMonTam;
        List<Chitietorder> dsChiTietOrder;
        Order order;
        string banChon, chon;
        Nhanvien nv;
        int soluong;
        int tongtt;
        bool flag = false;
        List<Mon> mons;
        List<Loaimon> loaimons;
        bool flagdathang = false;
        public MenuChon()
        {
            InitializeComponent();
            
        }
        public MenuChon(string luachon, Nhanvien nv)
        {
            InitializeComponent();
            chon = luachon;
            this.nv = nv;
            txtLuaChon.Text = luachon;
            flag = false;

        }
        public MenuChon(string ban, string luachon, Nhanvien nv)
        {
            InitializeComponent();
            banChon = ban;
            chon = luachon;
            this.nv = nv;
            txtBan.Text = ban;
            txtLuaChon.Text = luachon;
            flag = false;
        }
        public MenuChon(string ban, string luachon,Nhanvien nv, string madh)
        {
            InitializeComponent();
            banChon = ban;
            chon = luachon;
            this.nv = nv;
            txtBan.Text = ban;
            txtLuaChon.Text = luachon;
            //chitiet = XuLyChiTietOrder.chitietorders.Find(x => x.Madh == madh);
            order = Global.orders.Find(x => x.Madh == madh);
            flag = true;
        }
        public MenuChon(string luachon, Nhanvien nv, string madh)
        {
            InitializeComponent();
            chon = luachon;
            this.nv = nv;
            txtLuaChon.Text = luachon;
            //chitiet = XuLyChiTietOrder.chitietorders.Find(x => x.Madh == madh);
            var orders = Task.Run(() => XuLyOrder.GetOrders()).Result;
            order = orders.Find(x => x.Madh == madh);
           
            flagdathang = true;
        }
        public void hienThi()
        {
            
            icLoaimon.ItemsSource = loaimons.ToList().Where(x => x.Maloai != "TP");
            icMon.ItemsSource = mons.ToList().Where(x => x.Maloai != "TP");
            icExtra.ItemsSource = mons.ToList().Where(x => x.Maloai == "TP");
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaimons = Task.Run(() => XuLyLoaimon.GetLoaimons()).Result;
            mons = Task.Run(() => XulyMon.Getmons()).Result;
            hienThi();
            txtNV.Text = nv.Tennv;
            if (flagdathang == true)
            {
                dsChiTietOrder = new List<Chitietorder>();
                var chitietorders = Task.Run(() => XuLyChiTietOrder.GetChitietorders()).Result;
                foreach (var i in chitietorders)
                {
                    if (i.Madh == order.Madh)
                    {
                        dsChiTietOrder.Add(i);
                        soluong += i.Soluong;
                        tongtt += mons.Find(x => x.Mamon == i.Mamon).Dongia *i.Soluong;
                    }
                }
                foreach(var i in dsChiTietOrder)
                {
                    _ = XuLyChiTietOrder.DeleteChitietorder(i);
                }
                hienThiTT();
                return;
            }
            if (flag == false)
            {
                dsMon = new List<Mon>();
                dsChiTietOrder = new List<Chitietorder>();
                hienThiTT();
            }
            else
            {
                dsChiTietOrder = new List<Chitietorder>();
                //dsChiTietOrder.Add(chitiet);
                dsMon = new List<Mon>();
                foreach (var a in Global.chitietorders)
                {
                    if(a.Madh==order.Madh)
                    {
                        dsChiTietOrder.Add(a);
                        soluong += a.Soluong;
                        tongtt += mons.Find(x=>x.Mamon==a.Mamon).Dongia*a.Soluong;
                    }
                    //XuLyChiTietOrder.DeleteChiTietOrder(a);
                }
                Global.chitietorders.RemoveAll(x => x.Madh == order.Madh);
                hienThiTT();
            }

            //Loaimon lm = new Loaimon
            //{
            //    Maloai = "0",
            //    Tenloai = "Thường dùng"
            //};
            //foreach(var a in XuLyChiTietOrder.chitietorders.ToList() )
            //{
            //    int count = a.Mamon.Count();

            //hienThiTT();
            //}
        }
        public void hienThiTT()
        {
            lvMonTT.ItemsSource = null;
            lvMonTT.ItemsSource = dsChiTietOrder.Select(x => new
            {
                tenmon = (mons.Find(a => a.Mamon == x.Mamon)).Tenrutgon,
                soluong = x.Soluong,
                gia = (mons.Find(a => a.Mamon == x.Mamon)).Dongia * x.Soluong
            });
            txtTongSL.Text = soluong.ToString();
            txtTongTT.Text = tongtt.ToString();
        }
        private void btnLoaiMon_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            dsMonTam = mons.Where(a => a.Maloai == loaimons.Find(x => x.Tenloai == btn.Content.ToString()).Maloai).ToList();
            icMon.ItemsSource = dsMonTam;
        }

        private void btnMon_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Mon mon = mons.Find(a => a.Tenmon == btn.DataContext.ToString());
            soluong += 1;
            tongtt += (int)mon.Dongia;
            if (dsChiTietOrder.Find(a => a.Mamon == mon.Mamon) != null)
            {
                (dsChiTietOrder.Find(a => a.Mamon == mon.Mamon)).Soluong += 1;
            }
            else
            {
                Chitietorder cto = new Chitietorder
                {
                    Mamon = mon.Mamon,
                    Soluong = 1,
                };
                dsChiTietOrder.Add(cto);

            }
            hienThiTT();
        }

        private void btnThanhTien_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            string madh;
            if (flagdathang == true)
            {
                foreach (var i in dsChiTietOrder)
                {
                    i.Madh = this.order.Madh;
                    _ = XuLyChiTietOrder.AddChitietorder(i);
                }
                ThanhToan ttt= new ThanhToan(dsChiTietOrder, banChon, nv, soluong.ToString(), tongtt.ToString(), this.order);
                ttt.ShowDialog();
                if (ttt.ketqua == true)
                {
                    this.Close();
                }
                else if (ttt.ketqua == false)
                {
                    this.Show();
                    foreach (var i in dsChiTietOrder)
                    {
                        _ = XuLyChiTietOrder.DeleteChitietorder(i);
                    }
                }
                return;
            }
            if (this.order != null)
            {
                madh = this.order.Madh;
            }
            else
            {
                if (Global.orders.Count == 0)
                {
                    madh = "DHT" + "0001";
                }
                else
                {
                    int madht = int.Parse(Regex.Match(Global.orders.Last().Madh, @"\d+\.*\d*").Value) + 1;

                    madh = "DHT" + madht.ToString("0000");
                }
            }
            Order order;
            order = new Order();              
            order.Madh = madh;
            order.Manv = nv.Manv;
            order.Mach = nv.Mach;
            order.Tinhtrang = false;
            order.Makh = "";
            order.Diachigh = "";
            order.Sdtgh = "";
            order.Coupon = "";
            //if (this.order != null)
            //{
            //    order.Diachigh = this.order.Diachigh;
            //    order.Sdtgh=this.order.Sdtgh;
            //    order.Coupon=this.order.Coupon;
            //    order.Makh = this.order.Makh;
            //}
            //Global.orders.Add(order);
            foreach (var i in dsChiTietOrder)
            {
                i.Madh = order.Madh;
                Global.chitietorders.Add(i);
            }
            ThanhToan tt = new ThanhToan(dsChiTietOrder, banChon, nv, soluong.ToString(), tongtt.ToString(), order);
            tt.ShowDialog();
            if (tt.ketqua == true)
            {
                this.Close();
            }
            else if (tt.ketqua == false)
            {
                this.Show();
                Global.orders.RemoveAll(x => x.Madh == madh);
                Global.chitietorders.RemoveAll(x => x.Madh == madh);
            }
        }

        private void lvMonTT_Selected(object sender, RoutedEventArgs e)
        {
            splMon.Visibility = Visibility.Visible;

        }

        private void btnExtra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show( "Bạn muốn lưu đơn hàng này?", "Chú ý", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (flagdathang == true)
                {
                    foreach(var i in dsChiTietOrder)
                    {
                        i.Madh = this.order.Madh;
                        _ = XuLyChiTietOrder.AddChitietorder(i);
                    }
                    this.Close();
                    return;
                }

                string madh;
                Order order = new Order();

                if (this.order != null)
                {
                    madh = this.order.Madh;
                }
                else
                {
                    if (Global.orders.Count == 0)
                    {
                        madh = "DHT" + "0001";
                    }
                    else
                    {
                        int madht = int.Parse(Regex.Match(Global.orders.Last().Madh, @"\d+\.*\d*").Value) + 1;
                        madh = "DHT" + madht.ToString("0000");
                    }
                }
                //else
                //{
                //    int madht = int.Parse(Regex.Match(XuLyOrder.orders.Last().Madh, @"\d+\.*\d*").Value) + 1;
                //    madh = "DH" + madht.ToString("0000");
                //}

                order.Madh = madh;
                order.Manv = nv.Manv;
                order.Mach = nv.Mach;
                order.Tinhtrang = false;
                order.Diachigh = "";
                order.Sdtgh = "";
                order.Coupon = "";
                Global.orders.RemoveAll(x=>x.Madh==madh);
                Global.orders.Add(order);
                //XuLyOrder.AddOrder(order);
                foreach (var i in dsChiTietOrder)
                {
                    i.Madh = madh;
                    Global.chitietorders.Add(i);
                }

            }
            else
            {
                if (flagdathang == true)
                {
                    _ = XuLyOrder.DeleteOrder(order);
                    this.Close();
                    return;
                }
                if (order != null)
                {
                    Global.orders.Remove(order);
                    Global.chitietorders.RemoveAll(x => x.Madh == order.Madh);
                }
            }
            this.Close();


        }
    }
}
