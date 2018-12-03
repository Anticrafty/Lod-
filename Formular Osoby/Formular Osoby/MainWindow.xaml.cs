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
using FluentValidation;

namespace Formular_Osoby
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Skola> skoly = new List<Skola>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Osoba_Click(object sender, RoutedEventArgs e)
        {
            NactenaStranka.Navigate(new StrankaOsoba(NactenaStranka,null));

            Zak.Background = Brushes.Gray;
            Zak.BorderBrush = Brushes.LightGray;
            Trida.Background = Brushes.LightGray;
            Trida.BorderBrush = Brushes.Gray;
            Skola.Background = Brushes.LightGray;
            Skola.BorderBrush = Brushes.Gray;

        }

        private void Trida_Click(object sender, RoutedEventArgs e)
        {
            NactenaStranka.Navigate(new StrankaTrida(NactenaStranka, null));

            Trida.Background = Brushes.Gray;
            Trida.BorderBrush = Brushes.LightGray;
            Zak.Background = Brushes.LightGray;
            Zak.BorderBrush = Brushes.Gray;
            Skola.Background = Brushes.LightGray;
            Skola.BorderBrush = Brushes.Gray;
        }

        private void Skola_Click(object sender, RoutedEventArgs e)
        {
            NactenaStranka.Navigate(new StrankaSkola(NactenaStranka));

            Skola.Background = Brushes.Gray;
            Skola.BorderBrush = Brushes.LightGray;
            Zak.Background = Brushes.LightGray;
            Zak.BorderBrush = Brushes.Gray;
            Trida.Background = Brushes.LightGray;
            Trida.BorderBrush = Brushes.Gray;
        }
    }

}
