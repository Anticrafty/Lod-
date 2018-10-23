using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace evidence_uzivatelu
{
    class Loginator
    {
        private List<User> Users = new List<User>();

        static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

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

        public void SaveUsers()
        {
            string jsonUsers = JsonConvert.SerializeObject(Users, settings);

            // ŠKOLNÍ
            File.WriteAllText(@"D:\novakja16\Github\evidence uzivatelu\Users.json", jsonUsers);

            // NORMAND
            //File.WriteAllText(@"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\evidence uzivatelu\Users.json", jsonUsers);

            // EMIL
            
        }
        public void LoadUsers()
        {
            try
            {
                // ŠKOLNÍ
                string UserFromFile = File.ReadAllText((@"D:\novakja16\Github\evidence uzivatelu\Users.json"));

                // NORMAND
                //string UserFromFile = File.ReadAllText((@"C:\Users\pirat\OneDrive\Plocha\random\škola\VAH\GibHub\evidence uzivatelu\Users.json"));

                // EMIL

                Users = JsonConvert.DeserializeObject<List<User>>(UserFromFile, settings);
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("Nebyl nalezen záznam. Načtu improvizované uživatele.");
                Console.ReadLine();


                Admin Anti = new Admin();
                Anti.Nickname = "Anti";
                Anti.Password = "FragonsAreBest";



                User Hanz = new User();
                Hanz.Nickname = "Hanz";
                Hanz.Password = "FragonsStinks";

                Redaktor Vlkodlacice = new Redaktor();
                Vlkodlacice.Nickname = "Vlkodlačice";
                Vlkodlacice.Password = "ILoveRex";
                Redaktor Rex = new Redaktor();
                Rex.Nickname = "Rex";
                Rex.Password = "ILoveMyWoof";

                this.AddNewUSer(Anti);
                this.AddNewUSer(Hanz);
                this.AddNewUSer(Vlkodlacice);
                this.AddNewUSer(Rex);
                Console.Clear();
               
            }
        }

    }
}
