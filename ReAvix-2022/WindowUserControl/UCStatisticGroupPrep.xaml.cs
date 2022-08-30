using ReAvix_2022.Models;
using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UCStatisticGroupPrep.xaml
    /// </summary>
    public partial class UCStatisticGroupPrep : UserControl
    {
        private int NomerPrep;
        VMWindowStatisticGroupPrep vMWindowStatisticGroupPrep;
        ModelsNotes modelsNotes = new ModelsNotes();

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

        }

        private void BorderMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modelsNotes.DeleteNotesPrep(IndexSelectedItems: BorderMain.SelectedIndex);// Вызов метода удаления заметок
            MessageBox.Show("Заметка успешно удалена.", "Диалоговое окно");
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
    }
}
