using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAddPredmetsPrep
    {
        public int NomerPrep { get; set; }
        public VMWindowAddPredmetsPrep(int NumberPrep)
        {
            NomerPrep = NumberPrep;
        }

        int CountPredmets;
        public List<int> MassivNomerPredmets;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();


        public void ViewPredmets(out List<Grid> GridOut)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(Номер_Предмета) FROM [Предметы_Преподавателя] where [FK_Номер_Преподавателя] = {NomerPrep}";
            CommandSql.Connection = _Connection;
            CountPredmets = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select Номер_Предмета from [Предметы_Преподавателя] where [FK_Номер_Преподавателя] = {NomerPrep}";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            MassivNomerPredmets = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerPredmets.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            List<Grid> Borders = new List<Grid>();

            LinearGradientBrush LGB = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(57, 54, 176), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(128, 84, 174), 0.95));

            for (int i = 0; i < CountPredmets; i++)
            {
                Grid grid = new Grid
                {
                    Height = 210,
                    Width = 390,
                };

                DropShadowEffect dropShadowEffect = new DropShadowEffect
                {
                    Color = System.Windows.Media.Colors.Black,
                    ShadowDepth = 8,
                    BlurRadius = 12
                };

                Border border = new Border
                {
                    Width = 370,
                    Height = 210,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = LGB,
                    Effect = dropShadowEffect,

                };

                CommandSql.CommandText = $"select [Название_Предмета] from [Предметы_Преподавателя] where Номер_Предмета = {MassivNomerPredmets[i]}";

                TextBlock text_NamePredmet = new TextBlock
                {
                    Text = "Название предмета:",
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 21,
                    FontWeight = FontWeights.SemiBold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(25, 0, 0, 80),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                };

                TextBlock NamePredmet = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 17,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(25, 0, 0, 30),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Left,
                };

                TextBlock text_ShortInfo = new TextBlock
                {
                    Text = "Краткая информация о предмете",
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 22,
                    FontWeight = FontWeights.SemiBold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(0, 15, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                };

                CommandSql.CommandText = $"select [Ведущий_Преподаватель] from [Предметы_Преподавателя] where Номер_Предмета = {MassivNomerPredmets[i]}";
               
                TextBlock text_FioPrep = new TextBlock
                {
                    Text = "ФИО ведущего преподавателя:",
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 21,
                    FontWeight = FontWeights.SemiBold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(25, 50, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                };

                TextBlock FioPrep = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    Foreground = System.Windows.Media.Brushes.White,
                    FontSize = 17,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    Margin = new Thickness(25, 78, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                };

                BitmapImage bit1 = new BitmapImage(new Uri("/Resources/Images/icon_Arrows.png", UriKind.Relative));

                Image Arrows = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 25,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 30, 10),
                    Source = bit1,
                    Cursor = Cursors.Hand

                };

                grid.Children.Add(border);
                grid.Children.Add(NamePredmet);
                grid.Children.Add(FioPrep);
                grid.Children.Add(text_NamePredmet);
                grid.Children.Add(text_FioPrep);
                grid.Children.Add(text_ShortInfo);
                grid.Children.Add(Arrows);

                Borders.Add(grid);

            }
            GridOut = Borders;

        }
        public int CheckPredmets(int NomerPredmets, out int NomerSkilsOut)
        {
            _Connection.Close();
            CommandSql.Connection = _Connection;
            _Connection.Open();
            CommandSql.CommandText = $"select Номер_Предмета from Предметы_Преподавателя where Номер_Предмета = {NomerPredmets}";
            var Nomer = CommandSql.ExecuteScalar();
            if (Nomer == null)
            {
                return NomerSkilsOut = 1;
            }
            else
            {
                return NomerSkilsOut = 0;
            }

        }

    }
}
