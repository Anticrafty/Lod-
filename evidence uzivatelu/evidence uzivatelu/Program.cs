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

        static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        // prihlasený uživatl pro všechny funkce
        static User prihlaseny;

        // list všech uživatelů
        static Loginator prologin = new Loginator();

        // list všech knížek
        static Booksies books = new Booksies();

        // list všech aut
        static Carsies cars = new Carsies();

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
                if (prihlaseny is Redaktor)
                {
                    Console.WriteLine(" 4 - zapsat novou knihu");
                }
                if (prihlaseny is Redaktor)
                {
                    Console.WriteLine(" 5 - vymazat knihu");
                }
                if (prihlaseny is Admin)
                {
                    Console.WriteLine(" 6 - vytvořit nového uživatele");
                }
                if (prihlaseny is Admin)
                {
                    Console.WriteLine(" 7 - vymazat uživatele");
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
                    if (odpoved == 4 && prihlaseny is Redaktor)
                    {
                        int odpoved2 = 1;
                        Console.Write("Značku Auta: ");
                        string znackaauta = Console.ReadLine();
                        Console.Write("SPZ Auta: ");
                        string SPZAuta = Console.ReadLine();
                        Console.Write("Cena Auta: ");
                        string cena = Console.ReadLine();
                        bool ISBNP = int.TryParse(cena, out int cenaAuta);
                        if (!ISBNP)
                        {
                            odpoved2 = 0;
                        }
                        Console.Write("Najeté KM Auta: ");
                        string KM = Console.ReadLine();
                        bool ISKM = int.TryParse(KM, out int KMAuta);
                        if (!ISKM)
                        {
                            odpoved2 = 0;
                        }
                        if (odpoved2 == 1)
                        {                            
                            Car newcar = new Car()
                            {
                                Znacka = znackaauta,
                                SPZ = SPZAuta,
                                Cena = cenaAuta,
                                NajeteKM = KMAuta
                            };
                            cars.AddCar(newcar);                        
                        }
                    }
                    if (odpoved == 5 && prihlaseny is Redaktor)
                    {
                        Console.Write("SPZ Auta: ");
                        string SPZAuta = Console.ReadLine();
                        cars.RemoveCar(SPZAuta);                        
                    }
                    if (odpoved == 6 && prihlaseny is Admin aminovicz)
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
                    if (odpoved == 7 && prihlaseny is Admin aminoviczcz)
                    {
                        Console.Write("Jmeno uživatele: ");
                        string removedNick = Console.ReadLine();
                        Console.Write("Admins Password: ");
                        string adminspass = Console.ReadLine();
                        prologin.RemoveUser(removedNick, adminspass, aminoviczcz.GetMasterHeslo());
                    }
                }
                prologin.SaveUsers();
                books.SaveBooks();
            }
        }

        // přihlašovací funkce
        static bool Prihlasovani()
        {
            prologin.LoadUsers();
            books.LoadBooks();
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
           
        }

    }
}
