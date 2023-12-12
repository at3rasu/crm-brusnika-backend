using CrmBrusnika.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Context
{
    public class UsersContext: DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
