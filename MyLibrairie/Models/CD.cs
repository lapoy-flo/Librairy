using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrairie.DAL;

namespace MyLibrairie.Models
{
    public class CD : Media
    {
        public String Artist { get; set; }
        public CD(String title, String artist, int genre, byte available) : base(title, available, genre)
        {
            Artist = artist;
        }

        public void Add()
        {
            BDD.addAlbum(this);
        }

        public void AddMusic(string titleMusic, string titleAlbum)
        {
            int id = BDD.getAlbum(titleAlbum);
            BDD.addMusic(titleMusic, id);
        }

        public void List()
        {
            BDD.albumList();
        }

        public void Command()
        {
            // TODO voir pour l'évènement
        }
    }
}
