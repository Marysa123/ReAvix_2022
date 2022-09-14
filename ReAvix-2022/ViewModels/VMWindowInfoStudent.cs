using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Syncfusion.UI.Xaml.ProgressBar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowInfoStudent
    {
        int NomerStudent;
        int Count;
        int CountDos;

        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        public BitmapImage newBitmapImage;
        public static byte[] Image { get; set; }
        public List<int> MassivNomerSkils;
        public List<int> MassivNomerDos;
        public SeriesCollection seriesCollection { get; set; }
        public List<int> MassivNomerPredmet;
        List<Grid> MassivGrid;

        public string FI { get; set; }
        public string Cours { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string InfoMe { get; set; }


        public VMWindowInfoStudent(int NumberSt)
        {
            NomerStudent = NumberSt;
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
        }
        private static byte[] getString(Object o)
        {
            if (o == DBNull.Value) return null;
            return (byte[])o;
        }


        public void GetInfoStudentCard()
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
            Cours = "Студент(ка) " + (string)CommandSql.ExecuteScalar() + " курса";

            CommandSql.CommandText = $"select [Номер_Телефона] from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Phone = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [E_mail]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Mail = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Адрес]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Adress = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select  DATEPART(YEAR,getdate()) - DATEPART(YEAR,[Дата_Рождения]) from [Студенты] where [Номер_Студента] = {NomerStudent}";
            Age = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Краткая_Информация]  from [Студенты] where [Номер_Студента] = {NomerStudent}";
            InfoMe = (string)CommandSql.ExecuteScalar();

            _Connection.Close();



        }


        public void AddSkils(out List<Grid> bordersOut, int NumberSt)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT([Номер_Навыка]) from [Навыки] where [FK_Номер_Студента] = {NumberSt}";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_Навыка] from [Навыки] where [FK_Номер_Студента] = {NumberSt}";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            MassivNomerSkils = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerSkils.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            List<Grid> Borders = new List<Grid>();

            var bc = new BrushConverter();

            LinearGradientBrush LGB = new LinearGradientBrush();
            LGB.StartPoint = new Point(0, 0);
            LGB.EndPoint = new Point(1, 1);
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(36, 147, 209), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(51, 88, 220), 0.95));


            for (int i = 0; i < Count; i++)
            {
                Grid grid = new Grid
                {
                    Height = 240,
                    Width = 210,
                };

                DropShadowEffect dropShadowEffect = new DropShadowEffect
                {
                    Color = System.Windows.Media.Colors.Black,
                    ShadowDepth = 15,
                    BlurRadius = 20
                };

                Border border = new Border
                {
                    Width = 210,
                    Height = 240,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    Background = LGB,
                    Effect = dropShadowEffect,

                };
                CommandSql.CommandText = $"select [Категория_Навыка] from [Навыки] where [Номер_Навыка] = {MassivNomerSkils[i]}";



                TextBlock NameKategoria = new TextBlock
                {
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Height = 60,
                    Width = 190,
                    Margin = new Thickness(0, 0, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,

                };

                NameKategoria.Text = (string)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select CAST([Мастерство_Навыка] AS float) * 10 from [Навыки] where [Номер_Навыка] = {MassivNomerSkils[i]}";

                double Number = (double)CommandSql.ExecuteScalar();


                BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/images_information.png", UriKind.Relative));

                Image popupBox = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 35,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 10, 10, 20),
                    Source = bit,
                    Cursor = Cursors.Hand
                };


                SfCircularProgressBar Circular = new SfCircularProgressBar { Progress = Number, ProgressColor = new SolidColorBrush(Colors.Aqua), IndicatorInnerRadius = 0.6, IndicatorOuterRadius = 0.75, TrackOuterRadius = 0.7, TrackInnerRadius = 0.65, ShowProgressValue = true, IndicatorCornerRadius = 5 };
                Circular.Margin = new Thickness(0, 0, 0, 50);
                border.Child = popupBox;
                grid.Children.Add(border);
                grid.Children.Add(Circular);
                grid.Children.Add(NameKategoria);

                Borders.Add(grid);
            }
            bordersOut = Borders;

        }
        TextBlock MestoDos;
        TextBlock MestoDos1;
        public void AddDos(int NumberSt, out List<Grid> GridOut)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(Номер_Достижения) FROM Достижения where [FK_Номер_Студента] = {NumberSt}";
            CommandSql.Connection = _Connection;
            CountDos = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select (Номер_Достижения) FROM Достижения where [FK_Номер_Студента] = {NumberSt}";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            MassivNomerDos = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerDos.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            List<Grid> Borders = new List<Grid>();

            LinearGradientBrush LGB = new LinearGradientBrush();
            LGB.StartPoint = new Point(0, 0);
            LGB.EndPoint = new Point(1, 1);
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(57, 54, 176), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(128, 92, 174), 0.95));

            for (int i = 0; i < CountDos; i++)
            {
                Grid grid = new Grid
                {
                    Height = 240,
                    Width = 310,
                };

                DropShadowEffect dropShadowEffect = new DropShadowEffect
                {
                    Color = System.Windows.Media.Colors.Black,
                    ShadowDepth = 15,
                    BlurRadius = 20
                };

                Border border = new Border
                {
                    Width = 310,
                    Height = 240,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = LGB,
                    Effect = dropShadowEffect,

                };

                CommandSql.CommandText = $"select [Название_Соревнования] from Достижения where [Номер_Достижения] = {MassivNomerDos[i]}";



                TextBlock NameDos = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 24,
                    FontWeight = FontWeights.SemiBold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Height = 80,
                    Width = 120,
                    Margin = new Thickness(0, 10, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                };

                CommandSql.CommandText = $"select [Место_в_соревновании] from Достижения where [Номер_Достижения] = {MassivNomerDos[i]}";

                if ((string)CommandSql.ExecuteScalar() == "Участник")
                {
                    MestoDos1 = new TextBlock
                    {
                        Text = CommandSql.ExecuteScalar().ToString(),
                        Foreground = System.Windows.Media.Brushes.White,
                        FontSize = 24,
                        FontWeight = FontWeights.Regular,
                        FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                        Height = 40,
                        Width = 110,
                        Margin = new Thickness(0, 0, 55, 8),
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                    };

                }
                else
                {
                    MestoDos = new TextBlock
                    {
                        Text = CommandSql.ExecuteScalar() + " Место",
                        Foreground = System.Windows.Media.Brushes.White,
                        FontSize = 24,
                        FontWeight = FontWeights.Regular,
                        FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                        Height = 40,
                        Width = 90,
                        Margin = new Thickness(0, 0, 55, 8),
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                    };
                }

                BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/icon_Trophy.png", UriKind.Relative));

                Image popupBox = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 20, 20),
                    Source = bit,
                };

                BitmapImage bit1 = new BitmapImage(new Uri("/Resources/Images/icon_Arrows.png", UriKind.Relative));

                Image popupBox1 = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 25,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 20, 20, 0),
                    Source = bit1,
                    Cursor = Cursors.Hand

                };

                grid.Children.Add(border);
                grid.Children.Add(NameDos);

                if (CommandSql.ExecuteScalar().ToString() == "Участник")
                {
                    grid.Children.Add(MestoDos1);
                }
                else
                {
                    grid.Children.Add(MestoDos);
                }

                grid.Children.Add(popupBox);
                grid.Children.Add(popupBox1);

                Borders.Add(grid);

            }
            GridOut = Borders;
        }
        public void AddPredmet(out List<Grid> Massivgrid)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(DISTINCT [FK_Номер_Предмета]) from [Оценки] where [FK_Номер_Студента] = {NomerStudent}";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select DISTINCT ([FK_Номер_Предмета]) from [Оценки] where [FK_Номер_Студента] = {NomerStudent}";

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
                    Width = 380,
                    Height = 260,
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

                Label NamePredmet = new Label
                {
                    Content = CommandSql.ExecuteScalar(),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(15, 15, 0, 0),
                    Height = 35,
                    Width = 260,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top

                };
                CommandSql.CommandText = $"SELECT ROUND(AVG(CAST([Оценка] as FLOAT)),1) from [Оценки] WHERE [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NomerStudent} and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";

                Label AVGPredmet = new Label
                {
                    Content = "                                AVG: " + CommandSql.ExecuteScalar(),
                    Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#3AFFDC"),
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(0, 15, 0, 0),
                    Height = 35,
                    Width = 260,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top

                };

                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NomerStudent} and [Оценка] = 5 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count5 = (int)CommandSql.ExecuteScalar();
                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NomerStudent} and [Оценка] = 4 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count4 = (int)CommandSql.ExecuteScalar();
                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NomerStudent} and [Оценка] = 3 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
                int Count3 = (int)CommandSql.ExecuteScalar();
                CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {MassivNomerPredmet[i]} and [FK_Номер_Студента] = {NomerStudent} and [Оценка] = 2 and DATEPART(MONTH,[Дата]) = DATEPART(MONTH,getdate())";
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
            Massivgrid = MassivGrid;

        }
    }
}
