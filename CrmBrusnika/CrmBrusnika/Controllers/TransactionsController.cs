using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [Route("api/transactions/")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly LandsContext _context;
        
        public TransactionsController(LandsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            var newTransaction = new Transaction(
                transaction.EntityId,
                transaction.Stage);
           
            newTransaction.Entity = await _context.Entities.FindAsync(transaction.EntityId);

            newTransaction.Land = await _context.Lands.FindAsync(newTransaction.Entity.LandId);

            return newTransaction;
        }
    }
}
