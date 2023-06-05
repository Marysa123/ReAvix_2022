using ReAvix_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WindowAboutPredmet.xaml
    /// </summary>
    public partial class WindowAboutPredmet : Window
    {
        public int NumberPred { get; set; }

        VMWindowAboutPredmet windowAboutPredmet;

        string AdressKTP;
        string AdressFOS;
        string AdressDOC;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public WindowAboutPredmet()
        {

        }
        public WindowAboutPredmet(int NomerPred)
        {
            InitializeComponent();
            NumberPred = NomerPred;
            
            windowAboutPredmet = new VMWindowAboutPredmet(NumberPred);
            DataContext = windowAboutPredmet;
            CommandSql.Connection = _Connection; // Инифиализация подключения
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_DeleteDocPrep_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить этот предмет?", "Диалогове окно", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                CommandSql.CommandText = $"delete Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
                _Connection.Open();
                CommandSql.ExecuteNonQuery();
                MessageBox.Show("Успешное удаление предмета!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void button_UpdatePredmetPrep_Click(object sender, RoutedEventArgs e)
        {
            CommandSql.CommandText = $"Update [Предметы_Преподавателя] set Ведущий_Преподаватель = '{textbox_MainPrep.Text}',Описание_предмета = '{textbox_AboutPred.Text}',Итоговая_работа = '{textbox_EndJob.Text}',Количество_часов = {textbox_KolTime.Text} where Номер_Предмета = {NumberPred}"; // Создание запроса

            _Connection.Open();
            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            MessageBox.Show("Предмет успешно изменен.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_DownloadKTP_Click(object sender, RoutedEventArgs e)
        {
            windowAboutPredmet.GetDataPredmet("Документ_Первый");
        }

        private void button_DeleteKTP_Click(object sender, RoutedEventArgs e)
        {
            windowAboutPredmet.DeleteDocumentPredmets("Документ_Первый");
        }

        private void button_DownloadFOS_Click(object sender, RoutedEventArgs e)
        {
            windowAboutPredmet.GetDataPredmet("Документ_Второй");
        }

        private void button_DeleteFOS_Click(object sender, RoutedEventArgs e)
        {
            windowAboutPredmet.DeleteDocumentPredmets("Документ_Второй");
        }

        private void button_AddDocKTP_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Close();
            _Connection.Open();
            windowAboutPredmet.AddDocument(out string AdressDocument);
            if (AdressDocument != "")
            {
                AdressKTP = AdressDocument;
            }
            if (AdressKTP == null)
            {
                MessageBox.Show("Не заполнен документ!","Диалоговое окно",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var data = File.ReadAllBytes(AdressKTP);

            CommandSql.CommandText = $"Update [Предметы_Преподавателя] set Документ_Первый = @docKTP where Номер_Предмета = {NumberPred}"; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения

            CommandSql.Parameters.Add(new SqlParameter("@docKTP", data));
            
            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            button_AddDocKTP.IsEnabled = false;

            MessageBox.Show("Документ успешно добавлен.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_AddDocFOS_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Close();
            _Connection.Open();
            windowAboutPredmet.AddDocument(out string AdressDocument);
            if (AdressDocument != "")
            {
                AdressFOS = AdressDocument;
            }
            if (AdressFOS == null)
            {
                MessageBox.Show("Не заполнен документ!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var dataTwo = File.ReadAllBytes(AdressFOS);

            CommandSql.CommandText = $"Update [Предметы_Преподавателя] set Документ_Второй = @docFOS where Номер_Предмета = {NumberPred}"; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения

            CommandSql.Parameters.Add(new SqlParameter("@docFOS", dataTwo));

            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            button_AddDocFOS.IsEnabled = false;

            MessageBox.Show("Документ успешно добавлен.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_DownloadMen_Click(object sender, RoutedEventArgs e)
        {
            windowAboutPredmet.GetDataPredmet("Документ_Третий");
        }

        private void button_DeleteMen_Click(object sender, RoutedEventArgs e)
        {
            windowAboutPredmet.DeleteDocumentPredmets("Документ_Третий");
        }

        private void button_AddDocMen_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Close();
            _Connection.Open();
            windowAboutPredmet.AddDocument(out string AdressDocument);
            if (AdressDocument != "")
            {
                AdressDOC = AdressDocument;
            }
            if (AdressDOC == null)
            {
                MessageBox.Show("Не заполнен документ!", "Диалоговое окно",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var dataThree = File.ReadAllBytes(AdressDOC);

            CommandSql.CommandText = $"Update [Предметы_Преподавателя] set Документ_Третий = @docMen where Номер_Предмета = {NumberPred}"; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения

            CommandSql.Parameters.Add(new SqlParameter("@docMen", dataThree));
            
            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            button_AddDocMen.IsEnabled = false;

            MessageBox.Show("Документ успешно добавлен.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void textbox_KolTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
