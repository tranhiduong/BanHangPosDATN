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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BanHangDATN.Models;

namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dangnhap : Window
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (Global.CheckInternet() == false)
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau giây lát");
                return;
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Không được để trống tài khoản");
                return;
            }
            if (txtPassword.Password == "")
            {
                MessageBox.Show("Không được để trống mật khẩu");
                return;
            }
            var nhanviens = Task.Run(() => XuLyNhanVien.GetNhanviens()).Result;
            Nhanvien nv = nhanviens.Find(x => x.Manv==txtUsername.Text);
           
            if (nv == null)
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }
            if(nv.Matkhau!=txtPassword.Password)
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }
            WindowOrder order = new WindowOrder(nv);
            this.Hide();
            order.ShowDialog();
            this.Show();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
