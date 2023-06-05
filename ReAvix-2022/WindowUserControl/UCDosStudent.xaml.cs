using LiveChartsCore;
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
    /// Логика взаимодействия для UCDosStudent.xaml
    /// </summary>


    public partial class UCDosStudent : UserControl
    {

        VMWindowDosStudent vMWindowDosStudent;
        public int NumberStudent;
        List<int> MassivNomerSkils;
        List<int> MassivNomerDos;

        public UCDosStudent()
        {
            InitializeComponent();
        }

        public UCDosStudent(int NumberSt)
        {
            NumberStudent = NumberSt;
            InitializeComponent();
            vMWindowDosStudent = new VMWindowDosStudent(NumberStudent);
            DataContext = vMWindowDosStudent;
            vMWindowDosStudent.AddSkils(out List<Grid> borders, NumberStudent);
            PanelSkils.ItemsSource = borders;
            vMWindowDosStudent.AddDos(NumberStudent, out List<Grid> bordersOut);
            PanelDos.ItemsSource = bordersOut;
            MassivNomerSkils = vMWindowDosStudent.MassivNomerSkils;
            MassivNomerDos = vMWindowDosStudent.MassivNomerDos;
        }
 


        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void border_AddSliks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddSkils windowAddSkils = new WindowAddSkils(NumberStudent);
            windowAddSkils.ShowDialog();
            vMWindowDosStudent.AddSkils(out List<Grid> GridOut, NumberStudent); // Вызов метода и передача номера студента
            PanelSkils.ItemsSource = null;
            MassivNomerSkils = vMWindowDosStudent.MassivNomerSkils;
            PanelSkils.ItemsSource = GridOut;
        }

        WindowAboutSkils windowAboutSkils;
        private void PanelSkils_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerSkils[PanelSkils.SelectedIndex];
                VMWindowAboutSkils vMWindowAboutSkils = new VMWindowAboutSkils();
                vMWindowAboutSkils.CheckSkils(IndexItem, out int Index);
                if (Index == 1)
                {
                    MessageBox.Show("Этот элемент удален, пожалуйста обновите окно!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    windowAboutSkils = new WindowAboutSkils(IndexItem, NumberStudent);
                    windowAboutSkils.ShowDialog();
                    vMWindowDosStudent.AddSkils(out List<Grid> GridOut, NumberStudent); // Вызов метода и передача номера студента
                    PanelSkils.ItemsSource = null;
                    MassivNomerSkils = vMWindowDosStudent.MassivNomerSkils;
                    PanelSkils.ItemsSource = GridOut;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет навыков", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
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
                    MessageBox.Show("Этот элемент удален, пожалуйста обновите окно!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    WindowAboutDos windowAboutDos = new WindowAboutDos(IndexItem, NumberStudent);
                    windowAboutDos.ShowDialog();
                    vMWindowDosStudent.AddDos(NumberStudent, out List<Grid> bordersOut);
                    PanelDos.ItemsSource = null;
                    MassivNomerDos = vMWindowDosStudent.MassivNomerDos;
                    PanelDos.ItemsSource = bordersOut;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет достижений", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void border_AddDos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddDos windowAddDos = new WindowAddDos(NumberStudent);
            windowAddDos.ShowDialog();
            vMWindowDosStudent.AddDos(NumberStudent, out List<Grid> bordersOut);
            PanelDos.ItemsSource = null;
            MassivNomerDos = vMWindowDosStudent.MassivNomerDos;
            PanelDos.ItemsSource = bordersOut;
        }
    }
}
