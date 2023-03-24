using ReAvix_2022.WindowUserControl;
using System.Windows;
using System.Windows.Input;

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
        int NumberPrep;
        public WindowMainPrep(int NomerPrep)
        {
            NumberPrep = NomerPrep;
            InitializeComponent();

        }

        private void button_ProfilePrep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCProfilePrep(NumberPrep);
        }

        private void button_List_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCListStudentsPrep(NumberPrep);
        }

        private void button_StaticGroup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCStatisticGroupPrep(NumberPrep);
        }

        private void button_Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCMainPrep();
        }

        private void button_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowSign windowSign = new WindowSign();
            Hide();
            windowSign.Show();
        }

        private void button_AddInfoStudentPrep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCAddInfoStudentPrep(NomerPrep:NumberPrep);
        }

        private void button_AddInfoStudentPrepUsp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCPosvStud(NomerPrep:NumberPrep);
        }

        private void button_AddPredmetsPrep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UСAddPredmetsPrep(NumberPrep:NumberPrep);
        }
    }
}
