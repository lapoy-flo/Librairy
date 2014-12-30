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

            // Appel de la vue pour un album
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
            
            // Appel de la vue pour un livre
            var view = new BookView();
            view.showAllBook(rdr);

            connection.Close();
        }

        public void FindOneAlbum(int id_album)
        {
            string selectString = @"SELECT a.titre t, m.titre FROM music m, album a WHERE m.id_album = " + id_album + " AND m.id_album = a.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();

            // Appel de la vue pour les details d'un album
            var view = new AlbumView();
            view.showOneAlbum(rdr);

            connection.Close();
        }
    }
}
