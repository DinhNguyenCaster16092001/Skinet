using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class SkinetDbContext : DbContext
    {
        public SkinetDbContext(DbContextOptions<SkinetDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
