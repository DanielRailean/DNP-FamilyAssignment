using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Family.db");
        }
    }
}