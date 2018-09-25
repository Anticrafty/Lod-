using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lodě
{
    class Lod
    {
        public List<Policko> Kostra = new List<Policko>();
        public int Druh;
        
        public static List<Policko> Vypocitejlod(int odpoved, List<int> pozice)
        {
            int konecX = 0;
            int konecY = 0;
            List<int> xs = new List<int>();
            List<int> ys = new List<int>();
            List<Policko> buck = new List<Policko>();
            int odpovedi = odpoved - 1;
            int x = pozice[0];
            int y = pozice[1];
            int rotace = pozice[2];
            if (rotace == 1)
            {
                 konecY = y - odpovedi;
                 konecX = x;
            }
            else if (rotace == 2)
            {
                 konecX = x + odpovedi;
                 konecY = y;
            }
            else if (rotace == 3)
            {
                 konecY = y + odpovedi;
                 konecX = x;
            }
            else
            {
                 konecX = x - odpovedi;
                 konecY = y;
            }
            if ( konecY > 0 && konecY < 10 && konecX > 0 && konecX < 10)
            {
                // pokud je začatek větší než konec musí to začít koncem a končit začátkem
                    //x
                int konecXs = 0;
                int zacatekX = 0;
                if (x > konecX)
                {
                    zacatekX = konecX;
                    konecXs = x;
                } else
                {
                    zacatekX = x;
                    konecXs = konecX;
                }
                    //y
                int konecYs = 0;
                int zacatekY = 0;
                if (y > konecX)
                {
                    zacatekY = konecY;
                    konecYs = y;
                }
                else
                {
                    zacatekY = y;
                    konecYs = konecY;
                }
                for (;zacatekY < konecYs + 1;zacatekY++)
                {
                    for (; zacatekX < konecXs + 1; zacatekX++)
                    {
                        buck.Add(new Policko
                        {
                            X = zacatekY,
                            Y = zacatekX,
                            Stav = 1
                        });
                    }
                }
            }
            else
            {
                buck.Add(new Policko
                {
                    X = 0,
                    Y = 0,
                    Stav = 0
                });
            }

            return buck;
        }
    }
}
