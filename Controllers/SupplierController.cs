using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Application.SupplierOperations.Commands;
using WebApi.Application.SupplierOperations.Validators;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Controllers
{

    public class mgr
    {
        public string value { get; set; }
    }

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

        [HttpPost("migrating")]
        public IActionResult Migrating([FromQuery] string value)
        {
            if(value.Equals("migrate"))
            {
                var migrator = _context.Database.GetService<IMigrator>();

                System.Console.WriteLine(migrator);

                migrator.Migrate();

                return Ok("Successful");
            }
            else {
                return BadRequest("Invalid value");
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            GetSuppliersQuery query = new GetSuppliersQuery(_context, _mapper);

            var result = query.Handle();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            GetSupplierDetailQuery query = new GetSupplierDetailQuery(_context, _mapper);
            GetSupplierDetailQueryValidator validator = new GetSupplierDetailQueryValidator();

            query.SupplierId = id;

            validator.ValidateAndThrow(query);

            var result = query.Handle();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateSupplierModel newSupplier)
        {
            CreateSupplierCommand command = new CreateSupplierCommand(_context, _mapper);
            CreateSupplierCommandValidator validator = new CreateSupplierCommandValidator();

            command.Model = newSupplier;

            validator.ValidateAndThrow(command);

            var result = command.Handle();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateSupplierModel updatedSupplier)
        {
            UpdateSupplierCommand command = new UpdateSupplierCommand(_context, _mapper);
            UpdateSupplierCommandValidator validator = new UpdateSupplierCommandValidator();

            command.SupplierId = id;
            command.Model = updatedSupplier;

            validator.ValidateAndThrow(command);

            var result = command.Handle();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            DeleteSupplierCommand command = new DeleteSupplierCommand(_context);
            DeleteSupplierCommandValidator validator = new DeleteSupplierCommandValidator();

            command.SupplierId = id;

            validator.ValidateAndThrow(command);

            var result = command.Handle();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
