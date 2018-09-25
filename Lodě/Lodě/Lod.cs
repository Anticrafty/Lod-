using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lodě
{
    class Lod
    {
        public List<Policko> kostra = new List<Policko>();
        public int Druh;
        
        public static List<Policko> vypocitejlod(int odpoved, List<int> pozice)
        {
            int konec = 0;
            List<Policko> buck = new List<Policko>();
            int x = pozice[0];
            int y = pozice[1];
            int rotace = pozice[2];
            if (rotace == 1)
            {
                 konec = y - odpoved;
            }
            else if (rotace == 2)
            {
                 konec = x + odpoved;
            }
            else if (rotace == 3)
            {
                 konec = y + odpoved;
            }
            else
            {
                 konec = x - odpoved;
            }
            if ( konec > 0 && konec < 10)
            {

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
