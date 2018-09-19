using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kočka_a_myš
{
    class Mouse
    {
        Random rnd = new Random();

        public bool Alive = true;
        public int Agility = 10;

        public int CalculateChance()
        {
            int random = rnd.Next(1, 21);
            int bonus = -10 + random;
            int chance = Agility + bonus;
            return chance;
        }
    }

}
