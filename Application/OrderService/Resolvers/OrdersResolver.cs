namespace OrderService.Resolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Crosscutting.Helpers;
    using OrderService.Data;
    using OrderService.Data.Dto;
    using OrderService.Extensions;
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

        public async Task<ProductsOrder> CreateProductsOrder(ProductsOrder order)
        {
            var baseOrder = CreateOrder(order);
            baseOrder.Items = order.Items.Select(item => item.ToDto());

            var mutationResult = await _repository.CreateOrder(baseOrder);

            if (mutationResult == null)
                return default;

            return GetTypedOrder(mutationResult) as ProductsOrder;
        }

        public async Task<PrescriptionOrder> CreatePrescriptionOrder(PrescriptionOrder order)
        {
            var baseOrder = CreateOrder(order);
            baseOrder.PrescriptionId = order.PrescriptionId;

            var mutationResult = await _repository.CreateOrder(baseOrder);

            if (mutationResult == null)
                return default;


            return GetTypedOrder(mutationResult) as PrescriptionOrder;
        }

        private static IEnumerable<OrderStatusDto> InitializeOrderStatus() => new List<OrderStatusDto>
        {
            new()
            {
                Date = $"{DateTime.UtcNow.ToShortDateString()}-{DateTime.UtcNow.ToShortTimeString()}",
                Value = (int) OrderStatusEnum.PendingPayment
            },
            new()
            {
                Date = $"{DateTime.UtcNow.ToShortDateString()}-{DateTime.UtcNow.ToShortTimeString()}",
                Value = (int) OrderStatusEnum.Processing
            },
        };

        private static OrderDto CreateOrder(IOrder order) => new OrderDto
        {
            OrderId = IdGenerationHelper.GenerateId(10),
            Status = InitializeOrderStatus(),
            Value = order.Value,
            Date = DateTime.UtcNow.ToShortDateString(),
            PaymentId = order.PaymentId,
        };

        private IOrder GetTypedOrder(OrderDto order)
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