using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Set<Payment>().ToListAsync();
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Set<Payment>().FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
        {
            _context.Set<Payment>().Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(int id)
        {
            var payment = await _context.Set<Payment>().FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            _context.Set<Payment>().Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}