namespace ShoppingCartService.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        
        public string[] ProductIds { get; set; }
        
        public string OrderId { get; set; }
    }
}