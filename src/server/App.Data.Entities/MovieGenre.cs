namespace App.Data.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[movie_genre]")]
    public class MovieGenre
    {
        [ExplicitKey]
        public int MovieId { get; set; }

        [ExplicitKey]
        public int GenreId { get; set; }
    }
}
