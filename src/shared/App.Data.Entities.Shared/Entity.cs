namespace App.Data.Entities.Shared
{
    using Dapper.Contrib.Extensions;

    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
