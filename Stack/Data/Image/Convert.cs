using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Stack.Data.Image
{
    class Convert
    {
        public static string PathToBase64(string path)
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            string base64String = System.Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public static ImageSource Base64ToImage(string base64)
        {
            byte[] bytes = System.Convert.FromBase64String(base64);
            var bitImg = new BitmapImage();
            ImageSource imageSource = null;
            using (var stream = new MemoryStream(bytes))
            {
                bitImg.BeginInit();
                bitImg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bitImg.CacheOption = BitmapCacheOption.OnLoad; 
                bitImg.StreamSource = stream; bitImg.EndInit();
                imageSource = bitImg as ImageSource;
            }
            return imageSource;
        }
    }
}
