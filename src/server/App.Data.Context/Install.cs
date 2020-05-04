namespace App.Data.Context
{
    using App.Data.Context.Database;
    using App.Data.Context.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class Install
    {
        public static void AddConnectionString(this IServiceCollection services)
        {
            services.AddScoped<IConnectionString, ConnectionString>();
        }

        public static void AddSqlServerContext(this IServiceCollection services)
        {
            services.AddScoped<ISqlServerContext, SqlServerContext>();
        }
    }
}
