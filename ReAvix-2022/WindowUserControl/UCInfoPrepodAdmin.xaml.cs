﻿using ReAvix_2022.ViewModels;
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
    /// Логика взаимодействия для UCInfoPrepodAdmin.xaml
    /// </summary>
    public partial class UCInfoPrepodAdmin : UserControl
    {
        public UCInfoPrepodAdmin()
        {
            InitializeComponent();

            VMWindowInfoPrepodAdmin vMWindowInfoPrepodAdmin = new VMWindowInfoPrepodAdmin();
            DataContext = vMWindowInfoPrepodAdmin;
        }

        private void icon_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}