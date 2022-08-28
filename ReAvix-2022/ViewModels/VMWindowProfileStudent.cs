using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{

    internal class VMWindowProfileStudent
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        int NomerStudent;
        public BitmapImage newBitmapImage;
        public static byte[] Image { get; set; }
        public string SourceIm { get; set; }

        public string FI { get; set; }
        public string Cours { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string Fam { get; set; }
        public string Ima { get; set; }
        public string Otch { get; set; }
        public string Group { get; set; }
        public string PhoneRod { get; set; }
        public string DataRosh { get; set; }
        public string InfoMe { get; set; }


        public VMWindowProfileStudent(int NumberSt)
        {
            NomerStudent = NumberSt;
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта

        }
        private static byte[] getString(Object o)
        {
            if (o == DBNull.Value) return null;
            return (byte[])o;
        }

        public void GetInfoStudent()
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Фотография] from [Студенты] where [Номер_Студента] = {NomerStudent}";
            CommandSql.Connection = _Connection;
            var Item = CommandSql.ExecuteScalar();

            if (getString(Item) == null)
            {
                BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/_8AyKfK3yIA.jpg", UriKind.Relative));
                newBitmapImage = bit;
                _Connection.Close();
            }
            else
            {
                CommandSql.CommandText = $"select [Фотография] from [Студенты] where [Номер_Студента] = {NomerStudent}";
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
            CommandSql.CommandText = $"select [Фамилия] + ' ' + [Имя] as FIO from [Студенты] where [Номер_Студента] = {NomerStudent} group by [Фамилия],[Имя]";
            FI = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Курс]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Cours = "Студент(ка) "+(string)CommandSql.ExecuteScalar() + " курса";

            CommandSql.CommandText = $"select [Номер_Телефона] from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Phone = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [E_mail]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Mail = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Adress = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select  DATEPART(YEAR,getdate()) - DATEPART(YEAR,[Дата_Рождения]) from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Age = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [FK_Номер_Группы]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Group = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_Телефона_Родителей]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            PhoneRod = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Имя]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Ima = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Фамилия]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Fam = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Отчество]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Otch = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"SELECT convert(varchar, [Дата_Рождения], 101) from [Студенты] where [Номер_Студента] = {NomerStudent}";
            DataRosh = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Adress = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Краткая_Информация]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            InfoMe = (string)CommandSql.ExecuteScalar();

            _Connection.Close();

        }
 

        public string AddImage(out string Url)
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            openFile.ShowDialog();
            string FileName = openFile.FileName;

            return Url = FileName;
        }

    }

}
