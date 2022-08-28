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
        public IEnumerable<ISeries> series { get; set; }
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
            windowAddSkils.Show();
        }

        private void button_Update_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowDosStudent.AddSkils(out List<Grid> GridOut, NumberStudent); // Вызов метода и передача номера студента
            MassivNomerSkils = vMWindowDosStudent.MassivNomerSkils;
            PanelSkils.ItemsSource = GridOut; // Устанавливает новые значения

        }
        WindowAboutSkils windowAboutSkils;
        private void PanelSkils_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int IndexItem = MassivNomerSkils[PanelSkils.SelectedIndex];
            VMWindowAboutSkils vMWindowAboutSkils = new VMWindowAboutSkils();
            vMWindowAboutSkils.CheckSkils(IndexItem,out int Index);
            if (Index == 1)
            {
                MessageBox.Show("Этот элемент удален, пожалуйста обновите окно!", "Диалоговое окно");
            }
            else
            {
                windowAboutSkils = new WindowAboutSkils(IndexItem, NumberStudent);
                windowAboutSkils.Show();
            }
        }

        private void PanelDos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int IndexItem = MassivNomerDos[PanelDos.SelectedIndex];
            VMWindowAboutDos vMWindowAboutDos = new VMWindowAboutDos();
            vMWindowAboutDos.CheckSkils(IndexItem, out int Index);
            if (Index == 1)
            {
                MessageBox.Show("Этот элемент удален, пожалуйста обновите окно!", "Диалоговое окно");
            }
            else
            {
                WindowAboutDos windowAboutDos = new WindowAboutDos(IndexItem,NumberStudent);
                windowAboutDos.Show();
            }
        }


        private void button_UpdateDos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowDosStudent.AddDos(NumberStudent, out List<Grid> bordersOut);
            MassivNomerDos = vMWindowDosStudent.MassivNomerDos;
            PanelDos.ItemsSource = bordersOut;

        }

        private void border_AddDos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddDos windowAddDos = new WindowAddDos(NumberStudent);
            windowAddDos.Show();
        }
    }
}
