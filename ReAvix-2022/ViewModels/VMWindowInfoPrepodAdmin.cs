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
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowInfoPrepodAdmin
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        int Count;

        public byte[] Image;

        public List<int> MassivNomerPrep;

        public BitmapImage newBitmapImage;

        private static byte[] getString(Object o)
        {
            if (o == DBNull.Value) return null;
            return (byte[])o;
        }
        public VMWindowInfoPrepodAdmin()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection;
        }
        public void AddCardPrepod(out List<Grid> GridOut)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(Номер_Преподавателя) from [Преподаватели]";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_Преподавателя] from [Преподаватели]";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            MassivNomerPrep = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerPrep.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            List<Grid> GridPrep = new List<Grid>();

            LinearGradientBrush LGB = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(36, 147, 209), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(51, 88, 220), 0.95));

            DropShadowEffect dropShadowEffect = new DropShadowEffect
            {
                Color = Colors.Black,
                ShadowDepth = 5,
                BlurRadius = 5
            };
            var bc = new BrushConverter();


            for (int i = 0; i < Count; i++)
            {
                Grid grid = new Grid
                {
                    Height = 400,
                    Width = 620,
                };

                Border border = new Border
                {
                    Width = 620,
                    Height = 400,
                    CornerRadius = new System.Windows.CornerRadius(10),
                    Background = LGB,
                    Effect = dropShadowEffect,

                };

                CommandSql.CommandText = $"select [Фотография] from [Преподаватели] where [Номер_Преподавателя] = {MassivNomerPrep[i]}";
                CommandSql.Connection = _Connection;

                var Item = CommandSql.ExecuteScalar();

                if (getString(Item) == null)
                {
                    BitmapImage bit = new BitmapImage(new Uri("/Resources/Images/image_Holder (2).png", UriKind.Relative));
                    newBitmapImage = bit;
                }
                else
                {
                    CommandSql.CommandText = $"select [Фотография] from [Преподаватели] where [Номер_Преподавателя] = {MassivNomerPrep[i]}";
                    Image = (byte[])CommandSql.ExecuteScalar();

                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    newBitmapImage = new BitmapImage();
                    newBitmapImage.BeginInit();
                    newBitmapImage.StreamSource = ms;
                    newBitmapImage.EndInit();
                }


                TextBlock text_Caption = new TextBlock
                {
                    Text = "Карточка классного руководителя",
                    FontSize = 24,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 15, 0, 0),
                    Cursor = Cursors.Hand

                };

                Image popupBox = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Source = newBitmapImage,
                    Margin = new Thickness(10),
                    Stretch= Stretch.Uniform
                };
                Border borderBackgroundImage = new Border
                {
                    Width = 310,
                    Height = 320,
                    CornerRadius = new System.Windows.CornerRadius(5),
                    Background = Brushes.White,
                    Effect = dropShadowEffect,
                    HorizontalAlignment= HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(10,50,0,20)
                };

                StackPanel stackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 300,
                    Margin = new Thickness(0,60,20,0),
                };

                CommandSql.CommandText = $"select [Фамилия] + ' ' + [Имя] + ' ' + Отчество as FIO from [Преподаватели] where [Номер_Преподавателя] = {MassivNomerPrep[i]} group by [Фамилия],[Имя],Отчество";


                TextBlock Fio = new TextBlock
                {
                    Text = "ФИО: " + (string)CommandSql.ExecuteScalar(),
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light SemiCondensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = System.Windows.Media.Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 0, 0, 0),
                    Cursor = Cursors.Hand,
                    

                };

                CommandSql.CommandText = $"select [Номер_Телефона]  from [Преподаватели] where [Номер_Преподавателя] = {MassivNomerPrep[i]}";

                TextBlock Phone = new TextBlock
                {
                    Text = "Номер телефона: " + (string)CommandSql.ExecuteScalar(),
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                CommandSql.CommandText = $"select [E_mail]  from [Преподаватели] where [Номер_Преподавателя] = {MassivNomerPrep[i]}";

                TextBlock Email = new TextBlock
                {
                    Text = "E-mail: " + (string)CommandSql.ExecuteScalar(),
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                CommandSql.CommandText = $"select [FK_Закреплённая_группа]  from [Преподаватели] where [Номер_Преподавателя] = {MassivNomerPrep[i]}";

                TextBlock Group = new TextBlock
                {
                    Text = "Закрепленная группа: " + (string)CommandSql.ExecuteScalar(),
                    FontSize = 22,
                    FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed"),
                    FontWeight = FontWeights.Regular,
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 0, 0, 0)
                };

                BitmapImage bitImage = new BitmapImage(new Uri("/Resources/Images/icon_Arrows.png", UriKind.Relative));

                Image LeftArrow = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Source = bitImage,
                    Cursor = Cursors.Hand,
                    Margin = new Thickness(0,0,20,20),
                    Height = 30,
                    Width = 30
                };

                grid.Children.Add(border);
                grid.Children.Add(text_Caption);
                grid.Children.Add(borderBackgroundImage);
                borderBackgroundImage.Child = popupBox;
                stackPanel.Children.Add(Fio);
                stackPanel.Children.Add(Phone);
                stackPanel.Children.Add(Email);
                stackPanel.Children.Add(Group);
                grid.Children.Add(LeftArrow);

                grid.Children.Add(stackPanel);

                GridPrep.Add(grid);
            }
            _Connection.Close();
            GridOut = GridPrep;       
        }
    }
}
