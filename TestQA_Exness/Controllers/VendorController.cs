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
        [HttpGet]
        public IActionResult Get(string id)
        {  
            var vendor = _vendorsDbContext.Vendors.FirstOrDefault(v => v.Id == id);
            
            if (vendor == null)
                return NotFound(string.Format("Vendor {0} was not found", id));

            var categories = _vendorsDbContext.Categories
                .Where(c => c.Id == vendor.Id)
                .Select(c => c.Name);

            return Ok(new
            {
                id = vendor.Id,
                name = vendor.Name,
                rating = vendor.Rating,
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
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var vendor = _vendorsDbContext.Vendors.FirstOrDefault(v => v.Id == id);

            if (vendor == null)
            {
                return NotFound(string.Format("Vendor {0} was not found", id));
            }

            _vendorsDbContext.Vendors.Remove(vendor);
            _vendorsDbContext.SaveChanges();

            return NoContent();
        }
    }
    
}