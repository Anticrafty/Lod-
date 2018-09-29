using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lodě
{
    class Program
    {
        static void Main(string[] args)
        {
            // myšlenky
            // mapa 9 * 9
            /*
               123456789X
             ------------
             1|~~~~~~~~~|
             2|~~~~~~~~~|
             3|~~~~~~~~~|
             4|~~~~~~~~~|
             5|~~~~~~~~~|
             6|~~~~~~~~~|
             7|~~~~~~~~~|
             8|~~~~~~~~~|
             9|~~~~~~~~~|
             Y-----------
             */

            // políčko bude základní třída
            // mapa bude jen List políček
            // lodě budou ovlivňovat políčka

            // prázdný - 0 = ~
            // plný - 1 = ~
            // prázdný zásah - 2 = O
            // plný zásah - 3 = x
            // zničená loď - 4 = X

            // Program
            Mapa obalmapa1 = new Mapa();
            Mapa obalmapa2 = new Mapa();
            void createmap(int hrac)
            {
                Console.WriteLine(" Hráč {0} rozmisťuje lodě", hrac);
                //vyvolání vytvoření mapy
                if (hrac == 1)
                {
                    obalmapa1.Obal = Polickosvytvoreni();
                }
                else
                {
                    obalmapa2.Obal = Polickosvytvoreni();
                }
            }
            // funkce to aby si uživatel vybral pozici lodě a na jakou stranu se otočit
            List<int> urcipozici(int hrac)
            {
                List<int> vybrany = new List<int>();
                bool urci = false;
                while (!urci)
                {
                    Console.Clear();
                    if (hrac == 1)
                    {
                        obalmapa1.VypisMapu();
                    }
                    else
                    {
                        obalmapa2.VypisMapu();
                    }
                    Console.Write("Pozice X chci: ");
                    string zvolX = Console.ReadLine();
                    Console.Clear();
                    if (hrac == 1)
                    {
                        obalmapa1.VypisMapu();
                    }
                    else
                    {
                        obalmapa2.VypisMapu();
                    }
                    Console.Write("Pozice Y chci: ");
                    string zvolY = Console.ReadLine();
                    Console.Clear();
                    bool urci1 = int.TryParse(zvolX, out int zvolenyX);
                    bool urci2 = int.TryParse(zvolY, out int zvolenyY);
                    // nesmí jít mimo mapu
                    if (urci1 && urci2)
                    {
                        if (zvolenyX > 0 && zvolenyX < 10 && zvolenyY > 0 && zvolenyY < 10)
                        {
                            if (hrac == 1)
                            {
                                obalmapa1.VypisMapu();
                            }
                            else
                            {
                                obalmapa2.VypisMapu();
                            }
                            Console.WriteLine("1 - nahoru");
                            Console.WriteLine("2 - doprava");
                            Console.WriteLine("3 - dolu");
                            Console.WriteLine("4 - doleva");
                            Console.Write("Chci na stranu : ");
                            string zvolstranu = Console.ReadLine();
                            Console.Clear();
                            urci = int.TryParse(zvolstranu, out int zvolenastrana);
                            if (zvolenastrana < 1 || zvolenastrana > 5)
                            {
                                urci = false;
                            }
                            else
                            {
                                vybrany.Add(zvolenyX);
                                vybrany.Add(zvolenyY);
                                vybrany.Add(zvolenastrana);
                            }
                        }
                        if (urci == false)
                        {
                            Console.WriteLine(" Něco si zadal špatně!!! Zadej znovu a pořádně!!!");
                            Console.ReadLine();
                        }
                    }

                }
                return vybrany;
            }
            // funkce  na vybrání  a postavení lodi
            List<Policko> stavenilode(int bezpecnaodpoved, int hrac)
            {
                List<Policko> novypolicka = new List<Policko>();
                bool postavlod = true;
                while (postavlod)
                {
                    List<int> urcenapozice = urcipozici(hrac);
                    List<Policko> ListXYsouradnice = Lod.Vypocitejlod(bezpecnaodpoved, urcenapozice);
                    if (ListXYsouradnice[0].X != 0)
                    {
                        bool nenitamlod = true;
                        for (int wat = 1; wat < 3; wat++)
                        {
                            if (hrac == 1)
                            {
                                foreach (Policko novasouradnice in ListXYsouradnice)
                                {
                                    int pocetkontrolovanych = 0;
                                    foreach (Policko policko in obalmapa1.Obal)
                                    {


                                        if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                        {
                                            if (wat == 2 && nenitamlod)
                                            {
                                                obalmapa1.Obal[pocetkontrolovanych].Stav = 1;
                                                novypolicka.Add(novasouradnice);
                                                postavlod = false;
                                            }
                                            else if (wat == 1 && obalmapa1.Obal[pocetkontrolovanych].Stav == 1)
                                            {
                                                nenitamlod = false;
                                                Console.WriteLine("na souradnicich X: {0} Y: {1}, už část lodi je.", novasouradnice.X, novasouradnice.Y);

                                            }
                                        }
                                        pocetkontrolovanych++;
                                    }
                                }
                            }
                            else
                            {
                                foreach (Policko novasouradnice in ListXYsouradnice)
                                {
                                    int pocetkontrolovanych = 0;
                                    foreach (Policko policko in obalmapa2.Obal)
                                    {


                                        if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                        {
                                            if (wat == 2 && nenitamlod)
                                            {
                                                obalmapa2.Obal[pocetkontrolovanych].Stav = 1;
                                                novypolicka.Add(novasouradnice);
                                                postavlod = false;
                                            }
                                            else if (wat == 1 && obalmapa2.Obal[pocetkontrolovanych].Stav == 1)
                                            {
                                                nenitamlod = false;
                                                Console.WriteLine("na souradnicich X: {0} Y: {1}, už část lodi je.", novasouradnice.X, novasouradnice.Y);

                                            }
                                        }
                                        pocetkontrolovanych++;
                                    }
                                }
                            }

                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Loď by šla mimo mapu. Zadejte znovu opatrněji");
                        Console.ReadLine();
                    }
                }
                return novypolicka;
            }

            // funkce vytvoření mapy
            List<Policko> Polickosvytvoreni()
            {
                List<Policko> polickos = new List<Policko>();
                for (int y = 1; y < 10; y++)
                {
                    for (int x = 1; x < 10; x++)
                    {
                        polickos.Add(new Policko()
                        {
                            X = x,
                            Y = y,
                            Stav = 0
                        });
                    };
                }
                return polickos;
            }

            // funkce na postavení lodí           
            List<Lod> postavlode(int hrac)
            {
                createmap(hrac);
                List<Lod> postavenylode = new List<Lod>();
                List<int> druhylodi = new List<int>();
                bool stavenilodi = true;
                while (stavenilodi)
                {
                    bool trythat = false;
                    while (!trythat)
                    {

                        // vykreslení mapy
                        if (hrac == 1)
                        {
                            obalmapa1.VypisMapu();
                        }
                        else
                        {
                            obalmapa2.VypisMapu();
                        }
                        // rohodovani druhu lodi
                        if (!druhylodi.Contains(1))
                        {
                            Console.WriteLine("1 - ponorka");
                        }
                        if (!druhylodi.Contains(2))
                        {
                            Console.WriteLine("2 - torpedoborec");
                        }
                        if (!druhylodi.Contains(3))
                        {
                            Console.WriteLine("3 - křižník");
                        }
                        if (!druhylodi.Contains(4))
                        {
                            Console.WriteLine("4 - bitevní loď");
                        }
                        if (!druhylodi.Contains(5))
                        {
                            Console.WriteLine("5 - letadlová loď");
                        }
                        string odpoved = Console.ReadLine();
                        if (!druhylodi.Contains(1) || !druhylodi.Contains(2) || !druhylodi.Contains(3) || !druhylodi.Contains(4) || !druhylodi.Contains(5))
                        {
                            // kontrola
                            trythat = int.TryParse(odpoved, out int bezpecnaodpoved);
                            if (trythat)
                            {
                                // udělat vyběr
                                if (!druhylodi.Contains(bezpecnaodpoved))
                                {
                                    List<Policko> novypolicka = stavenilode(bezpecnaodpoved, hrac);
                                    druhylodi.Add(bezpecnaodpoved);
                                    postavenylode.Add(new Lod
                                    {
                                        Kostra = novypolicka,
                                        Druh = bezpecnaodpoved

                                    });
                                }

                            }
                        }
                        else
                        {
                            stavenilodi = false;
                            trythat = true;
                        }


                    }

                }
                return postavenylode;
            }
            // vyvolani staveni lodi
            List<Lod> postavenylodeP1 = postavlode(1);
            Console.Clear();
            List<Lod> postavenylodeP2 = postavlode(2);

            // útok

            // fukce na zádávání souradnic útoku
            List<int> urcipoziciutoku(int hrac)
            {
                List<int> vybrany = new List<int>();
                bool urci = false;
                while (!urci)
                {
                    if (hrac == 2)
                    {
                        obalmapa1.VypisMapu();
                    }
                    else
                    {
                        obalmapa2.VypisMapu();
                    }
                    Console.Write("Pozice X chci: ");
                    string zvolX = Console.ReadLine();
                    Console.Clear();
                    if (hrac == 2)
                    {
                        obalmapa1.VypisMapu();
                    }
                    else
                    {
                        obalmapa2.VypisMapu();
                    }
                    Console.Write("Pozice Y chci: ");
                    string zvolY = Console.ReadLine();
                    Console.Clear();
                    bool urci1 = int.TryParse(zvolX, out int zvolenyX);
                    bool urci2 = int.TryParse(zvolY, out int zvolenyY);
                    // nesmí jít mimo mapu
                    if (urci1 && urci2)
                    {
                        if (zvolenyX > 0 && zvolenyX < 10 && zvolenyY > 0 && zvolenyY < 10)
                        {

                            vybrany.Add(zvolenyX);
                            vybrany.Add(zvolenyY);
                            urci = true;
                        }
                    }
                }
                return vybrany;
            }
            // funkce na zjištění jestli tam je část lodi
            void zjistiazmen( int hrac)
            {
                
                List<Lod> hledanylode = new List<Lod>();
                if (hrac == 1)
                {
                    Console.WriteLine("Útočí hráč 1.");
                    hledanylode = postavenylodeP2;
                }
                else
                {
                    Console.WriteLine("Útočí hráč 2.");
                    hledanylode = postavenylodeP2;

                }
                List<int> pozice = urcipoziciutoku(hrac);
                List<int> potvrzenapozice = new List<int>();
                bool nenitamlod = true;
                int pocetkontrolovanych = 0;
                if (hrac == 1)
                    {
                    
                        foreach (Policko policko in obalmapa2.Obal)
                        {


                            if (pozice[0] == policko.X && pozice[1] == policko.Y)
                            {
                                if ( obalmapa2.Obal[pocetkontrolovanych].Stav == 1)
                                { 
                                    potvrzenapozice.Add(policko.X);
                                    potvrzenapozice.Add(policko.X);
                                    obalmapa2.Obal[pocetkontrolovanych].Stav = 3;
                                    nenitamlod = false;
                                    Console.WriteLine("Trefil jsi");
                                } else if (obalmapa2.Obal[pocetkontrolovanych].Stav == 0)
                                {
                                    obalmapa2.Obal[pocetkontrolovanych].Stav = 2;
                                    Console.WriteLine("Netrefil jsi");
                                } else
                                {
                                    Console.WriteLine("Tam jsi už střílel, ztratil jsi tím kolo");
                                }
                            }
                            pocetkontrolovanych++;

                        }
                    }
                    else
                    {
                   
                        foreach (Policko policko in obalmapa1.Obal)
                        {


                        if (pozice[0] == policko.X && pozice[1] == policko.Y)
                        {
                            if (obalmapa1.Obal[pocetkontrolovanych].Stav == 1)
                            {
                                potvrzenapozice.Add(policko.X);
                                potvrzenapozice.Add(policko.X);
                                obalmapa1.Obal[pocetkontrolovanych].Stav = 3;
                                nenitamlod = false;
                                Console.WriteLine("Trefil jsi");
                            }
                            else if (obalmapa1.Obal[pocetkontrolovanych].Stav == 0)
                            {
                                obalmapa1.Obal[pocetkontrolovanych].Stav = 2;
                                Console.WriteLine("Netrefil jsi");
                            }
                            else
                            {
                                Console.WriteLine("Tam jsi už střílel, ztratil jsi tím kolo");
                            }
                        }
                        pocetkontrolovanych++;
                        }

                    }

             
            }

                bool hrajede = true;
                int hracurtok = 1;
            while (hrajede)
            {
                Console.Clear();
                zjistiazmen(hracurtok);
                if (hracurtok == 1) { 
                     hracurtok++;
                } else
                {
                    hracurtok = 1;
                }
            }
        }
    }
}
