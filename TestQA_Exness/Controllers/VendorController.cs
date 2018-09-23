using System.Linq;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorsDbContext vendorsDbContext;

        public VendorController(VendorsDbContext vendorsDbContext)
        {
            this.vendorsDbContext = vendorsDbContext;
        }


        // GET /api/vendor/get/587d6b11-1491-456a-8e5c-d28d99ffdded
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {  
            var vendor = vendorsDbContext.Vendors.FirstOrDefault(v => v.id == id);
            
            if (vendor == null)
                return NotFound(string.Format("Vendor {0} was not found", id));

            var categories = vendorsDbContext.Categories
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
            vendorsDbContext.Add(vendor);
            vendorsDbContext.SaveChanges();

            return NoContent();
        }
        
        // DELETE /api/vendor/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var vendor = vendorsDbContext.Vendors.FirstOrDefault(v => v.id == id);

            if (vendor == null)
            {
                return NotFound(string.Format("Vendor {0} was not found", id));
            }

            vendorsDbContext.Vendors.Remove(vendor);
            vendorsDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Vendor v)
        {
            var vendor = vendorsDbContext.Vendors.Find(v.id);

            if (vendor == null)
            {
                return NotFound(string.Format("Vendor {0} was not found", v.id));
            }

            vendorsDbContext.Vendors.Remove(vendor);
            vendorsDbContext.SaveChanges();

            return NoContent();
        }
    }
}