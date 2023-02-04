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
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate,
                    EntityState.Modified => data.Entity.UpdatedDate,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", builder =>
            {
                builder.IsTemporal();
            }).HasQueryFilter(p => p.Visible && !p.Deleted);
            modelBuilder.Entity<Page>().ToTable("Pages", builder =>
            {
                builder.IsTemporal();
            }).HasQueryFilter(p => p.Visible && !p.Deleted);
            modelBuilder.Entity<Category>().ToTable("Categories", builder =>
            {
                builder.IsTemporal();
            }).HasQueryFilter(c => c.Visible && !c.Deleted);
            modelBuilder.Entity<Translate>().ToTable("Translates", builder =>
            {
                builder.IsTemporal();
            }); 
            modelBuilder.Entity<Language>().HasData(
                new Language() { Code = "tr-tr", Name = "Türkçe", Visible = true });
            modelBuilder.Entity<PageTranslateEntity>().HasIndex(pt => pt.Slug).IsUnique();
        }

    }
}