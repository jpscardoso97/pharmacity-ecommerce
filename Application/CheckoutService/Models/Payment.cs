namespace CheckoutService.Models
{
    public class Payment
    {
        public string PaymentId { get; set; }
        
        public string PaymentInfoId { get; set; }
        
        public string OrderId { get; set; }

        public string Amount { get; set; }
        
        public string Date { get; set; }
    }
}