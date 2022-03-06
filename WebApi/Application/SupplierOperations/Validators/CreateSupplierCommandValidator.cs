using FluentValidation;
using WebApi.Application.SupplierOperations.Commands;

namespace WebApi.Application.SupplierOperations.Validators
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Gender).NotEmpty().Length(5);
            RuleFor(x => x.Model.Address).NotEmpty();
            RuleFor(x => x.Model.Mail).EmailAddress();
            RuleFor(x => x.Model.Phone).NotEmpty().Length(15);
            RuleFor(x => x.Model.CompanyName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.CompanyMail).EmailAddress();
            RuleFor(x => x.Model.CompanyPhone).NotEmpty().Length(15);
        }
    }
}
