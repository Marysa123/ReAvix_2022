using ReAvix_2022.ViewModels;
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
using System.Windows.Shapes;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowInfoStudent.xaml
    /// </summary>
    public partial class WindowInfoStudent : Window
    {
        int NomerStudent;
        VMWindowInfoStudent vMWindowInfoStudent;
        List<int> MassivNomerSkils;
        List<int> MassivNomerDos;
        List<int> MassivNomerPred;



        public WindowInfoStudent(int NumberSt)
        {
            InitializeComponent();


            NomerStudent = NumberSt;
            vMWindowInfoStudent = new VMWindowInfoStudent(NumberSt);
            vMWindowInfoStudent.GetInfoStudentCard();
            ImagesProfile.Source = vMWindowInfoStudent.newBitmapImage;
            DataContext = vMWindowInfoStudent;
            vMWindowInfoStudent.AddSkils(out List<Grid> borders, NomerStudent);
            PanelSkils.ItemsSource = borders;
            vMWindowInfoStudent.AddDos(NomerStudent, out List<Grid> bordersOut);
            PanelDos.ItemsSource = bordersOut;
            vMWindowInfoStudent.AddPredmet(out List<Grid> MassivGridOut);
            PanelPredmet.ItemsSource = MassivGridOut;



            MassivNomerSkils = vMWindowInfoStudent.MassivNomerSkils;
            MassivNomerDos = vMWindowInfoStudent.MassivNomerDos;
            MassivNomerPred = vMWindowInfoStudent.MassivNomerPredmet;

        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();   
        }

        private void PanelDos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerDos[PanelDos.SelectedIndex];
                VMWindowAboutDos vMWindowAboutDos = new VMWindowAboutDos();
                vMWindowAboutDos.CheckSkils(IndexItem, out int Index);
                if (Index == 1)
                {
                    MessageBox.Show("Этот элемент удален.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    WindowAboutDos windowAboutDos = new WindowAboutDos(IndexItem, NomerStudent);
                    windowAboutDos.textbox_Mesto.IsReadOnly = true;
                    windowAboutDos.textbox_MestoProv.IsReadOnly = true;
                    windowAboutDos.textbox_NameSor.IsReadOnly = true;
                    windowAboutDos.button_DeleteDosStud.IsEnabled = false;
                    windowAboutDos.button_DeleteDosStud.Visibility = Visibility.Hidden;
                    windowAboutDos.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет достижений", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void PanelSkils_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerSkils[PanelSkils.SelectedIndex];
                VMWindowAboutSkils vMWindowAboutSkils = new VMWindowAboutSkils();
                vMWindowAboutSkils.CheckSkils(IndexItem, out int Index);
                if (Index == 1)
                {
                    MessageBox.Show("Этот элемент удален.", "Диалоговое окно",MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    WindowAboutSkils windowAboutSkils = new WindowAboutSkils(IndexItem, NomerStudent);
                    windowAboutSkils.button_UpdateSkilsStud.IsEnabled = false;
                    windowAboutSkils.button_DeleteSkilsStud.IsEnabled = false;
                    windowAboutSkils.button_DeleteSkilsStud.Visibility = Visibility.Hidden;
                    windowAboutSkils.button_UpdateSkilsStud.Visibility = Visibility.Hidden;
                    windowAboutSkils.textbox_TextSkils.IsReadOnly = true;
                    windowAboutSkils.combobox_ValueMaster.IsEnabled = false;



                    windowAboutSkils.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет навыков", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void PanelPredmet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int NomerPredmet = MassivNomerPred[PanelPredmet.SelectedIndex];
                WindowInfoAboutPredmet windowInfoAboutPredmet = new WindowInfoAboutPredmet(NomerPredmet, NomerStudent);
                windowInfoAboutPredmet.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет предметов", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
