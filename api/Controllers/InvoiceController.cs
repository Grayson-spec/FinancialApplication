using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly DbContext _context;

        public InvoiceController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _context.Set<Invoice>().ToListAsync();
        }

        // GET: api/Invoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Set<Invoice>().FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // POST: api/Invoice
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            _context.Set<Invoice>().Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

        // PUT: api/Invoice/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Invoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Set<Invoice>().FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            _context.Set<Invoice>().Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}