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
        public WindowMainStudent()
        {
            InitializeComponent();
        }
        public WindowMainStudent(int NomerStudent)
        {
            int Nomer = NomerStudent;
        }
    }
}
