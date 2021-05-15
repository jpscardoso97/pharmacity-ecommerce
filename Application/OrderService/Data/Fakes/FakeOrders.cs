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
            .RuleFor(o => o.Id, f => f.UniqueIndex)
            .RuleFor(o => o.OrderId, (f, o) => $"ORD-{o.Id}")
            .RuleFor(o => o.Value, f => f.Commerce.Price())
            .RuleFor(o => o.DeliveryId, (f, o) => $"DEL-{o.Id}")
            .RuleFor(o => o.Status, f => GetOrderStatusTransitions)
            .RuleFor(o => o.Date, f => "14-05-2021")
            .RuleFor(o => o.PaymentId, (f, o) => $"PAY-{o.Id}")
            .RuleFor(o => o.Items, f => GetOrderItems(f))
            .RuleFor(o => o.PrescriptionId, (f, o) => o.Items==null ? $"PRS-{o.Id}" : null)
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
                        Price = f.Commerce.Price(),
                        Quantity = f.Random.Int(1, 3).ToString()
                    },
                    new()
                    {
                        ProductId = "3",
                        Price = f.Commerce.Price(),
                        Quantity = f.Random.Int(1, 3).ToString()
                    },
                    new()
                    {
                        ProductId = "4",
                        Price = f.Commerce.Price(),
                        Quantity = f.Random.Int(1, 3).ToString()
                    }
                };
            }

            return null;
        }

        private static IDictionary<string, int> GetOrderStatusTransitions => new Dictionary<string, int>
        {
            {"15-05-2021", (int) OrderStatus.PendingPayment},
            {"16-05-2021", (int) OrderStatus.Processing},
            {"20-05-2021", (int) OrderStatus.Shipped},
            {"25-05-2021", (int) OrderStatus.Delivered}
        };
    }
}