namespace App.Data.Repository.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[Genre]")]
    public class Genre: Entity
    {
        public string Description { get; set; }
    }
}
