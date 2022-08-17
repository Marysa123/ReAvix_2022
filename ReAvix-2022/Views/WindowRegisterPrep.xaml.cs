using ReAvix_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ReAvix_2022.ViewModels.VMWindowRegisterPrep;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowRegisterPrep.xaml
    /// </summary>
    public partial class WindowRegisterPrep : Window
    {
        WindowSign windowSign = new WindowSign();
        public WindowRegisterPrep()
        {
            InitializeComponent();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_ExitSignWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            windowSign.Show();
        }

        private void button_Register_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
