using Microsoft.EntityFrameworkCore;
using Triquetra.Domain.Data.Entities;

namespace Triquetra.Migrations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                item.Entity.AddedOn = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialUnit> MaterialUnits { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractMaterial> ContractMaterials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}