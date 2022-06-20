using System.Drawing;
using System.Net;
using ZXing;

namespace SpecFlowTestProjectWithQRCode.Utils
{
    public static class ZxingForQRCode
    {
        public static string DecodeQrCode(string url)
        {
            WebClient wc = new();
            byte[] bytes = wc.DownloadData(url);
            MemoryStream ms = new(bytes);
            Image img = Image.FromStream(ms);
            var barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode((Bitmap)img);
            return result?.Text;
        }
    }
}
