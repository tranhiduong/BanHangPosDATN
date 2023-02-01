using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BanHangDATN.Models;
using System.Text.RegularExpressions;

namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for ThanhToan.xaml
    /// </summary>
    public partial class ThanhToan : Window
    {
        public bool ketqua = false;
        double giam = 0;
        double thanhtien;
        double thieu;
        double tralai;
        double khachdua;
        string hinhThuc = "Tiền mặt";
        string soLuong;
        string tong;
        Nhanvien nv;
        Order dh;
        Coupon cp;
        List<Chitietorder> cts;
        Hoadon hd = new Hoadon();
        string soban;
        Khachhang kh;
        public ThanhToan()
        {
            InitializeComponent();
            
        }
        public ThanhToan(List<Chitietorder> cts,string banChon, Nhanvien nv, string sl, string tongtt,Order donhang)
        {
            InitializeComponent();
            txtBan.Text = "Bàn " + banChon;
            soban = banChon;
            tong = tongtt;
            txtTong.Text = tongtt;
            txtKhachDua.Text = "0";
            txtGiam.Text = "0";
            txtTraLai.Text = "0";
            soLuong = sl;
            this.nv = nv;
            txtNV.Text = nv.Tennv;
            dh = donhang;
            thanhtien = double.Parse(tongtt);
            this.cts = cts;
            txtDiachigh.Text = dh.Diachigh;
            txtSdtgiao.Text = dh.Sdtgh;
            
        }
        
        public void hienThi()
        {
            thanhtien = double.Parse(txtTong.Text) - giam;
            thieu = thanhtien - double.Parse(txtKhachDua.Text);
            tralai = double.Parse(txtKhachDua.Text) - thanhtien;
            txtTT.Text = thanhtien.ToString();
            txtTraLai.Text = tralai.ToString();
            if (thieu >= 0)
            {
                txtThieu.Text = thieu.ToString();
            }
            else
            {
                txtThieu.Text = "0";
            }
            txtSoTien.Text = thanhtien.ToString();

        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSoTien.Text = null;
        }

        private void btnHT_Click(object sender, RoutedEventArgs e)
        {
            txtKhachDua.Text = txtSoTien.Text;
            khachdua = double.Parse(txtKhachDua.Text);
            if (tralai > 0)
            {
                txtTraLai.Text = "0";
            }
            else
            {
                txtTraLai.Text = tralai.ToString();
            }
            hienThi();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            txtSoTien.Text = txtSoTien.Text + btn.Content.ToString();
        }
        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtSoTien.Text = txtSoTien.Text.Substring(0, txtSoTien.Text.Length - 1);
        }

        private void btnMomo_Click(object sender, RoutedEventArgs e)
        {
            hinhThuc = btnMomo.Content.ToString();
            txtHinhThucTT.Text = "Thanh toán bằng " + hinhThuc ;
            MoMoQR moMo = new MoMoQR(thanhtien);
            moMo.ShowDialog();
            if (moMo.ketqua == false)
            {
                return;
            }
            txtKhachDua.Text = thanhtien.ToString();
            tralai = 0;
            thieu = 0;
            khachdua = thanhtien;
            txtTraLai.Text = "0";
            txtThieu.Text = "0";
        }

        private void btnVNpay_Click(object sender, RoutedEventArgs e)
        {
            hinhThuc = btnVNpay.Content.ToString();
            txtHinhThucTT.Text = "Thanh toán bằng " + hinhThuc ;
        }

        private void btnSliver_Click(object sender, RoutedEventArgs e)
        {
            giam = thanhtien * 0.03;
            txtGiam.Text = giam.ToString();
            hienThi();
        }

        private void btnGold_Click(object sender, RoutedEventArgs e)
        {
            giam = thanhtien * 0.05;
            txtGiam.Text = giam.ToString();
            hienThi();
        }

        private void btnPlatinum_Click(object sender, RoutedEventArgs e)
        {
            giam = thanhtien * 0.1;
            txtGiam.Text = giam.ToString();
            hienThi();
        }

        private void btnVip_Click(object sender, RoutedEventArgs e)
        {
            giam = thanhtien * 0.2;
            txtGiam.Text = giam.ToString();
            hienThi();
        }

        private void btnXoaKH_Click(object sender, RoutedEventArgs e)
        {
            txtMaKH.Text = null;
        }

        private void btnTimKH_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
            Khachhang kh = khachhangs.Find(a=>a.Sdt==txtMaKH.Text);
            if (kh != null)
            {
                this.kh = kh;
                txtTenKH.Text = kh.Tenkh;
                //if (kh.Diemthuong > 500 && kh.Diemthuong < 1000)
                //{
                //    btnSliver.IsEnabled = true;
                //}
                //else if (kh.Diemthuong >= 1000 && kh.Diemthuong < 2500)
                //{
                //    btnGold.IsEnabled = true;
                //}
                //else if (kh.Diemthuong >= 2500)
                //{
                //    btnPlatinum.IsEnabled = true;
                //}
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMaHD.Text = dh.Madh.ToString();
            txtDiem.Text = (int.Parse(txtTong.Text) / 1000).ToString();
            txtTT.Text = thanhtien.ToString();
            txtHinhThucTT.Text = "Thanh toán bằng " + hinhThuc ;
            hienThi();
            var coupons = Task.Run(() => XulyCoupon.GetCoupons()).Result;
            Coupon cp = coupons.Find(x => x.Macp == dh.Coupon);
            if (cp != null)
            {
                ApdungCoupon(cp);
            }
            if (soban!=null)
            {
                txtDiachigh.IsEnabled = false;
                txtSdtgiao.IsEnabled = false;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ketqua = false;
            this.Close();
        }

        private void btnHoanTat_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            if (khachdua < thanhtien)
            {
                MessageBox.Show("Không đủ tiền thanh toán");
                return;
            }
            if (soban == null)
            {
                if (txtSdtgiao.Text == "")
                {
                    MessageBox.Show("Không được để trống sdt giao hàng");
                    return;
                }
                if (txtDiachigh.Text == "")
                {
                    MessageBox.Show("Không được để trống địa chỉ giao hàng");
                    return;
                }
            }
            //Khachhang kh = XulyKhachhang.khachhangs.Find(a=>a.Makh==txtMaKH.Text);
            //kh.Diemtichluy += int.Parse(txtDiem.Text);
            var orders = Task.Run(() => XuLyOrder.GetOrders()).Result;
            string madh;
            if (dh.Tinhtrang == true)
            {
                madh = dh.Madh;
                dh.Tinhtrang =false;
            }
            else
            {
                int madht = int.Parse(Regex.Match(orders.Last().Madh, @"\d+\.*\d*").Value) + 1;
                madh = "DH" + madht.ToString("0000");
                foreach (var i in cts)
                {
                    i.Madh = madh;
                    _ = XuLyChiTietOrder.AddChitietorder(i);
                }
            }
            hd.Mahd = madh;
            hd.Ngaytt = DateTime.Now ;
            hd.Httt = hinhThuc;
            hd.Thanhtien = int.Parse(txtTT.Text);
            hd.Mach= nv.Mach;
            //hd.Htgg
            
            dh.Madh = madh;
            dh.Makh = txtMaKH.Text;
            //hd.ChitietHoadons = ct;
            //dh.Tinhtrang = true;
            dh.Sdtgh=txtSdtgiao.Text;
            dh.Diachigh = txtDiachigh.Text;

            if (this.kh != null)
            {
                this.kh.Diemthuong += int.Parse(txtDiem.Text);
                Task.Run(() => XulyKhachhang.UpdateKhachhang(this.kh));
            }
            Task.Run(()=>XuLyOrder.AddOrder(dh)).Wait();
            Task.Run(() => XuLyHoaDon.AddHoadon(hd)).Wait();
            InHoaDon inHoaDon = new InHoaDon(cts, hinhThuc, giam, double.Parse(tong), thanhtien, khachdua, tralai, nv,dh,soban);
            inHoaDon.ShowDialog();
            ketqua = true;           
            this.Close();
        }

        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            hinhThuc = btnCash.Content.ToString();
            txtHinhThucTT.Text = "Thanh toán bằng " + hinhThuc ;
        }

        private void btnApDung_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            var coupons = Task.Run(() => XulyCoupon.GetCoupons()).Result;
            Coupon cp = coupons.ToList().Find(x => x.Macp == txtCoupon.Text);
            ApdungCoupon(cp);
            
        }
        void ApdungCoupon(Coupon cp)
        {

            if (cp == null)
            {
                MessageBox.Show("KHông tồn tại coupon");
                return;
            }
            if (DateTime.Now < cp.Ngaybatdau.Value)
            {
                MessageBox.Show("Coupon chưa thể sử dụng");
                return;
            }
            if (DateTime.Now > cp.Ngayketthuc.Value)
            {
                MessageBox.Show("Coupon đã hết hạn");
                return;
            }
            if (cp.Soluong == 0)
            {
                MessageBox.Show("Coupon đã hết lượt sử dụng");
                return;
            }
            double mucgiam;
            double tongtien = int.Parse(tong);
            bool isNumeric = double.TryParse(cp.Mucgiam, out mucgiam);
            if (isNumeric == true)
            {
                if (tongtien >= mucgiam)
                {
                    txtGiam.Text = mucgiam.ToString();
                    thanhtien = tongtien - mucgiam;
                    txtTT.Text = thanhtien.ToString();
                    txtKhachDua.Text = "0";
                    txtThieu.Text = thanhtien.ToString();
                    txtTraLai.Text = (0 - thanhtien).ToString();
                    giam = mucgiam;
                    txtSoTien.Text=thanhtien.ToString();
                }
                else
                {
                    txtGiam.Text = tongtien.ToString();
                    thanhtien = 0;
                    txtTT.Text = thanhtien.ToString();
                    txtKhachDua.Text = "0";
                    txtThieu.Text = thanhtien.ToString();
                    txtTraLai.Text = (0 - thanhtien).ToString();
                    giam = mucgiam;
                    txtSoTien.Text = thanhtien.ToString();
                }
            }
            else
            {

                int phantram = int.Parse(Regex.Match(cp.Mucgiam, @"\d+").Value);
                mucgiam = tongtien * phantram / 100;
                if (mucgiam > cp.Giamtoida)
                {
                    mucgiam = cp.Giamtoida;
                    txtGiam.Text = mucgiam.ToString();
                    thanhtien = tongtien - mucgiam;
                    txtTT.Text = thanhtien.ToString();
                    txtKhachDua.Text = "0";
                    txtThieu.Text = thanhtien.ToString();
                    txtTraLai.Text = (0 - thanhtien).ToString();
                    giam = mucgiam;
                    txtSoTien.Text = thanhtien.ToString();
                }
                else
                {
                    txtGiam.Text = mucgiam.ToString();
                    thanhtien = tongtien - mucgiam;
                    txtTT.Text = thanhtien.ToString();
                    txtKhachDua.Text = "0";
                    txtThieu.Text = thanhtien.ToString();
                    txtTraLai.Text = (0 - thanhtien).ToString();
                    giam = mucgiam;
                    txtSoTien.Text = thanhtien.ToString();
                }
            }
        }
    }
}
