using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WPF;
using ReAvix_2022.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowInfoAboutPredmet.xaml
    /// </summary>
    public partial class WindowInfoAboutPredmet : Window
    {
        public ObservableCollection<ISeries> Series { get; set; }

        VMWindowInfoAboutPredmet windowInfoAboutPredmet;
        CartesianChart cartesianChart;

        private int NumberPrepdmet;
        private int NumberStudent;

        public WindowInfoAboutPredmet(int NomerPred, int NumberSt)
        {
            NumberPrepdmet = NomerPred;
            NumberStudent = NumberSt;

            InitializeComponent();

            windowInfoAboutPredmet = new VMWindowInfoAboutPredmet();
            windowInfoAboutPredmet.GetInfoPredmet(NumberPrepdmet); // Вызов метода для отображения информации о предмете

            DataContext = windowInfoAboutPredmet;

        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void combobox_Montch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContainerGrid.Children.Clear(); // Удаление дочерних элементов из Grid, чтобы не было нескольких графиков
            windowInfoAboutPredmet = new VMWindowInfoAboutPredmet();

            int IndexMontch = combobox_Montch.SelectedIndex + 1; // Получения индекса месяца

            windowInfoAboutPredmet.AddGraph(NumberPrepdmet, NumberStudent, IndexMontch, out ObservableCollection<ISeries> SeriesOut); // Метод создания графиков

            Series = SeriesOut; // Присовения значения для поля из входящего параметра

            cartesianChart = new CartesianChart() // Создание графика
            {
                Series = Series,
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
            };  
            ContainerGrid.Children.Add(cartesianChart); // Добавление графика в Grid
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
