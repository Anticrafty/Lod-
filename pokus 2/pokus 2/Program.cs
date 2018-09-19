using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokus_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pole = new List<int>();
            pole.Add(10);
            //int plodina = pole[0];

            foreach(int plodina in pole)
            {
                Console.WriteLine(plodina);
            }

            for (int i = 0; i < pole.Count; i++)
            {
                Console.WriteLine(pole[i]);
            }
        }
    }
}
