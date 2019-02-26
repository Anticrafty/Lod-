using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Funkce;
using Plugin.Toasts;

namespace Evidence_Znamek_Mobilni
{
    public partial class MainPage
    {
        static public Databaze SQLight;
        static public IToastNotificator notificator = DependencyService.Get<IToastNotificator>();
        public MainPage()
        {
            SQLight = new Databaze(null, Odesilatel.Android);
            InitializeComponent();
           
        }
    }
}
