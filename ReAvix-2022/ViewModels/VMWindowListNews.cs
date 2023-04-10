using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowListNews
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        BitmapImage newBitmapImage;


        public List<int> MassivNomerNews;
        public List<Expander> expanders;
        public static byte[] Image { get; set; }
        public static byte[] ImageTwo { get; set; }
        public static byte[] ImageThree { get; set; }


        int Count;
        
        public void GetListAndShowNews()
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select Count(Номер_Новости) from Новости";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select Номер_Новости from Новости";

            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();

            MassivNomerNews = new List<int>();
            while (sqlDataReader.Read())
            {
                MassivNomerNews.Add((int)sqlDataReader.GetValue(0));
            }

            expanders = new List<Expander>();

            LinearGradientBrush LGB = new LinearGradientBrush();
            LGB.StartPoint = new Point(0, 0);
            LGB.EndPoint = new Point(1, 1);
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(11, 60, 120), 0.15));
            LGB.GradientStops.Add(new GradientStop(Color.FromRgb(04,40, 136), 0.95));


            sqlDataReader.Close();
            for (int i = 0; i < Count; i++)
            {
                Expander expander = new Expander();
                expander.Margin = new Thickness(20, 0, 0, 0);
                expander.Width = 1380;
                expander.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                expander.Background = LGB;
                expander.Foreground = Brushes.White;

                Grid gridContainer = new Grid();


                Border backgroundBorder = new Border();
                backgroundBorder.Background = Brushes.White;
                backgroundBorder.CornerRadius = new CornerRadius(5);
                backgroundBorder.Width = 490;
                backgroundBorder.HorizontalAlignment= HorizontalAlignment.Right;
                backgroundBorder.VerticalAlignment= VerticalAlignment.Top;
                backgroundBorder.Margin = new Thickness(0,45,30,0);
                backgroundBorder.Opacity = 0.8;

                CommandSql.CommandText = $"select [Дата_Создания] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";
                string Date = (string)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select [Заголовок_Новости] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";
                expander.Header = CommandSql.ExecuteScalar() + "        " + Date;

                StackPanel stackPanel = new StackPanel();
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                stackPanel.Width = 850;

                CommandSql.CommandText = $"select [Фотография_Первая] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";
                Image = (byte[])CommandSql.ExecuteScalar();

                System.IO.MemoryStream ms = new System.IO.MemoryStream(Image);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = ms;
                newBitmapImage.EndInit();

                Label captionText = new Label();
                captionText.Content = "Фотографии с мероприятия:";
                captionText.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                captionText.FontSize = 24;
                captionText.Foreground = Brushes.White;
                captionText.Margin = new Thickness(30,0,0,0);

                Image image = new Image();
                image.HorizontalAlignment= HorizontalAlignment.Left;
                image.Margin = new Thickness(30,10,0,0);
                image.Source = newBitmapImage;


                CommandSql.CommandText = $"select [Фотография_Вторая] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";
                ImageTwo = (byte[])CommandSql.ExecuteScalar();

                System.IO.MemoryStream msTwo = new System.IO.MemoryStream(ImageTwo);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = msTwo;
                newBitmapImage.EndInit();

                Image imageTwo = new Image();
                imageTwo.HorizontalAlignment = HorizontalAlignment.Left;
                imageTwo.Margin = new Thickness(30,20,0,0);
                imageTwo.Source = newBitmapImage;


                CommandSql.CommandText = $"select [Фотография_Третья] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";
                ImageTwo = (byte[])CommandSql.ExecuteScalar();

                System.IO.MemoryStream msThree = new System.IO.MemoryStream(ImageTwo);
                ms.Seek(0, System.IO.SeekOrigin.Begin);

                newBitmapImage = new BitmapImage();
                newBitmapImage.BeginInit();
                newBitmapImage.StreamSource = msThree;
                newBitmapImage.EndInit();

                Image imageThree = new Image();
                imageThree.HorizontalAlignment = HorizontalAlignment.Left;
                imageThree.Margin = new Thickness(30,20,0,0);
                imageThree.Source = newBitmapImage;

                StackPanel stackPanelBorderInfoNews = new StackPanel();

                Label labelNameNew = new Label();
                labelNameNew.Content = "Название мероприятия:";
                labelNameNew.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                labelNameNew.FontSize = 26;
                labelNameNew.Foreground = Brushes.Black;
                labelNameNew.Margin = new Thickness(10, 20, 0, 0);

                CommandSql.CommandText = $"select [Заголовок_Новости] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";

                TextBlock nameNew = new TextBlock();
                nameNew.Text = (string)CommandSql.ExecuteScalar();
                nameNew.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                nameNew.FontSize = 24;
                nameNew.Foreground = Brushes.Black;
                nameNew.TextWrapping = TextWrapping.Wrap;
                nameNew.Margin = new Thickness(15,5,0,10);

                CommandSql.CommandText = $"select [Описание_Новости] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";

                TextBlock infoNew = new TextBlock();
                infoNew.Text = (string)CommandSql.ExecuteScalar();
                infoNew.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                infoNew.FontSize = 24;
                infoNew.Foreground = Brushes.Black;
                infoNew.TextWrapping = TextWrapping.Wrap;
                infoNew.Margin = new Thickness(15,0,10,10);

                Label labelKatNew = new Label();
                labelKatNew.Content = "Теги новости:";
                labelKatNew.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                labelKatNew.FontSize = 26;
                labelKatNew.Foreground = Brushes.Black;
                labelKatNew.Margin = new Thickness(10, 10, 0, 0);

                CommandSql.CommandText = $"select [Категории_Новости] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";

                TextBlock katNew = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    FontFamily = new FontFamily("Bahnschrift Light Condensed"),
                    FontSize = 24,
                    Foreground = Brushes.Black,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(15, 10, 0, 0)
                };

                Label labelAvtorNew = new Label();
                labelAvtorNew.Content = "Автор новости:";
                labelAvtorNew.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                labelAvtorNew.FontSize = 26;
                labelAvtorNew.Foreground = Brushes.Black;
                labelAvtorNew.HorizontalAlignment = HorizontalAlignment.Right;
                labelAvtorNew.VerticalAlignment = VerticalAlignment.Bottom;
                labelAvtorNew.Margin = new Thickness(0, 0, 20, 0);

                CommandSql.CommandText = $"select [Автор_Новости] from Новости where [Номер_Новости] = {MassivNomerNews[i]}";

                TextBlock avtorNew = new TextBlock();
                avtorNew.Text = (string)CommandSql.ExecuteScalar();
                avtorNew.FontFamily = new FontFamily("Bahnschrift Light Condensed");
                avtorNew.FontSize = 24;
                avtorNew.Foreground = Brushes.Black;
                avtorNew.HorizontalAlignment = HorizontalAlignment.Right;
                avtorNew.VerticalAlignment = VerticalAlignment.Bottom;
                avtorNew.TextWrapping = TextWrapping.Wrap;
                avtorNew.Margin = new Thickness(0, 0, 20, 20);


                stackPanelBorderInfoNews.Children.Add(labelNameNew);
                stackPanelBorderInfoNews.Children.Add(nameNew);
                
                stackPanelBorderInfoNews.Children.Add(infoNew);

                stackPanelBorderInfoNews.Children.Add(labelKatNew);
                stackPanelBorderInfoNews.Children.Add(katNew);

                stackPanelBorderInfoNews.Children.Add(labelAvtorNew);
                stackPanelBorderInfoNews.Children.Add(avtorNew);
                gridContainer.Children.Add(backgroundBorder);

                backgroundBorder.Child = stackPanelBorderInfoNews;

                stackPanel.Children.Add(captionText);
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(imageTwo);
                stackPanel.Children.Add(imageThree);

                gridContainer.Children.Add(stackPanel);
                expander.Content = gridContainer;
                expanders.Add(expander);
            }
        }
    }
}
