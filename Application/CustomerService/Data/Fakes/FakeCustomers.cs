namespace CustomerService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using CustomerService.Data.Dto;

    public static class FakeCustomers
    {
        private const int CustomerCount = 10;

        private static string[] GetRandomAddresses(Faker faker)
        {
            var addressesCount = faker.Random.Number(1, 3);
            var addressIds = new List<string>();
            for (var i = 0; i < addressesCount; i++)
            {
                addressIds.Add(FakeAddresses.GenerateAddressId(faker.Random.Number(0, CustomerCount-1)));
            }

            return addressIds.ToArray();
        }

        public static IEnumerable<CustomerDto> Data()
        {
            return new Faker<CustomerDto>()
                .RuleFor(c => c.CustomerId, (f, c) => $"CS-{f.UniqueIndex}")
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DiscountCard, f => f.Random.AlphaNumeric(5))
                .RuleFor(c => c.CartId, (f, c) => $"CRT-{f.UniqueIndex}")
                .RuleFor(c => c.WishlistId, (f, c) => $"WL-{f.UniqueIndex}")
                .RuleFor(c => c.Addresses, GetRandomAddresses)
                .Generate(CustomerCount);
        }
    }
}