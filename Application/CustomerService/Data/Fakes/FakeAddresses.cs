namespace CustomerService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using CustomerService.Data.Dto;

    public static class FakeAddresses
    {
        private const int AddressesCount = 10;

        private static List<string> GetRandomAddresses(Faker faker)
        {
            var addressesCount = faker.Random.Number(1, 3);
            var addressIds = new List<string>();
            for (var i = 0; i < addressesCount; i++)
            {
                addressIds.Add(GenerateAddressId(faker.Random.Number(1, AddressesCount)));
            }

            return addressIds;
        }

        public static IEnumerable<AddressDto> Data => new Faker<AddressDto>()
            .RuleFor(a => a.Id, f => f.UniqueIndex)
            .RuleFor(a => a.AddressId, (f, a) => GenerateAddressId(a.Id))
            .RuleFor(a => a.DeliveryAddress, f => f.Address.StreetName())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Country, f => f.Address.Country())
            .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
            .RuleFor(a => a.Phone, f => f.Phone.PhoneNumber())
            .Generate(AddressesCount);

        public static string GenerateAddressId(int index) => $"addr-{index}";
    }
}