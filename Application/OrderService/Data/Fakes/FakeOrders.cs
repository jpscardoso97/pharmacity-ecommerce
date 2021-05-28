namespace OrderService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using OrderService.Data.Dto;
    using OrderService.Models;

    public static class FakeOrders
    {
        private const int CountOrders = 5;

        public static IEnumerable<OrderDto> Data => new Faker<OrderDto>()
            .RuleFor(o => o.OrderId, (f, o) => $"ORD-{f.UniqueIndex}")
            .RuleFor(o => o.Value, f => f.Commerce.Price())
            .RuleFor(o => o.DeliveryId, (f, o) => $"DEL-{f.UniqueIndex}")
            .RuleFor(o => o.Status, f => GetOrderStatusTransitions)
            .RuleFor(o => o.Date, f => "14-05-2021")
            .RuleFor(o => o.PaymentId, (f, o) => $"PAY-{f.UniqueIndex}")
            .RuleFor(o => o.Items, f => GetOrderItems(f))
            .RuleFor(o => o.PrescriptionId, (f, o) => o.Items==null ? $"PRS-{f.UniqueIndex}" : null)
            .Generate(CountOrders);

        private static IEnumerable<OrderItemDto> GetOrderItems(Faker f)
        {
            if (f.Random.Bool())
            {
                return new List<OrderItemDto>()
                {
                    new()
                    {
                        ProductId = "0",
                        Quantity = f.Random.Int(1, 3).ToString()
                    },
                    new()
                    {
                        ProductId = "3",
                        Quantity = f.Random.Int(1, 3).ToString()
                    },
                    new()
                    {
                        ProductId = "4",
                        Quantity = f.Random.Int(1, 3).ToString()
                    }
                };
            }

            return null;
        }

        private static IEnumerable<OrderStatusDto> GetOrderStatusTransitions => new List<OrderStatusDto>
        {
            new (){ Date = "15/05/2021-5:30pm", Value = (int) OrderStatusEnum.PendingPayment},
            new (){ Date = "15/05/2021-5:31pm", Value = (int) OrderStatusEnum.Processing},
            new (){ Date = "20-05-2021-8:00am", Value = (int) OrderStatusEnum.Shipped},
            new (){ Date = "25-05-2021-3:30pm", Value = (int) OrderStatusEnum.Delivered}
        };
    }
}