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

        // list všech uživatelů
        static Loginator prologin = new Loginator();

        // list všech knížek
        static Booksies books = new Booksies();

        // menu funkce
        static void ukazmenu()
        {
            bool jedeprogram = true;
            while (jedeprogram)
            { 
                Console.WriteLine(" ");
                Console.WriteLine(" 1 - vyčíst všechny ");
                if(prihlaseny is Redaktor)
                {
                    Console.WriteLine(" 2 - zapsat novou knihu");
                }
                if (prihlaseny is Redaktor)
                {
                    Console.WriteLine(" 3 - vymazat knihu");
                }

                if (prihlaseny is Admin)
                {
                    Console.WriteLine(" 4 - vytvořit nového uživatele");
                }
                if (prihlaseny is Admin)
                {
                    Console.WriteLine(" 5 - vymazat uživatele");
                }
                Console.WriteLine(" 0 - odhlasit se");
                Console.Write(" Chci : ");
                String Chci = Console.ReadLine();
                Console.Clear();

                //kontrola čísla
                bool jevnabidce = int.TryParse(Chci, out int odpoved);
                if (jevnabidce)
                {
                    if (odpoved == 0)
                    {
                        jedeprogram = false;
                        prihlaseny = null;
                    }
                    if (odpoved == 1)
                    {
                        Console.WriteLine("Ještě je ve vývoji");
                    }
                    if (odpoved == 2 && prihlaseny is Redaktor)
                    {
                        Console.WriteLine(" 1 - Papírová kniha");
                        Console.WriteLine(" 2 - Ekniha");
                        Console.Write(" Chci : ");
                        String Chci2 = Console.ReadLine();
                        Console.Clear();

                        //kontrola čísla
                        bool jevnabidce2 = int.TryParse(Chci2, out int odpoved2);
                        if (jevnabidce2)
                        {
                            if (odpoved2 == 1 || odpoved2 == 2)
                            {
                                Console.Write("Jmeno knížky: ");
                                string jmenoknizky = Console.ReadLine();
                                Console.Write("ISBN knížky: ");
                                string ISBNknizky = Console.ReadLine();
                                bool ISBNP = int.TryParse(ISBNknizky, out int ISBNknizkyV);
                                if (!ISBNP)
                                {
                                    odpoved2 = 0;
                                }
                                Autor newautor = new Autor();
                                Console.Write("Jmeno Autora: ");
                                newautor.jmeno = Console.ReadLine();
                                Console.Write("Příjmení Autora: ");
                                newautor.primeni = Console.ReadLine();
                                if (odpoved2 == 1)
                                {                                    
                                    Console.Write("počet knih: ");
                                    string newStock = Console.ReadLine();
                                    bool isStock = int.TryParse(newStock, out int trueStock);                                    
                                    Console.Write("hmotnost knihy: ");
                                    string newWeight = Console.ReadLine();
                                    bool isWeight = int.TryParse(newWeight, out int trueWeight);
                                    if (isStock && isWeight)
                                    {
                                        PaperBook newbook = new PaperBook()
                                        {
                                            Name = jmenoknizky,
                                            ISBN = ISBNknizkyV,
                                            Autorknihy = newautor,
                                            Stock = trueStock,
                                            Weight = trueWeight

                                        };                                        
                                        books.AddBook(newbook);
                                    }
                                }
                                else if (odpoved2 == 2)
                                {
                                    Console.Write("URL knihy: ");
                                    string newURL = Console.ReadLine();
                                    Console.Write("MB knihy: ");
                                    string newSize = Console.ReadLine();
                                    bool isStock = int.TryParse(newSize, out int trueSize);
                                    EBook newbook = new EBook()
                                    {
                                        Name = jmenoknizky,
                                        ISBN = ISBNknizkyV,
                                        Autorknihy = newautor,
                                        URL = newURL,
                                        SizeMB = trueSize
                                    };
                                    books.AddBook(newbook);
                                    }
                                
                            }
                        }
                    }
                    if (odpoved == 3 && prihlaseny is Redaktor)
                    {

                        Console.Write("Jmeno knížky: ");
                        string removedName = Console.ReadLine();
                        Console.Write("ISBN knížky: ");
                        string ISBNknizky = Console.ReadLine();
                        bool ISBNP = int.TryParse(ISBNknizky, out int removedISBN);
                        if (ISBNP)
                        {
                            books.RemoveBook( removedName, removedISBN);
                        }
                    }
                    if (odpoved == 4 && prihlaseny is Admin aminovicz)
                    {
                        Console.WriteLine(" 1 - Uživatel");
                        Console.WriteLine(" 2 - Redaktor");
                        Console.Write(" Chci : ");
                        String Chci2 = Console.ReadLine();
                        Console.Clear();

                        //kontrola čísla
                        bool jevnabidce2 = int.TryParse(Chci2, out int odpoved2);
                        if (jevnabidce2)
                        {
                            if (odpoved2 == 1 || odpoved2 == 2)
                            {
                                Console.Write("Nickname noveho uživatele: ");
                                string newName = Console.ReadLine();
                                Console.Write("Password noveho uživatele: ");
                                string newpass = Console.ReadLine();
                                if (odpoved2 == 1)
                                {
                                    User newUser = new User()
                                    {
                                        Nickname = newName,
                                        Password = newpass
                                    };
                                    prologin.AddNewUSer(newUser);
                                }
                                else
                                {
                                    Console.Write("Admins Password: ");
                                    string prihlasovacipassAdmin = Console.ReadLine();
                                    if (prihlasovacipassAdmin == aminovicz.GetMasterHeslo())
                                    {
                                        Redaktor newUser = new Redaktor()
                                        {
                                            Nickname = newName,
                                            Password = newpass
                                        };
                                        prologin.AddNewUSer(newUser);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Špatný Admin Passwod");
                                    }
                                }
                            }
                        }       
                    }
                    if (odpoved == 5 && prihlaseny is Admin)
                    {
                        Console.WriteLine("Ještě je ve vývoji");
                        //prologin.RemoveUser(removedNick, adminspass, wrotenpass);
                    }
                }
            }
        }

        // přihlašovací funkce
        static bool Prihlasovani()
        {
            bool prihlasovaciproces = true;
            while (prihlasovaciproces)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" 1 - se Přihlásit ");
                Console.WriteLine(" 0 - Vypnout program");
                Console.Write(" Chci : ");
                String Chci = Console.ReadLine();
                Console.Clear();

                //kontrola čísla
                bool jevnabidce = int.TryParse(Chci, out int odpoved);
                if (jevnabidce)
                {
                    if (odpoved == 1)
                    {
                        // napíše jmeno a heslo
                        Console.Write("Nickname: ");
                        string prihlasovacinick = Console.ReadLine();
                        Console.Write("Password: ");
                        string prihlasovacipass = Console.ReadLine();
                        // funbkce v ktere se najde v listu iživatelů daný uživatel a jeho heslo a vloží se do této promněné, pokud spolu zadané a uložené souhlasí
                        User prihlasenyuzivatel = prologin.LogIn(prihlasovacinick, prihlasovacipass);
                        // pokud nesouhlasí tak se přesune program na začátek přihlašování
                        if (prihlasenyuzivatel != null)
                        {
                            // pokud je admin musí se přihlásit přez speciální heslo pro adminy
                            if (prihlasenyuzivatel is Admin notpleb)
                            {
                                Console.Write("Admins Password: ");
                                string prihlasovacipassAdmin = Console.ReadLine();
                                bool jedmin = notpleb.AdminLogIn(prihlasovacipassAdmin);
                                // pokud napíše správný, tak pokračuje dál k menu. Pokud ne tak se dostane zas na začátek přihlašování
                                if (jedmin)
                                {
                                    prihlaseny = prihlasenyuzivatel;
                                    return true;
                                }
                            } 
                            else
                            { 
                                prihlaseny = prihlasenyuzivatel;
                                return true;
                            }
                        }
                        Console.WriteLine("You wrote something wrong");

                    }
                    // podkud si zvolí vypnutí progamu, tak se vyšle naspátek false
                    else if (odpoved == 0)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            // stavající uživatele (Později se smaže)
            

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
            
            prologin.AddNewUSer(Anti);
            prologin.AddNewUSer(Hanz);
            prologin.AddNewUSer(Vlkodlacice);
            prologin.AddNewUSer(Rex);

            // ňáký knížky (Později se smaže)
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
            Lord.Name = "Warcraft: Lords of Chaos ";
            Lord.ISBN = 0671041525;
            Autor Christie = new Autor();
            Christie.jmeno = "Christe";
            Christie.primeni = "Eh?";
            Lord.Autorknihy = Richard;
            Lord.URL = "https://en.wikipedia.org/wiki/Warcraft:_Lord_of_the_Clans";
            Lord.SizeMB = 300;

            books.AddBook(DenDraka);
            books.AddBook(Lord);
            Console.Clear();

            // program
            bool jeprihlasen = true;
            while (jeprihlasen)
            {
                // přihlášení
                jeprihlasen = Prihlasovani();
                //pokud přihlašení vypíše true tak se spustí ukázka menu
                if (jeprihlasen)
                {
                    ukazmenu();
                }
            }
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };


          /*   string json = JsonConvert.SerializeObject(books, settings);

           File.WriteAllText(@"D:\novakja16\Github\evidence uzivatelu\jsonFile.json", json);

            string jsonFromFile = File.ReadAllText((@"D:\novakja16\Github\evidence uzivatelu\jsonFile.json"));

            List<Book> booksloaded = JsonConvert.DeserializeObject<List<Book>>(jsonFromFile, settings);

            if (booksloaded[0] is Book loadedbook)
            {
                Console.WriteLine(loadedbook);
            } */
        }

    }
}
