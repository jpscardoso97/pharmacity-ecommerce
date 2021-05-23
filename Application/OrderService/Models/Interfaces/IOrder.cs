namespace OrderService.Models.Interfaces
{
    using System.Collections.Generic;
    using HotChocolate;

    [GraphQLName("Order")]
    public interface IOrder
    {
        public string Id { get; set; }
        
        public string Value { get; set; }
        
        public string Date { get; set; }

        public IEnumerable<OrderStatus> Status { get; set; }
        
        public string PaymentId { get; set; }
        
        public string DeliveryId { get; set; }
    }
}