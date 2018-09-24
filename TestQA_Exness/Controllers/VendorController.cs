using System.Linq;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorsDbContext _vendorsDbContext;

        public VendorController(VendorsDbContext vendorsDbContext)
        {
            _vendorsDbContext = vendorsDbContext;
        }


        // GET /api/vendor/get/587d6b11-1491-456a-8e5c-d28d99ffdded
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {  
            var vendor = _vendorsDbContext.Vendors.FirstOrDefault(v => v.id == id);
            
            if (vendor == null)
                return NotFound(string.Format("Vendor {0} was not found", id));

            var categories = _vendorsDbContext.Categories
                .Where(c => c.id == vendor.id)
                .Select(c => c.name);

            return Ok(new
            {
                vendor.id,
                vendor.name,
                vendor.rating,
                categories
            });
        }

        // POST /api/vendor/create
        [HttpPost]
        public IActionResult Create([FromBody] Vendor vendor)
        {
            _vendorsDbContext.Add(vendor);
            _vendorsDbContext.SaveChanges();

            return NoContent();
        }
        
        // DELETE /api/vendor/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var vendor = _vendorsDbContext.Vendors.FirstOrDefault(v => v.id == id);

            if (vendor == null)
            {
                return NotFound(string.Format("Vendor {0} was not found", id));
            }

            _vendorsDbContext.Vendors.Remove(vendor);
            _vendorsDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Vendor v)
        {
            var vendor = _vendorsDbContext.Vendors.Find(v.id);

            if (vendor == null)
            {
                return NotFound(string.Format("Vendor {0} was not found", v.id));
            }

            _vendorsDbContext.Vendors.Remove(vendor);
            _vendorsDbContext.SaveChanges();

            return NoContent();
        }
    }
}