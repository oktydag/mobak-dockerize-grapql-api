using Moba.Services.Models;
using Moba.Services.Repositories.Constrains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moba.Services.Repositories
{
    public class SongRepository : ISongRepository
    {
        private List<Song> _Songs;

        public SongRepository()
        {
            _Songs = new List<Song>{
                new Song()
                {
                    Id = 1,
                    AlbumeId = 1,
                    Name = "S&M",
                    Description = "Cause I may be bad, but I'm perfectly good at it",
                },
                new Song()
                {
                    Id = 2,
                    AlbumeId = 1,
                    Name = "What's My Name?",
                    Description = "Hey boy, I really wanna see if you",
                },
                new Song()
                {
                    Id = 3,
                    AlbumeId = 1,
                    Name = "Only Girl (In the World)",
                    Description = "Want you to make me feel",
                },
                new Song()
                {
                    Id = 4,
                    AlbumeId = 2,
                    Name = "What's My Name?",
                    Description = "Hey boy, I really wanna see if you",
                },
                new Song()
                {
                    Id = 5,
                    AlbumeId = 2,
                    Name = "Work",
                    Description = "Work, work, work, work, work, work",
                },
                new Song()
                {
                    Id = 5,
                    AlbumeId = 2,
                    Name = "Kiss It Better",
                    Description = "What are you willing to do",
                },
            };
        }

        public Task<Song> GetSongAsync(int id)
        {
            return Task.FromResult(_Songs.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Song>> GetSongsAsync()
        {
            return Task.FromResult(_Songs);
        }

        public Task<List<Song>> GetSongsWithByAlbumeIdAsync(int AlbumeId)
        {
            return Task.FromResult(_Songs.Where(x => x.AlbumeId == AlbumeId).ToList());
        }
    }
}
