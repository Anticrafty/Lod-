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
            
                // vytvoření mapy
            List<Policko> polickos = new List<Policko>();
            for (int y = 1; y < 10; y++ )
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
            Mapa obalmapa = new Mapa()
            {
                Obal = polickos

            };
            // funkce to aby si uživatel vybral pozici lodě a na jakou stranu se otočit
              List<int> urcipozici() {
                    List<int> vybrany = new List<int>();
                    bool urci = false;
                  while (!urci) {
                        Console.Clear();
                        obalmapa.VypisMapu();
                        Console.Write("Pozice X chci: ");
                        string zvolX = Console.ReadLine();
                        Console.Clear();
                        obalmapa.VypisMapu();
                        Console.Write("Pozice Y chci: ");
                        string zvolY = Console.ReadLine();
                        Console.Clear();
                        bool urci1 = int.TryParse(zvolX, out int zvolenyX);
                        bool urci2 = int.TryParse(zvolY, out int zvolenyY);
                        // nesmí jít mimo mapu
                        if (urci1 && urci2) { 
                            if ( zvolenyX > 0  && zvolenyX < 10 && zvolenyY > 0 && zvolenyY < 10)
                            {
                                obalmapa.VypisMapu();
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
                                } else
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


            // postavení lodí
            List<Lod> postavenylode = new List<Lod>();
            List<int> druhylodi = new List<int>();
            bool stavenilodi = true;
            while (stavenilodi) { 
                bool trythat = false;
                while (!trythat)
                {

                    // vykreslení mapy
                    obalmapa.VypisMapu();
                    // rohodovani druhu lodi
                    if (!druhylodi.Contains(1)) { 
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
                    // kontrola
                    trythat = int.TryParse(odpoved, out int bezpecnaodpoved);
                    if (trythat)
                    {
                        // udělat vyběr
                        if (bezpecnaodpoved == 1 && !druhylodi.Contains(1))
                        {
                            List<Policko> novypolicka = new List<Policko>();
                            bool postavlod = true;
                            while (postavlod)
                            { 
                                List<int> urcenapozice = urcipozici();
                                List<Policko> ListXYsouradnice = Lod.Vypocitejlod( bezpecnaodpoved, urcenapozice);
                                if (ListXYsouradnice[0].X != 0 )
                                {
                                    Console.WriteLine("GG");
                                    Console.ReadLine();

                                    foreach (Policko novasouradnice in ListXYsouradnice)
                                    {     
                                        int pocetkontrolovanych = 0;
                                        foreach(Policko policko in obalmapa.Obal)
                                        {
                                            
                                            
                                            if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                            {
                                                obalmapa.Obal[pocetkontrolovanych].Stav = 1;
                                                Console.WriteLine("Do ID {0} se dal stav 1", pocetkontrolovanych);
                                                novypolicka.Add(novasouradnice);
                                            }
                                            pocetkontrolovanych++;
                                        }
                                    }
                                    postavlod = false;
                                } else
                                {
                                    Console.WriteLine("Loď by šla mimo mapu. Zadejte znovu opatrněji");
                                    Console.ReadLine();
                                }
                            }
                            druhylodi.Add(bezpecnaodpoved);
                            postavenylode.Add(new Lod
                            {
                                Kostra = novypolicka,
                                Druh = bezpecnaodpoved

                            });
                        }
                        if (bezpecnaodpoved == 2 && !druhylodi.Contains(2))
                        {
                            List<Policko> novypolicka = new List<Policko>();
                            bool postavlod = true;
                            while (postavlod)
                            {
                                List<int> urcenapozice = urcipozici();
                                List<Policko> ListXYsouradnice = Lod.Vypocitejlod(bezpecnaodpoved, urcenapozice);
                                if (ListXYsouradnice[0].X != 0)
                                {
                                    Console.WriteLine("GG");
                                    Console.ReadLine();

                                    foreach (Policko novasouradnice in ListXYsouradnice)
                                    {
                                        int pocetkontrolovanych = 0;
                                        foreach (Policko policko in obalmapa.Obal)
                                        {
                                            
                                            
                                            if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                            {
                                                obalmapa.Obal[pocetkontrolovanych].Stav = 1;
                                                Console.WriteLine("Do ID {0} se dal stav 1", pocetkontrolovanych);
                                                novypolicka.Add(novasouradnice);
                                            }
                                            pocetkontrolovanych++;
                                        }
                                    }
                                    postavlod = false;
                                }
                                else
                                {
                                    Console.WriteLine("Loď by šla mimo mapu. Zadejte znovu opatrněji");
                                    Console.ReadLine();
                                }
                            }
                            druhylodi.Add(bezpecnaodpoved);
                            postavenylode.Add(new Lod
                            {
                                Kostra = novypolicka,
                                Druh = bezpecnaodpoved

                            });
                        }
                        if (bezpecnaodpoved == 3 && !druhylodi.Contains(3))
                        {
                            List<Policko> novypolicka = new List<Policko>();
                            bool postavlod = true;
                            while (postavlod)
                            {
                                List<int> urcenapozice = urcipozici();
                                List<Policko> ListXYsouradnice = Lod.Vypocitejlod(bezpecnaodpoved, urcenapozice);
                                if (ListXYsouradnice[0].X != 0)
                                {
                                    Console.WriteLine("GG");
                                    Console.ReadLine();

                                    foreach (Policko novasouradnice in ListXYsouradnice)
                                    {
                                        int pocetkontrolovanych = 0;
                                        foreach (Policko policko in obalmapa.Obal)
                                        {
                                            
                                            
                                            if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                            {
                                                obalmapa.Obal[pocetkontrolovanych].Stav = 1;
                                                Console.WriteLine("Do ID {0} se dal stav 1", pocetkontrolovanych);
                                                novypolicka.Add(novasouradnice);
                                            }
                                            pocetkontrolovanych++;
                                        }
                                    }
                                    postavlod = false;
                                }
                                else
                                {
                                    Console.WriteLine("Loď by šla mimo mapu. Zadejte znovu opatrněji");
                                    Console.ReadLine();
                                }
                            }
                            druhylodi.Add(bezpecnaodpoved);
                            postavenylode.Add(new Lod
                            {
                                Kostra = novypolicka,
                                Druh = bezpecnaodpoved

                            });
                        }
                        if (bezpecnaodpoved == 4 && !druhylodi.Contains(4))
                        {
                            List<Policko> novypolicka = new List<Policko>();
                            bool postavlod = true;
                            while (postavlod)
                            {
                                List<int> urcenapozice = urcipozici();
                                List<Policko> ListXYsouradnice = Lod.Vypocitejlod(bezpecnaodpoved, urcenapozice);
                                if (ListXYsouradnice[0].X != 0)
                                {
                                    Console.WriteLine("GG");
                                    Console.ReadLine();

                                    foreach (Policko novasouradnice in ListXYsouradnice)
                                    {
                                        int pocetkontrolovanych = 0;
                                        foreach (Policko policko in obalmapa.Obal)
                                        {
                                            
                                            
                                            if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                            {
                                                obalmapa.Obal[pocetkontrolovanych].Stav = 1;
                                                Console.WriteLine("Do ID {0} se dal stav 1", pocetkontrolovanych);
                                                novypolicka.Add(novasouradnice);
                                            }
                                            pocetkontrolovanych++;
                                        }
                                    }
                                    postavlod = false;
                                }
                                else
                                {
                                    Console.WriteLine("Loď by šla mimo mapu. Zadejte znovu opatrněji");
                                    Console.ReadLine();
                                }
                            }
                            druhylodi.Add(bezpecnaodpoved);
                            postavenylode.Add(new Lod
                            {
                                Kostra = novypolicka,
                                Druh = bezpecnaodpoved

                            });
                        }
                        if (bezpecnaodpoved == 5 && !druhylodi.Contains(5))
                        {
                            List<Policko> novypolicka = new List<Policko>();
                            bool postavlod = true;
                            while (postavlod)
                            {
                                List<int> urcenapozice = urcipozici();
                                List<Policko> ListXYsouradnice = Lod.Vypocitejlod(bezpecnaodpoved, urcenapozice);
                                if (ListXYsouradnice[0].X != 0)
                                {
                                    Console.WriteLine("GG");
                                    Console.ReadLine();

                                    foreach (Policko novasouradnice in ListXYsouradnice)
                                    {
                                        int pocetkontrolovanych = 0;
                                        foreach (Policko policko in obalmapa.Obal)
                                        {
                                            
                                            
                                            if (novasouradnice.X == policko.X && novasouradnice.Y == policko.Y)
                                            {
                                                obalmapa.Obal[pocetkontrolovanych].Stav = 1;
                                                Console.WriteLine("Do ID {0} se dal stav 1", pocetkontrolovanych);
                                                novypolicka.Add(novasouradnice);
                                            }
                                            pocetkontrolovanych++;
                                        }
                                    }
                                    postavlod = false;
                                }
                                else
                                {
                                    Console.WriteLine("Loď by šla mimo mapu. Zadejte znovu opatrněji");
                                    Console.ReadLine();
                                }
                            }
                            druhylodi.Add(bezpecnaodpoved);
                            postavenylode.Add(new Lod
                            {
                                Kostra = novypolicka,
                                Druh = bezpecnaodpoved

                            });
                        }
                    }


                }
            }
        }
    }
}
