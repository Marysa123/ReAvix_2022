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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCAddInfoAdministrator.xaml
    /// </summary>
    public partial class UCAddInfoAdministrator : UserControl
    {
        VMWIndowAddInfoAdministrator vMWIndowAddInfoAdministrator;
        public UCAddInfoAdministrator()
        {
            InitializeComponent();

            vMWIndowAddInfoAdministrator = new VMWIndowAddInfoAdministrator();
            DataContext = vMWIndowAddInfoAdministrator;

            GridViewGroup.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoGroup().DefaultView;
            GridViewMugs.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoMugs().DefaultView;
            GridViewNameKat.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoKat().DefaultView;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_UpdateGroup_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NomerGroup.Text == "" || textbox_DescriptionGroup.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                vMWIndowAddInfoAdministrator.UpdateInfoGroup(textbox_NomerGroup.Text, textbox_DescriptionGroup.Text);
                GridViewGroup.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoGroup().DefaultView;
            }
        }

        private void button_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NomerGroup.Text == "" || textbox_DescriptionGroup.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                vMWIndowAddInfoAdministrator.AddInfoGroup(textbox_NomerGroup.Text,textbox_DescriptionGroup.Text);
                GridViewGroup.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoGroup().DefaultView;
            }
        }

        private void button_UpdateNameKat_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NameKat.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                vMWIndowAddInfoAdministrator.UpdateInfoKat(textbox_NomerNameKat.Text,textbox_NameKat.Text);
                GridViewNameKat.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoKat().DefaultView;
            }
        }

        private void button_AddNameKat_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NameKat.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                vMWIndowAddInfoAdministrator.AddInfoKat(textbox_NameKat.Text);
                GridViewNameKat.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoKat().DefaultView;
            }
        }

        private void button_UpdateMugs_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NameMugs.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                vMWIndowAddInfoAdministrator.UpdateInfoMugs(textbox_NomerMugs.Text,textbox_NameMugs.Text);
                GridViewMugs.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoMugs().DefaultView;
            }
        }

        private void button_AddMugs_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_NameMugs.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                vMWIndowAddInfoAdministrator.AddInfoMugs(textbox_NameMugs.Text);
                GridViewMugs.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoMugs().DefaultView;
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vMWIndowAddInfoAdministrator.DeleteInfoDataGrid("Кружки","Номер_Кружка",textbox_NomerMugs.Text);
            GridViewMugs.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoMugs().DefaultView;
        }

        private void DataGridRow_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            vMWIndowAddInfoAdministrator.DeleteInfoDataGrid("Категории_Навыка", "Номер_Категории", textbox_NomerNameKat.Text);
            GridViewNameKat.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoKat().DefaultView;
        }

        private void DataGridRow_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            vMWIndowAddInfoAdministrator.DeleteInfoDataGrid("Группа", "Номер_группы", textbox_NomerGroup.Text);
            GridViewGroup.ItemsSource = vMWIndowAddInfoAdministrator.GetInfoGroup().DefaultView;
        }
    }
}
