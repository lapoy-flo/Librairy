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
        const string ConnectionString = @"Data source=(localdb)\v11.0;Initial Catalog=librairie;Integrated Security=True";
         public void addAlbum(string titre, string artist, int genre)
        {
            string insertString = @"INSERT INTO music (titre, artist, id_genre) values ('" + titre + "','" + artist + "','" + genre + "')";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand insert = new SqlCommand(insertString, connection);
            int addBook = insert.ExecuteNonQuery();
            Console.WriteLine(addBook);
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
    }
}
