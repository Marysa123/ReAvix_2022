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
    /// Логика взаимодействия для UCInfoPrepodAdmin.xaml
    /// </summary>
    public partial class UCInfoPrepodAdmin : UserControl
    {
        public List<int> MassivNomerPrep;
        VMWindowInfoPrepodAdmin vMWindowInfoPrepodAdmin = new VMWindowInfoPrepodAdmin();
        public UCInfoPrepodAdmin()
        {
            InitializeComponent();

            DataContext = vMWindowInfoPrepodAdmin;
            vMWindowInfoPrepodAdmin.AddCardPrepod(out List<Grid> List);
            PanelPrepod.ItemsSource = List;
            MassivNomerPrep = vMWindowInfoPrepodAdmin.MassivNomerPrep;

        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PanelPrepod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerPrep[PanelPrepod.SelectedIndex];
                WindowAboutPrepodAdmin windowAboutPrepod = new WindowAboutPrepodAdmin(IndexItem);
                windowAboutPrepod.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет навыков", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
