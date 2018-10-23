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
    /// Interakční logika pro Nový_priklad.xaml
    /// </summary>
    public partial class Nový_priklad : Page
    {
        private Frame parentFrame;

        public Nový_priklad()
        {
            InitializeComponent();
        }
        public Nový_priklad(Frame parentframe) : this()
        {
            this.parentFrame = parentframe;
        }
        private void Tlacitko_Start(object sender, RoutedEventArgs e)
        {
            
            save.Content = "Save";
            Start_Butt.Content = "pokracovat";

            parentFrame.Navigate(new Priklad());

            int lvlec = 10 * MainWindow.lvl;

            int cast1 = MainWindow.rn.Next(1, lvlec);
            int znak = MainWindow.rn.Next(1, 4);
            int cast2 = MainWindow.rn.Next(1, lvlec);
            int jakybutt = MainWindow.rn.Next(1, 3);
            string prvni = cast1.ToString();
            string druhy = cast2.ToString();


            if (znak == 1)
            {
                MainWindow.vysledek = cast1 + cast2;

                string blem = prvni + " + " + druhy;
                MainWindow.mlemaz(blem);
            }
            else if (znak == 2)
            {
                MainWindow.vysledek = cast1 - cast2;
                string blem = prvni + " - " + druhy;
                MainWindow.mlemaz(blem);
            }
            else if (znak == 3)
            {
                MainWindow.vysledek = cast1 * cast2;
                string blem = prvni + " × " + druhy;
                MainWindow.mlemaz(blem);
            }
            if (jakybutt == 1)
            {
                Priklad.ToButt_1(MainWindow.vysledek);
                Priklad.ToButt_1(MainWindow.rn.Next(MainWindow.vysledek - (10 * MainWindow.lvl), MainWindow.vysledek + (10 * MainWindow.lvl)));
            }
            else
            {
                Priklad.ToButt_1(MainWindow.vysledek);
                Priklad.ToButt_1(MainWindow.rn.Next(MainWindow.vysledek - (10 * MainWindow.lvl), MainWindow.vysledek + (10 * MainWindow.lvl)));
            }

        }
    }
}
