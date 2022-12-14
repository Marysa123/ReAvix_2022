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

        private void button_RegisterPrep_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowRegisterPrep windowRegisterPrep = new WindowRegisterPrep();
            this.Hide();
            windowRegisterPrep.Show();
        }

        private void button_RegisterStud_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowRegisterStud windowRegisterStud = new WindowRegisterStud();
            this.Hide();
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

                    textbox_Login.Clear();
                    textbox_Password.Clear();
                    textbox_Login.BorderBrush = Brushes.Red;
                    textbox_Password.BorderBrush = Brushes.Red;
                }
            }
        }

        private void button_ChangePasssowrd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowPasswordRecovery windowPasswordRecovery = new WindowPasswordRecovery();
            windowPasswordRecovery.ShowDialog();
        }
    }
}
