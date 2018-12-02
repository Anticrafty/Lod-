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

namespace Formular_Osoby
{
    /// <summary>
    /// Interakční logika pro StrankaTrida.xaml
    /// </summary>
    public partial class StrankaTrida : Page
    {
        private Frame pretchoziFrame;
        public Trida UTridit = null;

        public StrankaTrida()
        {
            InitializeComponent();
        }

        public StrankaTrida(Frame predchozistranka, Trida STridni) : this()
        {
            this.pretchoziFrame = predchozistranka;
            UTridit = STridni;
            if (UTridit != null)
            {
                Jmeno.Text = UTridit.Jmeno;
                Kmenova.Text = UTridit.KmenovaTrida;
                Tridni.Content = UTridit.TridniUcitel.Primeni;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Trida ososba = new Trida()
            {
                Jmeno = Jmeno.Text,
                KmenovaTrida = Kmenova.Text,
                
            };
            if (UTridit == null)
            {
                ososba.TridniUcitel = null;
            }
            else
            {
                ososba.TridniUcitel = UTridit.TridniUcitel;
            }
            ValidatorTrida validator = new ValidatorTrida();
            FluentValidation.Results.ValidationResult validovany = validator.Validate(ososba);
            bool overeny = validovany.IsValid;
            IList<FluentValidation.Results.ValidationFailure> Errors = validovany.Errors;
            if (overeny)
            {
                Jmeno.Background = Brushes.Blue;
                Kmenova.Background = Brushes.Blue;
                Tridni.Background = Brushes.Blue;
                //ulož
            }
            else
            {
                bool booJmeno = false;
                bool booKmenova = false;
                bool booTridni = false;

                foreach (FluentValidation.Results.ValidationFailure error in Errors)
                {
                    if (error.PropertyName == "Jmeno")
                    {
                        booJmeno = true;
                        JmenoError.Text = error.ErrorMessage;
                        Jmeno.Background = Brushes.Red;

                    }
                    else if (error.PropertyName == "KmenovaTrida")
                    {
                        booKmenova = true;
                        KmenovaError.Text = error.ErrorMessage;
                        Kmenova.Background = Brushes.Red;
                    }
                    else if (error.PropertyName == "TridniUcitel")
                    {
                        booTridni = true;
                        TridniError.Text = error.ErrorMessage;
                        Tridni.Background = Brushes.Red;

                    }
                }
                if (booJmeno == false)
                {
                    JmenoError.Text = null;
                    Jmeno.Background = Brushes.Green;
                }
                if (booKmenova == false)
                {
                    KmenovaError.Text = null;
                    Kmenova.Background = Brushes.Green;
                }
                if (booTridni == false)
                {
                    TridniError.Text = null;
                    Tridni.Background = Brushes.Green;
                }
            }
        }
        private void Ucitel_Click(object sender, RoutedEventArgs e)
        {
            UTridit = new Trida();
            UTridit.Jmeno = Jmeno.Text;
            UTridit.KmenovaTrida = Kmenova.Text;

            pretchoziFrame.Navigate(new StrankaOsoba(pretchoziFrame, UTridit));
        }
    }
}
