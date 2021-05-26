namespace CheckoutService.Data.Dto
{
    using MongoDB.Bson;

    public class PaymentDto
    {
        public ObjectId Id { get; set; }
        
        public string PaymentId { get; set; }
        
        public string CustomerId { get; set; }
        
        public string PaymentInfoId { get; set; }

        public string Amount { get; set; }
        
        public string Date { get; set; }
    }
}