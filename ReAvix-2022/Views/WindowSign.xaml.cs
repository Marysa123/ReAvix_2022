using ReAvix_2022.Views;
using System.Windows;
using System.Windows.Input;

namespace ReAvix_2022
{
    /// <summary>
    /// Логика взаимодействия для WindowSign.xaml
    /// </summary>
    public partial class WindowSign : Window
    {
        public WindowSign()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void button_ChangePasssowrd_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void button_RegisterPrep_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowRegisterPrep windowRegisterPrep = new WindowRegisterPrep();
            this.Hide();
            windowRegisterPrep.Show();
        }

        private void button_RegisterStud_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowRegisterStud windowRegisterStud = new WindowRegisterStud();
            this.Hide();
            windowRegisterStud.Show();

        }

        private void button_Sign_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
