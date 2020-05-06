namespace Backend.Context.Interfaces
{
    using System;
    using System.Data;

    public interface ISqlServerContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
