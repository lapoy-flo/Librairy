using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie
{
    class BDD
    {
        const string ConnectionString = @"Data source=(localdb)\v11.0;Initial Catalog=library;Integrated Security=True";
        public void addAlbum(string titre, string artist, int genre)
        {
            string insertString = @"INSERT INTO album (titre, artist, id_genre) values ('" + titre + "','" + artist + "','" + genre + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand insert = new SqlCommand(insertString, connection);
            int addAlbum = insert.ExecuteNonQuery();
            Console.WriteLine(addAlbum);
            Console.ReadLine();
            connection.Close();
        }

        public void addBook(string titre, string autor, int genre, string isbn)
        {
            string insertString = @"INSERT INTO book (titre, autor, id_genre, isbn) values ('" + titre + "','" + autor + "','" + genre + "','" + isbn + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand insert = new SqlCommand(insertString, connection);
            int addBook = insert.ExecuteNonQuery();
            Console.WriteLine(addBook);
            Console.ReadLine();
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
            Console.ReadLine();
            connection.Close();
        }

        public void albumList()
        {
            string selectString = @"SELECT * FROM album";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                // Appeler la vue pour un album

            }
            Console.ReadLine();
            connection.Close();
        }

        private void musicList(int id_album, SqlConnection connection)
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
