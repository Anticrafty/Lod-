using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_uzivatelu
{
    class Program
    {
        // prihlasený uživatl pro všechny funkce
        static User prihlaseny;

        static Loginator prologin = new Loginator();

        // Vytvořte program pro evidenci uživatelů
        // uživatel se může přihlásit

        // Administrátor může mazat a vytvářet uživatele 
        // - aministrátor se ověřuje proti master hestli
        //   -> zadané 
         static User Prihlasovani()
        {
            bool prihlasovaciproces = true;
            while (prihlasovaciproces)
            {
                Console.WriteLine(" 1 - se Přihlásit ");
                Console.WriteLine(" 2 - Vypnout program");
                Console.Write(" Chci : ");
                String Chci = Console.ReadLine();

                bool jevnabidce = int.TryParse(Chci, out int odpoved);
                if (jevnabidce)
                {
                    if (odpoved == 1)
                    {
                        Console.Write("Nickname: ");
                        string prihlasovacinick = Console.ReadLine();
                        Console.Write("Password: ");
                        string prihlasovacipass = Console.ReadLine();
                        User prihlasenyuzivatel = prologin.LogIn(prihlasovacinick, prihlasovacipass);
                        return prihlasenyuzivatel;

                    }
                    else if (odpoved == 2)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            // stavající uživatele
            

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

            List<User> users = new List<User>();
            
            prologin.AddNewUSer(Anti);
            prologin.AddNewUSer(Hanz);
            prologin.AddNewUSer(Vlkodlacice);
            prologin.AddNewUSer(Rex);


            Prihlasovani();









            // ňáký knížky
            PaperBook DenDraka = new PaperBook();
            DenDraka.Name = "Warcraft: Day of the Dragon";
            DenDraka.ISBN = 0671041525;
                Autor Richard = new Autor();
                Richard.jmeno = "Richard";
                Richard.primeni = "Knaak";
            DenDraka.Autorknihy = Richard;
            DenDraka.Stock = 2;
            DenDraka.Weight = 300;

            EBook Lord = new EBook();
            Lord.Name = "Warcraft: Day of the Dragon";
            Lord.ISBN = 0671041525;
            Autor Christie = new Autor();
            Christie.jmeno = "Richard";
            Christie.primeni = "Knaak";
            Lord.Autorknihy = Richard;
            Lord.URL = "https://en.wikipedia.org/wiki/Warcraft:_Lord_of_the_Clans";
            Lord.SizeMB = 300;

            List<Book> books = new List<Book>();
            books.Add(DenDraka);
            books.Add(Lord);

            // program
            /*bool jeprihlasen = true;
            while (jeprihlasen)
            {
                jeprihlasen = Prihlasovani();

            }*/
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };


            string json = JsonConvert.SerializeObject(books, settings);

            File.WriteAllText(@"D:\novakja16\Github\evidence uzivatelu\jsonFile.json", json);

            string jsonFromFile = File.ReadAllText((@"D:\novakja16\Github\evidence uzivatelu\jsonFile.json"));

            List<Book> booksloaded = JsonConvert.DeserializeObject<List<Book>>(jsonFromFile, settings);

            if (booksloaded[0] is Book loadedbook)
            {
                Console.WriteLine(loadedbook);
            }
        }

    }
}
