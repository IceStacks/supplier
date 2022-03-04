using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using WebApi.Models;

namespace WebApi.DbOperations
{
    public class SupplierDbContext : DbContext
    {
        protected readonly MySqlConnection _connection;

        public SupplierDbContext(MySqlConnection connection)
        {
            _connection = connection;
        }

        public DbSet<Supplier> Suppliers { get; set; }
            
    }
}