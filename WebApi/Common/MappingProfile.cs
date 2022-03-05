using AutoMapper;
using WebApi.Models;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplier, GetSuppliersViewModel>();
            CreateMap<Supplier, GetSupplierDetailViewModel>();
            CreateMap<CreateSupplierModel, Supplier>();
            CreateMap<UpdateSupplierModel, Supplier>();
        }
    }
}
