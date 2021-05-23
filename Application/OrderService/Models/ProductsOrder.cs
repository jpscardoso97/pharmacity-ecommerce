namespace OrderService.Models
{
    using System.Collections.Generic;
    using HotChocolate;
    using OrderService.Models.Interfaces;

    
    [GraphQLName("ProductsOrder")]
    public class ProductsOrder : IOrder
    {
        public OrderItem[] Items { get; set; }
        
        public string Id { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public IEnumerable<OrderStatus> Status { get; set; }
        public string PaymentId { get; set; }
        public string DeliveryId { get; set; }
    }
}