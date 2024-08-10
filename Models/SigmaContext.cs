using Microsoft.EntityFrameworkCore;
using SigmaApplication.Entities;

namespace SigmaApplication.Models
{
    public class SigmaContext : DbContext
    {
        public SigmaContext(DbContextOptions<SigmaContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}