using ReAvix_2022.ViewModels;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
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

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection; // Инициализация подключения

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
           
                _Connection.Open(); // Открытие подключения
                CommandSql.CommandText = $"update [Преподаватели] set Фотография = @images where Номер_Преподавателя = {NomerPrep} "; // Создание запроса
                if (AdressImageOne == null)
                {

                }
                else
                {
                    var data = File.ReadAllBytes(AdressImageOne); // Инициализация подключения
                    CommandSql.Parameters.Add(new SqlParameter("@images", data));
                    CommandSql.ExecuteNonQuery(); // Выполнение запроса
                    _Connection.Close(); // Закрытие подключения
                    MessageBox.Show("Фотография успешно сохранена.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                button_ImageSave.IsEnabled = false;
                ImagesProfile.IsEnabled = false;
              
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
            if (textbox_Fam.Text == "" || textbox_Ima.Text == "" || textbox_Otc.Text == "" || textbox_EMail.Text == "" || textbox_Phone.Text == "" || textbox_Ellipse.Text == "" || textbox_Spec.Text == "" || textbox_Adress.Text == "" || textbox_Group.Text == "")
            {
                MessageBox.Show("Пустые поля!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                _Connection.Close();
                _Connection.Open();
                CommandSql.CommandText = $"update [Преподаватели] set [Имя]  = '{textbox_Ima.Text}',[Фамилия] = '{textbox_Fam.Text}',[Отчество] = '{textbox_Otc.Text}',[E_mail] = '{textbox_EMail.Text}',[Номер_Телефона] = '{textbox_Phone.Text}',[Адрес] = '{textbox_Adress.Text}',[Краткая_Информация] = '{textbox_DateMe.Text}',[FK_Закреплённая_группа] = '{textbox_Group.Text}',[Специальность] = '{textbox_Spec.Text}',[Ведущий_Кружок] = '{textbox_Ellipse.Text}' where Номер_Преподавателя = {NomerPrep} "; // Создание запроса
                CommandSql.ExecuteNonQuery(); // Выполнение запроса
                vMWindowProfilePrep.GetInfoPrep();
                _Connection.Close(); // Закрытие подключения
                MessageBox.Show("Данные успешно измененены.", "Диалоговое окно", MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textbox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void textbox_Regex_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }
    }
}
