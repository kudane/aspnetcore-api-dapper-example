namespace App.Data.Repository.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[Movie]")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Summary { get; set; }

        public decimal? Ratting { get; set; }

        public string PreviewImgUrl { get; set; }

        public string CoverImgUrl { get; set; }
    }
}
