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
    /// Interakční logika pro pokracovani.xaml
    /// </summary>
    public partial class pokracovani : Page
    {
        private Frame pretchoziFrame;
        public static int uhadnuty = 2;
        public pokracovani()
        {
            InitializeComponent();
        }

        public pokracovani( Frame predchozistranka) : this()
        {
            this.pretchoziFrame = predchozistranka;
            MainWindow.ZmenStreser(uhadnuty);
        }
}
}
