using ReAvix_2022.ViewModels;
using ReAvix_2022.Views;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для UCAddNewsAdmin.xaml
    /// </summary>
    public partial class UCAddNewsAdmin : UserControl
    {
        VMWindowAddNewsAdmin vMWindowAddNewsAdmin;
        SqlConnection _Connection = new SqlConnection(); // Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        string AdressImageOne;
        string AdressImageTwo;
        string AdressImageThree;

        byte[] ImageOne;
        byte[] ImageTwo;
        byte[] ImageThree;

        public UCAddNewsAdmin()
        {
            InitializeComponent();

            vMWindowAddNewsAdmin = new VMWindowAddNewsAdmin();
            DataContext = vMWindowAddNewsAdmin;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Image_Three_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowAddNewsAdmin.AddImage(out string AdressImageThreeOut);
            if (AdressImageThreeOut == "")
            {
             
            }
            else
            {
                Image_Three.Source = BitmapFrame.Create(new Uri(AdressImageThreeOut));
                AdressImageThree = AdressImageThreeOut;
            }
        }

        private void Image_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowAddNewsAdmin.AddImage(out string AdressImageTwoOut);
            if (AdressImageTwoOut == "")
            {
                
            }
            else
            {
                Image_Two.Source = BitmapFrame.Create(new Uri(AdressImageTwoOut));
                AdressImageTwo = AdressImageTwoOut;
            }
        }

        private void Image_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vMWindowAddNewsAdmin.AddImage(out string AdressImageOneOut);
            if (AdressImageOneOut == "")
            {
                
            }
            else
            {
                Image_One.Source = BitmapFrame.Create(new Uri(AdressImageOneOut));
                AdressImageOne = AdressImageOneOut;

            }
        }

        private void button_AddNews_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString;
            _Connection.Open(); 
            if (AdressImageOne == null || AdressImageTwo == null || AdressImageThree == null || textbox_AvtorNew.Text == "" || textbox_KatNew.Text == "" || textbox_MainTextCaption.Text == "" || textbox_TextNew.Text == "")
            {
                MessageBox.Show("Заполните необходимые данные.", "Диалоговое окно");
            }
            else
            {
                ImageOne = File.ReadAllBytes(AdressImageOne);
                ImageTwo = File.ReadAllBytes(AdressImageTwo);
                ImageThree = File.ReadAllBytes(AdressImageThree);

                DateTime dateTime = DateTime.Now;

                CommandSql.CommandText = $"insert into [Новости] ([Заголовок_Новости], [Описание_Новости], [Автор_Новости],[Дата_Создания],[Категории_Новости],[Фотография_Первая],[Фотография_Вторая],[Фотография_Третья])  VALUES('{textbox_MainTextCaption.Text}','{textbox_TextNew.Text}','{textbox_AvtorNew.Text}','{dateTime.ToString()}','{textbox_KatNew.Text}',@imagesOne,@imagesTwo,@imagesThree)";
                CommandSql.Connection = _Connection;
                CommandSql.Parameters.Add(new SqlParameter("@imagesOne", ImageOne));
                CommandSql.Parameters.Add(new SqlParameter("@imagesTwo", ImageTwo));
                CommandSql.Parameters.Add(new SqlParameter("@imagesThree", ImageThree));

                CommandSql.ExecuteNonQuery();
                _Connection.Close();
                MessageBox.Show("Новость успешно добавлена.", "Диалоговое окно");
            }
        }
    }
}
