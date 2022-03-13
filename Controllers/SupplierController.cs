using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("migrating")]
        public IActionResult Migrating()
        {
            var migrator = _context.Database.GetService<IMigrator>();

            migrator.Migrate();

            return Ok("Successful");

        }

        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine();
            Console.WriteLine("GetEnvironmentVariables: ");
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);

            GetSuppliersQuery query = new GetSuppliersQuery(_context, _mapper);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            GetSupplierDetailQuery query = new GetSupplierDetailQuery(_context, _mapper);
            GetSupplierDetailQueryValidator validator = new GetSupplierDetailQueryValidator();

            query.SupplierId = id;

            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateSupplierModel newSupplier)
        {
            CreateSupplierCommand command = new CreateSupplierCommand(_context, _mapper);
            CreateSupplierCommandValidator validator = new CreateSupplierCommandValidator();

            command.Model = newSupplier;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateSupplierModel updatedSupplier)
        {
            UpdateSupplierCommand command = new UpdateSupplierCommand(_context, _mapper);
            UpdateSupplierCommandValidator validator = new UpdateSupplierCommandValidator();

            command.SupplierId = id;
            command.Model = updatedSupplier;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            DeleteSupplierCommand command = new DeleteSupplierCommand(_context);
            DeleteSupplierCommandValidator validator = new DeleteSupplierCommandValidator();

            command.SupplierId = id;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
