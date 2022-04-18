namespace WebApi.Models
{
    public class UpdateSupplierModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public Company Company { get; set; }
    }
}
