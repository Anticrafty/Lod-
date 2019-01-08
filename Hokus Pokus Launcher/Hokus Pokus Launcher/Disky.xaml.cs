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
using System.Diagnostics;
using Path = System.IO.Path;

namespace Hokus_Pokus_Launcher
{
    /// <summary>
    /// Interakční logika pro Disky.xaml
    /// </summary>
    public partial class Disky : Page
    {
        private string app = null;
        private string Copirovani = null;
        private string path;
        private bool zapnutemazani = false;
        private bool zapnuteCopirovani = false;
        private int stranka = 0;
        public string predchoziSlozka;
        private Frame pretchoziFrame;
        public Disky()
        {
            InitializeComponent();
            
        }
        public Disky(int str, Frame predchozistranka, string slozka,string CopirovaniZ, string soubor) : this()
        {
            this.pretchoziFrame = predchozistranka;
            stranka = str;
            predchoziSlozka = slozka;
            Copirovani = CopirovaniZ;
            app = soubor;

            if (Copirovani != null)
            {
                zde.Visibility = Visibility.Visible;
            }
            if (slozka == null)
            {
                nalezeni_disku();
                zde.Visibility = Visibility.Hidden;
                mazac.Visibility = Visibility.Hidden;
                Copirak.Visibility = Visibility.Hidden;
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
            if( stranka == 0)
            {
                Predchozi.Visibility = Visibility.Hidden;
            }
            else
            {
                Predchozi.Visibility = Visibility.Visible ;
            }            
            
            DirectoryInfo[] dir = new DirectoryInfo(@predchoziSlozka).GetDirectories("*.*", SearchOption.TopDirectoryOnly);
            int minSloupec = 7 * stranka;
            int maxSloupec = (7 * stranka) + 7;
            int slozkaRada = 1;
            int slozkaSloupec = 0;
            foreach (DirectoryInfo slozka in dir)
            {
                if(slozkaRada >= minSloupec)
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
                    int strankovac = 0;
                    if (stranka != 0)
                    {
                        strankovac = 1;
                    }
                    Grid.SetRow(Naklikavac_slozka, slozkaRada - ((7 * stranka)- strankovac));

                    Naklikavac_slozka.Content = stack;
                    okno.Children.Add(Naklikavac_slozka);
                }
                slozkaSloupec++;
                if (slozkaSloupec == 9)
                {
                    slozkaSloupec = 0;
                    slozkaRada++;
                    Dalsi.Visibility = Visibility.Hidden;

                }
                if (slozkaRada == maxSloupec)
                {
                    Dalsi.Visibility = Visibility.Visible;
                    break;
                }
                
            }
            FileInfo[] file = new DirectoryInfo(@predchoziSlozka).GetFiles("*.exe", SearchOption.TopDirectoryOnly);
            
            foreach (FileInfo soubor in file)
            {
                if (slozkaRada >= minSloupec && slozkaRada != maxSloupec)
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

                    Naklikavac_soubor.Click += new RoutedEventHandler(Open_Exe);
                    Naklikavac_soubor.HorizontalAlignment = HorizontalAlignment.Left;
                    Naklikavac_soubor.VerticalAlignment = VerticalAlignment.Top;
                    Naklikavac_soubor.Width = 70;
                    Naklikavac_soubor.Height = 90;
                    Naklikavac_soubor.Margin = new Thickness(10, 10, 0, 0);
                    Naklikavac_soubor.Background = null;
                    Naklikavac_soubor.BorderBrush = null;
                    Grid.SetColumn(Naklikavac_soubor, slozkaSloupec);
                    int strankovac = 0;
                    if (stranka != 0)
                    {
                        strankovac = 1;
                    }
                    Grid.SetRow(Naklikavac_soubor, slozkaRada - ((7 * stranka) - strankovac));

                    Naklikavac_soubor.Content = stack;
                    okno.Children.Add(Naklikavac_soubor);
                }
                slozkaSloupec++;
                if (slozkaSloupec > 8)
                {
                    slozkaSloupec = 0;
                    slozkaRada++;
                    Dalsi.Visibility = Visibility.Hidden;
                }
                if (slozkaRada == 7)
                {
                    Dalsi.Visibility = Visibility.Visible;
                    break;
                }
                
            }
        }

        private void Open_Folder(object sender, EventArgs e)
        {
            Button klik = sender as Button;
            StackPanel vnitrek = klik.Content as StackPanel;
            TextBlock nazev = vnitrek.Children[1] as TextBlock;
            if (predchoziSlozka == null)
            {
                path = nazev.Text;
            }
            else
            {
                path = @predchoziSlozka + "\\" + nazev.Text;

            }
            if (zapnutemazani || zapnuteCopirovani)
            {
                Ano.Visibility = Visibility.Visible;
                Ne.Visibility = Visibility.Visible;
                app = nazev.Text;
            }
            else
            {      
                pretchoziFrame.Navigate(new Disky(0, pretchoziFrame, path, Copirovani, app));
            }

            
        }
        private void Open_Exe(object sender, EventArgs e)
        {
            Button klik = sender as Button;
            StackPanel vnitrek = klik.Content as StackPanel;
            TextBlock nazev = vnitrek.Children[1] as TextBlock;
            path = @predchoziSlozka + "\\" + nazev.Text;
            app = nazev.Text;
            if (zapnutemazani || zapnuteCopirovani)
            {
                Ano.Visibility = Visibility.Visible;
                Ne.Visibility = Visibility.Visible;            
            }
            else
            {
                Process proc = new Process();
                proc.StartInfo.FileName = path;
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                proc.Start();
            }

        }

        private void Predchozi_Click(object sender, RoutedEventArgs e)
        {
            Button posuvnik = sender as Button;
            if( posuvnik.Name == "Predchozi")
            {
                stranka--;
            }
            else if (posuvnik.Name == "Dalsi" )
            {
                stranka++;
            }
            string path = @predchoziSlozka;
            pretchoziFrame.Navigate(new Disky(stranka,pretchoziFrame, path, Copirovani, app));
        }

        private void  Smaz_Click(object sender, RoutedEventArgs e)
        {
            if ( zapnutemazani)
            {
                mazac.Background = Brushes.LightGray;
                mazac.Foreground = Brushes.Red;
                zapnutemazani = false;
            }
            else
            {                
                mazac.Background = Brushes.Gray;
                mazac.Foreground = Brushes.Blue;
                zapnutemazani = true;
                Copirak.Background = Brushes.LightGray;
                Copirak.Foreground = Brushes.Red;
                zapnuteCopirovani = false;
            }
        }

        private void AnoNe_Click(object sender, RoutedEventArgs e)
        {
            Button klik = sender as Button;
            string rozhodnuti = klik.Name;

            if (rozhodnuti == "Ano")
            {
                if (zapnutemazani)
                {
                    
                    try
                    {
                        System.IO.File.Delete(path);
                        
                    }
                    catch
                    {
                        System.IO.Directory.Delete(path, true);
                    }
                    pretchoziFrame.Navigate(new Disky(0, pretchoziFrame, null,null,null));
                }           
                else if ( zapnuteCopirovani )
                {
                    pretchoziFrame.Navigate(new Disky(0, pretchoziFrame, null , path, app));
                }
            }
            else
            {
                Ano.Visibility = Visibility.Hidden;
                Ne.Visibility = Visibility.Hidden;
                mazac.Background = Brushes.LightGray;
                mazac.Foreground = Brushes.Red;
                Copirak.Background = Brushes.LightGray;
                Copirak.Foreground = Brushes.Red;
                zapnutemazani = false;
                zapnuteCopirovani = false;
                app = null;
            }
            
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (zapnuteCopirovani)
            {
                Copirak.Background = Brushes.LightGray;
                Copirak.Foreground = Brushes.Red;
                zapnuteCopirovani = false;
            }
            else
            {
                Copirak.Background = Brushes.Gray;
                Copirak.Foreground = Brushes.Blue;
                zapnuteCopirovani = true;
                mazac.Background = Brushes.LightGray;
                mazac.Foreground = Brushes.Red;
                zapnutemazani = false;
            }
        }

        private void Zde_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                System.IO.File.Copy(Copirovani, @predchoziSlozka + "\\" + app);
            }
            catch
            {
                Copiruj(Copirovani, @predchoziSlozka, true);
            }
            pretchoziFrame.Navigate(new Disky(0, pretchoziFrame, null, null, null ));
        }

        private void Copiruj(string odkud, string kam, bool first)
        {
            DirectoryInfo dir = new DirectoryInfo(odkud);
            string sem;
            if (first)
            {
                sem = kam + "\\" + app;
            }
            else
            {
                sem = kam;
            }
            

            if (!Directory.Exists(sem))
            {
                Directory.CreateDirectory(sem);
            }

            FileInfo[] soubory = dir.GetFiles();
            foreach (FileInfo soubor in soubory)
            {
                string Docasny = Path.Combine(sem, soubor.Name);
                soubor.CopyTo(Docasny, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(sem, subdir.Name);
                Copiruj(subdir.FullName, temppath,false);
            }
        }
    }
}
