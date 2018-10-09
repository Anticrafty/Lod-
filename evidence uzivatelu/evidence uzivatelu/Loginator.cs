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

        public void AddNewUSer(User newuser)
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
                Console.WriteLine("Uživatel byl přidán");
                Users.Add(newuser);
            }
            else
            {
                Console.WriteLine("Uživatel již existuje");
            }
                

        }

        public void RemoveUser(string removedNick, string adminspass, string wrotenpass)
        {
            bool neninikdopodobny = true;
            int IDknihy = 0;
            int nicenaknihaID = 0;
            foreach (User book in Users)
            {
                if (removedNick == book.Nickname && adminspass == wrotenpass)
                {
                    neninikdopodobny = false;

                    nicenaknihaID = IDknihy;
                }
                IDknihy++;
            }
            if (neninikdopodobny || Users[nicenaknihaID] is Admin)
            {
                Console.WriteLine("Tento uživatel v listu neni, nebo jsi napsal špatné admin heslo, nebo jsi se pokusil vymazat Admina. ");
            }
            else
            {                
                Users.Remove(Users[nicenaknihaID]);
                Console.WriteLine("Uživatel je vymazán");
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
