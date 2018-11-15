using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    public enum Statistika {Život, Mana, Energie, Síla, Odolnost, Výdrž, Inteligence, Moudrost, Charizma};
    public class Stats
    {
        public Statistika stat;
        public string jmeno;
        public int velikost;
        
        public Stats()
        {
            jmeno = stat.ToString();
        }
    }
}
