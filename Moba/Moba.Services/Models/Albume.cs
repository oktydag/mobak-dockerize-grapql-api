using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moba.Services.Models
{
    public class Albume
    {
        public int Id { get; set; }
        public string AlbumeArtist { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        List<Song> Songs { get; set; }
    }
}
