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
using System.Windows.Threading;

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
        public bool timer = false;
        public bool vyhrano = false;

        private void TimerKonec_Tick()
        {
            pretchoziFrame.Navigate(new Konec(pretchoziFrame));
            MainWindow.HappyFox("Nestihl jsi odpovedět. Prohrál jste již vyhrané peníze.");
        }

        private void TimerTock_Tick(object sender, EventArgs e)
        {
            bool bloop = MainWindow.TickTock();
            DispatcherTimer blem = (sender as DispatcherTimer);
            if (bloop)
            {
                
                blem.Stop();
                TimerKonec_Tick();
            }
            else if (timer)
            {
                blem.Stop();
                done();
            }

        }

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
            int zacinajici_butt = rn.Next(1, 5);
            
            if (zacinajici_butt == 1)
            {
                Butt1.Content = otaska.moznosti[0].zneni;
                Butt2.Content = otaska.moznosti[1].zneni;
                Butt3.Content = otaska.moznosti[2].zneni;
                Butt4.Content = otaska.moznosti[3].zneni;
            }
            else if(zacinajici_butt == 2)
            {
                Butt1.Content = otaska.moznosti[3].zneni;
                Butt2.Content = otaska.moznosti[0].zneni;
                Butt3.Content = otaska.moznosti[1].zneni;
                Butt4.Content = otaska.moznosti[2].zneni;
            }
            else if(zacinajici_butt == 3)
            {
                Butt1.Content = otaska.moznosti[2].zneni;
                Butt2.Content = otaska.moznosti[3].zneni;
                Butt3.Content = otaska.moznosti[0].zneni;
                Butt4.Content = otaska.moznosti[1].zneni;
            }
            else if(zacinajici_butt == 4)
            {
                Butt1.Content = otaska.moznosti[1].zneni;
                Butt2.Content = otaska.moznosti[2].zneni;
                Butt3.Content = otaska.moznosti[3].zneni;
                Butt4.Content = otaska.moznosti[0].zneni;
            }            
            DispatcherTimer TimerTock = new DispatcherTimer();
            TimerTock.Tick += new EventHandler(TimerTock_Tick);
            TimerTock.Interval = new TimeSpan(0, 0, 1);
            TimerTock.Start();
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
            timer = true;
            if (blem == GetOdpoved().zneni )
            {
                vyhrano = true;         
            }
            else
            {
                vyhrano = false;  
            }
        }
        public void done()
        {
            if (vyhrano)
            {
                odpovezenych++;
                pretchoziFrame.Navigate(new pokracovani(pretchoziFrame));
            }
            else
            {
                pretchoziFrame.Navigate(new Konec(pretchoziFrame));
                MainWindow.HappyFox("Špatná odpoved. Prohrál jste již vyhraný peníze.");
            }
        }
    }
}
