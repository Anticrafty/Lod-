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
    /// Interakční logika pro Disky.xaml
    /// </summary>
    public partial class Disky : Page
    {
        public string predchoziSlozka;
        private Frame pretchoziFrame;
        public Disky()
        {
            InitializeComponent();
            
        }
        public Disky(Frame predchozistranka,string slozka) : this()
        {
            this.pretchoziFrame = predchozistranka;
            predchoziSlozka = slozka;
            if (slozka == null)
            {
                nalezeni_disku();
            }
            else
            {
                otevrinalezeni_slozky();
            }
        }
        public void nalezeni_disku()
        {
            DriveInfo[] Disky = DriveInfo.GetDrives();

            int diskRada = 1;
            int diskSloupec = 0;
            foreach (DriveInfo Disk in Disky)
            {
                Button Naklikavac_Disku = new Button();

                Image nahled = new Image();

                var url = @"https://winaero.com/blog/wp-content/uploads/2015/09/hard-drive-disk-icon.png";

                BitmapImage obrazek = new BitmapImage();
                obrazek.BeginInit();
                obrazek.UriSource = new Uri(url, UriKind.Absolute);
                obrazek.EndInit();

                nahled.Height = 70;
                nahled.Width = 70;
                nahled.Source = obrazek;

                TextBlock blem = new TextBlock();
                
                blem.Text = Disk.Name;
                blem.TextAlignment = TextAlignment.Center;

                StackPanel stack = new StackPanel();

                stack.Children.Add(nahled);
                stack.Children.Add(blem);

                Naklikavac_Disku.Click += new RoutedEventHandler(Open_Folder);
                Naklikavac_Disku.HorizontalAlignment = HorizontalAlignment.Left;
                Naklikavac_Disku.VerticalAlignment = VerticalAlignment.Top;
                Naklikavac_Disku.Width = 70;
                Naklikavac_Disku.Height = 90;
                Naklikavac_Disku.Margin = new Thickness(10, 10, 0, 0);
                Naklikavac_Disku.Background = null;
                Naklikavac_Disku.BorderBrush = null;
                Grid.SetColumn(Naklikavac_Disku, diskSloupec);
                Grid.SetRow(Naklikavac_Disku, diskRada);

                Naklikavac_Disku.Content = stack;
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

        private void otevrinalezeni_slozky()
        {
            DirectoryInfo[] dir = new DirectoryInfo(@predchoziSlozka).GetDirectories("*.*", SearchOption.TopDirectoryOnly);

            int slozkaRada = 1;
            int slozkaSloupec = 0;
            foreach (DirectoryInfo slozka in dir)
            {
                Button Naklikavac_slozka = new Button();

                Image nahled = new Image();

                var url = @"http://icons.iconarchive.com/icons/custom-icon-design/flatastic-1/256/folder-icon.png";

                BitmapImage obrazek = new BitmapImage();
                obrazek.BeginInit();
                obrazek.UriSource = new Uri(url, UriKind.Absolute);
                obrazek.EndInit();

                nahled.Height = 70;
                nahled.Width = 70;
                nahled.Source = obrazek;

                TextBlock blem = new TextBlock();

                blem.Text = slozka.Name;
                blem.TextAlignment = TextAlignment.Center;

                StackPanel stack = new StackPanel();

                stack.Children.Add(nahled);
                stack.Children.Add(blem);

                Naklikavac_slozka.Click += new RoutedEventHandler(Open_Folder);
                Naklikavac_slozka.HorizontalAlignment = HorizontalAlignment.Left;
                Naklikavac_slozka.VerticalAlignment = VerticalAlignment.Top;
                Naklikavac_slozka.Width = 70;
                Naklikavac_slozka.Height = 90;
                Naklikavac_slozka.Margin = new Thickness(10, 10, 0, 0);
                Naklikavac_slozka.Background = null;
                Naklikavac_slozka.BorderBrush = null;
                Grid.SetColumn(Naklikavac_slozka, slozkaSloupec);
                Grid.SetRow(Naklikavac_slozka, slozkaRada);

                Naklikavac_slozka.Content = stack;
                okno.Children.Add(Naklikavac_slozka);

                slozkaSloupec++;
                if (slozkaSloupec == 9)
                {
                    slozkaSloupec = 0;
                    slozkaRada++;
                }
                if (slozkaRada == 7)
                {
                    break;
                }
                
            }
            FileInfo[] file = new DirectoryInfo(@predchoziSlozka).GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo soubor in file)
            {
                Button Naklikavac_soubor = new Button();

                Image nahled = new Image();

                var url = @"https://cdn4.iconfinder.com/data/icons/ionicons/512/icon-ios7-gear-512.png";

                BitmapImage obrazek = new BitmapImage();
                obrazek.BeginInit();
                obrazek.UriSource = new Uri(url, UriKind.Absolute);
                obrazek.EndInit();

                nahled.Height = 70;
                nahled.Width = 70;
                nahled.Source = obrazek;

                TextBlock blem = new TextBlock();

                blem.Text = soubor.Name;
                blem.TextAlignment = TextAlignment.Center;

                StackPanel stack = new StackPanel();

                stack.Children.Add(nahled);
                stack.Children.Add(blem);

                Naklikavac_soubor.Click += new RoutedEventHandler(Open_Folder);
                Naklikavac_soubor.HorizontalAlignment = HorizontalAlignment.Left;
                Naklikavac_soubor.VerticalAlignment = VerticalAlignment.Top;
                Naklikavac_soubor.Width = 70;
                Naklikavac_soubor.Height = 90;
                Naklikavac_soubor.Margin = new Thickness(10, 10, 0, 0);
                Naklikavac_soubor.Background = null;
                Naklikavac_soubor.BorderBrush = null;
                Grid.SetColumn(Naklikavac_soubor, slozkaSloupec);
                Grid.SetRow(Naklikavac_soubor, slozkaRada);

                Naklikavac_soubor.Content = stack;
                okno.Children.Add(Naklikavac_soubor);

                slozkaSloupec++;
                if (slozkaSloupec == 9)
                {
                    slozkaSloupec = 0;
                    slozkaRada++;
                }
                if (slozkaRada == 7)
                {
                    break;
                }
            }
        }

        private void Open_Folder(object sender, EventArgs e)
        {
            Button klik = sender as Button;
            StackPanel vnitrek = klik.Content as StackPanel;
            TextBlock nazev = vnitrek.Children[1] as TextBlock;
            string path;
            if (predchoziSlozka == null)
            {
                path = nazev.Text;
            }
            else
            {
                path = @predchoziSlozka + "\\" + nazev.Text;
            }

            pretchoziFrame.Navigate(new Disky(pretchoziFrame, path));
        }
    }
}
