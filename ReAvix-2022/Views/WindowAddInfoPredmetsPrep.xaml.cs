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
    /// Логика взаимодействия для WindowAddInfoPredmetsPrep.xaml
    /// </summary>
    public partial class WindowAddInfoPredmetsPrep : Window
    {
        public int NumberPrep { get; set; }
        VMWindowAddInfoPredmetsPrep vMWindowAddInfoPredmetsPrep;

        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        public WindowAddInfoPredmetsPrep()
        {

        }
        public WindowAddInfoPredmetsPrep(int NomerPrep)
        {
            InitializeComponent();
            NumberPrep = NomerPrep;

            vMWindowAddInfoPredmetsPrep = new VMWindowAddInfoPredmetsPrep(NomerPrep:NumberPrep);
            DataContext = vMWindowAddInfoPredmetsPrep;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        string AdressKTP;
        string AdressFOS;
        string AdressDOC;
        private void button_AddKTP_Click(object sender, RoutedEventArgs e)
        {
            vMWindowAddInfoPredmetsPrep.AddDocument(out string AdressDocument);
            if (AdressDocument != "")
            {
                AdressKTP = AdressDocument;
                MessageBox.Show("Файл успешно добавлен","Диалоговое окно");
            }
        }

        private void button_AddFOS_Click(object sender, RoutedEventArgs e)
        {
            vMWindowAddInfoPredmetsPrep.AddDocument(out string AdressDocument);
            if (AdressDocument != "")
            {
                AdressFOS = AdressDocument;
                MessageBox.Show("Файл успешно добавлен", "Диалоговое окно");
            }
        }

        private void button_AddDoc_Click(object sender, RoutedEventArgs e)
        {
            vMWindowAddInfoPredmetsPrep.AddDocument(out string AdressDocument);
            if (AdressDocument != "")
            {
                AdressDOC = AdressDocument;
                MessageBox.Show("Файл успешно добавлен", "Диалоговое окно");
            }
        }

        private void button_AddPred_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            if (AdressKTP == null || AdressFOS == null || AdressDOC == null)
            {
                MessageBox.Show("Не заполнен один из обязательных документов!", "Диалоговое окно");
                return;
            }
            var data = File.ReadAllBytes(AdressKTP);
            var dataTwo = File.ReadAllBytes(AdressFOS);
            var dataThree = File.ReadAllBytes(AdressDOC);


            CommandSql.CommandText = $"insert into [Предметы_Преподавателя] ([Название_Предмета], [Ведущий_Преподаватель], [FK_Номер_Преподавателя],[Описание_предмета],[Итоговая_работа],[Количество_часов],[Документ_Первый],[Документ_Второй],[Документ_Третий]) VALUES('{combobox_Predmets.Text}','{textbox_Fio.Text}',{NumberPrep},'{textbox_InformationPredmet.Text}','{combobox_KindsJob.Text}',{textbox_KolvoTime.Text},@docKTP,@docFOS,@docMen)"; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения
            CommandSql.Parameters.Add(new SqlParameter("@docKTP", data));
            CommandSql.Parameters.Add(new SqlParameter("@docFOS", dataTwo));
            CommandSql.Parameters.Add(new SqlParameter("@docMen", dataThree));


            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            MessageBox.Show("Предмет успешно добавлен.", "Диалоговое окно");
            Close();
        }

        private void textbox_KolvoTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
