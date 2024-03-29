﻿namespace OrderService.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HotChocolate;
    using HotChocolate.Types;
    using OrderService.Models.Interfaces;
    using OrderService.Resolvers;
    
    [ExtendObjectType(OperationTypeNames.Query)]
    public class OrdersQuery
    {
        public IEnumerable<IOrder> GetOrders([Service] OrdersResolver resolver, string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
                return new List<IOrder>();
            
            return resolver.GetOrders(ids);
        }
        
        public async Task<IOrder> GetOrder([Service] OrdersResolver resolver, string orderId)
        {
            return await resolver.GetOrder(orderId);
        }
    }
}