using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using PickDrop.Authorization.Roles;
using PickDrop.Authorization.Users;
using PickDrop.MultiTenancy;
using PickDrop.Entities.Admin.Categories;

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

    }
}
