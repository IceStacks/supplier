using FluentValidation;
using WebApi.Application.SupplierOperations.Commands;

namespace WebApi.Application.SupplierOperations.Validators
{
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(2).When(y => y.Model.Name.Trim() != string.Empty);
            RuleFor(x => x.Model.Surname).MinimumLength(2).When(y => y.Model.Surname.Trim() != string.Empty);
            RuleFor(x => x.Model.Gender).Length(5).When(y => y.Model.Gender.Trim() != string.Empty);
            RuleFor(x => x.Model.Address).NotEmpty().When(y => y.Model.Address.Trim() != string.Empty);
            RuleFor(x => x.Model.Mail).EmailAddress().When(y => y.Model.Mail.Trim() != string.Empty);
            RuleFor(x => x.Model.Phone).Length(15).When(y => y.Model.Phone.Trim() != string.Empty); ;
            RuleFor(x => x.Model.CompanyName).MinimumLength(2).When(y => y.Model.CompanyName.Trim() != string.Empty); ;
            RuleFor(x => x.Model.CompanyMail).EmailAddress().When(y => y.Model.CompanyMail.Trim() != string.Empty);
            RuleFor(x => x.Model.CompanyPhone).Length(15).When(y => y.Model.CompanyPhone.Trim() != string.Empty); ;
        }
    }
}
