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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCAddInfoPredmetsAndSpec.xaml
    /// </summary>
    public partial class UCAddInfoPredmetsAndSpec : UserControl
    {
        public UCAddInfoPredmetsAndSpec()
        {
            InitializeComponent();

            VMWindowAddInfoPredmetsAndSpec vMWindowAddInfoPredmetsAndSpec = new VMWindowAddInfoPredmetsAndSpec();
            DataContext = vMWindowAddInfoPredmetsAndSpec;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_UpdatePredmets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_AddPredmets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_UpdateSpec_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_AddSpec_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
