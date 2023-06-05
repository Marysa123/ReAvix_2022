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
    /// Логика взаимодействия для UСAddPredmetsPrep.xaml
    /// </summary>
    public partial class UСAddPredmetsPrep : UserControl
    {
        public UСAddPredmetsPrep()
        {


        }
        List<int> MassivNomerPred;
        VMWindowAddPredmetsPrep vMWindowAddPredmetsPrep;
        int NumberPrep;
        public UСAddPredmetsPrep(int NumberPrep)
        {
            InitializeComponent();
            vMWindowAddPredmetsPrep = new VMWindowAddPredmetsPrep(NumberPrep);
            DataContext = vMWindowAddPredmetsPrep;
            this.NumberPrep = NumberPrep;
            vMWindowAddPredmetsPrep.ViewPredmets(out List<Grid> GridOut);
            PanelPredmets.ItemsSource = GridOut;
            MassivNomerPred = vMWindowAddPredmetsPrep.MassivNomerPredmets;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void border_AddPredmets_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowAddInfoPredmetsPrep windowAddInfoPredmetsPrep = new WindowAddInfoPredmetsPrep(NomerPrep:NumberPrep);
            windowAddInfoPredmetsPrep.ShowDialog();
            vMWindowAddPredmetsPrep.ViewPredmets(out List<Grid> GridOut);
            PanelPredmets.ItemsSource = null;
            MassivNomerPred = vMWindowAddPredmetsPrep.MassivNomerPredmets;
            PanelPredmets.ItemsSource = GridOut;
        }

        private void PanelPredmets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int IndexItem = MassivNomerPred[PanelPredmets.SelectedIndex];
                vMWindowAddPredmetsPrep.CheckPredmets(IndexItem, out int Index);
                if (Index == 1)
                {
                    MessageBox.Show("Этот элемент удален, пожалуйста обновите окно!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    WindowAboutPredmet windowAboutPredmet = new WindowAboutPredmet(IndexItem);
                    windowAboutPredmet.ShowDialog();
                    vMWindowAddPredmetsPrep.ViewPredmets(out List<Grid> GridOut);
                    PanelPredmets.ItemsSource = null;
                    MassivNomerPred = vMWindowAddPredmetsPrep.MassivNomerPredmets;
                    PanelPredmets.ItemsSource = GridOut;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В списке нет предметов", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
