using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace docrafERP.Models
{
    public class ImageModel
    {
        public int ImageID { get; set; }
        public BitmapImage Image { get; set; }

        private byte[] data;

        public byte[] Data
        {
            get { return data; }
            set { data = value;
                try
                {
                    this.Image = LoadImage(data);
                }
                catch { }
            }
        }

        //Image ConvertBufferToImage(byte[] buffer)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        return Image.FromStream(ms);
        //    }

        //}

        public BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }



    }
}
