namespace ShoppingCartService.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public string CustomerId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string DiscountCard { get; set; }
        
        public string CartId { get; set; }
        
        public string WishlistId { get; set; }
        
        public IEnumerable<string> Addresses { get; set; }
    }
}