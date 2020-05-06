using Backend.Context;
using Backend.Context.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

[assembly: TestFramework("Backend.Context.Test.Startup", "Backend.Context.Test")]

namespace App.Data.Context.Test
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
