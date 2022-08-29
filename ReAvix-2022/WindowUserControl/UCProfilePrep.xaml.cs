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
    /// Логика взаимодействия для UCProfilePrep.xaml
    /// </summary>
    public partial class UCProfilePrep : UserControl
    {
        int NomerPrep;
        VMWindowProfilePrep vMWindowProfilePrep;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public UCProfilePrep(int NumberPrep)
        {
            InitializeComponent();

            NomerPrep = NumberPrep;
            vMWindowProfilePrep = new VMWindowProfilePrep(NomerPrep);
            vMWindowProfilePrep.GetInfoPrep();
            ImagesProfile.Source = vMWindowProfilePrep.newBitmapImage;
            DataContext = vMWindowProfilePrep;
        }
        public UCProfilePrep()
        {
            InitializeComponent();
        }
        string AdressImageOne;

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = $"update [Преподаватели] set Фотография = @images where Номер_Преподавателя = {NomerPrep} "; // Создание запроса
            if (AdressImageOne == null)
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowProfilePrep.AddImage(out string AdressImageOneOut);
            if (AdressImageOneOut == "")
            {

            }
            else
            {
                ImagesProfile.Source = BitmapFrame.Create(new Uri(AdressImageOneOut));
                AdressImageOne = AdressImageOneOut;
            }
        }

        private void button_AddDop_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection; // Инициализация подключения
            _Connection.Open();
            CommandSql.CommandText = $"update [Преподаватели] set [Имя]  = '{textbox_Ima.Text}',[Фамилия] = '{textbox_Fam.Text}',[Отчество] = '{textbox_Otc.Text}',[E_mail] = '{textbox_EMail.Text}',[Номер_Телефона] = '{textbox_Phone.Text}',[Дата_рождения] = '{text_boxData.Text}',[Адрес] = '{textbox_Adress.Text}',[Краткая_Информация] = '{textbox_DateMe.Text}',[Ведущий_Предмет] = '{textbox_VedPredmet.Text}',[Дополнительный_Предмет] = '{textbox_DopPredmet.Text}',[Специальность] = '{textbox_Spec.Text}',[Ведущий_Кружок] = '{textbox_Ellipse.Text}' where Номер_Преподавателя = {NomerPrep} "; // Создание запроса
            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            vMWindowProfilePrep.GetInfoPrep();
            _Connection.Close(); // Закрытие подключения
            MessageBox.Show("Данные успешно измененены.", "Диалоговое окно", MessageBoxButton.OK);
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
