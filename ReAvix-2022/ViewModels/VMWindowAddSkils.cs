using ReAvix_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReAvix_2022.ViewModels
{
    public class VMWindowAddSkils
    {
        public List<Категории_Навыка> GetNameKat { get; set; }
        public VMWindowAddSkils()
        {
        }

        public void GetInfokat()
        {
            db_ReAvixEntities1 dc = new db_ReAvixEntities1();
            var item = dc.Категории_Навыка.ToList();
            GetNameKat = item;
        }
    }
}
