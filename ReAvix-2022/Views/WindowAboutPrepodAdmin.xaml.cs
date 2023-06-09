using Microsoft.Office.Interop.Excel;
using ReAvix_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
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
    /// Логика взаимодействия для WindowAboutPrepodAdmin.xaml
    /// </summary>
    public partial class WindowAboutPrepodAdmin : System.Windows.Window
    {
        public int Nomer { get; set; }
        VMWindowAboutPrepodAdmin VMWindowAboutPrepodAdmin;

        public WindowAboutPrepodAdmin(int NomerPrep)
        {
            InitializeComponent();
            Nomer = NomerPrep;
            VMWindowAboutPrepodAdmin = new VMWindowAboutPrepodAdmin(Nomer);
            DataContext = VMWindowAboutPrepodAdmin;
            VMWindowAboutPrepodAdmin.GetInfoPrep();
            ImagePrep.Source = VMWindowAboutPrepodAdmin.newBitmapImage;

            GridListStudent.ItemsSource = VMWindowAboutPrepodAdmin.dataTable.DefaultView;
        }

        private void icon_Exit2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
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


                sheet1.Cells[2, 3] = $"Спискок студентов {VMWindowAboutPrepodAdmin.NameGroup} группы";
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

                sheet1.Cells[GridListStudent.Items.Count + 6, 1] = $"Классный руководитель: {VMWindowAboutPrepodAdmin.FI}";
                Range Rng1 = sheet1.Range[sheet1.Cells[GridListStudent.Items.Count + 6, 1], sheet1.Cells[GridListStudent.Items.Count + 6, 2]];
                Rng1.Cells.Font.Name = "Times New Roman";
                Rng1.Cells.Font.Size = 16;
                Rng1.Cells.Font.Color = System.Drawing.Color.Black;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка создания отчета!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
