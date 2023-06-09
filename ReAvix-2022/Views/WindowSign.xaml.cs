using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ReAvix_2022
{
    /// <summary>
    /// Логика взаимодействия для WindowSign.xaml
    /// </summary>
    public partial class WindowSign : Window
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public WindowSign()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            if (CheckingDatabaseConnection())
            {

            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0); // Выход из приложения
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void button_ChangePasssowrd_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        /// <summary>
        /// Проверка для подключения к БД
        /// </summary>
        /// <returns></returns>
        public bool CheckingDatabaseConnection()
        {
            SqlConnection _Connection = new SqlConnection();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            try
            {
                _Connection.Open();
                _Connection.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Нет соединения с сервером.","Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }

        private void button_RegisterPrep_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowRegisterPrep windowRegisterPrep = new WindowRegisterPrep();
            Hide();
            windowRegisterPrep.Show();
        }

        private void button_RegisterStud_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowRegisterStud windowRegisterStud = new WindowRegisterStud();
            Hide();
            windowRegisterStud.Show();
        }

        private void button_Sign_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Open();
            CommandSql.CommandText = $"select [Номер_Студента] from [Студенты] where [Логин] = '{textbox_Login.Text}' and [Пароль] = '{textbox_Password.Password.ToString()}'";
            CommandSql.Connection = _Connection;
            object LoginStudent = CommandSql.ExecuteScalar();
            if (LoginStudent != null)
            {
                _Connection.Close();
                WindowMainStudent windowMainStudent = new WindowMainStudent(NomerSt: (int)LoginStudent);
                windowMainStudent.Show();
                Hide();
            }
            else
            {
                CommandSql.CommandText = $"select [Номер_Преподавателя] from [Преподаватели] where [Логин] = '{textbox_Login.Text}' and [Пароль] = '{textbox_Password.Password.ToString()}'";
                CommandSql.Connection = _Connection;
                object LoginPrep = CommandSql.ExecuteScalar();
                if (LoginPrep != null)
                {
                    _Connection.Close();
                    WindowMainPrep windowMainPrep = new WindowMainPrep(NomerPrep: (int)LoginPrep);
                    windowMainPrep.Show();
                    Hide();
                }
                else
                {
                    _Connection.Close();

                    if (textbox_Login.Text == ConfigurationManager.AppSettings["Login"] && textbox_Password.Password.ToString() == ConfigurationManager.AppSettings["Password"])
                    {
                        WindowAdministrator windowAdministrator = new WindowAdministrator();
                        windowAdministrator.Show();
                        Hide();
                    }
                    else
                    {
                        textbox_Login.Clear();
                        textbox_Password.Clear();
                        textbox_Login.BorderBrush = Brushes.Red;
                        textbox_Password.BorderBrush = Brushes.Red;
                    }  
                }
            }
        }

        private void button_ChangePasssowrd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowPasswordRecovery windowPasswordRecovery = new WindowPasswordRecovery();
            windowPasswordRecovery.ShowDialog();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
