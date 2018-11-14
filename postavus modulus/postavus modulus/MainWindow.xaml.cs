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

namespace postavus_modulus
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Panacek panacek_in = new Panacek();
        public MainWindow()
        {
            InitializeComponent();
            Panacek.Text = panacek_in.panacek;
            Helma.Text = panacek_in.helma;
            Stit.Text = panacek_in.stit;
            Boty.Text = panacek_in.boty;
            Telo.Text = panacek_in.telo;
            Zbran.Text = panacek_in.mec;
            Nohy.Text = panacek_in.nohy;
        }
    }
}
