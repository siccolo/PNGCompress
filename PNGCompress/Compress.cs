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

        public static byte[] CompressImage(Image source)
        {
            var quantizer = new WuQuantizer();
            using (var bitmap = new Bitmap(source))
            {
                using (var quantized = quantizer.QuantizeImage(bitmap))
                {
                    //quantized.Save(target, ImageFormat.Png);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        quantized.Save(ms, ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
            }
        }
    }
}
