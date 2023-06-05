using MaterialDesignThemes.Wpf;
using ReAvix_2022.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ReAvix_2022.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowRegisterPrep.xaml
    /// </summary>
    public partial class WindowRegisterPrep : Window
    {
        WindowSign windowSign = new WindowSign();
        public WindowRegisterPrep()
        {
            InitializeComponent();
        }

        private void icon_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_ExitSignWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            windowSign.Show();
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

            VMWindowRegisterPrep vMWindowRegisterPrep = new VMWindowRegisterPrep();

            vMWindowRegisterPrep.ValidateInfoStudentTextBox(resultTextBox: out bool resultTextBox, textbox_Ima.Text, textbox_Familia.Text, textbox_Otchestvo.Text, textbox_Login.Text, textbox_EMail.Text, textbox_Phone.Text, textbox_Adress.Text, textbox_MeText.Text, combobox_OtchGroup.Text, combobox_Spec.Text, combobox_Ellips.Text);
            if (resultTextBox == true)
            {
                vMWindowRegisterPrep.ValidateInfoStudentPasswordBox(PasswordOne: textbox_Password.Password.ToString(), PasswordTwo: textbox_VerifityPassword.Password.ToString(), out bool resultPassword);
                if (resultPassword == true)
                {
                    vMWindowRegisterPrep.ValidateInfoStudentLogin(LoginOne: textbox_Login.Text, result: out bool resultLogin);
                    if (resultLogin == true)
                    {
                        vMWindowRegisterPrep.ValidateInfoStudentEmail(EmailOne: textbox_EMail.Text, out bool resultEmail);
                        if (resultEmail == true)
                        {
                            vMWindowRegisterPrep.ValidateInfoStudentPhone(PhoneOne: textbox_Phone.Text, out bool resultPhone);
                            if (resultPhone == true)
                            {
                                vMWindowRegisterPrep.ValidateInfoGroup(Group:combobox_OtchGroup.Text,out bool resultGroup);
                                if (resultGroup == true)
                                {
                                    VMWindowConfirmationEmail VMwindowConfirmationEmail = new VMWindowConfirmationEmail();
                                    VMwindowConfirmationEmail.ConfirmationEmail(textbox_EMail.Text, out bool ResultConfirmation, out int CodeEmail);
                                    if (ResultConfirmation == false)
                                    {
                                        MessageBox.Show("Неправильный формат электронной почты", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        WindowConfirmationEmail windowConfirmationEmail = new WindowConfirmationEmail(CodeEmail);
                                        windowConfirmationEmail.ShowDialog();

                                        if (windowConfirmationEmail.ResultConfirmation == true)
                                        {
                                            vMWindowRegisterPrep.AddInfoPrepInDB(textbox_Ima.Text, textbox_Familia.Text, textbox_Otchestvo.Text, textbox_Login.Text, textbox_Password.Password.ToString(), textbox_EMail.Text, textbox_Phone.Text, Pol, $"{combobox_Day.Text + "." + combobox_Montch.Text + "." + combobox_Year.Text}", textbox_Adress.Text, combobox_Spec.Text, textbox_MeText.Text, combobox_Ellips.Text, combobox_OtchGroup.Text);
                                            MessageBox.Show("Вы успешно зарегистрировались!", "Диалоговое окно", MessageBoxButton.OK,MessageBoxImage.Information);
                                            windowSign.Show();
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Регистрация не выполнена", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Question);
                                        }
                                    }
                                }
                                else
                                {
                                    combobox_OtchGroup.BorderBrush = Brushes.Red;
                                    MessageBox.Show("Выберите другой класс!", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
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
        private void textbox_Regex_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[а-яА-Я]"))
            {
                e.Handled = true;
            }
        }

        private void textbox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
