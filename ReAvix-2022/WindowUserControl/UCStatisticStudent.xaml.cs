using ReAvix_2022.Models;
using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCStatisticStudent.xaml
    /// </summary>
    public partial class UCStatisticStudent : UserControl
    {
        ModelsNotes modelsNotes = new ModelsNotes();
        private int NumberStudent;

        List<int> MassivNomerPred;

        public UCStatisticStudent()
        {

        }
        VMWindowStatisticStudent vMWindowStatisticStudent;
        public UCStatisticStudent(int NumberSt)
        {
            InitializeComponent();
            NumberStudent = NumberSt;

            vMWindowStatisticStudent = new VMWindowStatisticStudent(NumberStudent);
            DataContext = vMWindowStatisticStudent; // Устанаваливает Контекст Данных на Внешнюю Модель

            modelsNotes.AddNotes(NumberStudent); // Вызов метода и передача номера студента
            BorderMain.ItemsSource = modelsNotes.MainBorders; //Устанавливает значения 
            vMWindowStatisticStudent.AddPredmet(out List<Grid> MassivGridOut);

            MassivNomerPred = vMWindowStatisticStudent.MassivNomerPredmet;
            PanelPredmet.ItemsSource = MassivGridOut;
        }



        private void BorderMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.DeleteNotes(IndexSelectedItems: BorderMain.SelectedIndex);// Вызов метода удаления заметок
            MessageBox.Show("Заметка успешно удалена.", "Диалоговое окно");
        }

        private void button_AddZam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddNotes windowAddNotes = new WindowAddNotes(NumberSt: NumberStudent); // ВЫзов окна добаления заметок
            windowAddNotes.ShowDialog();
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
            windowInfoAboutPredmet.ShowDialog();
        }
    }
}

