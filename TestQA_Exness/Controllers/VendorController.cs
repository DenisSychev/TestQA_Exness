using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestQA_Exness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        // GET api/vendor/5
        [HttpGet("get")]
        public ActionResult<string> Get(string id)
        {
            var result = "";
            if (id == "587d6b11-1491-456a-8e5c-d28d99ffdded")
            {
                result = @"{
                    'id': '587d6b11-1491-456a-8e5c-d28d99ffdded',
                    'name': 'Testing corp',
                    'rating': 5,
                    'categories': 
                        [
                            {
                            'id': '58bd2c46-6f8f-4474-9ba4-1038730e01d4',
                            'name': 'Testing software'
                            },
                            {
                            'id': '1ef43957-05a1-4900-819e-a4d8646188d5',
                            'name': 'System utilities'
                            }
                        ]
                    }";
                return result;
            }

            return NotFound(string.Format("Vendor {0} is not found", id));
        }
    }
}