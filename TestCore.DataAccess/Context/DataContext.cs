using Microsoft.EntityFrameworkCore;
using TestCore.DataAccess.Model;

namespace TestCore.DataAccess.Context
{
    public sealed class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<UserData> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=TestCore;Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}