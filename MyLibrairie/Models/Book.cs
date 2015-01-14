using MyLibrairie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie.Models
{
    public class Book : Media
    {
        public String Autor { get; set; }
        public String Isbn { get; set; }

        public Book(String title, String autor, int genre, String isbn, byte available) : base(title, available, genre)
        {
            Autor = autor;
            Isbn = isbn;
        }

        public void Add()
        {
            BDD.addBook(this);
        }

        public void List()
        {
            BDD.bookList();
        }

        public void Command()
        {
            // TODO voir pour l'évènement
        }
    }
}
