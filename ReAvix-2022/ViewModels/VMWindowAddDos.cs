using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAddDos
    {
        public int NumberStudent;
        public string SourceIm{ get; set; }

        public VMWindowAddDos()
        {
            SourceIm = "/Resources/Images/images_AddPhoto.png";

        }

        public string AddImage(out string Url)
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            openFile.ShowDialog();
            string FileName = openFile.FileName;

            return Url = FileName;
        }
    }
}
