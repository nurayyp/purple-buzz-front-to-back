using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<TeamMember> teamMembers { get; set; }
        public DbSet<WorkOption> workOptions { get; set; }
        public DbSet<OurGoal> ourGoals { get; set; }
        public DbSet<ContactPurpose> contactPurposes { get; set; }
        public DbSet<PricingOption> pricingOptions { get; set; }
    }
}
