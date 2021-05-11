namespace CustomerService.Data.Fakes
{
    using System.Collections.Generic;
    using Bogus;
    using CustomerService.Data.Dto;

    public class FakeCustomers
    {
        private static Faker<CustomerDto> _faker;
        
        public FakeCustomers()
        {
            _faker = new Faker<CustomerDto>()
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DiscountCard, f => f.Random.AlphaNumeric(5))
                .RuleFor(c => c.DiscountCard, f => f.Random.AlphaNumeric(5))
        }
        public static IEnumerable<CustomerDto> Data => new List<CustomerDto>
        {
            new()
            {
                Id = 0,
                Name = ""
            }
        };
    }
}