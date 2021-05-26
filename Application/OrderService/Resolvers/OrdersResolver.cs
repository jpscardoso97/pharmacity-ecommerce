namespace OrderService.Resolvers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using OrderService.Data;
    using OrderService.Data.Dto;
    using OrderService.Models;
    using OrderService.Models.Interfaces;

    public class OrdersResolver
    {
        private readonly OrdersRepository _repository;

        public OrdersResolver(OrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOrder> GetOrder(string id)
        {
            var queryResult = await _repository.GetOrderAsync(id, CancellationToken.None);

            if (queryResult == null)
                return default;

            return GetTypedOrder(queryResult);
        }

        public IEnumerable<IOrder> GetOrders(string ids)
        {
            var queryResult = _repository.GetOrders(ids)?.ToList();

            return queryResult?.Select(order => GetTypedOrder(order));
        }

        

        public static IOrder GetTypedOrder(OrderDto order)
        {
            return order.PrescriptionId != null
                ? new PrescriptionOrder
                {
                    Id = order.OrderId,
                    Value = order.Value,
                    DeliveryId = order.DeliveryId,
                    PaymentId = order.PaymentId,
                    PrescriptionId = order.PrescriptionId,
                    Status = order.Status.Select(o => new OrderStatus
                        {Date = o.Date, Value = OrderStatusHelper.GetEnumValue((OrderStatusEnum) o.Value)}),
                    Date = order.Date
                }
                : new ProductsOrder
                {
                    Id = order.OrderId,
                    Value = order.Value,
                    DeliveryId = order.DeliveryId,
                    PaymentId = order.PaymentId,
                    Items = order.Items.Select(itemDto => new OrderItem
                    {
                        ProductId = itemDto.ProductId,
                        Price = itemDto.Price,
                        Quantity = itemDto.Quantity
                    }).ToArray(),
                    Status = order.Status.Select(o => new OrderStatus
                        {Date = o.Date, Value = OrderStatusHelper.GetEnumValue((OrderStatusEnum) o.Value)}),
                    Date = order.Date
                };
        }
    }
}