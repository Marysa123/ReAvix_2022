using ReAvix_2022.WindowUserControl;
using System.Windows;
using System.Windows.Input;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowMainStudent.xaml
    /// </summary>
    public partial class WindowMainStudent : Window
    {
        public int NumberStudent { get; set; }
        public WindowMainStudent()
        {
            InitializeComponent();
        }
        public WindowMainStudent(int NomerSt)
        {
            NumberStudent = NomerSt;
            InitializeComponent();
        }

        private void button_Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCMainStudent();
        }

        public void button_Static_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCStatisticStudent(NumberSt: NumberStudent);
        }

        private void button_Dos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCDosStudent(NumberSt: NumberStudent);
        }

        private void button_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCProfileStudent(NumberSt: NumberStudent);
        }

        private void button_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowSign windowSign = new WindowSign();
            Hide();
            windowSign.Show();

        }

        private void button_News_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCListNews();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
