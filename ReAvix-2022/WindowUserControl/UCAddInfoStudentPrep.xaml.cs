using Microsoft.Office.Interop.Excel;
using ReAvix_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCAddInfoStudentPrep.xaml
    /// </summary>
    public partial class UCAddInfoStudentPrep : UserControl
    {
        int NumberPrep;
        VMWindowAddInfoStudentPrep vMWindowAddInfoStudent;
        public UCAddInfoStudentPrep(int NomerPrep)
        {
            NumberPrep = NomerPrep;
            InitializeComponent();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            sqlCommand.Connection = _Connection;

            vMWindowAddInfoStudent = new VMWindowAddInfoStudentPrep(NumberPrep);
            DataContext = vMWindowAddInfoStudent;

            SetViewNamePredmet();
            GetInfoStudent();

        }
        public UCAddInfoStudentPrep()
        {
            InitializeComponent();
        }

        string NameGroup;
        string NamePrep;
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();
        public void GetInfoStudent()
        {
            _Connection.Open();
            sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
            NameGroup = (string)sqlCommand.ExecuteScalar();

            sqlCommand.CommandText = $"select Фамилия + ' ' + Имя + ' ' + Отчество as ФИО from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
            NamePrep = (string)sqlCommand.ExecuteScalar();
            UpdateInfoStudent();
            GetInfoListStudent();
            _Connection.Close();
        }

        List<int> MassivNomerStudent = new List<int>();
        List<int> MassivNomerOchenok = new List<int>();
        List<string> ListNamePredmet = new List<string>();

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (textbox_NomerPredmet.Text == "" || textbox_Fam.Text == "" || textbox_Data.Text == "" || textbox_OChenka.Text == "" || textbox_VidWork.Text == "")
            {
                MessageBox.Show("Пустые поля!", "Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                _Connection.Close();

                _Connection.Open();
                sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
                string NameGroup = (string)sqlCommand.ExecuteScalar();


                sqlCommand.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
                sqlCommand.Connection = _Connection;
                int Count = (int)sqlCommand.ExecuteScalar();

                sqlCommand.CommandText = $"select Номер_Студента from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                MassivNomerStudent = new List<int>();
                while (sqlDataReader.Read())
                {
                    MassivNomerStudent.Add((int)sqlDataReader.GetValue(0));
                }
                sqlDataReader.Close();

                int Nomer = int.Parse(textbox_Fam.Text);
                int Ochenka = int.Parse(textbox_OChenka.Text);

                if (Ochenka >= 2 && Ochenka <= 5)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (Nomer == MassivNomerStudent[i])
                        {
                            sqlCommand.CommandText = $"select Предметы.Номер_Предмета from Предметы_Преподавателя,Предметы where  Предметы_Преподавателя.Название_Предмета = '{textbox_NomerPredmet.Text}' and  Предметы.Название_Предмета = '{textbox_NomerPredmet.Text}'";
                            int NomerPredmet = (int)sqlCommand.ExecuteScalar();
                            sqlCommand.CommandText = $"update Оценки set [Дата] = '{textbox_Data.Text}',[FK_Номер_Студента] ={textbox_Fam.Text},[FK_Номер_Предмета] = {NomerPredmet}, Оценка = {textbox_OChenka.Text}, Вид_оценочной_работы ='{textbox_VidWork.Text}' where Номер_оценки = {label_Номер.Content}";
                            try
                            {
                                sqlCommand.ExecuteNonQuery();
                                MessageBox.Show("Данные успешно обновлены", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Выберите строку!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            UpdateInfoStudent();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _Connection.Close();
            }
        }

        private void UpdateInfoStudent()
        {
            sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;
        }
        private void GetInfoPredmet(string Select)
        {
            GridViewPredmet.ItemsSource = null;
            sqlCommand.CommandText = $"{Select}";
            SqlDataAdapter sqlDataAdapterThree = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTableThree = new System.Data.DataTable("Студенты");
            sqlDataAdapterThree.Fill(dataTableThree);
            GridViewPredmet.ItemsSource = dataTableThree.DefaultView;
        }
        private void button_ListStudent_Click(object sender, RoutedEventArgs e)
        {
            GetInfoListStudent();
        }

        private void GetInfoListStudent()
        {
            GridViewPredmet.ItemsSource = null;
            sqlCommand.CommandText = $"select Номер_Студента as 'Номер студента',Фамилия,Имя,Отчество from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Студенты");
            sqlDataAdapter.Fill(dataTable);
            GridViewPredmet.ItemsSource = dataTable.DefaultView;
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (textbox_NomerPredmet.Text == "" || textbox_Fam.Text == "" || textbox_Data.Text == "" || textbox_OChenka.Text == "" || textbox_VidWork.Text == "")
            {
                MessageBox.Show("Пустые поля!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _Connection.Close();

                _Connection.Open();
                sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
                string NameGroup = (string)sqlCommand.ExecuteScalar();


                sqlCommand.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
                sqlCommand.Connection = _Connection;
                int Count = (int)sqlCommand.ExecuteScalar();

                sqlCommand.CommandText = $"select Номер_Студента from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                MassivNomerStudent = new List<int>();
                while (sqlDataReader.Read())
                {
                    MassivNomerStudent.Add((int)sqlDataReader.GetValue(0));
                }
                sqlDataReader.Close();

                int Nomer = int.Parse(textbox_Fam.Text);
                int Ochenka = int.Parse(textbox_OChenka.Text);

                if (Ochenka >= 2 && Ochenka <= 5)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (Nomer == MassivNomerStudent[i])
                        {
                            _Connection.Close();
                            _Connection.Open();
                            sqlCommand.CommandText = $"select Предметы.Номер_Предмета from Предметы_Преподавателя,Предметы where  Предметы_Преподавателя.Название_Предмета = '{textbox_NomerPredmet.Text}' and  Предметы.Название_Предмета = '{textbox_NomerPredmet.Text}'";
                            int NomerPredmet = (int)sqlCommand.ExecuteScalar();

                            sqlCommand.CommandText = $"insert into [Оценки] values ('{textbox_Data.Text}',{textbox_Fam.Text},{NomerPredmet},{textbox_OChenka.Text},'{textbox_VidWork.Text}')";
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);

                            UpdateInfoStudent();
                            _Connection.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {  
            if (GridView.CurrentCell.Column.DisplayIndex == 1)
            {
                _Connection.Open();
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel,MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.OK: 
                    sqlCommand.CommandText = $"delete from Оценки where [Номер_оценки] = {label_Номер.Content}";
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateInfoStudent();
                    _Connection.Close();
                   
                    break;
                    case MessageBoxResult.Cancel:
                        _Connection.Close();
                    break;
                }
                _Connection.Close();
            }
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void textbox_OChenka_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_Yvash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_NoYvash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_Bolezn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void border_AddDos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                sheet1.Name = "Отчёт";
                for (int j = 1; j < GridView.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[4, j + 1];
                    sheet1.Cells[4, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 6;

                    myRange.Value2 = GridView.Columns[j].Header;
                    myRange.Cells.Font.Name = "Times New Roman";
                    myRange.Cells.Font.Size = "16";
                    myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    for (int a = 1; a <= 3; a++)
                    {
                        sheet1.Columns[a].ColumnWidth = 20;
                    }
                    sheet1.Columns[4].ColumnWidth = 20;
                    sheet1.Columns[5].ColumnWidth = 40;
                    sheet1.Columns[6].ColumnWidth = 15;
                    sheet1.Columns[7].ColumnWidth = 35;
                    sheet1.Columns[8].ColumnWidth = 10;

                    myRange.Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

                }
                for (int i = 1; i < GridView.Columns.Count; i++)
                {
                    for (int j = 0; j < GridView.Items.Count; j++)
                    {
                        TextBlock b = GridView.Columns[i].GetCellContent(GridView.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 5, i + 1];
                        myRange.Value2 = b.Text;
                        myRange.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                        myRange.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                        myRange.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
                        myRange.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
                        myRange.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
                        myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }

                Range rng4 = sheet1.Range[sheet1.Cells[2, 2], sheet1.Cells[GridView.Items.Count + 7, 8]];
                rng4.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                rng4.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                rng4.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
                rng4.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;

                sheet1.Cells[2, 4] = $"Отчёт об успеваемости студентов {NameGroup} группы";
                Range rng = sheet1.Range[sheet1.Cells[2, 4], sheet1.Cells[2, 6]];
                rng.Cells.Font.Name = "Times New Roman";
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 16;
                rng.Cells.Font.Color = System.Drawing.Color.Black;

                string currentDate = DateTime.Now.Date.ToString("D");

                sheet1.Cells[GridView.Items.Count + 7, 6] = "Дата создания отчета: " + currentDate + "";
                Range Rng = sheet1.Range[sheet1.Cells[GridView.Items.Count + 7, 6], sheet1.Cells[GridView.Items.Count + 7, 7]];
                Rng.Cells.Font.Name = "Times New Roman";
                Rng.Cells.Font.Size = 16;
                Rng.Cells.Font.Color = System.Drawing.Color.Black;

                sheet1.Cells[GridView.Items.Count + 7, 2] = $"Классный руководитель: {NamePrep}";
                Range Rng1 = sheet1.Range[sheet1.Cells[GridView.Items.Count + 7, 2], sheet1.Cells[GridView.Items.Count + 7, 3]];
                Rng1.Cells.Font.Name = "Times New Roman";
                Rng1.Cells.Font.Size = 16;
                Rng1.Cells.Font.Color = System.Drawing.Color.Black;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка создания отчета!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void button_ListPredmets_Click(object sender, RoutedEventArgs e)
        {
            GetInfoPredmet($"select Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NumberPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета");
        }

        private void textbox_Fam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_NomerPredmet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetViewNamePredmet()
        {
            sqlCommand.CommandText = $"select Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NumberPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета";
            _Connection.Close();
            _Connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ListNamePredmet.Add((string)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            textbox_NomerPredmet.ItemsSource = ListNamePredmet;
            textbox_SearchPredmet.ItemsSource = ListNamePredmet;
            _Connection.Close();
        }

        private void textbox_SearchFam_TextChanged(object sender, TextChangedEventArgs e)
        {
            sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета and Фамилия Like '{textbox_SearchFam.Text}%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Номер_Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;
        }

        private void textbox_SearchVidRab_TextChanged(object sender, TextChangedEventArgs e)
        {
            sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета and Вид_оценочной_Работы Like '{textbox_SearchVidRab.Text}%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Номер_Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;
        }

        private void textbox_SearchData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета and Дата = '{textbox_SearchData.Text}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Номер_Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;
        }

        private void textbox_SearchIma_TextChanged(object sender, TextChangedEventArgs e)
        {
            sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета and Фамилия Like '{textbox_SearchFam.Text}%' and Имя like '{textbox_SearchIma.Text}%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Номер_Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;
        }

        private void button_Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета and Фамилия Like '{textbox_SearchFam.Text}%' and Имя like '{textbox_SearchIma.Text}%' and Дата = '{textbox_SearchData.Text}' and Вид_оценочной_Работы = '{textbox_SearchVidRab.Text}' and Название_Предмета = '{textbox_SearchPredmet.Text}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Номер_Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;
        }

        private void button_Trash_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox_SearchData.Text = "";
            textbox_SearchPredmet.Text = "";
            textbox_SearchFam.Clear();
            textbox_SearchIma.Clear();
            textbox_SearchVidRab.Clear();
            UpdateInfoStudent();
        }

        private void textbox_SearchPredmet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                sqlCommand.CommandText = $"select Номер_Оценки as 'Н',Фамилия,Имя,Отчество,Название_Предмета as 'Название предмета',Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',CONVERT(VARCHAR(10), Дата, 111) as Дата from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета and Название_Предмета = '{textbox_SearchPredmet.SelectedValue}'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                System.Data.DataTable dataTable = new System.Data.DataTable("Номер_Оценки");
                sqlDataAdapter.Fill(dataTable);
                GridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception)
            {
            }
        }
    }
}
