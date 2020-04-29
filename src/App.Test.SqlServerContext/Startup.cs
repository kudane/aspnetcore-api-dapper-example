using App.Data.Context;
using App.Data.Context.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

[assembly: TestFramework("App.Test.SqlServerContext.Startup", "App.Test.SqlServerContext")]

namespace App.Test.SqlServerContext
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink) { }

        protected void ConfigureServices(IServiceCollection services)
        {
            // injection connection string
            services.AddScoped<IConnectionString, TestConnectionString>();
            services.AddSqlServerContext();
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
    }

    class TestConnectionString : IConnectionString
    {
        string _connectionSrting = "test connection";

        public string GetConnection()
        {
            return _connectionSrting;
        }
    }
}
