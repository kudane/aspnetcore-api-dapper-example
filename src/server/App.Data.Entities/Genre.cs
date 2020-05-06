namespace App.Data.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[genre]")]
    public class Genre: Entity
    {
        public string Description { get; set; }
    }
}
