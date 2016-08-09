using Microsoft.EntityFrameworkCore;
using TestCore.DataAccess.Model;

namespace TestCore.DataAccess.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<UserData> Users { get; set; }
    }
}