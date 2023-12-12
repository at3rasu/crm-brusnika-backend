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
        private readonly TransactionsContext _context;
        
        public TransactionsController(TransactionsContext context)
        {
            _context = context;
        }


        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> createTransaction(Transaction transaction)
        {
            var newTransaction = await _context.Transactions.AddAsync(new Transaction(
                transaction.RegisterNumber,
                transaction.Adress,
                transaction.Square,
                transaction.AboutHolder,
                transaction.Price,
                transaction.SearchObject));
            await _context.SaveChangesAsync();

            return Ok(newTransaction);
        }
    }
}
