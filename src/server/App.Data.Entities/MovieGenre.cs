namespace App.Data.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[MovieGenre]")]
    public class MovieGenre
    {
        [ExplicitKey]
        public int MovieId { get; set; }

        [ExplicitKey]
        public int GenreId { get; set; }
    }
}
