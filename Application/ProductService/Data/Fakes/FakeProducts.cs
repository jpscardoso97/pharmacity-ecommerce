namespace ProductService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using ProductService.Data.Dto;

    public static class FakeProducts
    {
        private const int CountProducts = 10000;
        
        private static readonly string[] Sizes = { "small", "medium", "large"};

        public static IEnumerable<ProductDto> Data => new Faker<ProductDto>()
            .RuleFor(p => p.ProductId, p => p.Random.AlphaNumeric(8))
            .RuleFor(p => p.Price, p => p.Commerce.Price())
            .RuleFor(p => p.Color, p => p.Commerce.Color())
            .RuleFor(p => p.Description, p => p.Commerce.ProductDescription())
            .RuleFor(p => p.Size, p => p.PickRandom(Sizes))
            .RuleFor(p => p.Name, p => p.Commerce.ProductName())
            .RuleFor(p => p.Quantity, p => p.Random.Number(0, 100))
            .Generate(CountProducts);

    }
}