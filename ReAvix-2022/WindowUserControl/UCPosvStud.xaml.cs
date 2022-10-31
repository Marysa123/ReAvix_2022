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
using DataTable = System.Data.DataTable;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCPosvStud.xaml
    /// </summary>
    public partial class UCPosvStud : UserControl
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();

       DataTable dataTableFour;

        public UCPosvStud()
        {
            InitializeComponent();
        }
        string NameGroup;
        VMWindowPosvStud vMWindowPosvStud;
        public UCPosvStud(int NomerPrep)
        {
            InitializeComponent();

            vMWindowPosvStud = new VMWindowPosvStud();

            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();

            sqlCommand.Connection = _Connection;
            sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NomerPrep}";
            NameGroup = (string)sqlCommand.ExecuteScalar();
            _Connection.Close();

            vMWindowPosvStud.NumberPrep = NomerPrep;
            vMWindowPosvStud.NameGroup = NameGroup;

            DataContext = vMWindowPosvStud;

            vMWindowPosvStud.UpdateOmissions();
            GridViewOmissions.ItemsSource = vMWindowPosvStud.dataTableFour.DefaultView;
        }

        private void button_DeleteOmissions_Click(object sender, RoutedEventArgs e)
        {
            vMWindowPosvStud.DeleteOmission();
            GridViewOmissions.ItemsSource = null;
            GridViewOmissions.ItemsSource = vMWindowPosvStud.dataTableFour.DefaultView;

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            _Connection.Close();
            if (textbox_Bolezn.Text == "" || textbox_NoYvash.Text == "" || textbox_Yvash.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно");
            }
            else
            {
                _Connection.Open();
                if (label_NomerStud.Content == null)
                {
                    return;
                }

                sqlCommand.CommandText = $"update Пропуски set [Уважительные_Пропуски] = {textbox_Yvash.Text},[Неуважительные_Пропуски] = {textbox_NoYvash.Text}, [Пропуски_по_болезни] = {textbox_Bolezn.Text} where [FK_Номер_Студента] = {label_NomerStud.Content.ToString()}";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");

                GridViewOmissions.ItemsSource = null;
                sqlCommand.CommandText = $"select FK_Номер_Студента as 'Номер Студента',[Фамилия] + ' ' + [Имя] AS ФИО, Уважительные_Пропуски as 'Уважительные пропуски',Неуважительные_пропуски as 'Неуважительные пропуски',Пропуски_по_болезни as 'Пропуски по болезни' from [Пропуски],[Студенты] where FK_Номер_Студента = [Номер_Студента] and [FK_Номер_Группы] = '{NameGroup}' order by Уважительные_Пропуски desc";
                SqlDataAdapter sqlDataAdapterFour = new SqlDataAdapter(sqlCommand);
                dataTableFour = new System.Data.DataTable("Студенты");
                sqlDataAdapterFour.Fill(dataTableFour);
                GridViewOmissions.ItemsSource = dataTableFour.DefaultView;

                _Connection.Close();
            }
        }

        private void textbox_Bolezn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_NoYvash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textbox_Yvash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_AddOtch_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            sheet1.Name = "Отчёт";
            for (int j = 0; j < GridViewOmissions.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[4, j + 1];
                sheet1.Cells[4, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 6;
                myRange.Value2 = GridViewOmissions.Columns[j].Header;
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
            for (int i = 0; i < GridViewOmissions.Columns.Count; i++)
            {
                for (int j = 0; j < GridViewOmissions.Items.Count; j++)
                {
                    TextBlock b = GridViewOmissions.Columns[i].GetCellContent(GridViewOmissions.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 5, i + 1];
                    myRange.Value2 = b.Text;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
                    myRange.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
                }
            }

            Range rng4 = sheet1.Range[sheet1.Cells[2, 1], sheet1.Cells[GridViewOmissions.Items.Count + 9, 6]];
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

            sheet1.Cells[GridViewOmissions.Items.Count + 7, 5] = "Дата создания отчета: " + currentDate + "";
            Range Rng = sheet1.Range[sheet1.Cells[GridViewOmissions.Items.Count + 7, 5], sheet1.Cells[GridViewOmissions.Items.Count + 7, 5]];
            Rng.Cells.Font.Name = "Times New Roman";
            Rng.Cells.Font.Size = 16;
            Rng.Cells.Font.Color = System.Drawing.Color.Black;

            sheet1.Cells[GridViewOmissions.Items.Count + 7, 1] = "Преподаватель: ?";
            Range Rng1 = sheet1.Range[sheet1.Cells[GridViewOmissions.Items.Count + 7, 1], sheet1.Cells[GridViewOmissions.Items.Count + 7, 1]];
            Rng1.Cells.Font.Name = "Times New Roman";
            Rng1.Cells.Font.Size = 16;
            Rng1.Cells.Font.Color = System.Drawing.Color.Black;
        }
    }
}
