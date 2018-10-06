using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_uzivatelu
{
    class Loginator
    {
        private List<User> Users = new List<User>();

        public bool AddNewUSer(User newuser)
        {
            Users.Add(newuser);
            return true;
        }

        public User LogIn(string name, string password)
        {
            int idUzivatele = 0;
            foreach ( User user in Users)
            {
                if (user.Nickname == name && user.Password == password)
                {
                    return Users[idUzivatele];
                }
                idUzivatele++;
            }
            return null;
        }

    }
}
