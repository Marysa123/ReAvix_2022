using LiveChartsCore;
using ReAvix_2022.ViewModels;
using ReAvix_2022.WindowUserControl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для WindowAddSkils.xaml
    /// </summary>
    public partial class WindowAddSkils : Window
    {
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public int NumberStudent;
        public IEnumerable<ISeries> series { get; set; }


        VMWindowAddSkils vMWindowAddSkils;
        public WindowAddSkils(int NomerSt)
        {
            NumberStudent = NomerSt;
            InitializeComponent();

            vMWindowAddSkils = new VMWindowAddSkils();
            vMWindowAddSkils.GetInfokat();
            DataContext = vMWindowAddSkils;






        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_AddSkilsStud_Click(object sender, RoutedEventArgs e)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open(); // Открытие подключения
            CommandSql.CommandText = $"insert into [Навыки] VALUES('{combobox_NameKat.Text}',{combobox_ValueMster.Text},'{textbox_TextSkils.Text}',{NumberStudent})"; // Создание запроса
            CommandSql.Connection = _Connection; // Инифиализация подключения
            CommandSql.ExecuteNonQuery(); // Выполнение запроса
            _Connection.Close(); // Закрытие подключения
            MessageBox.Show("Навык успешно добавлен.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
