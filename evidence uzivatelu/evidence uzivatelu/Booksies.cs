using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace evidence_uzivatelu
{
    class Booksies
    {
        public List<Book> Books = new List<Book>();


        static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        public bool RemoveBook(string removedName,int removedISBN)
        {
            bool neninikdopodobny = true;
            int IDknihy = 0;
            int nicenaknihaID = 0;
            foreach (Book book in Books)
            {
                if (removedName == book.Name && removedISBN == book.ISBN)
                {
                    neninikdopodobny = false;

                    nicenaknihaID = IDknihy;
                }
                IDknihy++;
            }
            if (neninikdopodobny)
            {
                Console.WriteLine("Tato knížka v listu neni.");
                return false;
            }
            else
            {
                Books.Remove(Books[nicenaknihaID]);
                Console.WriteLine("knižka byla smazána");
                return true;
                
            }
        }

        public bool AddBook(Book newbook)
        {
            bool neninikdopodobny = true;
            foreach (Book book in Books)
            {
                if (newbook.Name == book.Name)
                {
                    neninikdopodobny = false;
                }
            }
            if (neninikdopodobny)
            {
                Books.Add(newbook);
                Console.WriteLine("knižka byla Vložena");
                return true;
            }
            else
            {
                Console.WriteLine("Tato knížka už v listu je.");
                return false;
            }

        }

        public void SaveBooks()
        {
            string jsonBooks = JsonConvert.SerializeObject(Books, settings);

            File.WriteAllText(@"D:\novakja16\Github\evidence uzivatelu\Books.json", jsonBooks);
        }
        public void LoadBooks()
        {
            try
            {
                string UserFromBooks = File.ReadAllText((@"D:\novakja16\Github\evidence uzivatelu\Books.json"));

                Books = JsonConvert.DeserializeObject<List<Book>>(UserFromBooks, settings);
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("Nebyl nalezen záznam. Načtu improvizované knížky.");
                Console.ReadLine();

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

                this.AddBook(DenDraka);
                this.AddBook(Lord);
                Console.Clear();
            }
        }
    }
}
