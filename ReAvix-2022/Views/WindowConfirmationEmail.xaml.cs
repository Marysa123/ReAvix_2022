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
        VMWindowConfirmationEmail windowConfirmationEmail = new VMWindowConfirmationEmail();

        public int CodeCinfirmnationEmail { get; set; }
        public bool ResultConfirmation { get; set; }

        public WindowConfirmationEmail(string Email)
        {
            InitializeComponent();

            windowConfirmationEmail.ConfirmationEmail(Email,out int Code);
            CodeCinfirmnationEmail = Code;
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_Confirmation_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(textbox_Code.Text) == CodeCinfirmnationEmail)
            {
                ResultConfirmation = true;
                this.Close();
            }
            else
            {
                ResultConfirmation = false;
                MessageBox.Show("Неверный код!", "Диалоговое окно", MessageBoxButton.OK);
            }
        }
        

        private void textbox_Code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
