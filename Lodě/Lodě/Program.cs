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
               123456789
             ------------
             A|~~~~~~~~~|
             B|~~~~~~~~~|
             C|~~~~~~~~~|
             D|~~~~~~~~~|
             E|~~~~~~~~~|
             F|~~~~~~~~~|
             G|~~~~~~~~~|
             H|~~~~~~~~~|
             I|~~~~~~~~~|
             ------------
             */

            // políčko bude základní třída
            // mapa bude jen List políček
            // lodě budou ovlivňovat políčka
           
        // Program

            // mapa
                // od zhora dolů
            List<List<int>> mapa = new List<List<int>>();
                // od leva do prava
            for (int pismeno = 0; pismeno < 9; pismeno++ )
            {
                mapa.Add(new List<int>());
                for (int cislo = 0; cislo < 9; cislo++)
                {
                    mapa[pismeno].Add(0);
                }
            }

            foreach (List<int> pismeno in mapa)
            {
                int kolikaty = 0;
                foreach (int cislo in pismeno)
                {
                    kolikaty++;
                    if (kolikaty == 9)
                    {
                        Console.WriteLine("~");
                    } else
                    {
                        Console.Write("~");
                    }
                }

                // 
            }
        }
    }
}
