using Syncfusion.UI.Xaml.ProgressBar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowDosStudent
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public int NumberStudent;
        int Count;

        public List<int> MassivNomerSkils;


        public VMWindowDosStudent(int NumberSt)
        {
            NumberStudent = NumberSt;
        }
        public VMWindowDosStudent()
        {

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
                    Width = 200,
                    Margin = new Thickness(0, 0, 0, 10),
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
                    Height = 25,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 10, 10, 0),
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

        int CountDos;
        public List<int> MassivNomerDos;
        TextBlock MestoDos;
        TextBlock MestoDos1;

        public static byte[] Image { get; set; }
        public BitmapImage newBitmapImage;



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
                    Height = 410,
                    Width = 390,
                };

                DropShadowEffect dropShadowEffect = new DropShadowEffect
                {
                    Color = System.Windows.Media.Colors.Black,
                    ShadowDepth = 15,
                    BlurRadius = 20
                };

                Border border = new Border
                {
                    Width = 380,
                    Height = 400,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = LGB,
                    Effect = dropShadowEffect,

                };


                CommandSql.CommandText = $"select [Изображение] from Достижения where [Номер_Достижения] = {MassivNomerDos[i]} and [FK_Номер_Студента] = {NumberStudent}";
                Image = (byte[])CommandSql.ExecuteScalar();

                System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = ms;
                newBitmapImage.EndInit();


                Image popupBox2 = new Image
                {
                    Height = 290,
                    Width = 290,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0,0,0,80),
                    Source = newBitmapImage
                };



                CommandSql.CommandText = $"select [Название_Соревнования] from Достижения where [Номер_Достижения] = {MassivNomerDos[i]}";



                TextBlock NameDos = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 20,
                    FontWeight = FontWeights.SemiBold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(0, 0, 0, 45),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
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
                        FontSize = 20,
                        FontWeight = FontWeights.Regular,
                        FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                        Height = 40,
                        Width = 110,
                        Margin = new Thickness(0, 0, 40, 0),
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
                        FontSize = 20,
                        FontWeight = FontWeights.Regular,
                        FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                        Height = 40,
                        Width = 90,
                        Margin = new Thickness(0, 0, 55, 0),
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
                    Margin = new Thickness(0, 0, 20, 15),
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
                grid.Children.Add(popupBox);
                grid.Children.Add(popupBox2);
                grid.Children.Add(popupBox1);


                CommandSql.CommandText = $"select [Место_в_соревновании] from Достижения where [Номер_Достижения] = {MassivNomerDos[i]}";

                if (CommandSql.ExecuteScalar().ToString() == "Участник")
                {
                    grid.Children.Add(MestoDos1);
                }
                else
                {
                    grid.Children.Add(MestoDos);
                }

                Borders.Add(grid);

            }
            GridOut = Borders;
        }
    }
}
