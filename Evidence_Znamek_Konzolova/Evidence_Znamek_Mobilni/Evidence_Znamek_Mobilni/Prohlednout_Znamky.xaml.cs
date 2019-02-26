using Classy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Evidence_Znamek_Mobilni
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Prohlednout_Znamky : ContentPage
	{
        static Picker urcipredmet;
        public Prohlednout_Znamky()
		{
            InitializeComponent();
            urcipredmet = UrciPredmet;

            set_predmety();
        }
        static public void set_predmety()
        {
            List<string> predmety = new List<string>();
            foreach (Predmet predmet in MainPage.SQLight.Get_predmety())
            {
                predmety.Add(predmet.Jmeno);
            }
            urcipredmet.ItemsSource = predmety;
        }
        void Urceny_predmet(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                List<Znamka> znamky = MainPage.SQLight.Get_znamky(MainPage.SQLight.Get_predmety()[selectedIndex].Jmeno);
                StackLayout export = new StackLayout();
                StackLayout hlavicka = new StackLayout();
                Label hlavickaL = new Label() { Text = " známka | váha" };
                hlavicka.Children.Add(hlavickaL);
                export.Children.Add(hlavicka);
                
                double soucet = 0;
                double pocet = 0;
                foreach (Znamka znamka in znamky)
                {
                    hlavicka = new StackLayout();
                    hlavickaL = new Label() { Text = znamka.známka + " | " + znamka.vaha };                    
                    hlavicka.Children.Add(hlavickaL);
                    export.Children.Add(hlavicka);

                    soucet = soucet + (znamka.známka * znamka.vaha);
                    pocet = pocet + znamka.vaha;
                }
                double prumer = soucet / pocet;
                hlavicka = new StackLayout();
                hlavickaL = new Label() { Text = "Průměr je: " + prumer.ToString(".0#") };                
                hlavicka.Children.Add(hlavickaL);
                Frame zvyrazneni = new Frame() { Content = hlavicka };
                export.Children.Add(zvyrazneni);
                Output.Children.Add(export);
            }
        }
    }
}