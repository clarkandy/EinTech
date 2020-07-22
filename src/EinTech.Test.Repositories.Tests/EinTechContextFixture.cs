using Eintech.Test.Infrastructure;
using EinTech.Test.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;

namespace EinTech.Test.Repositories.Tests
{
    public class EinTechContextFixture
    {
        private readonly DbConnection _connection;

        public EinTechContext Context { get; private set; }

        public EinTechContextFixture()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            DbContextOptions<EinTechContext> contextOptions = new DbContextOptionsBuilder<EinTechContext>().UseSqlite(_connection).Options;

            _connection = RelationalOptionsExtension.Extract(contextOptions).Connection;
            Context = new EinTechContext(contextOptions);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
            Seed();
        }

        public virtual void Dispose()
        {
            Context.Database.EnsureDeleted();
            _connection.Dispose();
        }

        private void Seed()
        {
            Context.People.AddRange(new Person(), new Person(), new Person());
            Context.SaveChanges();
        }
    }
}