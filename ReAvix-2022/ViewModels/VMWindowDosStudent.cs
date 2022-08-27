using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ReAvix_2022.Views;
using SkiaSharp;
using Syncfusion.UI.Xaml.ProgressBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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

        public void AddSkils(out List<Grid> bordersOut,int NumberSt)
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

                Border border = new Border
                {
                    Width = 210,
                    Height = 240,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    Background = LGB
                };
                CommandSql.CommandText = $"select [Категория_Навыка] from [Навыки] where [Номер_Навыка] = {MassivNomerSkils[i]}";



                TextBlock NameKategoria = new TextBlock
                {
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Height = 50,
                    Width = 150,
                    Margin = new Thickness(0,0,0,10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center
                };
                NameKategoria.Text = (string)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select CAST([Мастерство_Навыка] AS float) * 10 from [Навыки] where [Номер_Навыка] = {MassivNomerSkils[i]}";

                double Number = (double)CommandSql.ExecuteScalar();


                BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/icon_RightArrow.png", UriKind.Relative));

                Image popupBox = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0,0,10,10),
                    Source = bit,
                    Cursor = Cursors.Hand
                };


                SfCircularProgressBar Circular = new SfCircularProgressBar { Progress = Number, ProgressColor = new SolidColorBrush(Colors.Aqua),IndicatorInnerRadius = 0.6,IndicatorOuterRadius = 0.75,TrackOuterRadius = 0.7,TrackInnerRadius= 0.65,ShowProgressValue= true,IndicatorCornerRadius =5};
                Circular.Margin = new Thickness(0,0,0,50);
                border.Child = popupBox;
                grid.Children.Add(border);
                grid.Children.Add(Circular);
                grid.Children.Add(NameKategoria);

                Borders.Add(grid);
            }
            bordersOut = Borders;

        }
    }
}
