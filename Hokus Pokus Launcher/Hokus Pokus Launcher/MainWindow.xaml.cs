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
using System.IO;

namespace Hokus_Pokus_Launcher
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nalezeni_disku();
        }

        public void nalezeni_disku()
        {
            DriveInfo[] Disky = DriveInfo.GetDrives();

            int diskRada = 1;
            int diskSloupec = 0;
            foreach (DriveInfo Disk in Disky)
            {
                Button Naklikavac_Disku = new Button();
                TextBlock blem = new TextBlock();
                blem.Text = Disk.Name;
                blem.Background = Brushes.White;
                Naklikavac_Disku.HorizontalAlignment = HorizontalAlignment.Left;
                Naklikavac_Disku.VerticalAlignment = VerticalAlignment.Top;
                Naklikavac_Disku.Width = 70;
                Naklikavac_Disku.Height = 70;
                Naklikavac_Disku.Margin = new Thickness(10,10,0,0);
                Naklikavac_Disku.Background = Brushes.Lime;
                Grid.SetColumn(Naklikavac_Disku,diskSloupec);
                Grid.SetRow(Naklikavac_Disku, diskRada);

                Naklikavac_Disku.Content = blem;
                okno.Children.Add(Naklikavac_Disku);

                diskSloupec++;
                if (diskSloupec == 9)
                {
                    diskSloupec = 0;
                    diskRada++;
                }
                if (diskRada == 7)
                {
                    break;
                }
            }
        }

    }
}
