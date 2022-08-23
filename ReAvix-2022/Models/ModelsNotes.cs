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
        int Count;
        public List<Border> borders1;

        public void AddNotes(int nomer_Student)
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();
            CommandSql.CommandText = $"select COUNT(*) from [Заметки] where [FK_Номер_Студента] = '{nomer_Student}'";
            CommandSql.Connection = _Connection;
            Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Номер_заметки] from [Заметки] where [FK_Номер_Студента] = {nomer_Student}";

            SqlDataReader dataReader = CommandSql.ExecuteReader();
            MassivNomerZam = new List<int>();
            while (dataReader.Read())
            {
                MassivNomerZam.Add((int)dataReader.GetValue(0));
            }
            dataReader.Close();

            var bc = new BrushConverter();
            List<Border> borders = new List<Border>();

            for (int i = 0; i < Count; i++)
            {
                #region MyRegion

                Border border1 = new Border();
                border1.Width = 385;
                border1.Height = 60;
                border1.Background = (Brush)bc.ConvertFrom("#204FA9");
                border1.CornerRadius = new CornerRadius(5);
                border1.Margin = new Thickness(0, 0, 0, 0);

                Grid grid = new Grid();
                border1.Child = grid;

                CommandSql.CommandText = $"select [Текст] from [Заметки] where [Номер_заметки] = {MassivNomerZam[i]}";

                TextBlock textBlock = new TextBlock();
                textBlock.Text = (string)CommandSql.ExecuteScalar();
                textBlock.FontSize = 20;
                textBlock.Foreground = Brushes.White;
                textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                textBlock.Margin = new System.Windows.Thickness(20, 5, 0, 0);
                textBlock.FontFamily = new FontFamily("Bahnschrift Condensed");
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Width = 180;

                Border border2 = new Border();
                border2.Width = 120;
                border2.Height = 40;
                border2.CornerRadius = new System.Windows.CornerRadius(5);
                border2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                border2.Margin = new System.Windows.Thickness(0, 0, 30, 0);

                CommandSql.CommandText = $"select [Приоритет] from [Заметки] where [Номер_заметки] = {MassivNomerZam[i]}";

                Label label1 = new Label();
                label1.Content = CommandSql.ExecuteScalar();
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
                label1.FontFamily = new FontFamily("Bahnschrift Condensed");

                border2.Child = label1;

                grid.Children.Add(textBlock);
                grid.Children.Add(border2);

                borders.Add(border1);
                borders1 = borders;
                
                #endregion
            }
            _Connection.Close();
        }
        public void DeleteNotes(int IndexItems)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить заметку?", "Диалогове окно", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int NomerNotes = MassivNomerZam[IndexItems];
                _Connection.Open();
                CommandSql.CommandText = $"delete [Заметки] where [Номер_заметки] = {NomerNotes}";
                CommandSql.ExecuteNonQuery();
                _Connection.Close();
            }
            else
            {
                
            }
        }

    }
}
