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
    /// Логика взаимодействия для WindowPasswordRecovery.xaml
    /// </summary>
    public partial class WindowPasswordRecovery : Window
    {
        public WindowPasswordRecovery()
        {
            InitializeComponent();
        }
        public string EmailUser { get; set; }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void button_Confirmation_Click(object sender, RoutedEventArgs e)
        {
            VMWindowPasswordRecovery windowPasswordRecovery = new VMWindowPasswordRecovery();
            windowPasswordRecovery.SearchEmail(textbox_Email.Text);
            if (windowPasswordRecovery.CheckSearchEmail == false)
            {
                MessageBox.Show("Повторите попытку ввода!","Диалоговое окно",MessageBoxButton.OK);
            }
            else
            {
                EmailUser = textbox_Email.Text;
                Close();
                WindowConfirmationEmail windowConfirmationEmail = new WindowConfirmationEmail(textbox_Email.Text);
                windowConfirmationEmail.ShowDialog();
                if (windowConfirmationEmail.ResultConfirmation == true)
                {
                    WindowChangePassword windowChangePassword = new WindowChangePassword(EmailUser);
                    windowChangePassword.ShowDialog();
                }
            }
        }
    }
}
