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
        private int odpovezenych = 0;
        private Otaznikovec otazky;
        public otazka()
        {
            InitializeComponent();
            Otaznikovec otasky = new Otaznikovec();
            otasky.PriStartuLoad();
            otazky = otasky;
        }
        public otazka(Frame predchozistranka) : this()
        {
            this.pretchoziFrame = predchozistranka;
            otaznikovec();
        }
        public void otaznikovec()
        {
            Otazka otaska = otazky.Urovne[odpovezenych].Otazky[rn.Next(0,otazky.Urovne[odpovezenych].Otazky.Count())];
            string text = otaska.zneni;
            MainWindow.HappyFox(text);
            
            Butt1.Content = otaska.moznosti[0].zneni;
            Butt2.Content = otaska.moznosti[1].zneni;
            Butt3.Content = otaska.moznosti[2].zneni;
            Butt4.Content = otaska.moznosti[3].zneni;
        }
    }
}
