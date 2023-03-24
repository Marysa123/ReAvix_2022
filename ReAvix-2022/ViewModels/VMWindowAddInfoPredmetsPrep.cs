using Microsoft.Win32;
using ReAvix_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAddInfoPredmetsPrep
    {
        public int NumberPrep { get; set; }
        public List<Предметы> GetListPredmets { get; set; }

        public VMWindowAddInfoPredmetsPrep(int NomerPrep)
        {
            NumberPrep = NomerPrep;
            GetListPred();
        }

        public void GetListPred()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Предметы.ToList();
            GetListPredmets = item;
        }
        public string AddDocument(out string Url)
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.ShowDialog();
            string FileName = openFile.FileName;
            return Url = FileName;
        }
    }

}
