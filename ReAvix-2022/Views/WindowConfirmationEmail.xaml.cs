using ReAvix_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WindowConfirmationEmail.xaml
    /// </summary>
    public partial class WindowConfirmationEmail : Window
    {

        public bool ResultConfirmation { get; set; }
        public int CodeEmail { get; set; }
        public WindowConfirmationEmail(int CodeEmail)
        {
            InitializeComponent();

            this.CodeEmail = CodeEmail;
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResultConfirmation = false;
            Close();
        }

        private void button_Confirmation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConfirmationPassEmail(int.Parse(textbox_Code.Text), out bool ResultPass);
                ResultConfirmation = ResultPass;
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректный код!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        

        private void textbox_Code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void ConfirmationPassEmail(int Code, out bool ResultConfirmation)
        {
            if (CodeEmail == Code)
            {
                ResultConfirmation = true;
                Close();
            }
            else
            {
                ResultConfirmation = false;
                MessageBox.Show("Неверный код!", "Диалоговое окно", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
