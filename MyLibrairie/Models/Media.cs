using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrairie.Models
{
    public class Media
    {
        public String Title { get; set; }
        public byte Available { get; set; }
        public int Genre { get; set; }

        public Media(String title, byte available, int genre)
        {
            Title = title;
            Available = available;
            Genre = genre;
        }
    }
}
