using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
namespace BanHangDATN
{
    /// <summary>
    /// Interaction logic for MoMoQR.xaml
    /// </summary>
    public partial class MoMoQR : Window
    {
        double thanhtien;
        public bool ketqua;
        public MoMoQR(double thanhtien)
        {
            this.thanhtien = thanhtien;
            InitializeComponent();
            taoQRCode();
        }
        

        public System.Drawing.Image resizeImage(System.Drawing.Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((System.Drawing.Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }

        private void taoQRCode()
        {
            var qrcode_text = $"2|99|0938110932|||0|0|{thanhtien}";
            BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();

            EncodingOptions encodingOptions = new EncodingOptions() { Width = 250, Height = 250, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrcode_text);
            Bitmap logo = resizeImage(BanHangDATN.Resource1.logo_momo, 64, 64) as Bitmap;
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new System.Drawing.Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
            pic_qrcode.Source = ImageSourceFromBitmap(bitmap);
        }

        private void btnThanhCong_Click(object sender, RoutedEventArgs e)
        {
            ketqua = true;
            this.Close();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ketqua = false;
            this.Close();
        }
    }
}
