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
    internal class VMWindowChangePassword
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        public void ChangePassword(string Email,string PasswordChange)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.Connection = _Connection;


            CommandSql.CommandText = $"select Номер_Преподавателя from Преподаватели where Преподаватели.[E_mail] = '{Email}'";
            object Result = CommandSql.ExecuteScalar();
            if (Result == null)
            {
                CommandSql.CommandText = $"select Номер_Студента from Студенты where Студенты.[E_mail] = '{Email}'";
                Result = CommandSql.ExecuteScalar();


                CommandSql.CommandText = $"UPDATE Студенты SET Пароль={PasswordChange} WHERE Номер_Студента={Result}";
                CommandSql.ExecuteNonQuery();
                MessageBox.Show("Ваш пароль изменен!","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                CommandSql.CommandText = $"UPDATE Преподаватели SET Пароль={PasswordChange} WHERE Номер_Преподавателя={Result}";
                CommandSql.ExecuteNonQuery();
                MessageBox.Show("Ваш пароль изменен!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }
    }
}
