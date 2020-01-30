using Moba.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moba.Services.Repositories.Constrains
{
    public interface IAlbumeRepository
    {
        Task<List<Albume>> AlbumesAsync();
        Task<Albume> GetAlbumeAsync(int id);
    }
}
