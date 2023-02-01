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
    /// Interaction logic for XemHoaDon.xaml
    /// </summary>
    public partial class XemHoaDon : Window
    {
        public XemHoaDon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtpNgay.SelectedDate = DateTime.Today;
            //Hoadon hd = XuLyHoaDon.hoadons.ToList().Find(x=>x.Mahd=="DH0022");
            hienthi();
        }
        public void hienthi()
        {
            //icHoaDon.ItemsSource = XuLyHoaDon.hoadons.ToList().Where(x => x.Ngaytt.Date.ToShortDateString() == dtpNgay.SelectedDate.Value.ToShortDateString());

        }
        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dtpNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            hienthi();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
