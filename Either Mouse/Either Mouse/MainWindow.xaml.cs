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

namespace Either_Mouse
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Zarizeni> zarizenis = new List<Zarizeni>();
        public MainWindow()
        {
            InitializeComponent();
            NactiZarizeni();
            vypis_zarizeni();
        }

        public void NactiZarizeni()
        {
            zarizenis.Add(new Zarizeni() { jmeno = "Mys" });
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
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zarizenis.Add(new Zarizeni { jmeno = Name.Text });
            vypis_zarizeni();
            Uloz_zarizeni();
            Name.Text = null;
        }

        public void Uloz_zarizeni()
        {
            
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
                    if (zarizeni.jmeno == urceny_jmeno)
                    {
                        zarizeni.Citlivost = int.Parse(Citlivost.Value.ToString());
                        zarizeni.Click = int.Parse(Dvojklik.Value.ToString());
                        zarizeni.Scroll = int.Parse(Scroll.Value.ToString());
                    }
                }
            }
        }
    }
}
