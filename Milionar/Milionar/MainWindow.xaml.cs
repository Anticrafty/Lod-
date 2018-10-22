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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // nepoužito?
        bool padenapadenepouzitej = true;
        bool jinaotazkanepouzitej = true;
        bool publikumnepouzitej = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Collapsed;

            if (padenapadenepouzitej)
            {
                rada1.Visibility = Visibility.Visible;
            }
            if (publikumnepouzitej)
            {

                rada2.Visibility = Visibility.Visible;
            }
            if (jinaotazkanepouzitej)
            {
                rada3.Visibility = Visibility.Visible;
            }

            odpoved.Visibility = Visibility.Visible;
            

        }
    }
}
