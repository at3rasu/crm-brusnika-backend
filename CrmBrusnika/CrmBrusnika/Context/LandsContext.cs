using CrmBrusnika.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Context
{
    public class LandContext : DbContext
    {
        public LandContext(DbContextOptions<LandContext> options) : base(options)
        {

        }

        public DbSet<Land> Lands { get; set; }
    }
}
