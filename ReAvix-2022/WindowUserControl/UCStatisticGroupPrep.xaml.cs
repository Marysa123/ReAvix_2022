using LiveChartsCore;
using Microsoft.Office.Interop.Excel;
using ReAvix_2022.Models;
using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCStatisticGroupPrep.xaml
    /// </summary>
    public partial class UCStatisticGroupPrep : UserControl
    {
        private int NomerPrep;
        VMWindowStatisticGroupPrep vMWindowStatisticGroupPrep;
        ModelsNotes modelsNotes = new ModelsNotes();

        public ObservableCollection<LiveChartsCore.ISeries> Series { get; set; }
        LiveChartsCore.SkiaSharpView.WPF.CartesianChart cartesianChart;


        public UCStatisticGroupPrep()
        {

        }
        public UCStatisticGroupPrep(int NumberPrep)
        {
            InitializeComponent();

            NomerPrep = NumberPrep;
            vMWindowStatisticGroupPrep = new VMWindowStatisticGroupPrep(NomerPrep);

            modelsNotes.AddNotesPrep(NomerPrep);
            BorderMain.ItemsSource = modelsNotes.MainBordersPrep;
            vMWindowStatisticGroupPrep.GetOmissionsStudent();

            DataContext = vMWindowStatisticGroupPrep;


            vMWindowStatisticGroupPrep.GetAvgPredmet();
            BorderMainPredmets.ItemsSource = vMWindowStatisticGroupPrep.Grids;

            GridListStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTable.DefaultView;
            GridListOtclStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtclStudent.DefaultView;
            ListOchenokStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokStudent.DefaultView;
            GridListNoYlStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokThreeStudent.DefaultView;
            textbox_SearchPredmet.ItemsSource = vMWindowStatisticGroupPrep.ListNamePredmet;

        }

        private void BorderMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.DeleteNotesPrep(IndexSelectedItems: BorderMain.SelectedIndex);// Вызов метода удаления заметок
        }

        private void button_AddZam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddNotesPrep windowAddNotesPrep = new WindowAddNotesPrep(NomerPrep);
            windowAddNotesPrep.ShowDialog();
            modelsNotes.AddNotesPrep(NomerPrep);
            BorderMain.ItemsSource = modelsNotes.MainBordersPrep;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_ListStudent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                sheet1.Name = "Отчёт";
                for (int j = 0; j < GridListStudent.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[4, j + 1];
                    sheet1.Cells[4, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 6;

                    myRange.Value2 = GridListStudent.Columns[j].Header;
                    myRange.Cells.Font.Name = "Times New Roman";
                    myRange.Cells.Font.Size = "16";
                    myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    for (int a = 1; a <= 5; a++)
                    {
                        sheet1.Columns[a].ColumnWidth = 20;
                    }
                    sheet1.Columns[4].ColumnWidth = 25;
                    sheet1.Columns[5].ColumnWidth = 25;


                    myRange.Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

    

                }
                for (int i = 0; i < GridListStudent.Columns.Count; i++)
                {
                    for (int j = 0; j < GridListStudent.Items.Count - 1; j++)
                    {
                        TextBlock b = GridListStudent.Columns[i].GetCellContent(GridListStudent.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 5, i + 1];
                        myRange.Value2 = b.Text;

                        myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }


                sheet1.Cells[2, 3] = $"Спискок студентов {vMWindowStatisticGroupPrep.NameGroup} группы";
                Range rng = sheet1.Range[sheet1.Cells[2, 3], sheet1.Cells[2, 4]];
                rng.Cells.Font.Name = "Times New Roman";
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 16;
                rng.Cells.Font.Color = System.Drawing.Color.Black;

                string currentDate = DateTime.Now.Date.ToString("D");

                sheet1.Cells[GridListStudent.Items.Count + 5, 1] = "Дата создания отчета: " + currentDate + "";
                Range Rng = sheet1.Range[sheet1.Cells[GridListStudent.Items.Count + 5, 1], sheet1.Cells[GridListStudent.Items.Count + 5, 2]];
                Rng.Cells.Font.Name = "Times New Roman";
                Rng.Cells.Font.Size = 16;
                Rng.Cells.Font.Color = System.Drawing.Color.Black;

                sheet1.Cells[GridListStudent.Items.Count + 6, 1] = $"Классный руководитель: {vMWindowStatisticGroupPrep.FI}";
                Range Rng1 = sheet1.Range[sheet1.Cells[GridListStudent.Items.Count + 6, 1], sheet1.Cells[GridListStudent.Items.Count + 6, 2]];
                Rng1.Cells.Font.Name = "Times New Roman";
                Rng1.Cells.Font.Size = 16;
                Rng1.Cells.Font.Color = System.Drawing.Color.Black;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка создания отчета!","Диалоговое окно",MessageBoxButton.OK,MessageBoxImage.Information);
            }    
        }

        private void button_ListOtclStudent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                sheet1.Name = "Отчёт";
                for (int j = 0; j < GridListOtclStudent.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[4, j + 1];
                    sheet1.Cells[4, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 6;

                    myRange.Value2 = GridListOtclStudent.Columns[j].Header;
                    myRange.Cells.Font.Name = "Times New Roman";
                    myRange.Cells.Font.Size = "16";
                    myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    for (int a = 1; a <= 5; a++)
                    {
                        sheet1.Columns[a].ColumnWidth = 20;
                    }
                    sheet1.Columns[4].ColumnWidth = 25;
                    sheet1.Columns[5].ColumnWidth = 25;


                    myRange.Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

     

                }
                for (int i = 0; i < GridListOtclStudent.Columns.Count; i++)
                {
                    for (int j = 0; j < GridListOtclStudent.Items.Count - 1; j++)
                    {
                        TextBlock b = GridListOtclStudent.Columns[i].GetCellContent(GridListOtclStudent.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 5, i + 1];
                        myRange.Value2 = b.Text;
 
                        myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }


                sheet1.Cells[2, 3] = $"Спискок отличников {vMWindowStatisticGroupPrep.NameGroup} группы на месяц {DateTime.Now.Date.ToString("Y")}";
                Range rng = sheet1.Range[sheet1.Cells[2, 3], sheet1.Cells[2, 4]];
                rng.Cells.Font.Name = "Times New Roman";
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 16;
                rng.Cells.Font.Color = System.Drawing.Color.Black;

                string currentDate = DateTime.Now.Date.ToString("D");

                sheet1.Cells[GridListOtclStudent.Items.Count + 5, 1] = "Дата создания отчета: " + currentDate + "";
                Range Rng = sheet1.Range[sheet1.Cells[GridListOtclStudent.Items.Count + 5, 1], sheet1.Cells[GridListOtclStudent.Items.Count + 5, 2]];
                Rng.Cells.Font.Name = "Times New Roman";
                Rng.Cells.Font.Size = 16;
                Rng.Cells.Font.Color = System.Drawing.Color.Black;

                sheet1.Cells[GridListOtclStudent.Items.Count + 6, 1] = $"Классный руководитель: {vMWindowStatisticGroupPrep.FI}";
                Range Rng1 = sheet1.Range[sheet1.Cells[GridListOtclStudent.Items.Count + 6, 1], sheet1.Cells[GridListOtclStudent.Items.Count + 6, 2]];
                Rng1.Cells.Font.Name = "Times New Roman";
                Rng1.Cells.Font.Size = 16;
                Rng1.Cells.Font.Color = System.Drawing.Color.Black;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка создания отчета!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListOchenokStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokStudent.DefaultView;
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            vMWindowStatisticGroupPrep.GetListOtchenokAllStudent();
            ListOchenokStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokAllStudent.DefaultView;
        }

        private void button_ListNoYlStudent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                sheet1.Name = "Отчёт";
                for (int j = 0; j < GridListNoYlStudent.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[4, j + 1];
                    sheet1.Cells[4, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 6;

                    myRange.Value2 = GridListNoYlStudent.Columns[j].Header;
                    myRange.Cells.Font.Name = "Times New Roman";
                    myRange.Cells.Font.Size = "16";
                    myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    for (int a = 1; a <= 5; a++)
                    {
                        sheet1.Columns[a].ColumnWidth = 20;
                    }
                    sheet1.Columns[4].ColumnWidth = 25;
                    sheet1.Columns[5].ColumnWidth = 25;


                    myRange.Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);



                }
                for (int i = 0; i < GridListNoYlStudent.Columns.Count; i++)
                {
                    for (int j = 0; j < GridListNoYlStudent.Items.Count - 1; j++)
                    {
                        TextBlock b = GridListNoYlStudent.Columns[i].GetCellContent(GridListNoYlStudent.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 5, i + 1];
                        myRange.Value2 = b.Text;

                        myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }


                sheet1.Cells[2, 3] = $"Спискок троечников и не успевающих студентов {vMWindowStatisticGroupPrep.NameGroup} группы на месяц {DateTime.Now.Date.ToString("Y")}";
                Range rng = sheet1.Range[sheet1.Cells[2, 3], sheet1.Cells[2, 4]];
                rng.Cells.Font.Name = "Times New Roman";
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 16;
                rng.Cells.Font.Color = System.Drawing.Color.Black;

                string currentDate = DateTime.Now.Date.ToString("D");

                sheet1.Cells[GridListNoYlStudent.Items.Count + 5, 1] = "Дата создания отчета: " + currentDate + "";
                Range Rng = sheet1.Range[sheet1.Cells[GridListNoYlStudent.Items.Count + 5, 1], sheet1.Cells[GridListNoYlStudent.Items.Count + 5, 2]];
                Rng.Cells.Font.Name = "Times New Roman";
                Rng.Cells.Font.Size = 16;
                Rng.Cells.Font.Color = System.Drawing.Color.Black;

                sheet1.Cells[GridListNoYlStudent.Items.Count + 6, 1] = $"Классный руководитель: {vMWindowStatisticGroupPrep.FI}";
                Range Rng1 = sheet1.Range[sheet1.Cells[GridListNoYlStudent.Items.Count + 6, 1], sheet1.Cells[GridListNoYlStudent.Items.Count + 6, 2]];
                Rng1.Cells.Font.Name = "Times New Roman";
                Rng1.Cells.Font.Size = 16;
                Rng1.Cells.Font.Color = System.Drawing.Color.Black;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка создания отчета!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void textbox_SearchPredmet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            vMWindowStatisticGroupPrep.SearchFioNamePredmetStudent(textbox_SearchPredmet.SelectedValue.ToString());
            ListOchenokStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokAllStudent.DefaultView;
        }

        private void textbox_SearchFam_TextChanged(object sender, TextChangedEventArgs e)
        {
            vMWindowStatisticGroupPrep.SearchFioStudent(textbox_SearchFam.Text);
            ListOchenokStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokAllStudent.DefaultView;
        }

        private void textbox_SearchIma_TextChanged(object sender, TextChangedEventArgs e)
        {
            vMWindowStatisticGroupPrep.SearchFioAndImaStudent(textbox_SearchFam.Text,textbox_SearchIma.Text);
            ListOchenokStudent.ItemsSource = vMWindowStatisticGroupPrep.dataTableOtchenokAllStudent.DefaultView;
        }

        private void button_List_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                sheet1.Name = "Отчёт";
                for (int j = 0; j < ListOchenokStudent.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[4, j + 1];
                    sheet1.Cells[4, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 6;

                    myRange.Value2 = ListOchenokStudent.Columns[j].Header;
                    myRange.Cells.Font.Name = "Times New Roman";
                    myRange.Cells.Font.Size = "16";
                    myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    for (int a = 1; a <= 5; a++)
                    {
                        sheet1.Columns[a].ColumnWidth = 20;
                    }
                    sheet1.Columns[4].ColumnWidth = 25;
                    sheet1.Columns[5].ColumnWidth = 25;


                    myRange.Cells.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

   

                }
                for (int i = 0; i < ListOchenokStudent.Columns.Count; i++)
                {
                    for (int j = 0; j < ListOchenokStudent.Items.Count; j++)
                    {
                        TextBlock b = ListOchenokStudent.Columns[i].GetCellContent(ListOchenokStudent.Items[j]) as TextBlock;
                        Range myRange = (Range)sheet1.Cells[j + 5, i + 1];
                        myRange.Value2 = b.Text;

                        myRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }
                }


                sheet1.Cells[2, 2] = $"Отчет об успеваемости студента {vMWindowStatisticGroupPrep.NameGroup} группы";
                Range rng = sheet1.Range[sheet1.Cells[2, 2], sheet1.Cells[2, 3]];
                rng.Cells.Font.Name = "Times New Roman";
                rng.Cells.Font.Bold = true;
                rng.Cells.Font.Size = 16;
                rng.Cells.Font.Color = System.Drawing.Color.Black;

                string currentDate = DateTime.Now.Date.ToString("D");

                sheet1.Cells[ListOchenokStudent.Items.Count + 5, 1] = "Дата создания отчета: " + currentDate + "";
                Range Rng = sheet1.Range[sheet1.Cells[ListOchenokStudent.Items.Count + 5, 1], sheet1.Cells[ListOchenokStudent.Items.Count + 5, 2]];
                Rng.Cells.Font.Name = "Times New Roman";
                Rng.Cells.Font.Size = 16;
                Rng.Cells.Font.Color = System.Drawing.Color.Black;

                sheet1.Cells[ListOchenokStudent.Items.Count + 6, 1] = $"Классный руководитель: {vMWindowStatisticGroupPrep.FI}";
                Range Rng1 = sheet1.Range[sheet1.Cells[ListOchenokStudent.Items.Count + 6, 1], sheet1.Cells[ListOchenokStudent.Items.Count + 6, 2]];
                Rng1.Cells.Font.Name = "Times New Roman";
                Rng1.Cells.Font.Size = 16;
                Rng1.Cells.Font.Color = System.Drawing.Color.Black;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка создания отчета!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
