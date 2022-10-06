using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PickDrop.EntityFrameworkCore
{
    public static class PickDropDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PickDropDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PickDropDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
