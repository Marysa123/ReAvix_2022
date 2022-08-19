using ReAvix_2022.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowRegisterStud.xaml
    /// </summary>
    public partial class WindowRegisterStud : Window
    {
        WindowSign windowSign = new WindowSign();

        public WindowRegisterStud()
        {
            InitializeComponent();
        }

        private void button_ExitSignWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide(); // Скрывает окно
            windowSign.Show(); //Отображает скрытое окно "Входа"

        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0); // Выход из приложения
        }

        private void button_Register_Click(object sender, RoutedEventArgs e)
        {
            string Pol;

            if (radiobutton_Male.IsChecked == true)
            {
                Pol = radiobutton_Male.Content.ToString();
            }
            else
            {
                Pol = "Женский";
            }

            VMWindowRegisterStud vMWindowRegisterStud = new VMWindowRegisterStud();

            vMWindowRegisterStud.ValidateInfoStudentTextBox(resultTextBox: out bool resultTextBox, textbox_Ima.Text, textbox_Fam.Text, textbox_Otc.Text, textbox_Login.Text, textbox_EMail.Text, textbox_Phone.Text, textbox_PhoneRod.Text, textbox_Adress.Text, textbox_TextMe.Text, combobox_Group.Text);
            if (resultTextBox == true)
            {
                vMWindowRegisterStud.ValidateInfoStudentPasswordBox(PasswordOne: textbox_Password.Password.ToString(), PasswordTwo: textbox_VerifityPassword.Password.ToString(), out bool resultPassword);
                if (resultPassword == true)
                {
                    vMWindowRegisterStud.ValidateInfoStudentLogin(LoginOne: textbox_Login.Text, result: out bool resultLogin);
                    if (resultLogin == true)
                    {
                        vMWindowRegisterStud.ValidateInfoStudentEmail(EmailOne: textbox_EMail.Text, out bool resultEmail);
                        if (resultEmail == true)
                        {
                            vMWindowRegisterStud.ValidateInfoStudentPhone(PhoneOne: textbox_Phone.Text, out bool resultPhone);
                            if (resultPhone == true)
                            {
                                vMWindowRegisterStud.AddInfoStudentInDB(textbox_Ima.Text, textbox_Fam.Text, textbox_Otc.Text, textbox_Login.Text, textbox_Password.Password.ToString(), textbox_EMail.Text, textbox_Phone.Text, textbox_PhoneRod.Text, combobox_Cours.Text, Pol, $"{combobox_Day.Text + "." + combobox_Montch.Text + "." + combobox_Year.Text}", textbox_Adress.Text, textbox_TextMe.Text, combobox_Group.Text);
                                MessageBox.Show("Вы успешно зарегистрировались!","Диалоговое окно",MessageBoxButton.OK);
                                windowSign.Show();
                                Close();
                            }
                            else
                            {
                                textbox_Phone.Clear();
                                MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Phone, "Извините, этот номер уже занят.");
                                textbox_Phone.BorderBrush = Brushes.Red;
                            }
                        }
                        else
                        {
                            textbox_EMail.Clear();
                            MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_EMail, "Извините, эта почта уже занята.");
                            textbox_EMail.BorderBrush = Brushes.Red;
                        }
                    }
                    else
                    {
                        textbox_Login.Clear();
                        MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Login, "Извините, этот логин уже занят.");
                        textbox_Login.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    textbox_Password.Clear();
                    textbox_VerifityPassword.Clear();
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(textbox_Password, "Один из паролей не совпадает.");
                    textbox_Password.BorderBrush = Brushes.Red;
                    textbox_VerifityPassword.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                MessageBox.Show("Отсутсвует значение в одном из полей!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
