﻿using System;
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

namespace ApplikaceKod
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Panacek panacek = new Panacek();

        public MainWindow()
        {
            InitializeComponent();
            Panacek.Text = panacek.panacek_slozeny;
        }

        private void Leva_Horni_Ruka_Click(object sender, RoutedEventArgs e)
        {
            panacek.Leva_Horni_Ruka_Up
        }
    }
}
