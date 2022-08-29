using Microsoft.Win32;
using ReAvix_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowAddDos.xaml
    /// </summary>
    public partial class WindowAddDos : Window
    {
        public int NumberStudent;
        VMWindowAddDos vMWindowAddDos;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public WindowAddDos(int NumberSt)
        {
            NumberStudent = NumberSt;
            InitializeComponent();

            vMWindowAddDos = new VMWindowAddDos();
            DataContext = vMWindowAddDos;
            vMWindowAddDos.NumberStudent = NumberStudent;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        string AdressImageOne;
        string AdressImageTwo;


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowAddDos.AddImage(out string AdressImageOneOut);
            if (AdressImageOneOut =="")
            {

            }
            else
            {
                Image.Source = BitmapFrame.Create(new Uri(AdressImageOneOut));
                AdressImageOne = AdressImageOneOut;
            }
        }
       

        private void DopImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowAddDos.AddImage(out string AdressImageTwoOut);
            if (AdressImageTwoOut == "")
            {

            }
            else
            {
                DopImage.Source = BitmapFrame.Create(new Uri(AdressImageTwoOut));
                AdressImageTwo = AdressImageTwoOut;
            }
        }

        private void button_AddDop_Click(object sender, RoutedEventArgs e)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            var data = File.ReadAllBytes(AdressImageOne);
            var dataTwo = File.ReadAllBytes(AdressImageTwo);


            CommandSql.CommandText = $"insert into [Достижения] ([Изображение], [Дополнительное_Изображение], [Место_в_соревновании],[Место_Проведения],[Название_Соревнования],[FK_Номер_Студента])  VALUES(@images,@imagesDop,{combobox_Mesto.Text},'{textbox_Mesto.Text}','{textbox_Name.Text}',{NumberStudent})"; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения
            CommandSql.Parameters.Add(new SqlParameter ("@images",data));
            CommandSql.Parameters.Add(new SqlParameter("@imagesDop", dataTwo));


            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            MessageBox.Show("Достижение успешно добавлено.", "Диалоговое окно");
            Close();
        }
    }
}
