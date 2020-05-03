namespace App.Data.Repository.Entities
{
    using Dapper.Contrib.Extensions;

    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
