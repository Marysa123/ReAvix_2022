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
    /// Логика взаимодействия для WindowChangePassword.xaml
    /// </summary>
    public partial class WindowChangePassword : Window
    {
        public string EmailOut { get; set; }
        public WindowChangePassword(string Email)
        {
            EmailOut = Email;
            InitializeComponent();
        }

        private void button_Confirmation_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_Password.Text == textbox_PasswordTwo.Text)
            {
                VMWindowChangePassword windowChangePassword = new VMWindowChangePassword();
                windowChangePassword.ChangePassword(EmailOut, PasswordChange: textbox_PasswordTwo.Text);
                Close();
                WindowSign windowSign = new WindowSign();
                windowSign.Show();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!","Диалоговое окно",MessageBoxButton.OK);
            }
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
