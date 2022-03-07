using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.SupplierOperations.Commands
{
    public class DeleteSupplierCommand
    {
        public int SupplierId { get; set; }

        private readonly SupplierDbContext _context;

        public DeleteSupplierCommand(SupplierDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Supplier supplier = _context.Suppliers.FirstOrDefault(x => x.Id == SupplierId);

            if (supplier is null)
            {
                throw new InvalidOperationException("Silinecek tedarikçi bulunamadı.");
            }

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
