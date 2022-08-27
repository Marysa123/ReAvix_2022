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
using System.Windows.Shapes;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowAboutSkils.xaml
    /// </summary>
    public partial class WindowAboutSkils : Window
    {
        public int NumberStudent;
        public int NumberSkils;
        VMWindowAboutSkils vMWindowAboutSkils;
        public WindowAboutSkils(int NomerSkils,int NumberSt)
        {
            InitializeComponent();

            NumberStudent = NumberSt;
            NumberSkils = NomerSkils;

            vMWindowAboutSkils = new VMWindowAboutSkils(NumberSkils,NumberStudent);
            DataContext = vMWindowAboutSkils;

        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_UpdateSkilsStud_Click(object sender, RoutedEventArgs e)
        {
            vMWindowAboutSkils.UpdateSkils();
            MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");
            Close();
        }

        private void button_DeleteSkilsStud_Click(object sender, RoutedEventArgs e)
        {

            vMWindowAboutSkils.DeleteSkils();
            MessageBox.Show("Навык успешно удалён.", "Диалоговое окно");
            Close();
        }
    }
}
