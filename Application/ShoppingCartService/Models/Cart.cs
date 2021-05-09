namespace ShoppingCartService.Models
{
    public class Cart
    {
        public string[] ProductIds { get; set; }
        
        public string CustomerId { get; set; }
        
        public string OrderId { get; set; }
    }
}