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

namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for InHoaDon.xaml
    /// </summary>
    public partial class InHoaDon : Window
    {
        public List<Chitietorder> dsCTHD;
        

        
        public InHoaDon(List<Chitietorder> dsCTHD, string hinhthuc, double giam, double tong, double thanhtien, double khachdua, double tralai,Nhanvien nv,Order order,string soban)
        {
            InitializeComponent();
            txtsoban.Text = soban;
            this.dsCTHD = dsCTHD;
            txtDiachigh.Text = order.Diachigh;
            txtSdtgh.Text = order.Sdtgh;
            hienThiMonTT();
            txtMaHD.Text = order.Madh;
            //Print();
            txtHinhThuc.Text = hinhthuc;
            txtGiam.Text = giam.ToString();
            txtTong.Text = tong.ToString();
            txtTT.Text = thanhtien.ToString();
            txtKhachDua.Text = khachdua.ToString();
            txtTraLai.Text = tralai.ToString();
            //txtgio.Text = gio;
            txtThoiGian.Text = DateTime.Now.ToString();
            txtNhanVien.Text = nv.Tennv;
        }
        public void hienThiMonTT()
        {

            lvMonTT.ItemsSource = null;
            var mons = Task.Run(() => XulyMon.Getmons()).Result;
            lvMonTT.ItemsSource = dsCTHD.Select(x => new
            {
                tenmon =mons.Find(a=>a.Mamon==x.Mamon).Tenrutgon,
                soluong = x.Soluong,
                gia = x.Soluong* mons.Find(a => a.Mamon == x.Mamon).Dongia
            });

        }

        private void Print()
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
