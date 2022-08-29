using ReAvix_2022.ViewModels;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCProfileStudent.xaml
    /// </summary>
    public partial class UCProfileStudent : UserControl
    {
        int NomerStudent;
        VMWindowProfileStudent vMWindowProfileStudent;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public UCProfileStudent()
        {
            InitializeComponent();
        }
        public UCProfileStudent(int NumberSt)
        {
            InitializeComponent();

            NomerStudent = NumberSt;
            vMWindowProfileStudent = new VMWindowProfileStudent(NomerStudent);
            vMWindowProfileStudent.GetInfoStudent();
            ImagesProfile.Source = vMWindowProfileStudent.newBitmapImage;
            DataContext = vMWindowProfileStudent;


        }
        string AdressImageOne;

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowProfileStudent.AddImage(out string AdressImageOneOut);
            if (AdressImageOneOut == "")
            {

            }
            else
            {
                ImagesProfile.Source = BitmapFrame.Create(new Uri(AdressImageOneOut));
                AdressImageOne = AdressImageOneOut;
            }
        }

        private void button_AddDop_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения

            CommandSql.CommandText = $"update [Студенты] set [Имя]  = '{textbox_Ima.Text}',[Фамилия] = '{textbox_Fam.Text}',[Отчество] = '{textbox_Otc.Text}',[E_mail] = '{textbox_EMail.Text}',[Номер_Телефона] = '{textbox_Phone.Text}',[Номер_телефона_Родителей] = '{textbox_PhoneRod.Text}',[Дата_рождения] = '{text_boxData.Text}',[Адрес] = '{textbox_Adress.Text}',[Краткая_Информация] = '{textbox_DateMe.Text}' where Номер_Студента = {NomerStudent} "; // Создание запроса
            CommandSql.Connection = _Connection; // Инициализация подключения
            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            vMWindowProfileStudent.GetInfoStudent();
            _Connection.Close(); // Закрытие подключения
            MessageBox.Show("Данные успешно измененены.", "Диалоговое окно", MessageBoxButton.OK);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = $"update [Студенты] set Фотография = @images where Номер_Студента = {NomerStudent} "; // Создание запроса
            if (AdressImageOne ==null)
            {

            }
            else
            {
                var data = File.ReadAllBytes(AdressImageOne);
                CommandSql.Connection = _Connection; // Инициализация подключения
                CommandSql.Parameters.Add(new SqlParameter("@images", data));
                CommandSql.ExecuteNonQuery(); // Выполнение запроса
                _Connection.Close(); // Закрытие подключения
                MessageBox.Show("Фотография успешно сохранена.", "Диалоговое окно", MessageBoxButton.OK);
            }
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
