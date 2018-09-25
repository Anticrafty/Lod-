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

            ^ = y
            > = x
             */

            // políčko bude základní třída

            // mapa bude jen List políček
            // lodě budou ovlivňovat políčka

            // vytvopř nejdříve mapu
            // Program

            // mapa
            List<Policko> polickos = new List<Policko>();
            for (int x = 1; x < 10; x++)
            {
                for (int y = 1; y < 10; y++)
                {
                    polickos.Add(new Policko()
                    {
                        X = x,
                        Y = y
                    });
                }
            }
            Mapa mapa = new Mapa();
            mapa.Policka = polickos;
            mapa.VypisMapu();

        }
    }
}
