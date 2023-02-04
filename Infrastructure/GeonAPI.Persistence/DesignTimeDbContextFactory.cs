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
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(
                    maxRetryCount: 6,
                    maxRetryDelay: TimeSpan.FromSeconds(60),
                    errorNumbersToAdd: new[] { 4060 });
            });
            return new(dbContextOptionsBuilder.Options);
        }
    }
}