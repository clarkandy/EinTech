using EinTech.Test.Core;
using Microsoft.EntityFrameworkCore;

namespace Eintech.Test.Infrastructure
{
    public class EinTechContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public EinTechContext(DbContextOptions<EinTechContext> contextOptions)
            : base(contextOptions)
        {

        }
    }
}
