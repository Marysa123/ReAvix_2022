using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAboutPrepodAdmin
    {
        public int Nomer { get; set; }
        public static byte[] Image { get; set; }
        public string FI { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public string DataRosh { get; set; }
        public string InfoMe { get; set; }
        public string Spec { get; set; }
        public string VedEllipse { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Pol { get; set; }
        public int KolvoStudent { get; set; }
        public string NameGroup;
        public System.Data.DataTable dataTable;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        public BitmapImage newBitmapImage;

        private static byte[] getString(Object o)
        {
            if (o == DBNull.Value) return null;
            return (byte[])o;
        }
        public VMWindowAboutPrepodAdmin(int NomerPrep)
        {
            Nomer = NomerPrep;

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection; // Инициализация подключения
        }
        public void GetInfoPrep()
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Фотография] from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            CommandSql.Connection = _Connection;
            var Item = CommandSql.ExecuteScalar();

            if (getString(Item) == null)
            {
                BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/image_Holder (2).png", UriKind.Relative));
                newBitmapImage = bit;
                _Connection.Close();
            }
            else
            {
                CommandSql.CommandText = $"select [Фотография] from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
                Image = (byte[])CommandSql.ExecuteScalar();

                System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = ms;
                newBitmapImage.EndInit();
                _Connection.Close();
            }
            _Connection.Open();
            CommandSql.CommandText = $"select [Фамилия] + ' ' + [Имя] + ' ' + Отчество as FIO from [Преподаватели] where [Номер_Преподавателя] = {Nomer} group by [Фамилия],[Имя],Отчество ";
            FI = "ФИО: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_Телефона] from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Phone = "Номер телефона: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [E_mail]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Mail = "Электронаня почта: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Adress = "Адрес: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select  DATEPART(YEAR,getdate()) - DATEPART(YEAR,[Дата_Рождения]) from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Age = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [FK_Закреплённая_группа]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            NameGroup = (string)CommandSql.ExecuteScalar();
            Group = "Закрепленная группа: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"SELECT convert(varchar, [Дата_Рождения], 101) from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            DataRosh = "Дата рождения: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Adress = "Адрес: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Пол]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Pol = "Пол: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Краткая_Информация]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            InfoMe = "Краткая информация: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Специальность] from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Spec = "Специальность: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Ведущий_Кружок]  from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            VedEllipse = "Ведущий кружок: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Логин] from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Login = "Логин: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Пароль] from [Преподаватели] where [Номер_Преподавателя] = {Nomer}";
            Password = "Пароль: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
            KolvoStudent = (int)CommandSql.ExecuteScalar();

            GetListStudent();

            _Connection.Close();
        }
        public void GetListStudent()
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,Номер_Телефона as 'Номер телефона',convert(varchar, [Дата_Рождения], 101) as 'Дата рождения' from [Студенты] where FK_Номер_Группы = '{NameGroup}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTable = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTable);
        }
    }
}
