using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
