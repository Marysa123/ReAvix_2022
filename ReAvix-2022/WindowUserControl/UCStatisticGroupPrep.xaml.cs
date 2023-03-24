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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WPF;
using ReAvix_2022.ViewModels;
using System.Collections.ObjectModel;
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

        public ObservableCollection<ISeries> Series { get; set; }
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

            //vMWindowStatisticGroupPrep.AddGraph(out ObservableCollection<ISeries> SeriesOut);
            //Series = SeriesOut; // Присовения значения для поля из входящего параметра

            cartesianChart = new LiveChartsCore.SkiaSharpView.WPF.CartesianChart() // Создание графика
            {
                Series = Series,
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
            };
            ContainerGrid.Children.Add(cartesianChart); // Добавление графика в Grid


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
