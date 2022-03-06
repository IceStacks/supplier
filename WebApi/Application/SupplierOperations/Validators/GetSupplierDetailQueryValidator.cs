using FluentValidation;
using WebApi.Application.SupplierOperations.Commands;

namespace WebApi.Application.SupplierOperations.Validators
{
    public class GetSupplierDetailQueryValidator : AbstractValidator<GetSupplierDetailQuery>
    {
        public GetSupplierDetailQueryValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThan(0);
        }
    }
}
