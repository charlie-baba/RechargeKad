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
    [Route("api/Sample")]
    public class SampleController : Controller
    {
        private readonly RechargeKadDBContext _context;

        public SampleController(RechargeKadDBContext context)
        {
            _context = context;
        }

        // GET: api/Sample
        [HttpGet]
        public IEnumerable<RechargeTransaction> GetRechargeTransactions()
        {
            return _context.RechargeTransactions;
        }

        // GET: api/Sample/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRechargeTransaction([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rechargeTransaction = await _context.RechargeTransactions.SingleOrDefaultAsync(m => m.Id == id);

            if (rechargeTransaction == null)
            {
                return NotFound();
            }

            return Ok(rechargeTransaction);
        }

        // PUT: api/Sample/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRechargeTransaction([FromRoute] long id, [FromBody] RechargeTransaction rechargeTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rechargeTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(rechargeTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RechargeTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sample
        [HttpPost]
        public async Task<IActionResult> PostRechargeTransaction([FromBody] RechargeTransaction rechargeTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RechargeTransactions.Add(rechargeTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRechargeTransaction", new { id = rechargeTransaction.Id }, rechargeTransaction);
        }

        // DELETE: api/Sample/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRechargeTransaction([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rechargeTransaction = await _context.RechargeTransactions.SingleOrDefaultAsync(m => m.Id == id);
            if (rechargeTransaction == null)
            {
                return NotFound();
            }

            _context.RechargeTransactions.Remove(rechargeTransaction);
            await _context.SaveChangesAsync();

            return Ok(rechargeTransaction);
        }

        private bool RechargeTransactionExists(long id)
        {
            return _context.RechargeTransactions.Any(e => e.Id == id);
        }
    }
}