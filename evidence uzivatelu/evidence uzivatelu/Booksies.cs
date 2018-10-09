using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence_uzivatelu
{
    class Booksies
    {
        public List<Book> Books = new List<Book>();

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

    }
}
