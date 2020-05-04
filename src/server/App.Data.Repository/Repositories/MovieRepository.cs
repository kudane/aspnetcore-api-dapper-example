namespace App.Data.Repository.Repositories
{
    using App.Data.Context.Interfaces;
    using App.Data.Repository.Entities;
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Produces;
    using App.Data.Repository.Repositories.Base;
    using Dapper;
    using System;
    using System.Linq;

    internal class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private PageResult<Movie> _pageResult;

        public MovieRepository(ISqlServerContext context) : base(context.Connection)
        {
        }

        public ref PageResult<Movie> SelectByGenreKey(int key, int pageSize, int pageNumber)
        {
            var parameters = new { key, pageSize, pageNumber };

            var sql = @"
                  SELECT    COUNT(m.Id) 
                  FROM      [dbo].[Movie] m
                  INNER     JOIN [dbo].[MovieGenre] mg on m.Id = mg.MovieId
                  WHERE     mg.GenreId = @key;

                  SELECT    m.* 
                  FROM      [dbo].[Movie] m
                  INNER     JOIN [dbo].[MovieGenre] mg on m.Id = mg.MovieId
                  WHERE     mg.GenreId = @key
                  ORDER BY  [Id]
                  OFFSET    @pageSize * (@pageNumber - 1) ROWS
                  FETCH     NEXT @pageSize ROWS ONLY;";

            using (var multi = Connection.QueryMultiple(sql, parameters))
            {
                var totalItems = multi.Read<int>(buffered: false).First();
                var items = multi.Read<Movie>(buffered: false).AsList();

                _pageResult = new PageResult<Movie>
                {
                    CurrentPage = pageNumber,
                    TotalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize),
                    Items = items,
                    TotalItems = items.Count
                };
            }

            return ref _pageResult;
        }
    }
}
