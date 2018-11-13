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

namespace ApplikaceKod
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string panacek =
            "    O  \n" +
            "   /|\\ \n" +
            " /_|_\\\n" +
            "° |  |  °\n" +
            "  |  | \n" +
            " ^ ^ \n";
        public MainWindow()
        {
            InitializeComponent();
            Panacek.Text = panacek;
        }

        private void Tancuj_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
