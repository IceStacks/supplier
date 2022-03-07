using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.SupplierOperations.Commands
{
    public class GetSuppliersQuery
    {
        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;

        public GetSuppliersQuery(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetSuppliersViewModel> Handle()
        {
            var suppliers = _context.Suppliers.OrderBy(x => x.Id).ToList<Supplier>();

            List<GetSuppliersViewModel> suppliersViewModel = _mapper.Map<List<GetSuppliersViewModel>>(suppliers);

            return suppliersViewModel;
        }
    }
}
