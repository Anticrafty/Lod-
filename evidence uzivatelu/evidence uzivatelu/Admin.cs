using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_uzivatelu
{
    class Admin : Redaktor
    {
        private string MasterHeslo = "Brony/FurryMemes";
        public Admin()
        {
            Console.WriteLine("3. Profit");
        }
        public bool DeleteUSer(User userToDelete)
        {
            //action 
            return true;
        }

        public bool AdminLogIn(string name, string pass, string adminpass)
        {
            // specific for admin
            Console.WriteLine(adminpass);
            return false;
        }

    }
}
