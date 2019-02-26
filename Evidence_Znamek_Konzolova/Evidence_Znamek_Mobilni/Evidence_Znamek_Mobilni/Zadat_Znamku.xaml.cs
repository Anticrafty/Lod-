using Classy;
using Plugin.Toasts;
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
    public partial class Zadat_Znamku : ContentPage
    {
        static Picker urcipredmet;
        public Zadat_Znamku()
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
        async void Done(object sender, EventArgs args)
        {
            Znamka nova_znamka = new Znamka();
            nova_znamka.predmet = UrciPredmet_txt.Text;
            nova_znamka.známka = int.Parse(UrciZnamku_txt.Text);
            nova_znamka.vaha = int.Parse(UrciVahu_txt.Text);
            MainPage.SQLight.Add_znamka(nova_znamka);
            var options = new NotificationOptions()
            {
                Title = "Znamka zadana",
            };

            var result = await MainPage.notificator.Notify(options);
        }
    }
}