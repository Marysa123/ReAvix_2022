using ReAvix_2022.WindowUserControl;
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
    /// Логика взаимодействия для WindowMainPrep.xaml
    /// </summary>
    public partial class WindowMainPrep : Window
    {
        public WindowMainPrep()
        {
            InitializeComponent();
        }
        public WindowMainPrep(int NomerPrep)
        {
            int Nomer = NomerPrep;
            InitializeComponent();

        }

        private void button_ProfilePrep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCProfilePrep();
        }

        private void button_List_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCListStudentsPrep();
        }

        private void button_StaticGroup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCStatisticGroupPrep();
        }

        private void button_Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCMainPrep();
        }

        private void button_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowSign windowSign = new WindowSign();
            windowSign.Show();
            Close();
        }
    }
}
