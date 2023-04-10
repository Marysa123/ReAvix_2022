using ReAvix_2022.ViewModels;
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
    /// Логика взаимодействия для WindowAdministrator.xaml
    /// </summary>
    public partial class WindowAdministrator : Window
    {
        public WindowAdministrator()
        {
            InitializeComponent();

            VMWindowAdministrator windowAdministrator = new VMWindowAdministrator();
            DataContext = windowAdministrator;
        }

        private void button_AddNews_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCAddNewsAdmin();
        }

        private void button_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowSign windowSign = new WindowSign();
            windowSign.Show();
            Close();
        }
    }
}
