using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ReAvix_2022.Models;
using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCStatisticStudent.xaml
    /// </summary>
    public partial class UCStatisticStudent : UserControl
    {
        ModelsNotes modelsNotes = new ModelsNotes();
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        private int NumberStudent;

        public SeriesCollection seriesCollection { get; set; }
        public List<SeriesCollection> Series;
        List<int> MassivNomerPred;
        List<Grid> MassivGrid;

        public UCStatisticStudent()
        {

        }

        public UCStatisticStudent(int NumberSt)
        {
            InitializeComponent();
            NumberStudent = NumberSt;

            VMWindowStatisticStudent vMWindowStatisticStudent = new VMWindowStatisticStudent(NumberStudent);
            DataContext = vMWindowStatisticStudent; // Устанаваливает Контекст Данных на Внешнюю Модель

            modelsNotes.AddNotes(NumberStudent); // Вызов метода и передача номера студента
            BorderMain.ItemsSource = modelsNotes.MainBorders; //Устанавливает значения 
            vMWindowStatisticStudent.AddPredmet(out List<Grid> MassivGridOut);

            MassivNomerPred = vMWindowStatisticStudent.MassivNomerPredmet;
            MassivGrid = MassivGridOut;

            PanelPredmet.ItemsSource = MassivGrid;
        }



        private void BorderMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.DeleteNotes(IndexSelectedItems: BorderMain.SelectedIndex);// Вызов метода удаления заметок
        }

        private void button_AddZam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddNotes windowAddNotes = new WindowAddNotes(NumberSt: NumberStudent); // ВЫзов окна добаления заметок
            windowAddNotes.Show();
        }

        private void UpdateNotes_MouseDown(object sender, MouseButtonEventArgs e) //Событие Обновления Заметок
        {
            modelsNotes.AddNotes(NumberStudent); // Вызов метода и передача номера студента
            BorderMain.ItemsSource = modelsNotes.MainBorders; // Устанавливает новые значения 
        }
        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PanelPredmet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int NomerPredmet = MassivNomerPred[PanelPredmet.SelectedIndex];
            WindowInfoAboutPredmet windowInfoAboutPredmet = new WindowInfoAboutPredmet(NomerPredmet, NumberStudent);
            windowInfoAboutPredmet.Show();
        }
    }
}

