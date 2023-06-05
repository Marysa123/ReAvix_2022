using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAboutDos
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        int NumberStudent;
        int NumberDos;

        public string SourceImage { get; set; }
        public string MestoSorev { get; set; }
        public string MestoPro { get; set; }
        public string NameSorev { get; set; }

        public static byte[] Image { get; set; }
        public byte[] DopImage { get; set; }

        public BitmapImage newBitmapImage;
        public BitmapImage newBitmapImageTwo;


        public VMWindowAboutDos(int NomerDos,int NomerSt)
        {
            NumberStudent = NomerSt;
            NumberDos = NomerDos;
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection;

            GetDataSkils();
        }

        public VMWindowAboutDos()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection;
        }
        /// <summary>
        /// Удаление достижения
        /// </summary>
        public void DeleteDos()
        {
            _Connection.Open();
            CommandSql.CommandText = $"delete [Достижения] where Номер_Достижения = {NumberDos}";
            CommandSql.ExecuteNonQuery();
            _Connection.Close();
        }
        /// <summary>
        /// Метод для проверки существует ли данное достижение
        /// </summary>
        /// <param name="NomerDos">Номер достижения</param>
        /// <param name="NomerDosOut">Выходной параметр номера достижения</param>
        /// <returns></returns>
        public int CheckSkils(int NomerDos, out int NomerDosOut)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select Номер_Достижения from Достижения where Номер_Достижения = {NomerDos}";
            var Nomer = CommandSql.ExecuteScalar();
            if (Nomer == null)
            {
                return NomerDosOut = 1;
            }
            else
            {
                return NomerDosOut = 0;
            }
        }
        /// <summary>
        /// Получение данных о достижении
        /// </summary>
        public void GetDataSkils()
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Место_в_соревновании] from Достижения where [Номер_Достижения] = {NumberDos} and [FK_Номер_Студента] = {NumberStudent}";
            MestoSorev = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Место_Проведения] from Достижения where [Номер_Достижения] = {NumberDos} and [FK_Номер_Студента] = {NumberStudent}";
            MestoPro = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Название_Соревнования] from Достижения where [Номер_Достижения] = {NumberDos} and [FK_Номер_Студента] = {NumberStudent}";
            NameSorev = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Изображение] from Достижения where [Номер_Достижения] = {NumberDos} and [FK_Номер_Студента] = {NumberStudent}";
            Image = (byte[])CommandSql.ExecuteScalar();

            System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
            ms.Seek(0, System.IO.SeekOrigin.Begin);

            newBitmapImage = new BitmapImage();
            newBitmapImage.BeginInit();
            newBitmapImage.StreamSource = ms;
            newBitmapImage.EndInit();

            CommandSql.CommandText = $"select [Дополнительное_Изображение] from Достижения where [Номер_Достижения] = {NumberDos} and [FK_Номер_Студента] = {NumberStudent}";
            DopImage = (byte[])CommandSql.ExecuteScalar();

            System.IO.MemoryStream ms1 = new System.IO.MemoryStream(DopImage);
            ms.Seek(0, System.IO.SeekOrigin.Begin);

            newBitmapImageTwo = new BitmapImage();
            newBitmapImageTwo.BeginInit();
            newBitmapImageTwo.StreamSource = ms1;
            newBitmapImageTwo.EndInit();

            _Connection.Close();
        }
    }
}
