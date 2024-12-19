using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly DbContext _context;

        public SalesOrderController(DbContext context)
        {
            _context = context;
        }

        // GET: api/SalesOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrders()
        {
            return await _context.Set<SalesOrder>().ToListAsync();
        }

        // GET: api/SalesOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
        {
            var salesOrder = await _context.Set<SalesOrder>().FindAsync(id);

            if (salesOrder == null)
            {
                return NotFound();
            }

            return salesOrder;
        }

        // POST: api/SalesOrder
        [HttpPost]
        public async Task<ActionResult<SalesOrder>> CreateSalesOrder(SalesOrder salesOrder)
        {
            _context.Set<SalesOrder>().Add(salesOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesOrder), new { id = salesOrder.Id }, salesOrder);
        }

        // PUT: api/SalesOrder/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSalesOrder(int id, SalesOrder salesOrder)
        {
            if (id != salesOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SalesOrder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSalesOrder(int id)
        {
            var salesOrder = await _context.Set<SalesOrder>().FindAsync(id);

            if (salesOrder == null)
            {
                return NotFound();
            }

            _context.Set<SalesOrder>().Remove(salesOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}