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
    internal class VMWindowListStudentsPrep
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public int NomerPrep;
        int Count;

        public byte[] Image;

        public List<int> MassivNomerStudent;

        public BitmapImage newBitmapImage;

        public VMWindowListStudentsPrep(int NumberPrep)
        {
            NomerPrep = NumberPrep;
        }
        public VMWindowListStudentsPrep()
        {

        }

        private static byte[] getString(Object o)
        {
            if (o == DBNull.Value) return null;
            return (byte[])o;
        }

        public void AddStudent(out List<Grid> GridOut)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select [FK_Закреплённая_Группа] from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            CommandSql.Connection = _Connection;
            string ZakGroup = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{ZakGroup}'";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_Студента] from [Студенты] where [FK_Номер_Группы] = '{ZakGroup}'";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            MassivNomerStudent = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerStudent.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            List<Grid> GridStudent = new List<Grid>();

            LinearGradientBrush LGB = new LinearGradientBrush();
            LGB.StartPoint = new Point(0, 0);
            LGB.EndPoint = new Point(1, 1);
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(36, 147, 209), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(51, 88, 220), 0.95));

            DropShadowEffect dropShadowEffect = new DropShadowEffect
            {
                Color = System.Windows.Media.Colors.Black,
                ShadowDepth = 15,
                BlurRadius = 20
            };
            var bc = new System.Windows.Media.BrushConverter();


            for (int i = 0; i < Count; i++)
            {
                Grid grid = new Grid
                {
                    Height = 430,
                    Width = 300,
                };

                Border border = new Border
                {
                    Width = 300,
                    Height = 430,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    Background = LGB,
                    Effect = dropShadowEffect,

                };

                CommandSql.CommandText = $"select [Фотография] from [Студенты] where [Номер_Студента] = {MassivNomerStudent[i]}";
                CommandSql.Connection = _Connection;

                var Item = CommandSql.ExecuteScalar();

                if (getString(Item) == null)
                {
                    BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/image_Holder (2).png", UriKind.Relative));
                    newBitmapImage = bit;
                }
                else
                {
                    CommandSql.CommandText = $"select [Фотография] from [Студенты] where [Номер_Студента] = {MassivNomerStudent[i]}";
                    Image = (byte[])CommandSql.ExecuteScalar();

                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    newBitmapImage = new BitmapImage();
                    newBitmapImage.BeginInit();
                    newBitmapImage.StreamSource = ms;
                    newBitmapImage.EndInit();
                }


                Image popupBox = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Height = 300,
                    Width = 290,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 10, 0, 10),
                    Source = newBitmapImage,
                    Cursor = Cursors.Hand

                };

                CommandSql.CommandText = $"select [Фамилия] + ' ' + [Имя] as FIO from [Студенты] where [Номер_Студента] = {MassivNomerStudent[i]} group by [Фамилия],[Имя]";


                TextBlock Fio = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    FontSize = 24,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment= VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0,0,0,90),
                    Cursor = Cursors.Hand
                    
                };

                CommandSql.CommandText = $"select [Номер_Телефона]  from [Студенты] where [Номер_Студента] = {MassivNomerStudent[i]}";

                TextBlock Phone = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    FontSize = 20,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#2CFFD9"),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 0, 62)
                };


                Style style = Application.Current.FindResource("StyleButtonAllApplication") as Style;



                Button button = new Button
                {
                    Style = style,
                    Width = 150,
                    Height = 46,
                    Content = "Подробнее",
                    Margin = new Thickness(0, 0, 0, 10),
                    FontSize = 18,
                    HorizontalAlignment= HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed"),
                    IsEnabled = false,
                    Cursor = Cursors.Hand
                };

                grid.Children.Add(border);
                grid.Children.Add(popupBox);
                grid.Children.Add(Fio);
                grid.Children.Add(Phone);
                grid.Children.Add(button);

                GridStudent.Add(grid);
            }
            _Connection.Close();
            GridOut = GridStudent;
        }

    }
}
