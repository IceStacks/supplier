using FluentValidation;
using WebApi.Application.SupplierOperations.Commands;

namespace WebApi.Application.SupplierOperations.Validators
{
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(2).MaximumLength(20).When(y => y.Model.Name.Trim() != string.Empty);
            RuleFor(x => x.Model.Surname).MinimumLength(2).MaximumLength(20).When(y => y.Model.Surname.Trim() != string.Empty);
            RuleFor(x => x.Model.Gender).IsInEnum().When(y => y.Model.Gender.Trim() != string.Empty); // kontrol edilecek
            RuleFor(x => x.Model.Address).NotEmpty().MaximumLength(50).When(y => y.Model.Address.Trim() != string.Empty);
            RuleFor(x => x.Model.Mail).EmailAddress().When(y => y.Model.Mail.Trim() != string.Empty);
            RuleFor(x => x.Model.Phone).MinimumLength(10).MaximumLength(14).When(y => y.Model.Phone.Trim() != string.Empty); // kontrol edilecek
            RuleFor(x => x.Model.CompanyName).MinimumLength(2).MaximumLength(20).When(y => y.Model.CompanyName.Trim() != string.Empty); 
            RuleFor(x => x.Model.CompanyMail).EmailAddress().When(y => y.Model.CompanyMail.Trim() != string.Empty);
            RuleFor(x => x.Model.CompanyPhone).MinimumLength(10).MaximumLength(14).When(y => y.Model.CompanyPhone.Trim() != string.Empty); 
        }
    }
}
