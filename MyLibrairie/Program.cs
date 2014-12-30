using MyLibrairie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie
{
    class Program
    {
        static void Main(string[] args)
        {
            var bdd = new BDD();
            bdd.albumList();
            Console.WriteLine("--------------------------------------------------------------------");
            bdd.bookList();

            Console.ReadLine();
        }
    }
}
