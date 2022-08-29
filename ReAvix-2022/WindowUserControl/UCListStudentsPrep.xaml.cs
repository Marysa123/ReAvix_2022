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
    /// Логика взаимодействия для UCListStudentsPrep.xaml
    /// </summary>
    public partial class UCListStudentsPrep : UserControl
    {
        int NomerPrep;
        VMWindowListStudentsPrep vMWindowListStudentsPrep;
        public List<int> MassivNomerStudent;

        public UCListStudentsPrep(int NumberPrep)
        {
            NomerPrep = NumberPrep;
            InitializeComponent();

            vMWindowListStudentsPrep = new VMWindowListStudentsPrep(NomerPrep);
            DataContext = vMWindowListStudentsPrep;
            vMWindowListStudentsPrep.AddStudent(out List<Grid> borders);
            PanelStudent.ItemsSource = borders;
            MassivNomerStudent = vMWindowListStudentsPrep.MassivNomerStudent;
        }

        private void PanelStudent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int IndexItem = MassivNomerStudent[PanelStudent.SelectedIndex];
            WindowInfoStudent windowInfoStudent = new WindowInfoStudent(IndexItem);
            windowInfoStudent.ShowDialog();

        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
