using DAT250_REST.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAT250_REST.Data
{
    public class AppDBContext: IdentityDbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDBContext(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            Options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
        public required DbSet<Poll> Polls { get; set; }
        public required new DbSet<User> Users { get; set; }
        public required DbSet<Vote> Votes { get; set; }
        public required DbSet<VoteOption> VoteOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
