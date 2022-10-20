using System;
using GeonAPI.Domain.Entities;
using GeonAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeonAPI.Persistence.Contexts
{
    public class GeonAPIDbContext : DbContext
    {
        public GeonAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Multimedia> Multimedias { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added=> data.Entity.CreatedDate,
                    EntityState.Modified => data.Entity.UpdatedDate,
                    _=>DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}