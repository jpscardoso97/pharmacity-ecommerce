namespace CheckoutService.Models
{
    public class Payment
    {
        public string Id { get; set; }
        
        public string CustomerId { get; set; }
        
        public string PaymentInfoId { get; set; }
        
        public string Amount { get; set; }
        
        public string Date { get; set; }
    }
}