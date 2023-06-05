using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
#pragma warning disable CS0105 // Директива using для "System.Collections.Generic" ранее встречалась в этом пространстве имен
using System.Collections.Generic;
#pragma warning restore CS0105 // Директива using для "System.Collections.Generic" ранее встречалась в этом пространстве имен
using System.Collections.ObjectModel;
#pragma warning disable CS0105 // Директива using для "System.Configuration" ранее встречалась в этом пространстве имен
using System.Configuration;
#pragma warning restore CS0105 // Директива using для "System.Configuration" ранее встречалась в этом пространстве имен
#pragma warning disable CS0105 // Директива using для "System.Data.SqlClient" ранее встречалась в этом пространстве имен
using System.Data.SqlClient;
#pragma warning restore CS0105 // Директива using для "System.Data.SqlClient" ранее встречалась в этом пространстве имен


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
        public int KolvoStudent { get; set; }

        public List<Grid> Grids;
        public List<string> ListNamePredmet = new List<string>();
        private string Day; // Объявление переменных
        private string Number;
        private string Name;
        public string NameGroup;
        public string FI;
        public System.Data.DataTable dataTable;
        public System.Data.DataTable dataTableOtclStudent;
        public System.Data.DataTable dataTableOtchenokStudent;
        public System.Data.DataTable dataTableOtchenokAllStudent;
        public System.Data.DataTable dataTableOtchenokThreeStudent;


        public VMWindowStatisticGroupPrep(int NumberSt)
        {
            NomerPrep = NumberSt;

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = $"select [Имя] from [Преподаватели] where [Номер_Преподавателя] = {NumberSt} "; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения
            Name = (string)CommandSql.ExecuteScalar(); // Выполнение запроса

            CommandSql.CommandText = $"select Фамилия + ' ' + Имя + ' ' + Отчество as 'ФИО' from [Преподаватели] where [Номер_Преподавателя] = {NumberSt} "; // Создание запроса
            FI= (string)CommandSql.ExecuteScalar();

            _Connection.Close(); // Закрытие подключения
            GetAndViewData();
;
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
            NameGroup = (string)CommandSql.ExecuteScalar();

            GetListStudent();
            GetListOtclStudent();
            GetListOtchenokStudent();
            GetListOtchenokAllStudent();
            GetListThreelStudent();
            SetViewNamePredmet();

            CommandSql.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
            CommandSql.Connection = _Connection;
            int Count = (int)CommandSql.ExecuteScalar();

            KolvoStudent = Count;

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
        List<double> MassivOchenkaCount;
        List<string> MassivStringStudent;
        public void GetAvgPredmet()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select [FK_Закреплённая_группа] from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            CommandSql.Connection = _Connection;
            string NameGroup = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select COUNT(DISTINCT([Название_Предмета])) from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета";
            int Count = (int)CommandSql.ExecuteScalar();

            Grids = new List<Grid>();

            CommandSql.CommandText = $"select ROUND(AVG(CAST([Оценка] as FLOAT)),1) from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}'  and FK_Номер_Предмета = Номер_Предмета GROUP BY Номер_Предмета";
            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();
            MassivOchenkaCount = new List<double>();
            while (sqlDataReader.Read())
            {
                MassivOchenkaCount.Add((double)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            CommandSql.CommandText = $"select [Название_Предмета] from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета group by FK_Номер_Предмета,Название_Предмета";
            SqlDataReader sqlDataReader1 = CommandSql.ExecuteReader();
            MassivStringStudent = new List<string>();
            while (sqlDataReader1.Read())
            {
                MassivStringStudent.Add((string)sqlDataReader1.GetValue(0));
            }
            sqlDataReader1.Close();



            for (int i = 0; i < Count; i++)
            {
                Grid grid = new Grid
                {
                    Width = 324 
                };

                Label AvgPredmet = new Label
                {
                    Content = MassivOchenkaCount[i],
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Margin = new System.Windows.Thickness(0, 0, 0, 0),
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 20
                };

                TextBlock NamePredmet = new TextBlock
                {
                    Text = MassivStringStudent[i],
                    TextWrapping = System.Windows.TextWrapping.Wrap,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Margin = new System.Windows.Thickness(40, 0, 0, 0),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontSize = 20
                };
                grid.Children.Add(NamePredmet);
                grid.Children.Add(AvgPredmet);
                Grids.Add(grid);
            }
            _Connection.Close();
        }

        public static ObservableCollection<ISeries> Series { get; set; }
        public static ObservableCollection<ObservablePoint> observables;

        List<double> listOchenok;
        List<int> listDate;

       // int NomerPred, int NumberSt, int IndexMontch,
        //public void AddGraph(out ObservableCollection<ISeries> SeriesOut)
        //{
        //    if (Series == null || observables == null) // Проверка на null, поля должны быть пустые
        //    {

        //    }
        //    else
        //    {
        //        Series.Clear();
        //        observables.Clear();
        //    }

        //    _Connection.Open();
        //    CommandSql.Connection = _Connection;


        //    CommandSql.CommandText = $" SELECT DISTINCT(DATEPART(MONTH,[Дата])) from [Оценки_2] WHERE [ФИО_Студента] = 'Сердцев Дмитрий Витальевич'";
        //    SqlDataReader sqlDataReader1 = CommandSql.ExecuteReader();
        //    listDate = new List<int>();

        //    while (sqlDataReader1.Read())
        //    {
        //        listDate.Add((int)sqlDataReader1.GetValue(0));
        //    }
        //    sqlDataReader1.Close();

        //    CommandSql.CommandText = $"select ROUND(AVG(CAST([Оценка] as FLOAT)),1)  from [Оценки_2] where [Название_Предмета] = 'Математика' and [ФИО_Студента] = 'Сердцев Дмитрий Витальевич' and DATEPART(MONTH,[Дата]) = 09";
        //    SqlDataReader sqlDataReader = CommandSql.ExecuteReader();
        //    listOchenok = new List<double>();

        //    while (sqlDataReader.Read())
        //    {
        //        listOchenok.Add((double)sqlDataReader.GetValue(0));
        //    }
        //    sqlDataReader.Close();


        //    observables = new ObservableCollection<ObservablePoint>
        //    {
        //        new ObservablePoint(0,0)
        //    };


        //    for (int i = 0; i < 1; i++)
        //    {
        //        Series = new ObservableCollection<ISeries>
        //        {
        //            new LineSeries<ObservablePoint>
        //            {
        //                Values = observables,
        //                Fill = null
        //            }
        //        };

        //        observables.Add(new ObservablePoint(listDate[i], listOchenok[i]));
        //    }
        //    _Connection.Close();
        //    SeriesOut = Series;
        //}
        public void GetListStudent()
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,Номер_Телефона as 'Номер телефона',convert(varchar, [Дата_Рождения], 101) as 'Дата рождения' from [Студенты] where FK_Номер_Группы = '{NameGroup}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTable = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTable);
        }
        public void GetListOtclStudent()
        {
            CommandSql.CommandText = $"SELECT Фамилия,Имя,Отчество FROM Студенты\r\nWHERE NOT EXISTS  (\r\n SELECT *\r\n FROM Оценки\r\n WHERE FK_Номер_Студента = Номер_Студента and DATEPART(MONTH,getdate()) = DATEPART(MONTH,Дата)\r\n GROUP BY FK_Номер_Предмета,FK_Номер_Студента,FK_Номер_Предмета\r\n HAVING ROUND(AVG(CAST([Оценка] as FLOAT)),1) < 4.4\r\n) and FK_Номер_Группы = '{NameGroup}'\r\n";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtclStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtclStudent);
        }
        public void GetListOtchenokStudent()
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,ROUND(AVG(CAST([Оценка] as FLOAT)),1) as 'Средняя оценка',Название_Предмета as 'Название предмета' from Студенты,Оценки,Предметы where FK_Номер_Студента = Номер_Студента and FK_Номер_Предмета = Номер_Предмета and DATEPART(MONTH,getdate()) = DATEPART(MONTH,Дата) and FK_Номер_Группы = '{NameGroup}' group by Фамилия,Имя,Отчество,Название_Предмета \r\n";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtchenokStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtchenokStudent);
        }
        public void GetListOtchenokAllStudent()
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,ROUND(AVG(CAST([Оценка] as FLOAT)),1) as 'Средняя оценка',Название_Предмета as 'Название предмета' from Студенты,Оценки,Предметы where FK_Номер_Студента = Номер_Студента and FK_Номер_Предмета = Номер_Предмета and FK_Номер_Группы = '{NameGroup}' group by Фамилия,Имя,Отчество,Название_Предмета \r\n";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtchenokAllStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtchenokAllStudent);
        }
        public void GetListThreelStudent()
        {
            CommandSql.CommandText = $"SELECT Фамилия,Имя,Отчество FROM Студенты\r\nWHERE EXISTS (\r\n SELECT *\r\n FROM Оценки\r\n WHERE FK_Номер_Студента = Номер_Студента and DATEPART(MONTH,getdate()) = DATEPART(MONTH,Дата) and FK_Номер_Группы = '{NameGroup}'\r\n GROUP BY FK_Номер_Предмета\r\n HAVING ROUND(AVG(CAST([Оценка] as FLOAT)),1) < 3.4 \r\n)";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtchenokThreeStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtchenokThreeStudent);
        }
        private void SetViewNamePredmet()
        {
            CommandSql.CommandText = $"select Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NomerPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета";
            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ListNamePredmet.Add((string)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();
        }
        public void SearchFioStudent(string Fio)
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,ROUND(AVG(CAST([Оценка] as FLOAT)),1) as 'Средняя оценка',Название_Предмета as 'Название предмета' from Студенты,Оценки,Предметы where FK_Номер_Студента = Номер_Студента and FK_Номер_Предмета = Номер_Предмета and Фамилия LIKE '{Fio}%' and FK_Номер_Группы = '{NameGroup}' group by Фамилия,Имя,Отчество,Название_Предмета \r\n";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtchenokAllStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtchenokAllStudent);
        }
        public void SearchFioAndImaStudent(string Fio,string Ima)
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,ROUND(AVG(CAST([Оценка] as FLOAT)),1) as 'Средняя оценка',Название_Предмета as 'Название предмета' from Студенты,Оценки,Предметы where FK_Номер_Студента = Номер_Студента and FK_Номер_Предмета = Номер_Предмета and Фамилия LIKE '{Fio}%' and Имя like '{Ima}%' and FK_Номер_Группы = '{NameGroup}' group by Фамилия,Имя,Отчество,Название_Предмета \r\n";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtchenokAllStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtchenokAllStudent);
        }
        public void SearchFioNamePredmetStudent(string NamePredmet)
        {
            CommandSql.CommandText = $"select Фамилия,Имя,Отчество,ROUND(AVG(CAST([Оценка] as FLOAT)),1) as 'Средняя оценка',Название_Предмета as 'Название предмета' from Студенты,Оценки,Предметы where FK_Номер_Студента = Номер_Студента and FK_Номер_Предмета = Номер_Предмета and Название_Предмета = '{NamePredmet}' and FK_Номер_Группы = '{NameGroup}' group by Фамилия,Имя,Отчество,Название_Предмета \r\n";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandSql);
            dataTableOtchenokAllStudent = new System.Data.DataTable("Номер_Студента");
            sqlDataAdapter.Fill(dataTableOtchenokAllStudent);
        }
    }
}
