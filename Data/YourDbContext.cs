using Microsoft.EntityFrameworkCore;
using Netapp.Models; // Reference to your Models namespace

namespace Netapp.Data // Adjust based on your project structure
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
