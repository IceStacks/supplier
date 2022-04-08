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
            RuleFor(x => x.Model.Gender).NotEmpty(); // enum kontrolu yapilacak
            RuleFor(x => x.Model.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Model.Mail).EmailAddress();
            RuleFor(x => x.Model.Phone).NotEmpty().MinimumLength(10).MaximumLength(14); // kontrol edilecek, 1234567890 / +90 1234567890
            RuleFor(x => x.Model.Company.CompanyName).NotEmpty().MinimumLength(2).MaximumLength(20);
            RuleFor(x => x.Model.Company.CompanyMail).EmailAddress();
            RuleFor(x => x.Model.Company.CompanyPhone).NotEmpty().MinimumLength(10).MaximumLength(14); // kontrol edilecek, 1234567890 / +90 1234567890
        }
    }
}
