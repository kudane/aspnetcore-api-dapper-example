namespace App.Data.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[Movie]")]
    public class Movie: Entity
    {
        public string Subject { get; set; }

        public string Summary { get; set; }

        public decimal? Ratting { get; set; }

        public string PreviewImgUrl { get; set; }

        public string CoverImgUrl { get; set; }
    }
}
