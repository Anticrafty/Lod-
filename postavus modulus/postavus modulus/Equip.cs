using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    public class Equip
    {
        public string jmeno;
        public double hodnota = 0;
        public string obrazek = "   none";
        // později třeba nova classa Skill
        public Stats vylepsovany = new Stats();
        public string poznamky = null;
    }
}