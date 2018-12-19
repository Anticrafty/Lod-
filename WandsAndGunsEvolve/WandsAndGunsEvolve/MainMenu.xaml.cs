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

namespace WandsAndGunsEvolve
{
    /// <summary>
    /// Interakční logika pro MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private Frame PredchoziOkno;

        public MainMenu()
        {
            InitializeComponent();
        }
        public MainMenu( Frame Window ) : this()
        {
            this.PredchoziOkno = Window;
            Application.Current.MainWindow.Height = 500;
            Application.Current.MainWindow.Width = 540;
            and.Text = "" + (char)0X26;
        }
    }
}
