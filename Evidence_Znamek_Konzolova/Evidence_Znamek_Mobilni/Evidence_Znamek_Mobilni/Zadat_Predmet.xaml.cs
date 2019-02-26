using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funkce;
using Classy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toasts;

namespace Evidence_Znamek_Mobilni
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Zadat_Predmet : ContentPage
	{
		public Zadat_Predmet ()
		{
			InitializeComponent ();
		}
        async void Done(object sender, EventArgs args)
        {
            var predmet = input_jmeno.Text;

            Predmet novy_predmet = new Predmet() { Jmeno = predmet };
            MainPage.SQLight.Add_predmet(novy_predmet);
            var options = new NotificationOptions()
            {
                Title = "Predmet zadan",
            };

            var result = await MainPage.notificator.Notify(options);
            Zadat_Znamku.set_predmety();
            Prohlednout_Znamky.set_predmety();
        }
    }
}