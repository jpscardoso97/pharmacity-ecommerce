namespace OrderService.Data.Dto
{
    using System.Collections.Generic;
    using MongoDB.Bson;
    using OrderService.Models;

    public class OrderDto
    {
        public ObjectId Id { get; set; }

        public string OrderId { get; set; }
        
        public string CustomerId { get; set; }
        
        public string AddressId { get; set; }

        public string Value { get; set; }

        public string Date { get; set; }

        public IEnumerable<OrderStatusDto> Status { get; set; }

        public string PaymentId { get; set; }

        public string DeliveryId { get; set; }

        public string PrescriptionId { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}