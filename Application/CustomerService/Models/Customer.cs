namespace CustomerService.Models
{
    public class Customer
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string DiscountCard { get; set; }
        
        public string CartId { get; set; }
        
        public string WishlistId { get; set; }
        
        public string Addresses { get; set; }

        public string Orders { get; set; }
    }
}