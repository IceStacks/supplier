using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class SupplierController : ControllerBase
    {
        // private readonly SupplierDbContext _context;

        // public SupplierController(SupplierDbContext context)
        // {
        //     _context = context;
        // }

        [HttpGet]
        public IActionResult Index()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using(MySqlConnection connection = new MySqlConnection("Server=localhost;Database=IceStacks-Supplier;Uid=root;Pwd=55255Ahmet_"))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Suppliers", connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.Id = Convert.ToInt32(reader["id"]);
                    supplier.Name = reader["name"].ToString();
                    supplier.Surname = reader["surname"].ToString();
                    supplier.Gender = reader["gender"].ToString();
                    supplier.Address = reader["address"].ToString();
                    supplier.Mail = reader["mail"].ToString();
                    supplier.Phone = reader["phone"].ToString();
                    supplier.CompanyName = reader["company_name"].ToString();
                    supplier.CompanyMail = reader["company_mail"].ToString();
                    supplier.CompanyPhone = reader["company_phone"].ToString();

                    suppliers.Add(supplier);
                }

                reader.Close();
                connection.Close();
            }
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Store([FromBody] Supplier newSupplier) // model ile olacak
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Supplier updatedSupplier) // model ile olacak
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
