using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie.Views
{
    class BDD
    {
        const string ConnectionString = @"Data source=(localdb)\v11.0;Initial Catalog=library;Integrated Security=True";
        public void addAlbum(string titre, string artist, int genre, byte available)
        {
            string insertString = @"INSERT INTO album (titre, artist, id_genre, available) values ('" + titre + "','" + artist + "','" + genre + "','" + available + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand insert = new SqlCommand(insertString, connection);
            int addAlbum = insert.ExecuteNonQuery();
            Console.WriteLine(addAlbum);

            connection.Close();
        }

        public void addBook(string titre, string autor, int genre, string isbn, byte available)
        {
            string insertString = @"INSERT INTO book (titre, autor, id_genre, isbn, available) values ('" + titre + "','" + autor + "','" + genre + "','" + isbn + "','" + available + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand insert = new SqlCommand(insertString, connection);
            int addBook = insert.ExecuteNonQuery();
            Console.WriteLine(addBook);

            connection.Close();
        }
         
        public void addMusic(string titre, int id_album)
        {
            string insertString = @"INSERT INTO music (titre, id_album) values ('" + titre + "','" + id_album + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand insert = new SqlCommand(insertString, connection);
            int addMusic = insert.ExecuteNonQuery();
            Console.WriteLine(addMusic);

            connection.Close();
        }

        public void albumList()
        {
            string selectString = @"SELECT a.titre, a.artist, a.available, m.description FROM album a, musicGenre m WHERE a.id_genre = m.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();
            
            var view = new AlbumView();
            view.showAllAlbum(rdr);

            connection.Close();
        }

        public void bookList()
        {
            string selectString = @"SELECT b.titre, b.autor, b.available, bG.description FROM book b, bookGenre bG WHERE b.id_genre = bG.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();

            int i = 1;
            string available = "";
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Tous les livres")); // Centrer le texte
            Console.WriteLine();
            while (rdr.Read())
            {
                // Appeler la vue pour un livre

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

            connection.Close();
        }

        private void FindOneAlbum(int id_album, SqlConnection connection)
        {
            // Pas sûr que ça fonctionne !
            // Voir avec connection.Open() dans la fonction albumList()
            string selectString = @"SELECT * FROM music WHERE id_album = " + id_album;
            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // Appeler la vue pour les musiques

            }
            Console.ReadLine();
        }
    }
}
