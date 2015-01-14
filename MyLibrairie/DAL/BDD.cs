using MyLibrairie.Models;
using MyLibrairie.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie.DAL
{
    public class BDD
    {
        const string ConnectionString = @"Data source=(localdb)\v11.0;Initial Catalog=library;Integrated Security=True";

        public static void addAlbum(CD cd)
        {
            string insertString = @"INSERT INTO album (title, artist, id_genre, available) values ('" + cd.Title + "','" + cd.Artist + "','" + cd.Genre + "','" + cd.Available + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand insert = new SqlCommand(insertString, connection);
            int addAlbum = insert.ExecuteNonQuery();
            Console.WriteLine(addAlbum);

            connection.Close();
        }

        public static void addBook(Book book)
        {
            string insertString = @"INSERT INTO book (title, autor, id_genre, isbn, available) values ('" + book.Title + "','" + book.Autor + "','" + book.Genre + "','" + book.Isbn + "','" + book.Available + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand insert = new SqlCommand(insertString, connection);
            int addBook = insert.ExecuteNonQuery();
            Console.WriteLine(addBook);

            connection.Close();
        }
         
        public static void addMusic(string title, int id_album)
        {
            string insertString = @"INSERT INTO music (id_album, title) values ('" + id_album + "','" + title + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand insert = new SqlCommand(insertString, connection);
            int addMusic = insert.ExecuteNonQuery();
            Console.WriteLine(addMusic);

            connection.Close();
        }

        public static int getAlbum(string albumTitle)
        {
            int id = 0;
            string selectString = @"SELECT id FROM album WHERE title LIKE " + albumTitle;
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                id = (int)rdr["id"];
            }
            rdr.Close();

            connection.Close();

            return id;
        }

        public static void albumList()
        {
            string selectString = @"SELECT a.title, a.artist, a.available, m.description FROM album a, musicGenre m WHERE a.id_genre = m.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();

            // Appel de la vue pour un album
            var view = new AlbumView();
            view.showAllAlbum(rdr);

            connection.Close();
        }

        public static void bookList()
        {
            string selectString = @"SELECT b.title, b.autor, b.available, bG.description FROM book b, bookGenre bG WHERE b.id_genre = bG.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();
            
            // Appel de la vue pour un livre
            var view = new BookView();
            view.showAllBook(rdr);

            connection.Close();
        }

        public static void FindAlbum(string title)
        {
            string selectString = @"SELECT a.title t, m.title FROM music m, album a WHERE a.title LIKE '%" + title + "%' AND m.id_album = a.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();

            // Appel de la vue pour les details d'un album
            var view = new AlbumView();
            view.showOneAlbum(rdr);

            connection.Close();
        }

        public static void FindBook(string title)
        {
            string selectString = @"SELECT b.title, b.autor, b.isbn, b.available, bG.description FROM book b, bookGenre bG WHERE b.title LIKE '%" + title + "%' AND b.id_genre = bG.id";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(selectString, connection);
            var rdr = cmd.ExecuteReader();

            // Appel de la vue pour les details d'un album
            var view = new BookView();
            view.showOneBook(rdr);

            connection.Close();
        }
    }
}
