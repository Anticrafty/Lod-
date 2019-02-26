using System;
using Funkce;
using Classy;
using System.Collections.Generic;
using System.Linq;

namespace Evidence_Znamek_Konzolova
{
    class Program
    {

        static void Main(string[] args)
        {
            bool program = true;
            string path = @"D:\source\Evidence_Znamek_Konzolova\Znamky.db";

            Databaze SQLight = new Databaze(path, Odesilatel.Console);

            while (program)
            {
                Console.WriteLine("Co chceš udělat?");
                Console.WriteLine("1 - Zadat známku");
                Console.WriteLine("2 - Zadat předmět");
                Console.WriteLine("3 - Prohlednout Znamky");
                
                Console.WriteLine("E - Zavřit program");
                Console.WriteLine("-----------------------------");
                Console.Write("Chci:");
                string odpoved = Console.ReadLine();
                Console.Clear();

                if (odpoved == "E" || odpoved == "e")
                {
                    program = false;
                }
                else if (odpoved == "1")
                {
                    bool zadavani = true;
                    Znamka nova_znamka = new Znamka();
                    while (zadavani)
                    {
                        bool zadavani_predmet = true;
                        bool zadavani_znamka = false;
                        bool zadavani_vaha = false;
                        while (zadavani_predmet)
                        {
                            Console.WriteLine("jaký předmět?");
                            foreach(Predmet predmet in SQLight.Get_predmety())
                            {
                                Console.WriteLine(predmet.ID + " - " + predmet.Jmeno);
                            }
                            Console.WriteLine("E - Nechi zadávat známku");
                            Console.WriteLine("-----------------------------");
                            Console.Write("Chci předmět číslem:");
                            string odpoved_predmet = Console.ReadLine();
                            Console.Clear();

                            if (odpoved_predmet == "E" || odpoved_predmet == "e")
                            {
                                zadavani = false;
                                zadavani_predmet = false;
                            }
                            else
                            {
                                bool je_predmet_odpoved = int.TryParse(odpoved_predmet, out int ciselna_predmet_odpoved);
                                if (je_predmet_odpoved)
                                {
                                    if (ciselna_predmet_odpoved > 0 || ciselna_predmet_odpoved < SQLight.Get_predmety().Count() + 1)
                                    {
                                        nova_znamka.predmet = SQLight.Get_predmety()[ciselna_predmet_odpoved - 1].Jmeno;
                                        zadavani_znamka = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("!!! Napiš číslo předmětu správně !!!");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("!!! Napiš odpověď správně !!!");
                                }
                            }
                            while (zadavani_znamka)
                            {
                                Console.WriteLine("jaká známka?");
                                Console.WriteLine("1 - Vynikající");
                                Console.WriteLine("2 - Nadočekávání");
                                Console.WriteLine("3 - Dobrý");
                                Console.WriteLine("4 - Dostačující");
                                Console.WriteLine("5 - Nedostačující");
                                Console.WriteLine("E - Nechi zadávat známku");
                                Console.WriteLine("-----------------------------");
                                Console.Write("Chci známku číslem:");
                                string odpoved_znamka = Console.ReadLine();
                                Console.Clear();

                                if (odpoved_znamka == "E" || odpoved_znamka == "e")
                                {
                                    zadavani = false;
                                    zadavani_predmet = false;
                                    zadavani_znamka = false;
                                }
                                else
                                {
                                    bool je_znamka_odpoved = int.TryParse(odpoved_znamka, out int ciselna_znamka_odpoved);
                                    if (je_znamka_odpoved)
                                    {
                                        if(ciselna_znamka_odpoved > 0 && ciselna_znamka_odpoved < 6)
                                        {
                                            nova_znamka.známka = ciselna_znamka_odpoved;
                                            zadavani_vaha = true;
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("!!! Napiš existující známku!!!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("!!! Napiš odpověď správně !!!");
                                    }
                                }
                                while(zadavani_vaha)
                                {
                                    Console.WriteLine("jakou váhu?");
                                    Console.WriteLine("1");
                                    Console.WriteLine("2");
                                    Console.WriteLine("3");
                                    Console.WriteLine("4");
                                    Console.WriteLine("5");
                                    Console.WriteLine("6");
                                    Console.WriteLine("7");
                                    Console.WriteLine("8");
                                    Console.WriteLine("9");
                                    Console.WriteLine("10");
                                    Console.WriteLine("E - Nechi zadávat známku");
                                    Console.WriteLine("-----------------------------");
                                    Console.Write("Chci váhu:");
                                    string odpoved_vaha = Console.ReadLine();
                                    Console.Clear();
                                    if (odpoved_vaha == "E" || odpoved_vaha == "e")
                                    {
                                        zadavani = false;
                                        zadavani_predmet = false;
                                        zadavani_znamka = false;
                                        zadavani_vaha = false;
                                    }
                                    else
                                    {
                                        bool je_odpoved_vaha = int.TryParse(odpoved_vaha, out int ciselna_odpoved_vaha);
                                        if (je_odpoved_vaha)
                                        {
                                            if (ciselna_odpoved_vaha > 0 && ciselna_odpoved_vaha < 11)
                                            {
                                                nova_znamka.vaha = ciselna_odpoved_vaha;
                                                SQLight.Add_znamka(nova_znamka);
                                                zadavani = false;
                                                zadavani_predmet = false;
                                                zadavani_znamka = false;
                                                zadavani_vaha = false;
                                                Console.WriteLine("Znamka uložena.");
                                                Console.ReadLine();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.WriteLine("!!! Napiš existující váhu!!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("!!! Napiš odpověď správně !!!");
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
                else if(odpoved == "2")
                {
                    Console.WriteLine("Pokud chceš odejít ze zadávání stačí enterovat naprosto prázdnou odpoved a nic se neuloží.");
                    Console.Write(" napiš název předmětu:");
                    string predmet =  Console.ReadLine();
                    Console.Clear();
                    if (predmet == "")
                    {
                        Console.WriteLine("Nebylo nic zadáno. Vracím do menu");
                        Console.ReadLine();
                    }
                    else
                    {
                        Predmet novy_predmet = new Predmet() { Jmeno = predmet };
                        SQLight.Add_predmet(novy_predmet);
                        Console.WriteLine("Předmet byl uložen");
                        Console.ReadLine();
                    }
                }
                else if (odpoved == "3")
                {
                    bool zadavani_predmet = true;
                    while (zadavani_predmet)
                    {
                        Console.WriteLine("jaký předmět?");
                        foreach (Predmet predmet in SQLight.Get_predmety())
                        {
                            Console.WriteLine(predmet.ID + " - " + predmet.Jmeno);
                        }
                        Console.WriteLine("E - Nechi zjistit známky");
                        Console.WriteLine("-----------------------------");
                        Console.Write("Chci předmět číslem:");
                        string odpoved_predmet = Console.ReadLine();
                        Console.Clear();

                        if (odpoved_predmet == "E" || odpoved_predmet == "e")
                        {
                            zadavani_predmet = false;
                        }
                        else
                        {
                            bool je_predmet_odpoved = int.TryParse(odpoved_predmet, out int ciselna_predmet_odpoved);
                            if (je_predmet_odpoved)
                            {
                                if (ciselna_predmet_odpoved > 0 || ciselna_predmet_odpoved < SQLight.Get_predmety().Count() + 1)
                                {
                                    List<Znamka> znamky = SQLight.Get_znamky(SQLight.Get_predmety()[ciselna_predmet_odpoved - 1].Jmeno);
                                    Console.WriteLine("známka | váha");
                                    double soucet = 0;
                                    double pocet = 0;
                                    foreach (Znamka znamka in znamky)
                                    {
                                        Console.Write(znamka.známka + " | ");
                                        Console.WriteLine(znamka.vaha);
                                        soucet = soucet + (znamka.známka * znamka.vaha);
                                        pocet = pocet + znamka.vaha;
                                    }
                                    Console.WriteLine("-------------------------------------------------------");
                                    double prumer = soucet / pocet;
                                    Console.WriteLine("Průměr je: " + prumer.ToString(".0#"));

                                    Console.ReadLine();
                                    zadavani_predmet = false;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("!!! Napiš číslo předmětu správně !!!");
                                }

                            }
                            else
                            {
                                Console.WriteLine("!!! Napiš odpověď správně !!!");
                            }
                        }
                    }
                   
                }
                else
                {
                    Console.WriteLine("!!! Napiš  správnou odpověď!!!");
                }

            }
        }           
        
    }           
}
 

