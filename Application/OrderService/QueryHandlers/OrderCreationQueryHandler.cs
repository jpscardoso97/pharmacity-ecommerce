namespace OrderService.QueryHandlers
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
    using OrderService.Resolvers;

    public class OrderCreationQueryHandler
    {
        private readonly OrdersRepository _repository;

        public OrderCreationQueryHandler(OrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductsOrder> CreateProductsOrder(ProductsOrder order)
        {
            if (!ValidateOrder(order))
            {
                throw new ArgumentException("Invalid order");
            }

            var baseOrder = CreateOrder(order);
            baseOrder.Items = order.Items?.Select(item => item.ToDto());

            var mutationResult = await _repository.CreateOrder(baseOrder);

            if (mutationResult == null)
                return default;

            return OrdersResolver.GetTypedOrder(mutationResult) as ProductsOrder;
        }

        public async Task<PrescriptionOrder> CreatePrescriptionOrder(PrescriptionOrder order)
        {
            if (!ValidateOrder(order))
            {
                throw new ArgumentException("Invalid order");
            }

            var baseOrder = CreateOrder(order);
            baseOrder.PrescriptionId = order.PrescriptionId;

            var mutationResult = await _repository.CreateOrder(baseOrder);

            if (mutationResult == null)
                return default;


            return OrdersResolver.GetTypedOrder(mutationResult) as PrescriptionOrder;
        }

        private static IEnumerable<OrderStatusDto> InitializeOrderStatus() => new List<OrderStatusDto>
        {
            new()
            {
                Date = DateHelper.GenerateReadableDateTime(),
                Value = (int) OrderStatusEnum.PendingPayment
            },
            new()
            {
                Date = DateHelper.GenerateReadableDateTime(),
                Value = (int) OrderStatusEnum.Processing
            },
        };

        private static OrderDto CreateOrder(IOrder order) => new OrderDto
        {
            OrderId = IdGenerationHelper.GenerateId(10),
            Status = InitializeOrderStatus(),
            Value = order.Value,
            Date = DateHelper.GenerateReadableDateTime(),
            PaymentId = order.PaymentId,
        };

        private bool ValidateOrder(IOrder order)
        {
            if (string.IsNullOrWhiteSpace(order.Value) ||
                string.IsNullOrWhiteSpace(order.PaymentId))
            {
                return false;
            }

            switch (order)
            {
                case PrescriptionOrder prescriptionOrder
                    when string.IsNullOrWhiteSpace(prescriptionOrder.PrescriptionId):
                    return false;
                case ProductsOrder productsOrder when productsOrder.Items?.Length == 0:
                    return false;
            }

            return true;
        }
    }
}