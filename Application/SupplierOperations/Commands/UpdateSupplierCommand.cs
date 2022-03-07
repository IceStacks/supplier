using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.SupplierOperations.Commands
{
    public class UpdateSupplierCommand
    {
        public UpdateSupplierModel Model { get; set; }
        public int SupplierId { get; set; }

        private readonly SupplierDbContext _context;

        private readonly IMapper _mapper;


        public UpdateSupplierCommand(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Supplier supplier = _context.Suppliers.FirstOrDefault(x => x.Id == SupplierId);

            if (supplier is null)
            {
                throw new InvalidOperationException("Güncellenecek tedarikçi bulunamadı.");
            }

            _mapper.Map(Model, supplier);
            _context.SaveChanges();
        }
    }
}
