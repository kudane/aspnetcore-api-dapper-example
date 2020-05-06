namespace Domain.Entities.Extensions
{
    public static class EntityExtension
    {
        public static bool IsNotNull(this Entity entity)
        {
            return entity != null;
        }

        public static bool IsNull(this Entity entity)
        {
            return entity is null;
        }
    }
}
