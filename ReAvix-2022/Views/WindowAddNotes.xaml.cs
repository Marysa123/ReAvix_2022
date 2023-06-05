using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowAddNotes.xaml
    /// </summary>
    public partial class WindowAddNotes : Window
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        int NomerStudent;
        public WindowAddNotes(int NumberSt)
        {
            NomerStudent = NumberSt;
            InitializeComponent();
        }

        private void button_AddNotes_Click(object sender, RoutedEventArgs e)
        {
            AddNotesInBd();
        }
        /// <summary>
        /// Добавление заметок в Базу данных
        /// </summary>
        private void AddNotesInBd()
        {
            if (textbox_Text.Text != "")
            {
                _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
                _Connection.Open();
                CommandSql.CommandText = $"insert into [Заметки] VALUES('{textbox_Text.Text}','{combobox_Property.Text}',{NomerStudent},NULL)";
                CommandSql.Connection = _Connection;
                Name = (string)CommandSql.ExecuteScalar();
                _Connection.Close();
                MessageBox.Show("Заметка успешно добавлена.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Пустое поле!","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
