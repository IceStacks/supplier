using FluentValidation;
using WebApi.Application.SupplierOperations.Commands;

namespace WebApi.Application.SupplierOperations.Validators
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.Model.Gender).NotEmpty().Length(5); // enum kontrolu yapilacak
            RuleFor(x => x.Model.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.Mail).EmailAddress().MaximumLength(30);
            RuleFor(x => x.Model.Phone).NotEmpty().Length(15); // kontrol edilecek
            RuleFor(x => x.Model.CompanyName).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.Model.CompanyMail).EmailAddress().MaximumLength(30);
            RuleFor(x => x.Model.CompanyPhone).NotEmpty().Length(15);
        }
    }
}
