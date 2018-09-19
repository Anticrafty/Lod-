using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oběšenec
{
    class Program
    {
        static void Main(string[] args)
        {
        // je vždy daný
            
            // hra jede
            bool hrajede = true;

            // slova
            List<string> slova = new List<string>()
            {
               "drak",
               "energetak",
               "rohy",
               "kridla",
               "kamarad",
               "pes",
               "vlk",
               "tlapka",
               "počítač",
               "klavesnice"
            };

            // obrázky oběšence
            List<string> obrazkyobesence = new List<string>()
            {
                "    _____  \n" +
                "   |/   |  \n" +
                "   |    0  \n" +
                "   |   /|\\ \n" +
                "   |   / \\ \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |/   |   \n" +
                "   |    0  \n" +
                "   |   /|\\ \n" +
                "   |   /   \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |/   |  \n" +
                "   |    0  \n" +
                "   |   /|\\ \n" +
                "   |       \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |/   |  \n" +
                "   |    0  \n" +
                "   |   /|  \n" +
                "   |        \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |/   |  \n" +
                "   |    0  \n" +
                "   |    |  \n" +
                "   |       \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |/   |  \n" +
                "   |    0  \n" +
                "   |       \n" +
                "   |       \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |/      \n" +
                "   |       \n" +
                "   |       \n" +
                "   |       \n" +
                " /---\\     ",
                "    _____  \n" +
                "   |       \n" +
                "   |       \n" +
                "   |       \n" +
                "   |       \n" +
                " /---\\     ",
                "           \n" +
                "   |       \n" +
                "   |       \n" +
                "   |       \n" +
                "   |       \n" +
                " /---\\     ",
                "           \n" +
                "           \n" +
                "           \n" +
                "           \n" +
                "           \n" +
                " /---\\     ",
                "           \n" +
                "           \n" +
                "           \n" +
                "           \n" +
                "           \n" +
                "            ",
            };

            //počet životů 
            int zivoty = 10;

        // připrava hry

            // nahodny cislo pro slovo
            Random nahodne = new Random();
            int nahodnecislo = nahodne.Next(0, slova.Count);

            // vybrání slova
            string slovo = slova[nahodnecislo];
            //Console.WriteLine(slovo);

            // vypočitat počet písmen
            int pocetpismen = slovo.Length;
            //Console.WriteLine(pocetpismen);

            // písmena ve slovu
            var rozdelenyslovo = slovo.ToCharArray();
            Console.Write(" ");
            /* foreach (char pismeno in rozdelenyslovo)
             {
                 Console.Write(pismeno);
                 Console.Write(" ");
             }
             Console.WriteLine(" ");*/

            // Průběh hry
            while (hrajede) {
              // vypsání
                // vypsání životů
                Console.WriteLine("  Životy:{0}", zivoty);
                Console.WriteLine("");
                // vypsání míst pro písmena
                List<string> pole = new List<string>();
                for (int MistoProPismeno = 0; MistoProPismeno < pocetpismen; MistoProPismeno++)
                {
                    pole.Add("_");
                }
                Console.Write(" ");
                foreach (string MistoPismeno in pole) {
                    Console.Write(MistoPismeno);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                // vyzobrazení oběšence
                Console.WriteLine(obrazkyobesence[zivoty]);
                if (zivoty == 0) {
                    hrajede = false;
                } else
                {
                    zivoty--;
                }
           }
        }
    }
}
