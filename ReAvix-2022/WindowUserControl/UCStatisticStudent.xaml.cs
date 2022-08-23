using ReAvix_2022.Models;
using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCStatisticStudent.xaml
    /// </summary>
    public partial class UCStatisticStudent : UserControl
    {
        int nomer_NotesStudent;
        ModelsNotes modelsNotes = new ModelsNotes();

        public UCStatisticStudent(int nomer_Student)
        {
            InitializeComponent();
            nomer_NotesStudent = nomer_Student;

            VMWindowStatisticStudent vMWindowStatisticStudent = new VMWindowStatisticStudent(nr_Student: nomer_Student);
            DataContext = vMWindowStatisticStudent; // Устанаваливает Контекст Данных на Внешнюю Модель

            modelsNotes.AddNotes(nomer_Student); // Вызов метода и передача номера студента
            BorderMain.ItemsSource = modelsNotes.borders1; //Устанавливает значения 
        }
        private void BorderMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.DeleteNotes(IndexItems:BorderMain.SelectedIndex);// Вызов метода удаления заметок
        }

        private void button_AddZam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddNotes windowAddNotes = new WindowAddNotes(NomerNotesStudent:nomer_NotesStudent); // ВЫзов окна добаления заметок
            windowAddNotes.Show();
        }

        private void UpdateNotes_MouseDown(object sender, MouseButtonEventArgs e) //Событие Обновления Заметок
        {
            modelsNotes.AddNotes(nomer_NotesStudent); // Вызов метода и передача номера студента
            BorderMain.ItemsSource = modelsNotes.borders1; // Устанавливает новые значения 
        }
    }
}

