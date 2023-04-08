using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAddNewsAdmin
    {
        public string SourceIm { get; set; }

        public VMWindowAddNewsAdmin()
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
