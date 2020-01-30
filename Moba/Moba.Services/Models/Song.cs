using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moba.Services.Models
{
    public class Song
    {
        public int Id { get; set; }
        public int AlbumeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        Albume Albume { get; set; }
    }
}
