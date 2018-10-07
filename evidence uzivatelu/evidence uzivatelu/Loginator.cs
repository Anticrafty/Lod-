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
            bool neninikdopodobny = true;
            foreach (User user in Users)
            {
                if (newuser.Nickname == user.Nickname)
                {
                    neninikdopodobny = false;
                }
            }
            if (neninikdopodobny)
            {
                Users.Add(newuser);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveUser(string removedNick, string adminspass, string wrotenpass)
        {
            bool neninikdopodobny = true;
            int IDknihy = 0;
            int nicenaknihaID;
            foreach (User book in Users)
            {
                if (removedNick == book.Nickname && adminspass == wrotenpass)
                {
                    neninikdopodobny = false;

                    nicenaknihaID = IDknihy;
                }
                IDknihy++;
            }
            if (neninikdopodobny)
            {
                Console.WriteLine("Tento uživatel v listu neni. Nebo jsi napsal špatné admin heslo. ");
                return false;
            }
            else
            {
                Users.Remove(Users[IDknihy]);
                return true;

            }
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
