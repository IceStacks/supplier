using FluentValidation;
using WebApi.Application.SupplierOperations.Commands;

namespace WebApi.Application.SupplierOperations.Validators
{
    public class DeleteSupplierCommandValidator : AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierCommandValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThan(0);
        }
    }
}
