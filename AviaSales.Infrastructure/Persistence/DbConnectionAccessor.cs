using System.Data;
using AviaSales.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AviaSales.Infrastructure.Persistence
{
    internal class DbConnectionAccessor : IDbConnectionAccessor, IDisposable
    {
        public IDbConnection Connection { get; }

        public DbConnectionAccessor(IConfiguration config)
        {
            Connection = new NpgsqlConnection(config.GetConnectionString("Postgres"));
        }

        public void Dispose()
            => Connection.Dispose();
    }
}
