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

        public void VytvorLod()
        {
            bool trythat = false;
            while (!trythat)
            {
                string odpoved = Console.ReadLine();

                trythat = int.TryParse(odpoved, out int bezpecnaodpoved);
            }
            
        }
    }
}
