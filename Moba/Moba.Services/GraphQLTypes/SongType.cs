using GraphQL.Types;
using Moba.Services.Models;
using Moba.Services.Repositories.Constrains;

namespace Moba.Services.GraphQLTypes
{
    public class SongType : ObjectGraphType<Song>
    {
        public SongType(IAlbumeRepository AlbumeRepository)
        {
            Field(x => x.Id).Description("Song id.");
            Field(x => x.Name).Description("Song name.");
            Field(x => x.Description, nullable: true).Description("Song description.");
            Field(x => x.AlbumeId).Description("Albume ID of song.");

            Field<AlbumeType>(
                "Albume",
                resolve: context => AlbumeRepository.GetAlbumeAsync(context.Source.AlbumeId).Result
             );
        }
    }
}
