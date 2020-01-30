using Moba.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moba.Services.Repositories.Constrains
{
    public interface ISongRepository
    {
        Task<List<Song>> GetSongsAsync();
        Task<List<Song>> GetSongsWithByAlbumeIdAsync(int AlbumeId);
        Task<Song> GetSongAsync(int id);
    }
}
