using ReAvix_2022.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReAvix_2022.ViewModels
{


    public class VMWindowRegisterPrep
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public List<Группа> GetGroup { get; set; }
       // public List<Предметы> GetPredmets { get; set; }
        public List<Специальности> GetSpecialnost { get; set; }
        public List<Кружки> GetMugs { get; set; }

        public VMWindowRegisterPrep()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            
            GetInfoGroup();
            GetInfoMugs();
            GetInfoSpecialnost();
        }


        public void AddInfoPrepInDB(string Ima, string Fam, string Otch, string Login, string Password, string Mail, string NomerTel, string Pol, string Date, string Adress,string Spec,string LeadingMugle,string InfoMe,string ZakGroup)
        {
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = "set language english;";
            CommandSql.CommandText = "Insert into [Преподаватели] (Имя,Фамилия,Отчество,Логин,Пароль,E_mail,Номер_Телефона,Пол,Дата_рождения,Адрес,Специальность,Краткая_Информация,Ведущий_Кружок,FK_Закреплённая_группа,Фотография) values (@im,@fa,@ot,@lo,@pa,@ma,@no,@po,@da,@ad,@cp,@lm,@ci,@za,null)"; // Строка запроса
            CommandSql.Connection = _Connection;

            //@im,@fa,@ot,@lo,@pa,@ma,@no,@po,@da,@ad,@vp,@dp,@cp,@ci,@za
            CommandSql.Parameters.AddWithValue("@im", Ima); // Параметры строки запроса
            CommandSql.Parameters.AddWithValue("@fa", Fam);
            CommandSql.Parameters.AddWithValue("@ot", Otch);
            CommandSql.Parameters.AddWithValue("@lo", Login);
            CommandSql.Parameters.AddWithValue("@pa", Password);
            CommandSql.Parameters.AddWithValue("@ma", Mail);
            CommandSql.Parameters.AddWithValue("@no", NomerTel);
            CommandSql.Parameters.AddWithValue("@po", Pol);
            CommandSql.Parameters.AddWithValue("@da", Date);
            CommandSql.Parameters.AddWithValue("@ad", Adress);
            CommandSql.Parameters.AddWithValue("@cp", Spec);
            CommandSql.Parameters.AddWithValue("@ci", InfoMe);
            CommandSql.Parameters.AddWithValue("@lm", LeadingMugle);
            CommandSql.Parameters.AddWithValue("@za", ZakGroup);

            CommandSql.ExecuteNonQuery(); // Выплнение запроса SQL
            _Connection.Close(); // Закрытие подключения
        }
        public bool ValidateInfoStudentPasswordBox(string PasswordOne, string PasswordTwo, out bool result)
        {
            if (PasswordOne != PasswordTwo)
            {
                return result = false;
            }
            return result = true;
        }

        public bool ValidateInfoStudentTextBox(out bool resultTextBox, string Ima, string Fam, string Otch, string Login, string Mail, string NomerTel, string Adress, string InfoMe,string ZaGroup,string Spec, string VedEllipse)
        {
            if (Ima == "" || Fam == "" || Otch == "" || Login == "" || Mail == "" || NomerTel == "" ||  Adress == "" || InfoMe == "" || ZaGroup == "" || Spec =="" || VedEllipse == "")
            {
                return resultTextBox = false;
            }
            return resultTextBox = true;
        }
        public bool ValidateInfoStudentLogin(string LoginOne, out bool result)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Логин] from [Преподаватели] where [Логин] = '{LoginOne}'";
            CommandSql.Connection = _Connection;
            string LoginTwo = (string)CommandSql.ExecuteScalar();

            if (LoginOne == LoginTwo)
            {
                _Connection.Close();
                return result = false;
            }
            else
            {
                CommandSql.CommandText = $"select [Логин] from [Студенты] where [Логин] = '{LoginOne}'";
                string LoginThree = (string)CommandSql.ExecuteScalar();

                if (LoginOne == LoginThree)
                {
                    _Connection.Close();
                    return result = false;
                }
            }
            _Connection.Close();
            return result = true;
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

        public bool ValidateInfoGroup(string Group, out bool result)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [FK_Закреплённая_группа] from [Преподаватели] where [FK_Закреплённая_группа] = '{Group}'";
            string GroupTwo = (string)CommandSql.ExecuteScalar();

           if (Group == GroupTwo)
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

        public void GetInfoGroup()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Группа.ToList();
            GetGroup = item;
        }

        public void GetInfoSpecialnost()
        {
            db_ReAvixEntities dc = new db_ReAvixEntities();
            var item = dc.Специальности.ToList();
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
