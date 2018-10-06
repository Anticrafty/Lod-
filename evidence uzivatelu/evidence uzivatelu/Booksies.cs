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

        bool removebook(Book removedbook)
        {
            bool neninikdopodobny = true;
            int IDknihy = 0;
            int nicenaknihaID;
            foreach (Book book in Books)
            {
                if (removedbook.Name == book.Name && removedbook.ISBN == book.ISBN)
                {
                    neninikdopodobny = false;

                    nicenaknihaID = IDknihy;
                }
                IDknihy++;
            }
            if (neninikdopodobny)
            {
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
                return false;
            }

        }

    }
}
