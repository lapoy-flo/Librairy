using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrairie.Views;

namespace MyLibrairie
{
    public class AlbumView
    {
        public void showAllAlbum(SqlDataReader rdr)
        {
            int i = 1;
            string available = "";
            Console.Clear();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Tous les albums")); // Centrer le texte
            Console.WriteLine();
            while (rdr.Read())
            {
                // Appeler la vue pour un album

                if ((int)(byte)rdr["available"] == 1) // Cast (int)(byte) car tinyint dans la base
                    available = "disponible";
                else
                    available = "emprunté";
                Console.WriteLine("{0}. {1} - {2} ({3})     {4}", i, rdr["titre"], rdr["artist"], rdr["description"], available);
                i++;
            }
            if (i == 1)
                Console.WriteLine("Aucun album trouvé...");
            rdr.Close();
        }

        public void showOneAlbum(SqlDataReader rdr)
        {
            Console.Clear();
            int i = 0;
            while (rdr.Read())
            {
                if (i < 1)
                {
                    Console.WriteLine("Titre de l'album : {0}", rdr["t"]);
                }
                i++;
                Console.WriteLine("     {0}. {1}", i, rdr["titre"]);
            }
            rdr.Close();
        }
    }
}
