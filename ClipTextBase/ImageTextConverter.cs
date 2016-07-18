using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tesseract;
using System.IO;

namespace ClipTextBase
{
    public static class ImageTextConverter
    {
        public static string convertImageToText(Image image, string filename)
        {

            var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);

            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            var temp = ms.ToArray();

            var p = Pix.LoadFromFile(filename);

            var page = engine.Process(p);
            var text = page.GetText();

            return text;
        }


    }
}
