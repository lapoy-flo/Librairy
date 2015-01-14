using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie.Views
{
    public class IndexView
    {
        public static void menu()
        {
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Ma bibliothèque")); // Centrer le texte
            Console.WriteLine();
            Console.WriteLine("1. Voir toute ma bibliothèque");
            Console.WriteLine("2. Trouver un livre");
            Console.WriteLine("3. Trouver un album");
            Console.WriteLine("4. Ajouter un livre");
            Console.WriteLine("5. Ajouter un album");
            Console.WriteLine("6. Quitter");
            Console.WriteLine();
            Console.Write("Faites votre choix : ");
        }
    }
}
