using Moba.Services.Models;
using Moba.Services.Repositories.Constrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moba.Services.Repositories
{
    public class AlbumeRepository : IAlbumeRepository
    {
        private List<Albume> _Albumes;

        public AlbumeRepository()
        {
            _Albumes = new List<Albume>{
                new Albume()
                {
                    Id = 1,
                    Name = "Loud",
                    AlbumeArtist = "Rihanna",
                    Price = 100
                },
                new Albume()
                {
                    Id = 2,
                    Name = "Anti",
                    AlbumeArtist = "Rihanna",
                    Price = 200
                }
            };
        }

        public Task<List<Albume>> AlbumesAsync()
        {
            return Task.FromResult(_Albumes);
        }

        public Task<Albume> GetAlbumeAsync(int id)
        {
            return Task.FromResult(_Albumes.FirstOrDefault(x => x.Id == id));
        }
    }
}
