using ReAvix_2022.Models;
using ReAvix_2022.WindowUserControl;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Media;


namespace ReAvix_2022.ViewModels
{

    internal class VMWindowStatisticStudent
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        const string GoodOne = "Доброе утро, ";
        const string GoodTwo = "Доброй день, ";
        const string GoodThree = "Добрый вечер, ";
        const string GoodFour = "Доброй ночи, ";

        public string Date { get; set; }
        public string GoodTime { get; set; }
        public string Day { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public byte RespectfulOmissions { get; set; }
        public byte DisrespectfulOmissions { get; set; }
        public byte AbsencesIllness { get; set; }


        public VMWindowStatisticStudent(int nr_Student)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select [Имя] from [Студенты] where [Номер_Студента] = {nr_Student} ";
            CommandSql.Connection = _Connection;
            Name = (string)CommandSql.ExecuteScalar();
            _Connection.Close();
            ViewingDate();

            GetOmissionsStudent(nr_Student: nr_Student, "Уважительные_Пропуски", out byte ReOmissons);
            RespectfulOmissions = ReOmissons;
            GetOmissionsStudent(nr_Student: nr_Student, "Неуважительные_Пропуски", out byte NoOmissons);
            DisrespectfulOmissions = NoOmissons;
            GetOmissionsStudent(nr_Student: nr_Student, "Пропуски_по_болезни", out byte BolOmissons);
            AbsencesIllness = BolOmissons;

        }

        public void GetOmissionsStudent(int nr_Student, string Column, out byte Omissons)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [{Column}] from [Пропуски] where [FK_Номер_Студента] = {nr_Student}";
            Omissons = (byte)CommandSql.ExecuteScalar();
            _Connection.Close();
        }


        private void ViewingDate()
        {
            DateTime dateTime1 = DateTime.Now.Date; //Какое сегодня число
            Number = dateTime1.Day.ToString();

            DateTime time = DateTime.Now; //Выбор фразы по количеству времени на данный момент
            if ((time.Hour >= 6.0) && (time.Hour <= 12.0))
                GoodTime = GoodOne;
            if (time.Hour > 12.0 && time.Hour < 15.0)
                GoodTime = GoodTwo;
            if (time.Hour >= 15.0 && time.Hour < 21.0)
                GoodTime = GoodThree;
            if (time.Hour >= 21.0 || time.Hour < 6.0)
                GoodTime = GoodFour;

            DateTime date = DateTime.Today; // Месяц и год
            Day = date.ToString("Y");

            DateTime dateTime = DateTime.Now.Date; // День недели
            dateTime.DayOfWeek.ToString();
            Date = dateTime.ToString("dddd");
            NormalizeString(Date);
            Date = "Сегодня " + Date + ",";
        }
        unsafe void NormalizeString(string str)
        {
            fixed (char* pBase = str)
            {
                char prev = '\0';
                for (char* ptr = pBase; ptr < pBase + str.Length; prev = *ptr++)
                    if (char.IsLetter(*ptr))
                        *ptr = char.IsLetter(prev) ? char.ToLower(*ptr) : char.ToUpper(*ptr);
            }
        }
    }
}
