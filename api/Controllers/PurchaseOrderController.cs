using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly DbContext _context;

        public PurchaseOrderController(DbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrders()
        {
            return await _context.Set<PurchaseOrder>().ToListAsync();
        }

        // GET: api/PurchaseOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrder(int id)
        {
            var purchaseOrder = await _context.Set<PurchaseOrder>().FindAsync(id);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return purchaseOrder;
        }

        // POST: api/PurchaseOrder
        [HttpPost]
        public async Task<ActionResult<PurchaseOrder>> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.Set<PurchaseOrder>().Add(purchaseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseOrder), new { id = purchaseOrder.Id }, purchaseOrder);
        }

        // PUT: api/PurchaseOrder/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePurchaseOrder(int id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/PurchaseOrder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePurchaseOrder(int id)
        {
            var purchaseOrder = await _context.Set<PurchaseOrder>().FindAsync(id);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            _context.Set<PurchaseOrder>().Remove(purchaseOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}