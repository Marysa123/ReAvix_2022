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
    internal class VMWindowProfilePrep
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        int NomerPrep;
        public BitmapImage newBitmapImage;
        public static byte[] Image { get; set; }
        public string SourceIm { get; set; }
        public string FI { get; set; }
        public string VedPredmet { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string Fam { get; set; }
        public string Ima { get; set; }
        public string Otch { get; set; }
        public string Group { get; set; }
        public string DataRosh { get; set; }
        public string InfoMe { get; set; }
        public string DopPredmet { get; set; }
        public string Spec { get; set; }
        public string VedEllipse { get; set; }
        public string VedPredmetTwo { get; set; }


        public VMWindowProfilePrep(int NumberPrep)
        {
            NomerPrep = NumberPrep;
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
        }
        private static byte[] getString(Object o)
        {
            if (o == DBNull.Value) return null;
            return (byte[])o;
        }

        public void GetInfoPrep()
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Фотография] from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
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
                CommandSql.CommandText = $"select [Фотография] from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
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
            CommandSql.CommandText = $"select [Фамилия] + ' ' + [Имя] as FIO from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep} group by [Фамилия],[Имя]";
            FI = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Ведущий_предмет] from Преподаватели where [Номер_Преподавателя] = {NomerPrep}";
            VedPredmetTwo = (string)CommandSql.ExecuteScalar();
            VedPredmet = "Преподаватель. Ведущий предмет: " + (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_Телефона] from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Phone = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [E_mail]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Mail = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Adress = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select  DATEPART(YEAR,getdate()) - DATEPART(YEAR,[Дата_Рождения]) from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Age = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [FK_Закреплённая_группа]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Group = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Имя]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Ima = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Фамилия]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Fam = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Отчество]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Otch = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"SELECT convert(varchar, [Дата_Рождения], 101) from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            DataRosh = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Adress = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Краткая_Информация]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            InfoMe = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Дополнительный_Предмет]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            DopPredmet = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Специальность]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            Spec = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Ведущий_Кружок]  from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            VedEllipse = (string)CommandSql.ExecuteScalar();


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
