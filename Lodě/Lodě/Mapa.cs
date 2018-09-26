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
            Console.WriteLine("  123456789X");
            Console.WriteLine(" -----------");
            foreach ( Policko policko in Obal)
            {
                if(policko.X == 1)
                {
                    Console.Write("{0}|", policko.Y);
                }
                if(policko.X == 9)
                {                   
                    if ( policko.Stav == 0 )
                    {
                        Console.WriteLine("~|");
                    } 
                    else if ( policko.Stav == 1)
                    {
                        Console.WriteLine("V|");
                    }
                    else if ( policko.Stav == 2)
                    {
                        Console.WriteLine("O|");
                    }
                    else if ( policko.Stav == 3)
                    {
                        Console.WriteLine("x|");
                    } 
                    else if ( policko.Stav == 4 )
                    {
                        Console.WriteLine("X|");
                    }
                        
                }
                else
                {
                    if (policko.Stav == 0 )
                    {
                        Console.Write("~");
                    }
                    else if ( policko.Stav == 1)
                    {
                        Console.Write("V");
                    }
                    else if (policko.Stav == 2)
                    {
                        Console.Write("O");
                    }
                    else if (policko.Stav == 3)
                    {
                        Console.Write("x");
                    }
                    else if (policko.Stav == 4)
                    {
                        Console.Write("X");
                    }
                }
            }
            Console.WriteLine("Y-----------");
        }
    }
}
