using LiveCharts.Wpf;
using LiveChartsCore;
using ReAvix_2022.Models;
using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
#pragma warning disable CS0105 // Директива using для "LiveChartsCore" ранее встречалась в этом пространстве имен
using LiveChartsCore;
#pragma warning restore CS0105 // Директива using для "LiveChartsCore" ранее встречалась в этом пространстве имен
using LiveChartsCore.SkiaSharpView.WPF;
#pragma warning disable CS0105 // Директива using для "ReAvix_2022.ViewModels" ранее встречалась в этом пространстве имен
using ReAvix_2022.ViewModels;
#pragma warning restore CS0105 // Директива using для "ReAvix_2022.ViewModels" ранее встречалась в этом пространстве имен
#pragma warning disable CS0105 // Директива using для "System.Collections.ObjectModel" ранее встречалась в этом пространстве имен
using System.Collections.ObjectModel;
#pragma warning restore CS0105 // Директива using для "System.Collections.ObjectModel" ранее встречалась в этом пространстве имен
#pragma warning disable CS0105 // Директива using для "System.Windows" ранее встречалась в этом пространстве имен
using System.Windows;
#pragma warning restore CS0105 // Директива using для "System.Windows" ранее встречалась в этом пространстве имен
#pragma warning disable CS0105 // Директива using для "System.Windows.Controls" ранее встречалась в этом пространстве имен
using System.Windows.Controls;
#pragma warning restore CS0105 // Директива using для "System.Windows.Controls" ранее встречалась в этом пространстве имен
#pragma warning disable CS0105 // Директива using для "System.Windows.Input" ранее встречалась в этом пространстве имен
using System.Windows.Input;
#pragma warning restore CS0105 // Директива using для "System.Windows.Input" ранее встречалась в этом пространстве имен

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

        public ObservableCollection<ISeries> Series { get; set; }
#pragma warning disable CS0169 // Поле "UCStatisticGroupPrep.cartesianChart" никогда не используется.
        LiveChartsCore.SkiaSharpView.WPF.CartesianChart cartesianChart;
#pragma warning restore CS0169 // Поле "UCStatisticGroupPrep.cartesianChart" никогда не используется.


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

            //vMWindowStatisticGroupPrep.AddGraph(out ObservableCollection<ISeries> SeriesOut);
            //Series = SeriesOut; // Присовения значения для поля из входящего параметра

            //cartesianChart = new LiveChartsCore.SkiaSharpView.WPF.CartesianChart() // Создание графика
            //{
            //    Series = Series,
            //    ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
            //};
            //ContainerGrid.Children.Add(cartesianChart); // Добавление графика в Grid
        }

        private void BorderMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.DeleteNotesPrep(IndexSelectedItems: BorderMain.SelectedIndex);// Вызов метода удаления заметок
        }

        private void button_Update_MouseDown(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.AddNotesPrep(NomerPrep);
            BorderMain.ItemsSource = modelsNotes.MainBordersPrep;
        }

        private void button_AddZam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddNotesPrep windowAddNotesPrep = new WindowAddNotesPrep(NomerPrep);
            windowAddNotesPrep.ShowDialog();
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
