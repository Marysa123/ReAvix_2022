using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
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
using System.Windows.Media;

namespace ReAvix_2022.Models
{
    internal class ModelsNotes
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        List<int> MassivNomerZam;
        List<int> MassivNomerZamPrep;

        public List<Border> MainBorders;
        public List<Border> MainBordersPrep;

        int Count;
        int CountPrep;
        /// <summary>
        /// Метод добавления Заметок для студента
        /// </summary>
        /// <param name="NumberSt">Номер студента</param>
        public void AddNotes(int NumberSt)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(*) from [Заметки] where [FK_Номер_Студента] = '{NumberSt}'";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_заметки] from [Заметки] where [FK_Номер_Студента] = {NumberSt}";

            SqlDataReader dataReader = CommandSql.ExecuteReader(); // Считывание данных с запроса
            MassivNomerZam = new List<int>(); // Создание экземпляра List<Int>
            while (dataReader.Read()) // Считывание
            {
                MassivNomerZam.Add((int)dataReader.GetValue(0)); // Добавление данных в List
            }
            dataReader.Close(); //Закрытие чтения

            var bc = new BrushConverter();
            List<Border> borders = new List<Border>();

            for (int i = 0; i < Count; i++)
            {
                #region MyRegion

                Border border1 = new Border
                {
                    Width = 385,
                    Height = 60,
                    Background = (Brush)bc.ConvertFrom("#204FA9"),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(0, 0, 0, 0)
                };

                Grid grid = new Grid();
                border1.Child = grid;

                CommandSql.CommandText = $"select [Текст] from [Заметки] where [Номер_заметки] = {MassivNomerZam[i]}";

                TextBlock textBlock = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    FontSize = 20,
                    Foreground = Brushes.White,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Margin = new System.Windows.Thickness(20, 5, 0, 0),
                    FontFamily = new FontFamily("Bahnschrift Light SemiCondensed"),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 180
                };

                Border border2 = new Border
                {
                    Width = 120,
                    Height = 40,
                    CornerRadius = new System.Windows.CornerRadius(5),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                    Margin = new System.Windows.Thickness(0, 0, 30, 0)
                };

                CommandSql.CommandText = $"select [Приоритет] from [Заметки] where [Номер_заметки] = {MassivNomerZam[i]}";

                Label label1 = new Label
                {
                    Content = CommandSql.ExecuteScalar()
                };
                string Back = label1.ToString(); ;
                if (Back == "System.Windows.Controls.Label: Высокий")
                {
                    border2.Background = (Brush)bc.ConvertFrom("#D74848");
                }
                else if (Back == "System.Windows.Controls.Label: Низкий")
                {
                    border2.Background = (Brush)bc.ConvertFrom("#78A554");
                }
                else if (Back == "System.Windows.Controls.Label: Средний")
                {
                    border2.Background = (Brush)bc.ConvertFrom("#CD906E");
                }

                label1.FontSize = 18;
                label1.Foreground = Brushes.White;
                label1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                label1.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                label1.FontFamily = new FontFamily("Bahnschrift Light SemiCondensed");

                border2.Child = label1;

                grid.Children.Add(textBlock);
                grid.Children.Add(border2);

                borders.Add(border1);
                MainBorders = borders;

                #endregion
            }
            _Connection.Close();
        }
        /// <summary>
        /// Метод удаления заметок для студента
        /// </summary>
        /// <param name="IndexItems">Индекс выбранной заметки</param>
        public void DeleteNotesPrep(int IndexSelectedItems)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить заметку?", "Диалогове окно", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int NomerNotes = MassivNomerZamPrep[IndexSelectedItems];
                _Connection.Open();
                CommandSql.CommandText = $"delete [Заметки] where [Номер_заметки] = {NomerNotes}";
                CommandSql.ExecuteNonQuery();
                _Connection.Close();
            }
        }
        public void DeleteNotes(int IndexSelectedItems)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить заметку?", "Диалогове окно", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int NomerNotes = MassivNomerZam[IndexSelectedItems];
                _Connection.Open();
                CommandSql.CommandText = $"delete [Заметки] where [Номер_заметки] = {NomerNotes}";
                CommandSql.ExecuteNonQuery();
                _Connection.Close();
            }
        }
        public void AddNotesPrep(int NumberPrep)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(*) from [Заметки] where [FK_Номер_Преподавателя] = '{NumberPrep}'";
            CommandSql.Connection = _Connection;
            CountPrep = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_заметки] from [Заметки] where [FK_Номер_Преподавателя] = {NumberPrep}";

            SqlDataReader dataReader = CommandSql.ExecuteReader(); // Считывание данных с запроса
            MassivNomerZamPrep = new List<int>(); // Создание экземпляра List<Int>
            while (dataReader.Read()) // Считывание
            {
                MassivNomerZamPrep.Add((int)dataReader.GetValue(0)); // Добавление данных в List
            }
            dataReader.Close(); //Закрытие чтения

            var bc = new BrushConverter();
            List<Border> borders = new List<Border>();

            for (int i = 0; i < CountPrep; i++)
            {
                #region MyRegion

                Border border1 = new Border
                {
                    Width = 385,
                    Height = 60,
                    Background = (Brush)bc.ConvertFrom("#204FA9"),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(0, 0, 0, 0)
                };

                Grid grid = new Grid();
                border1.Child = grid;

                CommandSql.CommandText = $"select [Текст] from [Заметки] where [Номер_заметки] = {MassivNomerZamPrep[i]}";

                TextBlock textBlock = new TextBlock
                {
                    Text = (string)CommandSql.ExecuteScalar(),
                    FontSize = 20,
                    Foreground = Brushes.White,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Margin = new System.Windows.Thickness(20, 5, 0, 0),
                    FontFamily = new FontFamily("Bahnschrift Light SemiCondensed"),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 180
                };

                Border border2 = new Border
                {
                    Width = 120,
                    Height = 40,
                    CornerRadius = new System.Windows.CornerRadius(5),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                    Margin = new System.Windows.Thickness(0, 0, 30, 0)
                };

                CommandSql.CommandText = $"select [Приоритет] from [Заметки] where [Номер_заметки] = {MassivNomerZamPrep[i]}";

                Label label1 = new Label
                {
                    Content = CommandSql.ExecuteScalar()
                };
                string Back = label1.ToString(); ;
                if (Back == "System.Windows.Controls.Label: Высокий")
                {
                    border2.Background = (Brush)bc.ConvertFrom("#D74848");
                }
                else if (Back == "System.Windows.Controls.Label: Низкий")
                {
                    border2.Background = (Brush)bc.ConvertFrom("#78A554");
                }
                else if (Back == "System.Windows.Controls.Label: Средний")
                {
                    border2.Background = (Brush)bc.ConvertFrom("#CD906E");
                }

                label1.FontSize = 18;
                label1.Foreground = Brushes.White;
                label1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                label1.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                label1.FontFamily = new FontFamily("Bahnschrift Light SemiCondensed");

                border2.Child = label1;

                grid.Children.Add(textBlock);
                grid.Children.Add(border2);

                borders.Add(border1);
                MainBordersPrep = borders;

                #endregion
            }
            _Connection.Close();
        }
    }
}
