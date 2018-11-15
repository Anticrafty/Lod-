using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    class Boty
    {
        public string jmeno = "none";
        public int hodnota = 0;
        public string obrazek = "   none";
        // později třeba nova classa Skill
        public List<string> vylepsovany_staty = new List<string>();
        public List<int> velikost_vylepseni = new List<int>();
        public string poznamky = null;

        public void pridej_vylepseni(string stat, int velikost)
        {
            vylepsovany_staty.Add(stat);
            velikost_vylepseni.Add(velikost);
        }
    }
}
