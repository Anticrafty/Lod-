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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Label text;
        public static ProgressBar progress;

        static public int vysledek;

        static public int lvl = 1;
        static public int exp = 0;
        static public int expneed = 10;
    

        static public Random rn = new Random();

        public MainWindow()
        {
            InitializeComponent();
            text = mlem;
            progress = progresswxp;
            myframe.Navigate(new Nový_priklad(myframe));
        }
        static public void mlemaz(string zadany)
        {

            text.Content = zadany;
        }
        static public void NewProgress(int expPredany)
        {
            progress.Value = expPredany;
        }
       

       

        static public void calculateexp()
        {
            if (exp == expneed)
            {
                lvl++;                
                expneed = exp + (lvl * 10);
                exp = 0;
                progress.Maximum = expneed;
                progress.Value = 0;
            }

        }

        // 10 = (10) 10 + 20 = (40) 30 + 30 = (100)60 + 40 = (200) 100 + 50 = (350) 150 + 60 = (560) 210
        // 210 - 60 = 150 - 50 = 100 - 40 = 60 -30 = 30 - 20 = 10 = 10
        // 6,5,4,3,2,1

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string saveOrLoad = save.Content.ToString();

            if(saveOrLoad == "Save")
            {
                int vypocitaneExp = 0;

                int pocitanylvl = lvl;

                int theNeed = expneed;

                while (pocitanylvl != 0 )
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

                int infoexp = exp + vypocitaneExp;

                string jsonEXP = JsonConvert.SerializeObject(infoexp);

                File.WriteAllText(@"D:\novakja16\Matematicka hra\Ulozena hra.json", jsonEXP);

                mlem.Content = "Uloženo";
            }
            else if (saveOrLoad == "Load game")
            {

                string UserFromFile = File.ReadAllText((@"D:\novakja16\Matematicka hra\Ulozena hra.json"));
                int expLoaded = JsonConvert.DeserializeObject<int>(UserFromFile);

                int alredydidwxp = 0;
                int expused = 0;
                while (expLoaded > expused)
                { 
                   
                    lvl++;
                    alredydidwxp = expused;
                    expused = expused + expneed;
                    expneed = expused + (lvl * 10);
                    progresswxp.Maximum = expneed;
                    progresswxp.Value = 0;
                }
                exp = expLoaded - alredydidwxp;
                mlem.Content = "Loaded";
                save.Visibility = Visibility.Hidden;
                progresswxp.Value = exp;

            }
        }
    }
}
