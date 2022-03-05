using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;

        public SupplierController(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList<Supplier>();
            
            if(suppliers is null)
            {
                return NotFound();      // burada middleware yazilip oradan exception firlatilabilir.
            }

            List<GetSuppliersViewModel> suppliersViewModel = _mapper.Map<List<GetSuppliersViewModel>>(suppliers);

            return Ok(suppliersViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id) 
        {
            
            var supplier = _context.Suppliers.FirstOrDefault(x => x.Id == id);

            if(supplier is null)
            {
                return NotFound("asdasd");      
            }

            GetSupplierDetailViewModel supplierViewModel = _mapper.Map<GetSupplierDetailViewModel>(supplier);

            return Ok(supplierViewModel);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateSupplierModel newSupplier) 
        {
            if(newSupplier is null)
            {
                return BadRequest();    
            }

            Supplier supplier = _mapper.Map<Supplier>(newSupplier);  

            _context.Suppliers.Add(supplier); 
            _context.SaveChanges();

            return Ok();
        }


        // guncelleme kisminda sorun var, guncelleme yapmak yerine yeni supplier yaratiyor. Duzenlenecek
        

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateSupplierModel updatedSupplier) 
        {
            Supplier supplier = _context.Suppliers.FirstOrDefault(x => x.Id == id);

            if(supplier is null)
            {
                return NotFound();      
            }

            supplier = _mapper.Map<Supplier>(updatedSupplier);
            
            _context.Update(supplier);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            Supplier supplier = _context.Suppliers.FirstOrDefault(x => x.Id == id);

            if(supplier is null)
            {
                return NotFound();      
            }

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

            return Ok();
        }
    }
}
