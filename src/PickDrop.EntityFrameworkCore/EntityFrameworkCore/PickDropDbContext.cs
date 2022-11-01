using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PickDrop.Authorization.Roles;
using PickDrop.Authorization.Users;
using PickDrop.Entities.Admin.Categories;
using PickDrop.Entities.Admin.SurchargeTimes;
using PickDrop.Entities.Admin.VehicleDetails;
using PickDrop.MultiTenancy;

namespace PickDrop.EntityFrameworkCore
{
    public class PickDropDbContext : AbpZeroDbContext<Tenant, Role, User, PickDropDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public PickDropDbContext(DbContextOptions<PickDropDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }
        public DbSet<SurchargeTime> SurchargeTimes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
               .HasMany(x => x.Subcategories)
                .WithOne()
                .HasForeignKey(g => g.ParentId);
        }

    }
}
