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

        bool RemoveBook(string removedName,int removedISBN)
        {
            bool neninikdopodobny = true;
            int IDknihy = 0;
            int nicenaknihaID;
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
                Books.Remove(Books[IDknihy]);
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
