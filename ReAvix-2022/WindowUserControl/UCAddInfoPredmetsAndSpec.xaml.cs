using ReAvix_2022.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCAddInfoPredmetsAndSpec.xaml
    /// </summary>
    public partial class UCAddInfoPredmetsAndSpec : UserControl
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();
        public UCAddInfoPredmetsAndSpec()
        {
            InitializeComponent();

            VMWindowAddInfoPredmetsAndSpec vMWindowAddInfoPredmetsAndSpec = new VMWindowAddInfoPredmetsAndSpec();
            DataContext = vMWindowAddInfoPredmetsAndSpec;

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            sqlCommand.Connection = _Connection;

            _Connection.Open();
            GetInfoPredmet();
            GetInfoSpec();
            _Connection.Close();
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
     
        private void button_UpdatePredmets_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NamePredmet.Text == "")
            {
                MessageBox.Show("Пустое поле!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _Connection.Open();
                sqlCommand.CommandText = $"update [Предметы] set Название_Предмета = '{textbox_NamePredmet.Text}' where Номер_Предмета = {textbox_NomerPredmet.Text}";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные обновлены", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                GetInfoPredmet();
                _Connection.Close();
            }
        }

        private void button_AddPredmets_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NamePredmet.Text == "")
            {
                MessageBox.Show("Пустое поле!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _Connection.Open();
                sqlCommand.CommandText = $"insert into [Предметы] values ('{textbox_NamePredmet.Text}')";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные добавлены", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                GetInfoPredmet();
                _Connection.Close();
            }
        }

        private void button_UpdateSpec_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NameSpec.Text == "")
            {
                MessageBox.Show("Пустое поле!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _Connection.Open();
                sqlCommand.CommandText = $"update [Специальности] set Название_Специальности = '{textbox_NameSpec.Text}' where Номер_Специальности = {textbox_NomerSpec.Text}";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные обновлены", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                GetInfoPredmet();
                _Connection.Close();
            }
        }

        private void button_AddSpec_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NameSpec.Text == "")
            {
                MessageBox.Show("Пустое поле!","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                _Connection.Open();
                sqlCommand.CommandText = $"insert into [Специальности] values ('{textbox_NameSpec.Text}')";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные добавлены", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                GetInfoSpec();
                _Connection.Close();
            }
        }

        private void GetInfoPredmet()
        {
            sqlCommand.CommandText = $"select [Номер_Предмета] as 'Номер', [Название_Предмета] as 'Название предмета' from Предметы";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridViewNamePred.ItemsSource = dataTable.DefaultView;
        }
        private void GetInfoSpec()
        {
            sqlCommand.CommandText = $"select Номер_Специальности as 'Номер', [Название_Специальности] as 'Название специальности' from Специальности";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridViewNameSpec.ItemsSource = dataTable.DefaultView;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            _Connection.Open();
            switch (result)
            {
                case MessageBoxResult.OK:
                    sqlCommand.CommandText = $"delete from Предметы where [Номер_Предмета] = '{textbox_NomerPredmet.Text}'";
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetInfoPredmet();
                    _Connection.Close();

                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
            _Connection.Close();
        }

        private void DataGridRow_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            _Connection.Open();
            switch (result)
            {
                case MessageBoxResult.OK:
                    sqlCommand.CommandText = $"delete from Специальности where [Номер_Специальности] = '{textbox_NomerSpec.Text}'";
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetInfoSpec();
                    _Connection.Close();

                    break;
                case MessageBoxResult.Cancel:
                    _Connection.Close();
                    break;
            }
            _Connection.Close();

        }
    }
}
