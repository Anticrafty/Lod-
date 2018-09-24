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
                    if ( policko.Stav == 0 || policko.Stav == 1)
                    {
                        Console.WriteLine("~");
                    } 
                    else if ( policko.Stav == 2)
                    {
                        Console.WriteLine("O");
                    }
                    else if ( policko.Stav == 3)
                    {
                        Console.WriteLine("x");
                    } 
                    else if ( policko.Stav == 4 )
                    {
                        Console.WriteLine("X");
                    }
                        
                }
                else
                {
                    if (policko.Stav == 0 || policko.Stav == 1)
                    {
                        Console.Write("~");
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
        }
    }
}
