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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace postavus_modulus
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Panacek panacek_in = new Panacek();
        Globals globals = new Globals(panacek_in);
        Makra loaded = new Makra();
        List<Button> ukazatele = new List<Button>();
        public int kolikrat_vic = 1;
        public MainWindow()
        {
            InitializeComponent();
            UpdateWindow();
            loaded.LoadMacros();

            ukazatele.Add(Butt_Pretchozi);
            ukazatele.Add(Butt_1);
            ukazatele.Add(Butt_2);
            ukazatele.Add(Butt_3);
            ukazatele.Add(Butt_4);
            ukazatele.Add(Butt_5);
            ukazatele.Add(Butt_6);
            ukazatele.Add(Butt_7);
            ukazatele.Add(Butt_8);
            ukazatele.Add(Butt_9);
            ukazatele.Add(Butt_10);
            ukazatele.Add(Butt_11);
            ukazatele.Add(Butt_12);
            ukazatele.Add(Butt_Dalsi);

            UkazMacra();
        }
        public void UpdateWindow()
        {
            Panacek.Text = globals.Panacek.panacek;

            Helma.Text = globals.Panacek.helma.obrazek;
            Helma_jmeno.Text = globals.Panacek.helma.jmeno;
            Stit.Text = globals.Panacek.stit.obrazek;
            Stit_jmeno.Text = globals.Panacek.stit.jmeno;
            Boty.Text = globals.Panacek.boty.obrazek;
            Boty_jmeno.Text = globals.Panacek.boty.jmeno;
            Telo.Text = globals.Panacek.telo.obrazek;
            Telo_jmeno.Text = globals.Panacek.telo.jmeno;
            Zbran.Text = globals.Panacek.zbran.obrazek;
            Zbran_jmeno.Text = globals.Panacek.zbran.jmeno;
            Nohy.Text = globals.Panacek.nohy.obrazek;
            Nohy_jmeno.Text = globals.Panacek.nohy.jmeno;

            Zivot.Maximum = globals.Panacek.Max_Health.velikost;
            Zivot.Value = globals.Panacek.Health.velikost;
            Mana.Maximum = globals.Panacek.Max_Mana.velikost;
            Mana.Value = globals.Panacek.Mana.velikost;
            Energie.Maximum = globals.Panacek.Max_Energie.velikost;
            Energie.Value = globals.Panacek.Energie.velikost;
        }
        public void UkazMacra()
        {

            int macro = 12 * (kolikrat_vic - 1);
            int povoleno = 0;
            if (loaded.codes.Count() < (12 * kolikrat_vic) + 1)
            {
                povoleno = loaded.codes.Count();
                ukazatele[13].Visibility = Visibility.Hidden;
            }
            else
            {
                povoleno = 12 * kolikrat_vic;
                ukazatele[13].Visibility = Visibility.Visible;
            }


            for (; macro < povoleno; macro++)
            {

                ukazatele[(macro - (12 * (kolikrat_vic - 1))) + 1].Visibility = Visibility.Visible;
                string kolikaty = (macro + 1).ToString();
                ukazatele[(macro - (12 * (kolikrat_vic - 1))) + 1].Content = kolikaty;
            }
            for (; macro < 12 * kolikrat_vic; macro++)
            {
                ukazatele[(macro - (12 * (kolikrat_vic - 1))) + 1].Visibility = Visibility.Hidden;
            }
        }

        private void Butt_Posuvnik_Click(object sender, RoutedEventArgs e)
        {
            Button zmacknuty = sender as Button;
            if (zmacknuty.Name == "Butt_Pretchozi")
            {
                kolikrat_vic--;
                if (kolikrat_vic == 1)
                {
                    ukazatele[0].Visibility = Visibility.Hidden;
                }
                UkazMacra();
            }
            else
            {
                kolikrat_vic++;
                ukazatele[0].Visibility = Visibility.Visible;
                UkazMacra();
            }
        }

        private void Rohodnute_macro(object sender, RoutedEventArgs e)
        {
            Button zmacknuty = sender as Button;
            string vzaty = zmacknuty.Content.ToString();
            int cislo = int.Parse(vzaty);
            int kolikaty = cislo - 1;
            Editor_Macra.Text = loaded.codes[kolikaty];
            Start_Butt.Visibility = Visibility.Visible;
        }
        private async void Start_macro(object sender, RoutedEventArgs e)
        {
            Udelej_macro();
        }
        private async void Udelej_macro()
        {
            string vstup = Editor_Macra.Text;
            var metadata = MetadataReference.CreateFromFile(typeof(Panacek).Assembly.Location);

            try
            {
                await CSharpScript.RunAsync(
                vstup,
                options: ScriptOptions.Default.WithReferences(metadata),
                globals: loaded
                );


            } catch (CompilationErrorException e)
            {
                Errors.Text = string.Join(Environment.NewLine, e.Diagnostics);
            }
        }
    }
}
