using App.Data.Context.Interfaces;
using System.Data;
using Xunit;

namespace App.Data.Context.Test
{
    public class Connection_Test
    {
        private readonly ISqlServerContext _context;

        public Connection_Test(ISqlServerContext context)
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
