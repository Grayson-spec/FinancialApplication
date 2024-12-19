using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DbContext _context;

        public ItemController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Set<Item>().ToListAsync();
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Set<Item>().FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            _context.Set<Item>().Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var item = await _context.Set<Item>().FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Set<Item>().Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}