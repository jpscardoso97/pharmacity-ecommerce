namespace CheckoutService.InputTypes
{
    public class OrderItem
    {
        public string ProductId { get; set; }

        public string Price { get; set; }
        
        public string Quantity { get; set; }
    }
}