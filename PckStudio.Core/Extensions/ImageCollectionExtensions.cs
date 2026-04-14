using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PckStudio.Core.Extensions
{
    public static class ImageCollectionExtensions
    {
        public static void Insert(this ImageList.ImageCollection _, int index, string key, Image image)
        {
            var images = new List<Image>();
            var keys = new List<string>();

            for (int i = 0; i < _.Count; i++)
            {
                keys.Add(_.Keys[i]);
                images.Add(_[i]);
            }

            images.Insert(index, image);
            keys.Insert(index, key);

            _.Clear();

            for (int i = 0; i < images.Count; i++)
            {
                _.Add(keys[i], images[i]);
            }
        }
    }
}
