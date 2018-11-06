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

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro Konec.xaml
    /// </summary>
    public partial class Konec : Page
    {

        private Frame pretchoziFrame;

        public Konec()
        {
            InitializeComponent();
        }
        public Konec(Frame predchozistranka) : this()
        {

            this.pretchoziFrame = predchozistranka;

        }
        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
