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
    /// Interakční logika pro StrankaOsoba.xaml
    /// </summary>
    public partial class StrankaOsoba : Page
    {
        private Frame pretchoziFrame;
        public Trida trida = null;
        public string SkolyJmeno;
        public StrankaOsoba()
        {
            InitializeComponent();
        }
        public StrankaOsoba(Frame predchozistranka, Trida postaveni, string jmenoSkoly) : this()
        {
            this.pretchoziFrame = predchozistranka;
            trida = postaveni;
            SkolyJmeno = jmenoSkoly;
            if(postaveni != null)
            {
                NadpisSkola.Visibility = Visibility.Collapsed;
                Skola.Visibility = Visibility.Collapsed;
                SkolaError.Visibility = Visibility.Collapsed;

                NadpisTrida.Visibility = Visibility.Collapsed;
                Trida.Visibility = Visibility.Collapsed;
                TridaError.Visibility = Visibility.Collapsed;
            }
            else
            {
                Application.Current.MainWindow.Height = 650;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Osoba ososba = new Osoba()
            {
                Jmeno = Jmeno.Text,
                Primeni = Primeni.Text,
                Email = Email.Text,
            };

            try
            {
                string vzaty = Datum.Text;
                DateTime prelozeny = DateTime.Parse(vzaty);
                ososba.DatumNarozeni = prelozeny;
                DatumError.Text = null;
                Datum.Background = Brushes.Green;

            }
            catch
            {

            }
            ValidatorOsoba validator = new ValidatorOsoba();
            FluentValidation.Results.ValidationResult validovany = validator.Validate(ososba);
            bool overeny = validovany.IsValid;
            IList<FluentValidation.Results.ValidationFailure> Errors = validovany.Errors;
            bool booSkola = false;
            bool booTrida = false;
            int idPotvrzeneSkoly = 0;
            int idPotvrzeneTridy = 0;
            if (trida == null)
            {
                if (Skola.Text == "")
                {
                    booSkola = true;
                    booTrida = true;
                    overeny = false;
                    SkolaError.Text = "Zadejte prosím jméno Školy";
                    TridaError.Text = "Zadejte prosím jméno Školy";
                    Skola.Background = Brushes.Red;
                    Trida.Background = Brushes.Red;
                }
                else
                {
                    int idKontrolovaneSkoly = 0;
                    bool existujeSkola = false;

                    foreach (Skola skola in MainWindow.skoly)
                    {
                        if (skola.Jmeno == Skola.Text)
                        {
                            idPotvrzeneSkoly = idKontrolovaneSkoly;
                            existujeSkola = true;
                        }
                        idKontrolovaneSkoly++;
                    }
                    if (!existujeSkola)
                    {
                        booSkola = true;
                        booTrida = true;

                        overeny = false;
                        SkolaError.Text = "Tato škola není v záznamu.";
                        TridaError.Text = "Tato škola není v záznamu.";
                        Skola.Background = Brushes.Red;
                        Trida.Background = Brushes.Red;
                    }
                    else
                    {
                        if (Trida.Text == "")
                        {
                            booTrida = true;
                            overeny = false;
                            TridaError.Text = "Zadejte prosím jméno Třídy";
                            Trida.Background = Brushes.Red;
                        }
                        else
                        {
                            int idKontrolovaneTridy = 0;
                            bool existujeTrida = false;

                            foreach (Trida skola in MainWindow.skoly[idPotvrzeneSkoly].Tridy)
                            {
                                if (skola.Jmeno == Skola.Text)
                                {
                                    idPotvrzeneTridy = idKontrolovaneSkoly;
                                    existujeTrida = true;
                                }
                                idKontrolovaneTridy++;
                            }
                            if (existujeTrida)
                            {
                                booTrida = true;

                                overeny = false;
                                TridaError.Text = "Tato Třída není v záznamu.";
                                Trida.Background = Brushes.Red;
                            }

                        }
                    }
                }
            }
            if (overeny)
            {
                Jmeno.Background = Brushes.Blue;
                Primeni.Background = Brushes.Blue;
                Email.Background = Brushes.Blue;
                Datum.Background = Brushes.Blue;
                Trida.Background = Brushes.Blue;
                Skola.Background = Brushes.Blue;

                if (trida == null)
                {
                    //ulož
                    MainWindow.skoly[idPotvrzeneSkoly].Tridy[idPotvrzeneTridy].Zaci.Add(ososba);
                }
                else
                {
                    trida.TridniUcitel = ososba;
                    pretchoziFrame.Navigate(new StrankaTrida(pretchoziFrame, trida, SkolyJmeno));
                }
            }
            else
            {
                bool booJmeno = false;
                bool booPrimeni = false;
                bool booEmail = false;
                bool booDatum = false;

                foreach (FluentValidation.Results.ValidationFailure error in Errors)
                {
                    if (error.PropertyName == "Jmeno")
                    {
                        booJmeno = true;
                        JmenoError.Text = error.ErrorMessage;
                        Jmeno.Background = Brushes.Red;

                    }
                    else if (error.PropertyName == "Primeni")
                    {
                        booPrimeni = true;
                        PrimeniError.Text = error.ErrorMessage;
                        Primeni.Background = Brushes.Red;
                    }
                    else if (error.PropertyName == "Email")
                    {
                        booEmail = true;
                        EmailError.Text = error.ErrorMessage;
                        Email.Background = Brushes.Red;

                    }
                    else if (error.PropertyName == "DatumNarozeni")
                    {
                        booDatum = true;
                        DatumError.Text = error.ErrorMessage;
                        Datum.Background = Brushes.Red;
                    }
                }
                if (booJmeno == false)
                {
                    JmenoError.Text = null;
                    Jmeno.Background = Brushes.Green;
                }
                if (booPrimeni == false)
                {
                    PrimeniError.Text = null;
                    Primeni.Background = Brushes.Green;
                }
                if (booEmail == false)
                {
                    EmailError.Text = null;
                    Email.Background = Brushes.Green;
                }
                if (booDatum == false)
                {
                    DatumError.Text = null;
                    Datum.Background = Brushes.Green;
                }
                if (!booSkola)
                {
                    SkolaError.Text = null;
                    Skola.Background = Brushes.Green;
                }
                if(!booTrida)
                {
                    TridaError.Text = null;
                    Skola.Background = Brushes.Green;
                }

            }
        }
    }
}
