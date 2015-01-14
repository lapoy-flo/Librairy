using MyLibrairie.DAL;
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
            string answer;
            byte quit = 0;

            do
            {
                IndexView.menu();
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        BDD.albumList();
                        Console.WriteLine("---------------------------------------------------------------------");
                        BDD.bookList();
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        break;

                    case "6":
                        quit = 1;
                        break;

                    default:
                        BDD.albumList();
                        break;
                }
            } while (quit == 0);
            Console.WriteLine("Au revoir");
            Console.ReadLine();
        }
    }
}
