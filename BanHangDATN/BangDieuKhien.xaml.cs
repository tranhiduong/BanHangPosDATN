using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for BangDieuKhien.xaml
    /// </summary>
    public partial class BangDieuKhien : Window
    {
        public BangDieuKhien()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ThongTinKhachHang.Visibility = Visibility.Hidden;
            ThemKhachHang.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void hienThi()
        {
            txtTenKhachHang.Clear();
            txtSdt.Clear();
        }

        private void btnHoanTatThemKH_Click(object sender, RoutedEventArgs e)
        {
            //Khachhang kh = new Khachhang { 
            //Tenkh=txtTenKhachHang.Text,
            //Ngaysinh=dtpNgaySinh.DisplayDate,
            //Sdt=txtSDT.Text,
            //Diachi=txtDiaChiKhachHang.Text,
            //Email=txtEmail.Text,
            //Cmnd=txtCmdn.Text
            //};
            //if (btnNam.IsChecked == true)
            //{
            //    kh.Giotinh = "Nam";
            //}
            //else
            //    kh.Giotinh = "Nữ";
            //XulyKhachhang.AddKhachhang(kh);
            //MessageBox.Show("Thêm thành công khách hàng mới!");
            //hienThi();
            ThemKhachHang.Visibility = Visibility.Hidden;

        }

        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            ThongTinKhachHang.Visibility = Visibility.Visible;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThemKH_Click(object sender, RoutedEventArgs e)
        {
            ThemKhachHang.Visibility = Visibility.Visible;
        }

        private void btnHoanTat_Click(object sender, RoutedEventArgs e)
        {
            ThongTinKhachHang.Visibility = Visibility.Hidden;
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
            Khachhang kh = khachhangs.Find(a => a.Sdt == txtMaKH.Text);
            if (kh == null)
            {
                MessageBox.Show("Khách hàng không tồn tại!");
            }
            else
            {
                tTenKh.Visibility = Visibility.Visible;
                tDiaChi.Visibility = Visibility.Visible;
                tDiem.Visibility = Visibility.Visible;
                //tHanMuc.Visibility = Visibility.Visible;
                txtTenKH.Text = kh.Tenkh;
                txtSDTKH.Text = kh.Sdt.ToString();
                txtDiemTichLuy.Text = kh.Diemthuong.ToString();
                //if (kh.Diemthuong < 500)
                //{
                //    txtHanMuc.Text = "Thẻ khách hàng thân thiết";
                //}
                //else if (kh.Diemthuong < 1000)
                //{
                //    txtHanMuc.Text = "Thẻ khách hàng Silver";

                //}
                //else if (kh.Diemthuong < 2500)
                //{
                //    txtHanMuc.Text = "Thẻ khách hàng Gold";

                //}
                //else
                //{
                //    txtHanMuc.Text = "Thẻ khách hàng Platinum";

                //}
            }


        }

        private void btnThemkhachhang_new_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            if (txtTenKhachHang.Text == "")
            {
                MessageBox.Show("Tên khách hàng khỗng được để trống");
                return;
            }
            if (txtSdt.Text == "")
            {
                MessageBox.Show("Sdt khách hàng khỗng được để trống");
                return;
            }
            var khachhangs = Task.Run(() => XulyKhachhang.GetKhachhangs()).Result;
            string makh;
            if (khachhangs.Count() == 0)
            {
                makh = "KH0001";
            }
            else
            {
                int makht = int.Parse(Regex.Match(khachhangs.Last().Makh, @"\d+\.*\d*").Value) + 1;
                makh = "KH" + makht.ToString("0000");
            }
            if (khachhangs.Where(x => x.Sdt == txtSdt.Text).Count() != 0)
            {
                MessageBox.Show("Đã tồn tại số điện thoại khách hàng");
                return;
            }
            Khachhang kh = new Khachhang {
                Makh=makh,
                Tenkh = txtTenKhachHang.Text,
                Ngaysinh = "",
                Sdt = txtSdt.Text,
                Diachi = "",
                Email = "",
                Cmnd = "",
                Gioitinh = "",
                Matkhau="",
            };
            
            Task.Run(()=>XulyKhachhang.AddKhachhang(kh)).Wait();
            MessageBox.Show("Thêm mới khách hàng thành công!");
            hienThi();
            ThemKhachHang.Visibility = Visibility.Hidden;
        }
    }
}
