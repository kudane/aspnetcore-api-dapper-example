using App.Data.Context.Interfaces;
using System.Data;
using Xunit;

namespace App.Test.SqlServerContext
{
    public class SqlServerContextTest
    {
        private readonly ISqlServerContext _context;

        public SqlServerContextTest(ISqlServerContext context)
        {
            _context = context;
        }

        [Fact]
        public void Context_Should_Connect_Server()
        {
            // Arrange
            var state = _context.Connection.State;

            // Act
            Assert.Equal(ConnectionState.Open, state);
        }
    }
}
