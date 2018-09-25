using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lodě
{
    class Mapa
    {
        public List<Policko> Policka = new List<Policko>();
        public void VypisMapu()
        {
            // najdi v specifikacich políčku v "Listu<Policko> Policka"  policko s X = x a Y = y

            // Najít v 
            // mapě
            //políčko
            // !! které ma info X == x && Y == y !!
            for (int x = 1; x < 10; x++)
            {              
                for (int y = 1; y < 10; y++)
                {
                    foreach (Policko PoloIcko in Policka)
                    {
                        if (PoloIcko.X == x && PoloIcko.Y == y)
                        {
                            //Console.Write("{0}{1}", PoloIcko.X, PoloIcko.Y);
                            Console.Write("~");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
    
}
