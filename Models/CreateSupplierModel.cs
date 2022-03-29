using Bogus;

namespace WebApi.Models
{
    public class CreateSupplierModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyPhone { get; set; }

        public static Faker<CreateSupplierModel> FakeData {get; } = new Faker<CreateSupplierModel>()
            .RuleFor(s => s.Name, f => f.Name.FirstName())
            .RuleFor(s => s.CompanyName, f => f.Name.FirstName())
            .RuleFor(s => s.Surname, f => f.Name.LastName())
            .RuleFor(s => s.Gender, f => f.PickRandom<Gender>())
            .RuleFor(s => s.Address, f => f.Address.City())
            .RuleFor(p => p.Mail, (f, p) => f.Internet.Email(p.Name, p.Surname))
            .RuleFor(p => p.CompanyMail, (f, p) => f.Internet.Email(p.CompanyName))
            .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber("###-###-##-##"))
            .RuleFor(p => p.CompanyPhone, f => f.Phone.PhoneNumber("###-###-##-##"));   
    }

}
