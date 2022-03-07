using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.SupplierOperations.Commands
{
    public class GetSupplierDetailQuery
    {
        public int SupplierId { get; set; }

        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;

        public GetSupplierDetailQuery(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetSupplierDetailViewModel Handle()
        {
            var supplier = _context.Suppliers.Where(x => x.Id == SupplierId).SingleOrDefault();

            if (supplier is null)
            {
                throw new InvalidOperationException("Aranan tedarikçi bulunamadı.");
            }

            GetSupplierDetailViewModel supplierViewModel = _mapper.Map<GetSupplierDetailViewModel>(supplier);

            return supplierViewModel;
        }
    }
}
