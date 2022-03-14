using AutoMapper;
using System;
using System.Linq;
using Utilities;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.SupplierOperations.Commands
{
    public class CreateSupplierCommand
    {
        public CreateSupplierModel Model { get; set; }

        private readonly SupplierDbContext _context;
        
        private readonly IMapper _mapper;


        public CreateSupplierCommand(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var supplier = _context.Suppliers.SingleOrDefault(supplier => supplier.Phone == Model.Phone && supplier.Mail == Model.Mail);

            if (supplier is not null)
            {
                return new ErrorResult("Bu telefon ve mail ile daha önce kayıt edilmiş.");
            }

            supplier = _mapper.Map<Supplier>(Model);

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return new SuccessResult("Tedarikçi başarıyla eklendi.");

        }
    }
}
