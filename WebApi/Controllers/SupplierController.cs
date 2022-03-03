using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierDbContext _context;

        public BookController(SupplierDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddSupplier([FromBody] Supplier newSupplier) // model ile olacak
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] Supplier updatedSupplier) // model ile olacak
        {
           
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            return Ok();
        }
    }
}
