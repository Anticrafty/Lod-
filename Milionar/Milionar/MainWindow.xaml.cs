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

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ProgressBar ukazator;
        public static TextBox Tuls;
        public MainWindow()
        {
            InitializeComponent();
            ukazator = Streser;
            Tuls = tuls;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stranka.Navigate(new otazka(stranka));
            start.Visibility = Visibility.Collapsed;

        }
        static public void ZmenStreser(int cislo)
        {
            ukazator.Value = cislo;
            ukazator.Maximum = 15;
        }

        static public bool TickTock()
        {
            if (ukazator.Maximum != 30)
            {
                ukazator.Maximum = 30;
                ukazator.Value = 0;
            }
            ukazator.Value++;
            if (ukazator.Value == 30)
            {
                return true;
            }
            return false;

        }

        static public void HappyFox(string reward)
        {
            Tuls.Text = reward;
            Tuls.FontSize = 24; 
        }
    }
}
