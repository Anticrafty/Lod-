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
        public StrankaOsoba()
        {
            InitializeComponent();
        }
        public StrankaOsoba(Frame predchozistranka, Trida postaveni) : this()
        {
            this.pretchoziFrame = predchozistranka;
            trida = postaveni;
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
            if (overeny)
            {
                Jmeno.Background = Brushes.Blue;
                Primeni.Background = Brushes.Blue;
                Email.Background = Brushes.Blue;
                Datum.Background = Brushes.Blue;
                
                if (trida == null)
                {
                    //ulož
                }
                else
                {
                    trida.TridniUcitel = ososba;
                    pretchoziFrame.Navigate(new StrankaTrida(pretchoziFrame, trida));
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

            }
        }
    }
}
