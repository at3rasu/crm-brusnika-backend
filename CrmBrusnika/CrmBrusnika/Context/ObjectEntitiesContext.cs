using CrmBrusnika.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Context
{
    public class ObjectEntitiesContext : DbContext
    {
        public ObjectEntitiesContext(DbContextOptions<ObjectEntitiesContext> options) : base(options)
        {

        }

        public DbSet<ObjectEntity> ObjectEntities { get; set; }
    }
}
