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
    /// Логика взаимодействия для UCListNews.xaml
    /// </summary>
    public partial class UCListNews : UserControl
    {
        VMWindowListNews vMWindowListNews;

        public UCListNews()
        {
            InitializeComponent();

            vMWindowListNews = new VMWindowListNews();
            DataContext = vMWindowListNews;
            vMWindowListNews.GetListAndShowNews();
            PanelNews.ItemsSource = vMWindowListNews.expanders;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
