namespace CheckoutService.InputTypes
{
    public class PrescriptionOrder
    {
        public string Value { get; set; }
        
        public string CustomerId { get; set; }
        
        public string AddressId { get; set; }

        public string PaymentId { get; set; }

        public string PrescriptionId { get; set; }
    }
}