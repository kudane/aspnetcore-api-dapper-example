namespace App.Data.Entities.Shared
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[movie]")]
    public class Movie: Entity
    {
        public string Subject { get; set; }

        public string Summary { get; set; }

        public decimal? Ratting { get; set; }

        public string PreviewImgUrl { get; set; }

        public string CoverImgUrl { get; set; }
    }
}
