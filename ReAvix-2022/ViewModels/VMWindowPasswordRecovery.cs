using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowPasswordRecovery
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        public bool CheckSearchEmail { get; set; }

        public void SearchEmail(string Email)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта

            _Connection.Open(); // Открытие подключения
            CommandSql.Connection = _Connection;

            CommandSql.CommandText = $"select Преподаватели.E_mail from Преподаватели where Преподаватели.[E_mail] = '{Email}'";
            if (CommandSql.ExecuteScalar() == null)
            {
                CommandSql.CommandText = $"select Студенты.E_mail from Студенты where Студенты.[E_mail] = '{Email}'";
                if (CommandSql.ExecuteScalar() == null)
                {
                    CheckSearchEmail = false;
                }
                else
                {
                    CheckSearchEmail = true;
                }
            }
            else
            {
                CheckSearchEmail = true;
            }
        }

        
    }
}
