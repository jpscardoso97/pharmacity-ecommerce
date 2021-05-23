namespace OrderService.Models
{
    using System.Collections.Generic;
    using HotChocolate;
    using OrderService.Models.Interfaces;

    
    [GraphQLName("PrescriptionOrder")]
    public class PrescriptionOrder : IOrder
    {
        public string PrescriptionId { get; set; }

        public string Id { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public IEnumerable<OrderStatus> Status { get; set; }
        public string PaymentId { get; set; }
        public string DeliveryId { get; set; }
    }
}