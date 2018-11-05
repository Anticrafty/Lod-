using Milionar.Classy;
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
    /// Interakční logika pro otazka.xaml
    /// </summary>
    
    public partial class otazka : Page
    {
        private Random rn = new Random();
        private Frame pretchoziFrame;
        static int odpovezenych = 0;
        static Otaznikovec otazky;
        static int cisloOtazky;

        public otazka()
        {
            InitializeComponent();
            Otaznikovec otasky = new Otaznikovec();
            otasky.PriStartuLoad();
            otazky = otasky;
            cisloOtazky = rn.Next(0, otazky.Urovne[odpovezenych].Otazky.Count());
        }
        public otazka(Frame predchozistranka) : this()
        {
            this.pretchoziFrame = predchozistranka;
            otaznikovec();
        }
        public void otaznikovec()
        {
            Otazka otaska = otazky.Urovne[odpovezenych].Otazky[cisloOtazky];
            string text = otaska.zneni;
            MainWindow.HappyFox(text);
            
            Butt1.Content = otaska.moznosti[0].zneni;
            Butt2.Content = otaska.moznosti[1].zneni;
            Butt3.Content = otaska.moznosti[2].zneni;
            Butt4.Content = otaska.moznosti[3].zneni;
        }
        static Odpoved GetOdpoved()
        {
            foreach (Odpoved moznost in otazky.Urovne[odpovezenych].Otazky[cisloOtazky].moznosti)
            {
                if (moznost.pravdive)
                {
                    return moznost;
                }
            }

            return null;
        }

        private void Butt_Click(object sender, RoutedEventArgs e)
        {
            Button supr = (sender as Button);
            string blem = supr.Content.ToString();
            if (blem == GetOdpoved().zneni )
            {
                odpovezenych++;
                pretchoziFrame.Navigate(new pokracovani(pretchoziFrame));                
            }
        }
    }
}
