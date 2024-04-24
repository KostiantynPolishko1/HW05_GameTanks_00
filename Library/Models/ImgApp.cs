using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWF.Models
{
    public class ImgApp
    {
        public readonly string path;
        public readonly List<string> imgNames;
        public Dictionary<string, FileStream?> fsImgs;

        public ImgApp()
        {
            path = setPathImg(Environment.CurrentDirectory);
            imgNames = new List<string>() { "default" };
            fsImgs = new Dictionary<string, FileStream?>();

            setFsImgs(imgNames);
        }

        private string setPathImg(string path) => path.Substring(0, path.IndexOf("bin")) + "Sources\\";

        private void setFsImgs(List<string> imgNames)
        {
            foreach (string img in imgNames)
            {
                fsImgs.Add(img, File.Open(this.path + img + ".jpg", FileMode.Open));
            }
        }
    }
}
