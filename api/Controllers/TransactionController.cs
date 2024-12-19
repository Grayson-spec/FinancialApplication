using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DbContext _context;

        public TransactionController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Set<Transaction>().ToListAsync();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Set<Transaction>().FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            _context.Set<Transaction>().Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Set<Transaction>().FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            _context.Set<Transaction>().Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}