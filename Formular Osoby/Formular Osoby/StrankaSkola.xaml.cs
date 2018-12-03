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
    /// Interakční logika pro StrankaSkola.xaml
    /// </summary>
    public partial class StrankaSkola : Page
    {

        private Frame pretchoziFrame;

        public StrankaSkola()
        {
            InitializeComponent();
        }

        public StrankaSkola(Frame predchozistranka) : this()
        {
            this.pretchoziFrame = predchozistranka;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Skola ososba = new Skola()
            {
                Jmeno = Jmeno.Text
            };
            
            ValidatorSkola validator = new ValidatorSkola();
            FluentValidation.Results.ValidationResult validovany = validator.Validate(ososba);
            bool overeny = validovany.IsValid;
            IList<FluentValidation.Results.ValidationFailure> Errors = validovany.Errors;
            if (overeny)
            {
                Jmeno.Background = Brushes.Blue;                

                    //ulož
               
            }
            else
            {
                bool booJmeno = false;                

                foreach (FluentValidation.Results.ValidationFailure error in Errors)
                {
                    if (error.PropertyName == "Jmeno")
                    {
                        booJmeno = true;
                        JmenoError.Text = error.ErrorMessage;
                        Jmeno.Background = Brushes.Red;

                    }                    
                }
                if (booJmeno == false)
                {
                    JmenoError.Text = null;
                    Jmeno.Background = Brushes.Green;
                }               

            }
        }
    }
}
