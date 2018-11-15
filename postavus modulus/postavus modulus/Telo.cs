using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postavus_modulus
{
    public class Telo : Equip
    {
        public Telo()
        {

            if (jmeno == null)
            {
                jmeno = "Tělo";
            }
        }
    }
}
