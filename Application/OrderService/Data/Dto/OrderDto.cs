namespace OrderService.Data.Dto
{
    using System.Collections.Generic;

    public class OrderDto
    {
        public int Id { get; set; }
        
        public string OrderId { get; set; }
        
        public string Value { get; set; }
        
        public string Date { get; set; }

        public IDictionary<string, int> Status { get; set; }
        
        public string PaymentId { get; set; }
        
        public string DeliveryId { get; set; }
        
        public string PrescriptionId { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}