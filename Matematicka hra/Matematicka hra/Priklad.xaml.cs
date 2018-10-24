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

namespace Matematicka_hra
{
    
    /// <summary>
    /// Interakční logika pro Priklad.xaml
    /// </summary>
    public partial class Priklad : Page
    {
        private Frame parentFrame;

        public static Button pristupButt_1;
        public static Button pristupButt_2;
        public Priklad()
        {
            InitializeComponent();
            pristupButt_1 = Butt_1;
            pristupButt_2 = Butt_2;
        }
        public Priklad(Frame parentframe) : this()
        {
            this.parentFrame = parentframe;
        }

        static public void ToButt_1(int vysledek)
        {
            pristupButt_1.Content = vysledek;
        }
        static public void ToButt_2(int vysledek)
        {
            pristupButt_2.Content = vysledek;
        }

        private void Tlacitko_1(object sender, RoutedEventArgs e)
        {
            int tip = Convert.ToInt32(Butt_1.Content);
            if (tip == MainWindow.vysledek)
            {
                MainWindow.exp++;
                MainWindow.NewProgress(MainWindow.exp);
                MainWindow.calculateexp();
                MainWindow.mlemaz("Správná odpoved");
            }
            else
            {
                MainWindow.mlemaz("Špatná odpověď");
            }
            parentFrame.Navigate(new Nový_priklad(parentFrame));

            Nový_priklad.ToButt_Save("Save");
            Nový_priklad.ToButt_Start("pokracovat");

        }

        private void Tlacitko_2(object sender, RoutedEventArgs e)
        {
            int tip = Convert.ToInt32(Butt_2.Content);
            if (tip == MainWindow.vysledek)
            {
                MainWindow.exp++;
                MainWindow.NewProgress(MainWindow.exp);
                MainWindow.calculateexp();
                MainWindow.mlemaz("Správná odpoved");
            }
            else
            {
                MainWindow.mlemaz("Špatná odpověď");
            }
            parentFrame.Navigate(new Nový_priklad(parentFrame));

            Nový_priklad.ToButt_Save("Save");
            Nový_priklad.ToButt_Start("pokracovat");
        }
    }
}
