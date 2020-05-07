namespace Domain.Entity
{
    using Dapper.Contrib.Extensions;

    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
