using Microsoft.EntityFrameworkCore;
using WebApi.Models;
namespace WebApi.DbOperations
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)     {}
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
