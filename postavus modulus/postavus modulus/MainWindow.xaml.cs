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

namespace postavus_modulus
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Panacek panacek_in = new Panacek();
        Globals globals = new Globals(panacek_in);
        public MainWindow()
        {
            InitializeComponent();

            Panacek.Text = globals.Panacek.panacek;

            Helma.Text = globals.Panacek.helma.obrazek;
            Stit.Text = globals.Panacek.stit.obrazek;
            Boty.Text = globals.Panacek.boty.obrazek;
            Telo.Text = globals.Panacek.telo.obrazek;
            Zbran.Text = globals.Panacek.mec.obrazek;
            Nohy.Text = globals.Panacek.nohy.obrazek;

            Zivot.Maximum = globals.Panacek.Max_Health.velikost;
            Zivot.Value = globals.Panacek.Health.velikost;
            Mana.Maximum = globals.Panacek.Max_Mana.velikost;
            Mana.Value = globals.Panacek.Mana.velikost;
            Energie.Maximum = globals.Panacek.Max_Energie.velikost;
            Energie.Value = globals.Panacek.Energie.velikost;
        }

    }
}
