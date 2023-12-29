using CrmBrusnika.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Context
{
    public class LandsContext : DbContext
    {
        public LandsContext(DbContextOptions<LandsContext> options) : base(options)
        {

        }

        public DbSet<Land> Lands { get; set; }
        public DbSet<ObjectEntity> Entities { get; set; }
    }
}
