using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace App.Utility.Extensions
{
    /// <summary>
    /// </summary>
    public static class ImageExtension
    {
        public static byte[] ToBytes(this Bitmap @this)
        {
            var stream = new MemoryStream();
            @this.Save(stream, ImageFormat.Jpeg);

            return stream.ToArray();
        }

        public static string ToBase64(this Bitmap @this, bool includeMeta = true)
        {
            var bytes = ToBytes(@this);

            if (includeMeta)
            {
                return "data:image/png;base64," + Convert.ToBase64String(bytes);
            }

            return Convert.ToBase64String(bytes);
        }
    }
}
