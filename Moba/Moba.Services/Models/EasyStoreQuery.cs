using GraphQL.Types;
using Moba.Services.GraphQLTypes;
using Moba.Services.Repositories.Constrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moba.Services.Models
{
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(IAlbumeRepository AlbumeRepository, ISongRepository SongRepository)
        {
            Field<AlbumeType>(
                "Albume",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Albume id" }
                ),
                resolve: context => AlbumeRepository.GetAlbumeAsync(context.GetArgument<int>("id")).Result
            );

            Field<SongType>(
                "Song",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Song id" }
                ),
                resolve: context => SongRepository.GetSongAsync(context.GetArgument<int>("id")).Result
            );
        }
    }
}
