namespace OrderService.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HotChocolate;
    using OrderService.Models.Interfaces;
    using OrderService.Resolvers;

    public class OrdersQuery
    {
        public IEnumerable<IOrder> GetOrders([Service] OrdersResolver resolver, string ids)
        {
            return resolver.GetOrders(ids);
        }
        
        public async Task<IOrder> GetOrder([Service] OrdersResolver resolver, string orderId)
        {
            return await resolver.GetOrder(orderId);
        }
    }
}