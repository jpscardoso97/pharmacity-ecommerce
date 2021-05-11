namespace ShoppingCartService.Data.Fakes
{
    using System.Collections.Generic;
    using ShoppingCartService.Data.Dto;

    public static class Carts
    {
        public static IEnumerable<CartDto> Data => new List<CartDto>
        {
            new()
            {
                Id = 0,
                CartId = "CRT-1",
                ProductIds = new []{ "0", "1" }
            },
            new()
            {
                Id = 1,
                CartId = "CRT-2",
                ProductIds = new []{ "1", "2" }
            }
        };
    }
}