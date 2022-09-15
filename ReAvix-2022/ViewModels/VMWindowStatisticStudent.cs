
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{

    internal class VMWindowStatisticStudent
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        const string GoodOne = "Доброе утро"; // Создание констант с фразами
        const string GoodTwo = "Доброй день";
        const string GoodThree = "Добрый вечер";
        const string GoodFour = "Доброй ночи";

        private string Day; // Объявление переменных
        private string Number;
        private string Name;
        public int NumberStudent;

        private int Count;

        public SeriesCollection seriesCollection { get; set; }
        public  List<int> MassivNomerPredmet;
        List<Grid> MassivGrid;

        // Объявление полей
        public string Date { get; set; }
        public string GoodTime { get; set; }
        public int RespectfulOmissions { get; set; }
        public int DisrespectfulOmissions { get; set; }
        public int AbsencesIllness { get; set; }

        public VMWindowStatisticStudent(int NumberSt)
        {
            NumberStudent = NumberSt;

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = $"select [Имя] from [Студенты] where [Номер_Студента] = {NumberStudent} "; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения
            Name = (string)CommandSql.ExecuteScalar(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            GetAndViewData();

            GetOmissionsStudent("Уважительные_Пропуски", out int ReOmissons); // Вызов метода с передачей параметров
            RespectfulOmissions = ReOmissons;

            GetOmissionsStudent("Неуважительные_Пропуски", out int NoOmissons); // Вызов метода с передачей параметров
            DisrespectfulOmissions = NoOmissons;

            GetOmissionsStudent("Пропуски_по_болезни", out int BolOmissons); // Вызов метода с передачей параметров
            AbsencesIllness = BolOmissons;

        }
        /// <summary>
        /// Метод получения пропусков студента
        /// </summary>
        /// <param name="Column">Наименование столбца</param>
        /// <param name="Omissons">Выходной параметр с результатом</param>
        public void GetOmissionsStudent(string Column, out int Omissons)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [{Column}] from [Пропуски] where [FK_Номер_Студента] = {NumberStudent}";
            Omissons = (int)CommandSql.ExecuteScalar();
            _Connection.Close();
        }

        /// <summary>
        /// Получение и отображение дат, фразы и имени студента
        /// </summary>
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
        /// <summary>
        /// Делает 1 символ строки заглавным
        /// </summary>
        /// <param name="str"></param>
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
        public List<Grid> AddPredmet(out List<Grid> Massivgrid)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(DISTINCT [FK_Номер_Предмета]) from [Оценки] where [FK_Номер_Студента] = {NumberStudent}";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select DISTINCT ([FK_Номер_Предмета]) from [Оценки] where [FK_Номер_Студента] = {NumberStudent}";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();
            MassivNomerPredmet = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerPredmet.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            var bc = new System.Windows.Media.BrushConverter();

            List<Grid> Grids = new List<Grid>();


            for (int i = 0; i < Count; i++)
            {
                Grid ContainerGrid = new Grid
                {
                    Width = 400,
                    Height = 280,
                    Margin = new System.Windows.Thickness(0, 0, 0, 0)
                };


                DropShadowEffect dropShadowEffect = new DropShadowEffect
                {
                    Color = System.Windows.Media.Colors.Black,
                    ShadowDepth = 15,
                    BlurRadius = 20
                };

                Border BackGroundBorder = new Border
                {
                    Background = (System.Windows.Media.Brush)bc.ConvertFrom("#3446A9"),
                    CornerRadius = new System.Windows.CornerRadius(5),
                    Effect = dropShadowEffect,
                };


                CommandSql.CommandText = $"select [Название_предмета] from [Предметы] where [Номер_Предмета] = {MassivNomerPredmet[i]}";

                TextBlock NamePredmet = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(15, 15, 0, 0),
                    Height = 55,
                    Width = 260,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top

                };
                CommandSql.CommandText = $"SELECT ROUND(AVG(CAST([Оценка] as FLOAT)),1) from [Оценки] WHERE [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NumberStudent} and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";

                Label AVGPredmet = new Label
                {
                    Content = "                                Среднее: " + CommandSql.ExecuteScalar(),
                    Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#3AFFDC"),
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(0, 25, 20, 0),
                    Height = 35,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top

                };

                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NumberStudent} and [Оценка] = 5 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count5 = (int)CommandSql.ExecuteScalar();
                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NumberStudent} and [Оценка] = 4 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count4 = (int)CommandSql.ExecuteScalar();
                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NumberStudent} and [Оценка] = 3 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count3 = (int)CommandSql.ExecuteScalar();
                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NumberStudent} and [Оценка] = 2 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count2 = (int)CommandSql.ExecuteScalar();

                seriesCollection = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title ="Оценка 5",
                            Values = new ChartValues<ObservableValue> {new ObservableValue(Count5) },
                            DataLabels = true,
                            FontSize = 16,
                            Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#2195F2"),
                            Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#1C00ff00")

                        },
                        new PieSeries
                        {
                            Title ="Оценка 4",
                            Values = new ChartValues<ObservableValue> {new ObservableValue(Count4) },
                            DataLabels = true,
                            FontSize = 16,
                            Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#F34336"),
                            Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#1C00ff00")


                        },
                        new PieSeries
                        {
                            Title ="Оценка 3",
                            Values = new ChartValues<ObservableValue> {new ObservableValue(Count3) },
                            DataLabels = true,
                            FontSize = 16,
                            Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FEC007"),
                            Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#1C00ff00")

                        },
                        new PieSeries
                        {
                            FontSize = 16,
                            Title ="Оценка 2",
                            Values = new ChartValues<ObservableValue> {new ObservableValue(Count2) },
                            DataLabels = true,
                            Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#607D8A"),
                            Stroke = (System.Windows.Media.Brush)bc.ConvertFrom("#1C00ff00")

                        },
                };



                PieChart pieChart = new PieChart
                {
                    HoverPushOut = 10,
                    InnerRadius = 40,
                    Series = seriesCollection,
                    DataContext = seriesCollection,
                    LegendLocation = LegendLocation.Right,
                    Margin = new Thickness(0, 45, 10, 0),
                    Height = 200,
                    FontSize = 12,
                    Width = 310,
                    Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#ffffff"),



                };

                ((DefaultLegend)pieChart.ChartLegend).BulletSize = 16;
                ((DefaultLegend)pieChart.ChartLegend).FontSize = 16;
                ((DefaultTooltip)pieChart.DataTooltip).BulletSize = 20;
                ((DefaultTooltip)pieChart.DataTooltip).Background = System.Windows.Media.Brushes.Black;



                BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/icon_RightArrow.png", UriKind.Relative));

                Image popupBox = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(10),
                    Source = bit,
                    Cursor = Cursors.Hand
                };


                ContainerGrid.Children.Add(BackGroundBorder);
                ContainerGrid.Children.Add(pieChart);
                ContainerGrid.Children.Add(NamePredmet);
                ContainerGrid.Children.Add(AVGPredmet);
                ContainerGrid.Children.Add(popupBox);

                Grids.Add(ContainerGrid);
                MassivGrid = Grids;


            }
            _Connection.Close();
            return (Massivgrid = MassivGrid);

        }
    }
}
