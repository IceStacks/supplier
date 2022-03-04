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

        // asagida yazdigim db baglantilari duzeltilecek. 
        // DI ile yapmaya calisacagim,  simdilik gecici olarak bu sekilde kullandim.

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=IceStacks-Supplier;Uid=root;Pwd=55255Ahmet_;");

        [HttpGet]
        public IActionResult Index()
        {
            List<GetSuppliersViewModel> suppliers = new List<GetSuppliersViewModel>();

            connection.Open();

            MySqlCommand cmd = new MySqlCommand("select * from Suppliers", connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                GetSuppliersViewModel supplier = new GetSuppliersViewModel();

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
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id) // model ile olmali
        {
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("select * from Suppliers where id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            
            MySqlDataReader reader = cmd.ExecuteReader();

            GetSupplierDetailViewModel supplier = new GetSupplierDetailViewModel();

            while(reader.Read())
            {
                supplier.Name = reader["name"].ToString();
                supplier.Surname = reader["surname"].ToString();
                supplier.Gender = reader["gender"].ToString();
                supplier.Address = reader["address"].ToString();
                supplier.Mail = reader["mail"].ToString();
                supplier.Phone = reader["phone"].ToString();
                supplier.CompanyName = reader["company_name"].ToString();
                supplier.CompanyMail = reader["company_mail"].ToString();
                supplier.CompanyPhone = reader["company_phone"].ToString();
            }
            
            reader.Close();
            connection.Close();
            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateSupplierModel newSupplier) // model ile olmali
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Suppliers (name, surname, gender, address, mail, phone, company_name, company_mail, company_phone) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7, @p8, @p9)",connection);
            cmd.Parameters.AddWithValue("@p1",newSupplier.Name);
            cmd.Parameters.AddWithValue("@p2",newSupplier.Surname);
            cmd.Parameters.AddWithValue("@p3",newSupplier.Gender);
            cmd.Parameters.AddWithValue("@p4",newSupplier.Address);
            cmd.Parameters.AddWithValue("@p5",newSupplier.Mail);
            cmd.Parameters.AddWithValue("@p6",newSupplier.Phone);
            cmd.Parameters.AddWithValue("@p7",newSupplier.CompanyName);
            cmd.Parameters.AddWithValue("@p8",newSupplier.CompanyMail);
            cmd.Parameters.AddWithValue("@p9",newSupplier.CompanyPhone);
            cmd.ExecuteNonQuery();
            
            connection.Close();
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Supplier updatedSupplier) // model ile olmali
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
