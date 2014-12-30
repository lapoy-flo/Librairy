using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie.Views
{
    class BookView
    {
        public void showAllBook(SqlDataReader rdr)
        {
            int i = 1;
            string available = "";
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Tous les livres")); // Centrer le texte
            Console.WriteLine();
            while (rdr.Read())
            {
                if ((int)(byte)rdr["available"] == 1) // Cast (int)(byte) car tinyint dans la base
                    available = "disponible";
                else
                    available = "emprunté";
                Console.WriteLine("{0}. {1} - {2} ({3})     {4}", i, rdr["titre"], rdr["artist"], rdr["description"], available);
                i++;
            }
            if (i == 1)
                Console.WriteLine("Aucun livre trouvé...");
            rdr.Close();
        }
    }
}
