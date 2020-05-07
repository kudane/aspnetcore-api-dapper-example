namespace Backend.Repository.Repositories
{
    using Backend.Context.Interfaces;
    using Backend.Repository.Interfaces;
    using Backend.Repository.Repositories.Base;
    using Dapper;
    using Domain.Entity;
    using Domain.Entity.Produces;
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
                  SELECT    COUNT(m.id) 
                  FROM      dbo.movie m
                  INNER     JOIN dbo.movie_genre mg on m.id = mg.movieid
                  WHERE     mg.genreid = @key;

                  SELECT    m.* 
                  FROM      dbo.movie m
                  INNER     JOIN dbo.movie_genre mg on m.id = mg.movieid
                  WHERE     mg.genreid = @key
                  ORDER BY  id
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
