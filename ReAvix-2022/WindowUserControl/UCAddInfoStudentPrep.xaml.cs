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

            vMWindowAddInfoStudent = new VMWindowAddInfoStudentPrep(NumberPrep);
            DataContext = vMWindowAddInfoStudent;

            GetInfoStudent();

        }
        public UCAddInfoStudentPrep()
        {
            InitializeComponent();

        }
        string NameGroup;
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();
        public void GetInfoStudent()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();

            sqlCommand.Connection = _Connection;
            sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
            NameGroup = (string)sqlCommand.ExecuteScalar();

            UpdateInfoStudent();

            GetInfoPredmet($"select Предметы.Номер_Предмета as 'Номер предмета',Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NumberPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета");

            _Connection.Close();
        }

        List<int> MassivNomerStudent = new List<int>();
        List<int> MassivNomerOchenok = new List<int>();


        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (textbox_NomerPredmet.Text == "" || textbox_Fam.Text == "" || textbox_Data.Text == "" || textbox_OChenka.Text == "" || textbox_VidWork.Text == "")
            {
                MessageBox.Show("Пустые поля", "Диалоговое окно");
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

                            sqlCommand.CommandText = "set language english;";
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.CommandText = $"update Оценки set [Дата] = Convert(datetime,'{textbox_Data.Text}'),[FK_Номер_Студента] ={textbox_Fam.Text},[FK_Номер_Предмета] = {textbox_NomerPredmet.Text}, Оценка = {textbox_OChenka.Text}, Вид_оценочной_работы ='{textbox_VidWork.Text}' where Номер_оценки = {label_Номер.Content}";
                            try
                            {
                                sqlCommand.ExecuteNonQuery();
                                MessageBox.Show("Данные успешно обновлены", "Диалоговое окно");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Выберите строку!", "Диалоговое окно");
                            }

                            UpdateInfoStudent();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные", "Диалоговое окно");
                }

                GetInfoPredmet($"select DISTINCT(Предметы.[Номер_Предмета]) as 'Номер предмета',Предметы.[Название_Предмета] as 'Название предмета' from [Оценки],[Студенты],[Предметы],[Предметы_Преподавателя] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Предметы.Номер_Предмета and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета group by FK_Номер_Предмета,Предметы.Название_Предмета,Предметы.Номер_Предмета");
                _Connection.Close();
                    
            }
        }

        private void UpdateInfoStudent()
        {
            GridViewPredmet.ItemsSource = null;
            //  sqlCommand.CommandText = $"select Номер_оценки as 'Номер строки',Convert(date, Дата,101) as Дата,ФИО_Студента,[Оценки_2].Название_Предмета as 'Название Предмета',[Оценка],[Вид_оценочной_работы] as 'Вид оценочной работы' from [Оценки_2],[Студенты] where FK_Номер_Группы = '{NameGroup}' and ФИО_Студента = Фамилия + ' ' + Имя + ' ' + Отчество";
            sqlCommand.CommandText = $"select Номер_Оценки as 'Номер',Дата,Оценка,Вид_оценочной_Работы as 'Вид оценочной работы',Имя,Фамилия,Название_Предмета as 'Название предмета' from [Оценки],[Студенты],Предметы where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;

            GetInfoPredmet($"select Предметы.Номер_Предмета as 'Номер предмета',Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NumberPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета");

        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (textbox_NomerPredmet.Text == "" || textbox_Fam.Text == "" || textbox_Data.Text == "" || textbox_OChenka.Text == "" || textbox_VidWork.Text == "")
            {
                MessageBox.Show("Пустые поля", "Диалоговое окно");
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
                            sqlCommand.CommandText = "set language english;";
                            sqlCommand.ExecuteNonQuery();

                            sqlCommand.CommandText = $"insert into [Оценки] values ('{textbox_Data.Text}',{textbox_Fam.Text},{textbox_NomerPredmet.Text},{textbox_OChenka.Text},'{textbox_VidWork.Text}')";
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены", "Диалоговое окно");

                            UpdateInfoStudent();
                            _Connection.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные", "Диалоговое окно");
                }
            }
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {  
            if (GridView.CurrentCell.Column.DisplayIndex == 0)
            {
                _Connection.Open();
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel);

                switch (result)
                {
                    case MessageBoxResult.OK:

                    _Connection.Close();

                    _Connection.Open();
                    sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
                    string NameGroup = (string)sqlCommand.ExecuteScalar();

                    sqlCommand.CommandText = $"select COUNT (Номер_Оценки) from [Студенты],[Оценки] where [FK_Номер_Студента] = [Номер_Студента]  and FK_Номер_Группы = '{NameGroup}'";
                    sqlCommand.Connection = _Connection;
                    int Count = (int)sqlCommand.ExecuteScalar();

                    sqlCommand.CommandText = $"select Номер_Оценки from [Студенты],[Оценки] where [FK_Номер_Студента] = [Номер_Студента]  and FK_Номер_Группы = '{NameGroup}'";

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    MassivNomerOchenok = new List<int>();
                    while (sqlDataReader.Read())
                    {
                       MassivNomerOchenok.Add((int)sqlDataReader.GetValue(0));
                    }
                    sqlDataReader.Close();

                    var Name = ((DataRowView)GridView.SelectedItems[0]).Row["Номер"].ToString();


                    for (int i = 0; i < Count; i++)
                    {
                        if (Name == MassivNomerOchenok[i].ToString())
                        {
                            sqlCommand.CommandText = $"delete from Оценки where [Номер_оценки] = {Name}";
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Запись удалена!");
                            UpdateInfoStudent();
                            GetInfoPredmet($"select Предметы.Номер_Предмета as 'Номер предмета',Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NumberPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета");
                            _Connection.Close();
                        }
                    }  
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
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            sheet1.Name = "Отчёт";
            for (int j = 0; j < GridView.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[4, j + 1];
                sheet1.Cells[4, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 6;
                myRange.Value2 = GridView.Columns[j].Header;
                myRange.Cells.Font.Name = "Times New Roman";
                myRange.Cells.Font.Size = "16";
                for (int a = 1; a <= 3; a++)
                {
                    sheet1.Columns[a].ColumnWidth = 20;
                }
                sheet1.Columns[4].ColumnWidth = 40;
                sheet1.Columns[5].ColumnWidth = 40;
                sheet1.Columns[6].ColumnWidth = 20;

                myRange.VerticalAlignment = XlHAlign.xlHAlignCenter;
                myRange.Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                myRange.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                myRange.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                myRange.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
                myRange.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
                myRange.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;

            }
            for (int i = 0; i < GridView.Columns.Count; i++)
            {
                for (int j = 0; j < GridView.Items.Count; j++)
                {
                    TextBlock b = GridView.Columns[i].GetCellContent(GridView.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 5, i + 1];
                    myRange.Value2 = b.Text;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
                }
            }

            Range rng4 = sheet1.Range[sheet1.Cells[2, 1], sheet1.Cells[GridView.Items.Count + 9, 6]];
            rng4.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
            rng4.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
            rng4.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
            rng4.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;

            sheet1.Cells[2, 1] = "Отчёт об успеваемости студентов ?? группы Волчихинский Политехнический колледж за 1 семестр 22-23 уч.года";
            Range rng = sheet1.Range[sheet1.Cells[2, 1], sheet1.Cells[2, 3]];
            rng.Cells.Font.Name = "Times New Roman";
            rng.Cells.Font.Bold = true;
            rng.Cells.Font.Size = 16;
            rng.Cells.Font.Color = System.Drawing.Color.Black;

            string currentDate = DateTime.Now.Date.ToString("D");

            sheet1.Cells[GridView.Items.Count + 7, 5] = "Дата создания отчета: " + currentDate + "";
            Range Rng = sheet1.Range[sheet1.Cells[GridView.Items.Count + 7, 5], sheet1.Cells[GridView.Items.Count + 7, 5]];
            Rng.Cells.Font.Name = "Times New Roman";
            Rng.Cells.Font.Size = 16;
            Rng.Cells.Font.Color = System.Drawing.Color.Black;

            sheet1.Cells[GridView.Items.Count + 7, 1] = "Преподаватель: ?";
            Range Rng1 = sheet1.Range[sheet1.Cells[GridView.Items.Count + 7, 1], sheet1.Cells[GridView.Items.Count + 7, 1]];
            Rng1.Cells.Font.Name = "Times New Roman";
            Rng1.Cells.Font.Size = 16;
            Rng1.Cells.Font.Color = System.Drawing.Color.Black;
        }

        private void button_ListPredmets_Click(object sender, RoutedEventArgs e)
        {
            GetInfoPredmet($"select Предметы.Номер_Предмета as 'Номер предмета',Предметы_Преподавателя.Название_Предмета as 'Название предмета' from Предметы_Преподавателя,Предметы where FK_Номер_Преподавателя = {NumberPrep} and Предметы.Название_Предмета = Предметы_Преподавателя.Название_Предмета");
        }

        private void button_ListStudent_Click(object sender, RoutedEventArgs e)
        {
            GridViewPredmet.ItemsSource = null;
            sqlCommand.CommandText = $"select Номер_Студента as 'Номер студента',Фамилия,Имя,Отчество from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Студенты");
            sqlDataAdapter.Fill(dataTable);
            GridViewPredmet.ItemsSource = dataTable.DefaultView;
        }
    }
}
