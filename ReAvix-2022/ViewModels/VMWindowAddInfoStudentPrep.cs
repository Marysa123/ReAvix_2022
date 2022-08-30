using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAddInfoStudentPrep
    {
        int NumberPrep;
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();

        public VMWindowAddInfoStudentPrep(int NomerPrep)
        {
            NumberPrep = NomerPrep;

        }
        public void GetInfoStudent()
        {
          


        }
    }
}
