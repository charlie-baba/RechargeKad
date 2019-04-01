using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RechargeKad.Model;

namespace RechargeKad.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly RechargeKadDBContext _context;

        public TransactionsController(RechargeKadDBContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<RechargeTransaction> GetTransactions()
        {
            return _context.RechargeTransactions;
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction([FromRoute] string transId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactions = await _context.RechargeTransactions.Where(m => m.TransactionId == transId).ToListAsync();

            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);
        }
     
    }
}