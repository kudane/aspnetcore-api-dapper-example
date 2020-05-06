namespace Backend.Context.Database
{
    using Backend.Context.Interfaces;

    internal class ConnectionString : IConnectionString
    {
        public string GetConnection() => Configuration.ConnectionSrting;
    }
}
