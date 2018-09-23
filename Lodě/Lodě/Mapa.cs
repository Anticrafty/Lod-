using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lodě
{
    class Mapa
    {
        public List<Policko> Obal = new List<Policko>();

        public void VypisMapu()
        {
            foreach ( Policko policko in Obal)
            {
                if(policko.X == 9)
                {
                    Console.WriteLine("~");
                }
                else
                {
                    Console.Write("~");
                }
                
            }
        }
    }
}
