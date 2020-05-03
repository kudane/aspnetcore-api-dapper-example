namespace App.Data.Context.Database
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using App.Data.Context.Interfaces;

    internal class SqlServerContext : ISqlServerContext
    {
        private readonly IDbConnection _connection;

        public SqlServerContext(IConnectionString connectionString)
        {
            if (connectionString is null)
            {
                throw new NullReferenceException(connectionString.GetType().ToString());
            }

            if (String.IsNullOrEmpty(connectionString.GetConnection()))
            {
                throw new ArgumentNullException("Connection String");
            }

            _connection ??= (_connection = new SqlConnection(connectionString.GetConnection()));
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
