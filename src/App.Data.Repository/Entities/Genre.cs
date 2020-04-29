namespace App.Data.Repository.Entities
{
    using Dapper.Contrib.Extensions;

    [Table("[dbo].[Genre]")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
