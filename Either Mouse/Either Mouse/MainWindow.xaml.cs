using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Either_Mouse
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static  ComboBox zarizeninini;

        List<Zarizeni> zarizenis = new List<Zarizeni>();

        public const UInt32 SPI_SETMOUSESPEED = 0x0071;
        public const UInt32 SPI_SETWHEELSCROLLLINES = 0x0069;
        public const UInt32 SPI_SETDOUBLECLICKTIME = 0x0020;

        public JSON soubory = new JSON(null);

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(
        UInt32 uiAction,
        UInt32 uiParam,
        UInt32 pvParam,
        UInt32 fWinIni);

        public MainWindow()
        {
            InitializeComponent();
            NactiZarizeni();
            vypis_zarizeni();
        }

        public void NactiZarizeni()
        {
            zarizenis.Add(new Zarizeni() { jmeno = "Default" });
            foreach ( Zarizeni zarizeni in soubory.nacti_zarizeni())
            {
                zarizenis.Add(zarizeni);
            }
            zarizeninini = Zarizeninini;
        }
        public void vypis_zarizeni()
        {
            Zarizeninini.Items.Clear();
            foreach ( Zarizeni zarizeni in zarizenis)
            {
                ComboBoxItem NCBI = new ComboBoxItem();
                NCBI.Content = new TextBlock() { Text = zarizeni.jmeno };
                Zarizeninini.Items.Add(NCBI);
            }
        }
        private void novy_vybrany_zarizeni(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItem urceny = Zarizeninini.SelectedItem as ComboBoxItem;
            if(urceny != null)
            { 
                TextBlock urceny_text = urceny.Content as TextBlock;
                string urceny_jmeno = urceny_text.Text;
                foreach (Zarizeni zarizeni in zarizenis)
                {
                    if(zarizeni.jmeno == urceny_jmeno)
                    {
                        Citlivost.Value = zarizeni.Citlivost;
                        Dvojklik.Value = zarizeni.Click;
                        Scroll.Value = zarizeni.Scroll;
                        nastav_nastaveny(zarizeni);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool jmeno_existuje = false;
            foreach (Zarizeni zarizeni in zarizenis)
            {
                if (zarizeni.jmeno == Name.Text)
                {
                    jmeno_existuje = true;
                }
            }
            if (!jmeno_existuje)
            {
                zarizenis.Add(new Zarizeni { jmeno = Name.Text });
                vypis_zarizeni();
                Uloz_zarizeni();
                Name.Text = null;
            }
        }

        public void Uloz_zarizeni()
        {
            List<Zarizeni> ukladany = new List<Zarizeni>();
            int id_zarizeni = 0;
            foreach(Zarizeni zarizeni in zarizenis)
            {
                if(id_zarizeni != 0)
                {
                    ukladany.Add(zarizeni);
                }
                id_zarizeni++;
            }
            soubory.uloz_zarizeni(ukladany);
        }

        private void Uloz_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem urceny = Zarizeninini.SelectedItem as ComboBoxItem;
            if (urceny != null)
            {
                TextBlock urceny_text = urceny.Content as TextBlock;
                string urceny_jmeno = urceny_text.Text;
                foreach (Zarizeni zarizeni in zarizenis)
                {
                    if (zarizeni.jmeno == urceny_jmeno && urceny_jmeno != "Default")
                    {
                        zarizeni.Citlivost = int.Parse(Citlivost.Value.ToString());
                        zarizeni.Click = int.Parse(Dvojklik.Value.ToString());
                        zarizeni.Scroll = int.Parse(Scroll.Value.ToString());
                        nastav_nastaveny(zarizeni);
                        Uloz_zarizeni();
                    }
                }
            }
        }

        private void nastav_nastaveny(Zarizeni zarizeni)
        {
            nastav_speed(uint.Parse(zarizeni.Citlivost.ToString()));
            nastav_scroll(uint.Parse(zarizeni.Scroll.ToString()));
            nastav_click(uint.Parse(zarizeni.Click.ToString()));

        }
        private void nastav_speed(uint citlivost)
        {
            SystemParametersInfo
           (
           SPI_SETMOUSESPEED,
           0,
           citlivost,
           0
           );
        }
        private void nastav_scroll(uint scroll)
        {
            SystemParametersInfo
            (
                SPI_SETWHEELSCROLLLINES,
                scroll,
                0,                
                0
            );
        }
        private void nastav_click(uint click)
        {
           SystemParametersInfo
           (
               SPI_SETDOUBLECLICKTIME,
               click,
               0,
               0
           );
        }

    }
}
