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
    /// Логика взаимодействия для WindowMainStudent.xaml
    /// </summary>
    public partial class WindowMainStudent : Window
    {
        public int Nomer_Student { get; set; }
        public WindowMainStudent()
        {
            InitializeComponent();
        }
        public WindowMainStudent(int NomerSt)
        {
            Nomer_Student = NomerSt;
            InitializeComponent();
        }

        private void button_Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCMainStudent();
        }

        public void button_Static_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCStatisticStudent(nomer_Student: Nomer_Student);
        }

        private void button_Dos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCDosStudent();
        }

        private void button_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new UCProfileStudent();
        }

        private void button_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowSign windowSign = new WindowSign();
            Hide();
            windowSign.Show();
            
        }

    }
}
