namespace App.Data.Context.Database
{
    using App.Data.Context.Interfaces;

    internal class ConnectionString : IConnectionString
    {
        public string GetConnection() => Configuration.ConnectionSrting;
    }
}
