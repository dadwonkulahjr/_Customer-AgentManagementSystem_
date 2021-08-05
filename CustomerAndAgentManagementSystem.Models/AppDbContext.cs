using Microsoft.EntityFrameworkCore;


namespace CustomerAndAgentManagementSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agent> Agents { get; set; }
    }
}
