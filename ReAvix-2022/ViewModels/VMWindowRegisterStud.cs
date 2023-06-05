using ReAvix_2022.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowRegisterStud
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public VMWindowRegisterStud()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            GetInfoGroup();
            CommandSql.Connection = _Connection;
        }
        public void AddInfoStudentInDB(string Ima, string Fam, string Otch, string Login, string Password, string Mail, string NomerTel, string NomerTelRod, string Course, string Pol, string Date, string Adress, string InfoMe, string NomerGroup)
        {
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = "set language english;";
            CommandSql.CommandText = "Insert into [Студенты] (Имя,Фамилия,Отчество,Логин,Пароль,E_mail,Номер_Телефона,Номер_телефона_Родителей,Курс,Пол,Дата_рождения,Адрес,Краткая_Информация,FK_Номер_Группы,Фотография) values (@im,@fa,@ot,@lo,@pa,@ma,@no,@tr,@cu,@po,@da,@ad,@cr,@gr,null)"; // Строка запроса
            CommandSql.Connection = _Connection;
            CommandSql.Parameters.AddWithValue("@im", Ima); // Параметры строки запроса
            CommandSql.Parameters.AddWithValue("@fa", Fam);
            CommandSql.Parameters.AddWithValue("@ot", Otch);
            CommandSql.Parameters.AddWithValue("@lo", Login);
            CommandSql.Parameters.AddWithValue("@pa", Password);
            CommandSql.Parameters.AddWithValue("@ma", Mail);
            CommandSql.Parameters.AddWithValue("@no", NomerTel);
            CommandSql.Parameters.AddWithValue("@tr", NomerTelRod);
            CommandSql.Parameters.AddWithValue("@cu", Course);
            CommandSql.Parameters.AddWithValue("@po", Pol);
            CommandSql.Parameters.AddWithValue("@da", Date);
            CommandSql.Parameters.AddWithValue("@ad", Adress);
            CommandSql.Parameters.AddWithValue("@cr", InfoMe);
            CommandSql.Parameters.AddWithValue("@gr", NomerGroup);
            CommandSql.ExecuteNonQuery(); // Выплнение запроса SQL
            _Connection.Close(); // Закрытие подключения
        }
        public bool ValidateInfoStudentTextBox(out bool resultTextBox, string Ima, string Fam, string Otch, string Login, string Mail, string NomerTel, string NomerTelRo, string Adress, string InfoMe, string NomerGroup)
        {
            if (Ima == "" || Fam == "" || Otch == "" || Login == "" || Mail == "" || NomerTel == "" || NomerTelRo == "" || Adress == "" || InfoMe == "" || NomerGroup == "")
            {
                return resultTextBox = false;
            }
            return resultTextBox = true;

        }
        public bool ValidateInfoStudentPasswordBox(string PasswordOne, string PasswordTwo, out bool result)
        {
            if (PasswordOne != PasswordTwo)
            {
                return result = false;
            }
            return result = true;
        }
        public bool ValidateInfoStudentLogin(string LoginOne, out bool result)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Логин] from [Студенты] where [Логин] = '{LoginOne}'";
            string LoginTwo = (string)CommandSql.ExecuteScalar();

            if (LoginOne == LoginTwo)
            {
                _Connection.Close();
                return result = false;
            }
            else
            {
                CommandSql.CommandText = $"select [Логин] from [Преподаватели] where [Логин] = '{LoginOne}'";
                string LoginThree = (string)CommandSql.ExecuteScalar();

                if (LoginOne == LoginThree)
                {
                    _Connection.Close();
                    return result = false;
                }
                else
                {
                    _Connection.Close();
                    return result = true;
                }
            }
        }
        public bool ValidateInfoStudentEmail(string EmailOne, out bool result)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [E_mail] from [Студенты] where [E_mail] = '{EmailOne}'";
            string EmailTwo = (string)CommandSql.ExecuteScalar();

            if (EmailOne == EmailTwo)
            {
                _Connection.Close();
                return result = false;
            }
            else
            {
                CommandSql.CommandText = $"select [E_mail] from [Преподаватели] where [E_mail] = '{EmailOne}'";
                string EmailThree = (string)CommandSql.ExecuteScalar();

                if (EmailOne == EmailThree)
                {
                    _Connection.Close();
                    return result = false;
                }
                else
                {
                    _Connection.Close();
                    return result = true;
                }
            }
        }
        public bool ValidateInfoStudentPhone(string PhoneOne, out bool result)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Номер_Телефона] from [Студенты] where [Номер_Телефона] = '{PhoneOne}'";
            string PhoneTwo = (string)CommandSql.ExecuteScalar();

            if (PhoneOne == PhoneTwo)
            {
                _Connection.Close();
                return result = false;
            }
            else
            {
                CommandSql.CommandText = $"select [Номер_Телефона] from [Преподаватели] where [Номер_Телефона] = '{PhoneOne}'";
                string PhoneThree = (string)CommandSql.ExecuteScalar();

                if (PhoneOne == PhoneThree)
                {
                    _Connection.Close();
                    return result = false;
                }
                else
                {
                    _Connection.Close();
                    return result = true;
                }
            }
        }

        public List<Группа> GetGroup { get; set; }

        public void GetInfoGroup()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Группа.ToList();
            GetGroup = item;
        }
    }
}
