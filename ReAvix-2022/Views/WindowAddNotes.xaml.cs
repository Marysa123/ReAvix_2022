using ReAvix_2022.Models;
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
    /// Логика взаимодействия для WindowAddNotes.xaml
    /// </summary>
    public partial class WindowAddNotes : Window
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();
        int NomerStudent;
        public WindowAddNotes(int NomerNotesStudent)
        {
            NomerStudent = NomerNotesStudent;
            InitializeComponent();
        }

        private void button_AddNotes_Click(object sender, RoutedEventArgs e)
        {
            AddNotesInBd();
        }

        private void AddNotesInBd()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"insert into [Заметки] VALUES('{textbox_Text.Text}','{combobox_Property.Text}',{NomerStudent},NULL)";
            CommandSql.Connection = _Connection;
            Name = (string)CommandSql.ExecuteScalar();

            _Connection.Close();
            this.Hide();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
