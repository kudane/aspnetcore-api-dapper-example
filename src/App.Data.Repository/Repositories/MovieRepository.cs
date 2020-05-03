namespace App.Data.Repository.Repositories
{
    using App.Data.Context.Interfaces;
    using App.Data.Repository.Entities;
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Repositories.Base;
    using App.Data.Repository.Utilities;
    using Dapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ISqlServerContext context) : base(context.Connection)
        { 
        }

        public async Task<IEnumerable<Movie>> SelectByGenreKey(int key, Pager pager)
        {
            var parameters = new { key, pager.PageSize, pager.PageNumber };
            var sql = @"
                  SELECT    m.* from [dbo].[Movie] m
                  INNER     JOIN [dbo].[MovieGenre] mg on m.Id = mg.MovieId
                  WHERE     mg.GenreId = @key
                  ORDER BY  [Id]
                  OFFSET    @PageSize * (@PageNumber - 1) ROWS
                  FETCH     NEXT @PageSize ROWS ONLY";

            return await Connection.QueryAsync<Movie>(sql, parameters);
        }
    }
}
