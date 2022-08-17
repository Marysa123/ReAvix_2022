using ReAvix_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReAvix_2022.ViewModels
{
   

    public class VMWindowRegisterPrep
    {
        public VMWindowRegisterPrep()
        {
            GetInfoPredmets();
            GetInfoGroup();
            GetInfoSpecialnost();
            GetInfoMugs();
        }

        public List<Группа> GetGroup { get; set; }
        public List<Предметы> GetPredmets { get; set; }
        public List<Специльности> GetSpecialnost { get; set; }
        public List<Кружки> GetMugs { get; set; }



        public void GetInfoGroup()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Группа.ToList();
            GetGroup = item;
        }
        public void GetInfoPredmets()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Предметы.ToList();
            GetPredmets = item;
        }
        public void GetInfoSpecialnost()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Специльности.ToList();
            GetSpecialnost = item;
        }
        public void GetInfoMugs()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Кружки.ToList();
            GetMugs = item;
        }

    }
}
