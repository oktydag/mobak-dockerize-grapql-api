using GraphQL.Types;
using Moba.Services.Models;
using Moba.Services.Repositories.Constrains;
using System.Linq;

namespace Moba.Services.GraphQLTypes
{
    public class AlbumeType : ObjectGraphType<Albume>
    {
        public AlbumeType(ISongRepository SongRepository)
        {
            Field(x => x.Id).Description("Albume id.");
            Field(x => x.Name, nullable: true).Description("Albume name.");
            Field(x => x.Price).Description("Albume price.");
            Field(x => x.AlbumeArtist).Description("Albume Artist.");


            Field<ListGraphType<SongType>>(
                "Songs",
                resolve: context => SongRepository.GetSongsWithByAlbumeIdAsync(context.Source.Id).Result.ToList()
            );
        }
    }
}
