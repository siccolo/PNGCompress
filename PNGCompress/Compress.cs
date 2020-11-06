using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using nQuant;

namespace PNGCompress
{
    public sealed class Compress
    {
        public static void CompressImage(string source, string target)
        {
            //    private static int alphaTransparency = 10;
            //private static int alphaFader = 70;
            var quantizer = new WuQuantizer();
            using (var bitmap = new Bitmap(source))
            {
                //using (var quantized = quantizer.QuantizeImage(bitmap, alphaTransparency, alphaFader))
                //{
                //    quantized.Save(targetPath, ImageFormat.Png);
                //}
                using(var quantized = quantizer.QuantizeImage(bitmap))
                {
                    quantized.Save(target, ImageFormat.Png);
                }
            }
        }
    }
}
