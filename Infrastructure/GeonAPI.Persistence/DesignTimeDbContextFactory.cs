using GeonAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeonAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GeonAPIDbContext>
    {
        public GeonAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<GeonAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}