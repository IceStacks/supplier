using Bogus;

namespace WebApi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
