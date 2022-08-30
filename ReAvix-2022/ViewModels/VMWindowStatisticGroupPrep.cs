using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowStatisticGroupPrep
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        public int NomerPrep;

        public string Date { get; set; }
        public string GoodTime { get; set; }

        const string GoodOne = "Доброе утро"; // Создание констант с фразами
        const string GoodTwo = "Доброй день";
        const string GoodThree = "Добрый вечер";
        const string GoodFour = "Доброй ночи";

        public int RespectfulOmissions { get; set; }
        public int DisrespectfulOmissions { get; set; }
        public int AbsencesIllness { get; set; }



        private string Day; // Объявление переменных
        private string Number;
        private string Name;

        public VMWindowStatisticGroupPrep(int NumberSt)
        {
            NomerPrep = NumberSt;

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = $"select [Имя] from [Преподаватели] where [Номер_Преподавателя] = {NumberSt} "; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения
            Name = (string)CommandSql.ExecuteScalar(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            GetAndViewData();

        }
        private void GetAndViewData()
        {
            DateTime dateTime1 = DateTime.Now.Date; //Какое сегодня число
            Number = dateTime1.Day.ToString();

            DateTime time = DateTime.Now; //Выбор фразы по количеству времени на данный момент
            if ((time.Hour >= 6.0) && (time.Hour <= 12.0))
                GoodTime = GoodOne + ", " + Name;
            if (time.Hour > 12.0 && time.Hour < 15.0)
                GoodTime = GoodTwo + ", " + Name;
            if (time.Hour >= 15.0 && time.Hour < 21.0)
                GoodTime = GoodThree + ", " + Name;
            if (time.Hour >= 21.0 || time.Hour < 6.0)
                GoodTime = GoodFour + ", " + Name;

            DateTime date = DateTime.Today; // Месяц и год
            Day = date.ToString("Y");

            DateTime dateTime = DateTime.Now.Date; // День недели
            dateTime.DayOfWeek.ToString();
            Date = dateTime.ToString("dddd");
            NormalizeString(Date);
            Date = "Сегодня " + Date + ", " + Number + " " + Day;
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
        public void GetOmissionsStudent()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            List<int> MassivNomerStudent;
            CommandSql.CommandText = $"select [FK_Закреплённая_группа] from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            CommandSql.Connection = _Connection;
            string NameGroup = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
            CommandSql.Connection = _Connection;
            int Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select Номер_Студента from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();
            MassivNomerStudent = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerStudent.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();



            for (int i = 0; i < Count; i++)
            {
                CommandSql.CommandText = $"select Уважительные_Пропуски from [Пропуски] where [FK_Номер_Студента] = {MassivNomerStudent[i]}";
                RespectfulOmissions += (int)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select Неуважительные_Пропуски from [Пропуски] where [FK_Номер_Студента] = {MassivNomerStudent[i]}";
                DisrespectfulOmissions += (int)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select Пропуски_по_болезни from [Пропуски] where [FK_Номер_Студента] = {MassivNomerStudent[i]}";
                AbsencesIllness += (int)CommandSql.ExecuteScalar();










            }










            _Connection.Close();
        }

    }
}
