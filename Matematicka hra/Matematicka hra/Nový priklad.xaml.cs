using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                Priklad.ToButt_2(MainWindow.rn.Next(MainWindow.vysledek - (10 * MainWindow.lvl), MainWindow.vysledek + (10 * MainWindow.lvl)));
            }
            else
            {
                Priklad.ToButt_2(MainWindow.vysledek);
                Priklad.ToButt_1(MainWindow.rn.Next(MainWindow.vysledek - (10 * MainWindow.lvl), MainWindow.vysledek + (10 * MainWindow.lvl)));
            }

        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            string saveOrLoad = save.Content.ToString();

            if (saveOrLoad == "Save")
            {
                int vypocitaneExp = 0;

                int pocitanylvl = MainWindow.lvl;

                int theNeed = MainWindow.expneed;

                while (pocitanylvl != 0)
                {
                    int odpocitavani = theNeed - (pocitanylvl * 10);
                    // 60 - (3 *10) = 60 -30 = 30 | 30 - (2 * 10) = 30 - 20 = 10 | 10 - (1 * 10) = 10 - 10 = 0
                    vypocitaneExp = vypocitaneExp + odpocitavani;
                    // 0 + 30 = 30 | 30 + 10 = 40  | 40 + 0 = 40
                    theNeed = odpocitavani;
                    // 30 | 10 | 0
                    pocitanylvl = pocitanylvl - 1;
                    // 2 | 1 | 0
                }

                int infoexp = MainWindow.exp + vypocitaneExp;

                string jsonEXP = JsonConvert.SerializeObject(infoexp);

                File.WriteAllText(@"D:\novakja16\Matematicka hra\Ulozena hra.json", jsonEXP);

                MainWindow.mlemaz("Uloženo");
            }
            else if (saveOrLoad == "Load game")
            {

                string UserFromFile = File.ReadAllText((@"D:\novakja16\Matematicka hra\Ulozena hra.json"));
                int expLoaded = JsonConvert.DeserializeObject<int>(UserFromFile);

                int alredydidwxp = 0;
                int expused = 0;
                while (expLoaded > expused)
                {

                    MainWindow.lvl++;
                    alredydidwxp = expused;
                    expused = expused + MainWindow.expneed;
                    MainWindow.expneed = expused + (MainWindow.lvl * 10);
                    MainWindow.NewProgress(MainWindow.expneed);
                    MainWindow.NewProgress(0);
                }
                MainWindow.exp = expLoaded - alredydidwxp;
                MainWindow.mlemaz("Loaded");
                parentFrame.Navigate(new Priklad());
                MainWindow.NewProgress(MainWindow.exp);

            }
        }
    }
}
