using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.DbOperations;
using WebApi.Models;
using System.Linq;
using Utilities;
using WebApi.Application.SupplierOperations.Commands;
using AutoMapper;
using WebApi.Application.SupplierOperations.Validators;
using FluentValidation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MigrationController : ControllerBase
    {

        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;

        public MigrationController(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("migrating")]
        public IActionResult Migrating([FromQuery] string value)
        {
            if (value.Equals("migrate"))
            {
                var migrator = _context.Database.GetService<IMigrator>();

                migrator.Migrate();

                return Ok("Successful");
            }
            else
            {
                return BadRequest("Invalid value");
            }
        }

        [HttpPost("fakedata")]
        public IActionResult FakeData([FromQuery] string value)
        {
            if(value.Equals("fakedata"))
            {
                CreateSupplierCommand command = new CreateSupplierCommand(_context, _mapper);

                int n = 10;

                for (int i = 0; i < n; i++)
                {
                    var newSupplier = CreateSupplierModel.FakeData.Generate(1).First();
                    command.Model = newSupplier;
                    var result = command.Handle();
                    if (result.Success == false)
                    {
                        return BadRequest(result);
                    }
                }
                return Ok("success");
            }
            else
            {
                return BadRequest("Invalid value");
            }
        }
    }
}