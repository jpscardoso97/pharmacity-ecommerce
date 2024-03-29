﻿namespace CheckoutService.InputTypes
{
    using System.Collections.Generic;

    public class ProductsOrder
    {
        public IEnumerable<OrderItem> Items { get; set; }
        
        public string Value { get; set; }
        
        public string PaymentId { get; set; }
        
        
        public string CustomerId { get; set; }
        
        public string AddressId { get; set; }
    }
}