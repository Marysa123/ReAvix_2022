using ReAvix_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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
    /// Логика взаимодействия для WindowAboutDos.xaml
    /// </summary>
    public partial class WindowAboutDos : Window
    {
        public int NumberStudent;
        public int NumberDos;


        public WindowAboutDos()
        {
            InitializeComponent();
        }

        VMWindowAboutDos vMWindowAboutDos;
        public WindowAboutDos(int NomerDos, int NumberSt)
        {
            InitializeComponent();
            NumberStudent = NumberSt;
            NumberDos = NomerDos;

            vMWindowAboutDos = new VMWindowAboutDos(NumberDos,NumberSt);
            DataContext = vMWindowAboutDos;
            images.Source = vMWindowAboutDos.newBitmapImage;
            imagesTwo.Source = vMWindowAboutDos.newBitmapImageTwo;
           
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_DeleteDosStud_Click(object sender, RoutedEventArgs e)
        {
            vMWindowAboutDos.DeleteDos();
            MessageBox.Show("Достижение успешно удалено.", "Диалоговое окно");
            Close();
        }
    }
}
