using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_uzivatelu
{
    class Program
    {
        // Vytvořte program pro evidenci uživatelů
        // uživatel se může přihlásit

        // Administrátor může mazat a vytvářet uživatele 
        // - aministrátor se ověřuje proti master hestli
        //   -> zadané 
        void bool Prihlasovani()
        {
            bool prihlasovaciproces = true;
            while (prihlasovaciproces)
                Console.WriteLine(" 1 - se Přihlásit ");
                Console.WriteLine("  - Vypnout program");
                Console.Write(" Chci : ");
                String Chci = Console.ReadLine();

                bool jevnabidce = int.TryParse(Chci, out int odpoved);
                if (jevnabidce)
                {
                    if (odpoved == 1)
                    {
                        Admin.AdminLogIn("", "", "");
                    }
                    else if (odpoved == 2)
                    {
                        prihlasovaciproces = false;
                    }
                }
        }
        static void Main(string[] args)
        {
            // stavající uživatele
            List<User> users = new List<User>();

            Admin Anti = new Admin();
            Anti.Nickname = "Anti";
            Anti.Password = "FragonsAreBest";



            User Hanz = new User();
            Hanz.Nickname = "Hanz";
            Hanz.Password = "FragonsStinks";

            Redaktor Vlkodlacice = new Redaktor();
            Vlkodlacice.Nickname = "Hanz";
            Vlkodlacice.Password = "FragonsStinks";
            Redaktor Rex = new Redaktor();
            Rex.Nickname = "Hanz";
            Rex.Password = "FragonsStinks";

            users.Add(Anti);
            users.Add(Hanz);
            users.Add(Vlkodlacice);
            users.Add(Rex);
            // program
            bool jeprihlasen = true;
            while (jeprihlasen)
            {
                jeprihlasen = Prihlasovani();

            }
        }

    }
}
