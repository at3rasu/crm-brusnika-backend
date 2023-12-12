using CrmBrusnika.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Context
{
    public class TransactionsContext: DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
