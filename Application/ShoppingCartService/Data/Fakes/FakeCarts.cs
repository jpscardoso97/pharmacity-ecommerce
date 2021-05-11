namespace ShoppingCartService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using ShoppingCartService.Data.Dto;

    public class FakeCarts
    {
        private static readonly string[] ProductIds = new[]
            {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        private const int CartCount = 10;
        private static int CartProductsCount => new Faker().Random.Number(0, 5);

        public static IEnumerable<CartDto> Data => new CartDto[]
        {
            new()
            {
                CartId = "CRT-0",
                ProductIds = new[] {"0", "6", "3"}
            },
            new()
            {
                CartId = "CRT-1",
                ProductIds = new[] {"3", "6", "8"}
            },
            new()
            {
                CartId = "CRT-2",
                ProductIds = new[] {"1", "9", "5"}
            },
            new()
            {
                CartId = "CRT-3",
                ProductIds = new[] {"0", "2", "4"}
            },
            new()
            {
                CartId = "CRT-4",
                ProductIds = new[] {"6", "7"}
            },
            new()
            {
                CartId = "CRT-5",
                ProductIds = new[] {"0", "4"}
            },
            new()
            {
                CartId = "CRT-6",
                ProductIds = new[] {"4"}
            },
            new()
            {
                CartId = "CRT-7",
                ProductIds = new[] {"8"}
            },
            new()
            {
                CartId = "CRT-8",
                ProductIds = new[] {"3"}
            },
            new()
            {
                CartId = "CRT-9",
                ProductIds = new[] {"7", "5"}
            }
        };
    };
}