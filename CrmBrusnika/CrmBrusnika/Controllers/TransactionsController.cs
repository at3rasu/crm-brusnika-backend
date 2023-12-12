using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsContext _context;
        
        public TransactionsController(TransactionsContext context)
        {
            _context = context;
        }



    }
}
