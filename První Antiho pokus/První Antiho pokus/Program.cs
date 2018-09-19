using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace První_Antiho_pokus
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Učení základů
            
            int cislo = 10;
            cislo++;

            bool TF = true;

            string text = "Anti was here";

            Console.Write(text);
            Console.WriteLine(text);
            Console.WriteLine(text)*/

            /*      První pokusy
            
            int cislo = 25;
            bool Kontrola = true;

            while (Kontrola) { 
                Console.WriteLine("Je číslo rovno 25?");
                Console.Write("číslo je ");
                Console.WriteLine(cislo);

                if (cislo == 25)
                {
                    Console.WriteLine("Číslo je zadané číslo 25");
                    cislo++;
                }
                else {
                    Console.WriteLine("Číslo už není 25");
                    Kontrola = false;
                }
            }*/


            /* Čtverec
             
            
            Console.WriteLine("*********");
            for (int anti = 0; anti < 3; anti++)
            {
                Console.WriteLine("*       *");
            }
            Console.WriteLine("*********");*/
            int zadavani = 0;
            int danahodnota = 0;
            while (zadavani == 0) { 
                string zadani = Console.ReadLine();

                // zk. 1
                /* 
                   try
                   {
                        int danahodnota= int.Parse(txt);
                        Console.Write("Vrchní strana jednoho čtverce má ");
                    } catch (Exception e) {
                        Console.Write("Nebylo zadano čislo ");
                    }
            
                 */
                // zk. 2 

                bool check = int.TryParse(zadani, out danahodnota);
                if (check)
                {
                    danahodnota++;
                    Console.Write("Vrchní strana jednoho čtverce má ");
                    Console.Write(danahodnota);
                    Console.WriteLine(" hvězdiček");
                    zadavani = 1;
                } else
                {
                    Console.WriteLine("Napiš číslo");
                }
                
            }

            // vypisováníčtverce
            for (int materna = 0; materna < danahodnota; materna++)
            {
                if (materna == 0 || materna == danahodnota - 1)
                {
                    for (int crafty = 0; crafty < danahodnota; crafty++)
                    {
                        if (crafty == danahodnota - 1)
                        {
                            Console.WriteLine("*");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                }
                else
                {
                    for (int anti = 0; anti < danahodnota; anti++)
                    {
                        if (anti == 0)
                        {
                            Console.Write("*");
                        }
                        else if (anti == danahodnota - 1)
                        {
                            Console.WriteLine("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
        }
    }
}
