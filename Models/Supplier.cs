using Bogus;

namespace WebApi.Models
{
    public class Supplier
    {
        //TODO: Company sinifi olusturulacak
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyPhone { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
