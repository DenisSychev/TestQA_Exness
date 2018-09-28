using System;
using System.Linq;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        
        // GET /api/vendor/get?id=587d6b11-1491-456a-8e5c-d28d99ffdded
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var vendor = _vendorsDbContext.Vendors
                .Include(v => v.Categories)
                .FirstOrDefault(v => v.Id == id);

            if (vendor == null)
                return NotFound(string.Format("Vendor {0} was not found", id));

            return Ok(new
            {
                id = vendor.Id,
                name = vendor.Name,
                rating = vendor.Rating,
                categories = vendor.Categories
            });
        }

        // POST /api/vendor/create
        [HttpPost]
        public IActionResult Create([FromBody] Vendor vendor)
        {
            try
            {
                _vendorsDbContext.Vendors.Add(vendor);
                _vendorsDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }

        // DELETE /api/vendor/delete
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var vendor = _vendorsDbContext.Vendors.FirstOrDefault(v => v.Id == id);

            if (vendor == null)
            {
                return NotFound(string.Format("Vendor {0} was not found", id));
            }

            var categories = _vendorsDbContext.Categories
                .Where(category => category.VendorId == id)
                .ToList();

            foreach (var category in categories)
            {
                _vendorsDbContext.Categories.Remove(category);
            }

            _vendorsDbContext.Vendors.Remove(vendor);
            _vendorsDbContext.SaveChanges();

            return NoContent();
        }
    }
}