namespace WebApi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
    }
}