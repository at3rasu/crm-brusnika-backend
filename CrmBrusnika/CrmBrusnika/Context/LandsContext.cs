using CrmBrusnika.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CrmBrusnika.Context
{
    public class LandsContext : DbContext
    {
        public LandsContext(DbContextOptions<LandsContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Land>()
                .HasOne(e => e.Entity)
                .WithOne(e => e.Land)
                .HasForeignKey<ObjectEntity>(e => e.LandId)
                .IsRequired();
        }

        public DbSet<Land> Lands { get; set; }
        public DbSet<ObjectEntity> Entities { get; set; }
        public DbSet<Transaction> transactions { get; set; }
    }
}
