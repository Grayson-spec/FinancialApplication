using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly DbContext _context;

        public VendorController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return await _context.Set<Vendor>().ToListAsync();
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var vendor = await _context.Set<Vendor>().FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // POST: api/Vendor
        [HttpPost]
        public async Task<ActionResult<Vendor>> CreateVendor(Vendor vendor)
        {
            _context.Set<Vendor>().Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVendor), new { id = vendor.Id }, vendor);
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVendor(int id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVendor(int id)
        {
            var vendor = await _context.Set<Vendor>().FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            _context.Set<Vendor>().Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}